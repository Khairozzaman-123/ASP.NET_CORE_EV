using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using work_01.Models;
using work_01.ViewModels;

namespace work_01.Controllers
{
    [Authorize]
    public class VisitorsController : Controller
    {
        private readonly VisitorDbContext db;
        private readonly IHostingEnvironment _he;
        public VisitorsController(VisitorDbContext db, IHostingEnvironment he)
        {
            this._he = he;
            this.db = db;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string usertext)
        {
            ViewBag.SWord = usertext;
            var visitors = db.Visitors.Include(v => v.City).Select(x => new VisitorsRetriveVm
            {
                Id = x.Id,
                VisitorName = x.VisitorName,
                cName = x.City.cName,
                Phone = x.Phone,
                VisitDate = x.VisitDate,
                Image = x.Image
            });
            if (!string.IsNullOrEmpty(usertext))
            {
                usertext = usertext.ToLower();
                visitors = visitors.Where(c => c.VisitorName.ToLower().Contains(usertext));
            }
            return View(await visitors.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitor = await db.Visitors
                .Include(v => v.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitor == null)
            {
                return NotFound();
            }

            return View(visitor);
        }

        public IActionResult Create()
        {
            ViewData["cId"] = new SelectList(db.Cities, "cId", "cName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitorsVM visitor)
        {
            //Image
            string webroot = _he.WebRootPath;
            string folder = "Images";
            string imgFileName = Guid.NewGuid().ToString() + "_" + visitor.Image.FileName;
            string newFilePath = Path.Combine(folder, imgFileName);
            string fileToWrite = Path.Combine(webroot, folder, imgFileName);

            if (ModelState.IsValid)
            {
                using (var stream = new FileStream(fileToWrite, FileMode.Create))
                {
                    visitor.Image.CopyTo(stream);
                }
                Visitor visitors = new Visitor
                {
                    VisitorName = visitor.VisitorName,
                    cId = visitor.cId,
                    Phone = visitor.Phone,
                    VisitDate = visitor.VisitDate,
                    Image = newFilePath
                };
                db.Visitors.Add(visitors);
                await db.SaveChangesAsync();
                return PartialView("_success");
            }
            ViewData["cId"] = new SelectList(db.Cities, "cId", "cName", visitor.cId);
            return PartialView("_error");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var visitor = await db.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return NotFound();
            }
            VisitorsVM vvm = new VisitorsVM
            {
                Id = visitor.Id,
                VisitorName = visitor.VisitorName,
                cId = visitor.cId,
                Phone = visitor.Phone,
                VisitDate = visitor.VisitDate,
                ImagePath = visitor.Image
            };
            ViewData["cId"] = new SelectList(db.Cities, "cId", "cName", vvm.cId);
            return View(vvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VisitorsVM vm)
        {
            var v = await db.Visitors.FindAsync(id);
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (vm.Image != null)
                {
                    var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\", v.Image);
                    System.IO.File.Delete(path2);
                    string newFileName = Guid.NewGuid().ToString() + "_" + vm.Image.FileName;
                    string newFilePath = Path.Combine("Images", newFileName);
                    string file = Path.Combine(_he.WebRootPath, newFilePath);
   
                    v.Id = vm.Id;
                    v.VisitorName = vm.VisitorName;
                    v.cId = vm.cId;
                    v.Phone = vm.Phone;
                    v.VisitDate = vm.VisitDate;
                    v.Image = newFilePath;
                    using (var stream = new FileStream(file, FileMode.Create))
                    {
                        await vm.Image.CopyToAsync(stream);
                    }
                    db.Update(v);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    v.Id = vm.Id;
                    v.VisitorName = vm.VisitorName;
                    v.cId = vm.cId;
                    v.Phone = vm.Phone;
                    v.VisitDate = vm.VisitDate;
                    v.Image = v.Image;
                    
                    db.Update(v);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            ViewData["cId"] = new SelectList(db.Cities, "cId", "cName", vm.cId);
            return View(vm);
        }

        public IActionResult Delete(int? id)
        {
            Visitor visitor = db.Visitors.Find(id);
            
            if (visitor.Image != null)
            {
                //For Image Delete Form Folder
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\", visitor.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                //Delete Data
                var del = (from Visitor in db.Visitors where Visitor.Id == id select Visitor).FirstOrDefault();
                db.Visitors.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            else
            {
                //Delete Data
                var del = (from Visitor in db.Visitors where Visitor.Id == id select Visitor).FirstOrDefault();
                db.Visitors.Remove(del);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var visitor = await db.Visitors
        //        .Include(v => v.City)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (visitor == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(visitor);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int? id)
        //{
        //    if (id != null)
        //    {
        //        var visitor = await db.Visitors.FindAsync(id);
        //        db.Visitors.Remove(visitor);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View();
        //}

        private bool VisitorExists(int id)
        {
            return db.Visitors.Any(e => e.Id == id);
        }
    }
}
