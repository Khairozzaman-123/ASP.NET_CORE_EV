using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using evidence.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.EntityFrameworkCore;
using evidence.VModels;

namespace evidence.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DepartmentDbContext db;
        private readonly IHostingEnvironment hosting;
        public StudentsController(DepartmentDbContext db, IHostingEnvironment hosting)
        {
            this.hosting = hosting;
            this.db = db;
        }

        public IActionResult Index()
        {

            return View(db.Students.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Departments = db.departments.ToList();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SVModel vModel, IFormFile fileobj)
        {
            //Upload Image into Folder
            var imgext = Path.GetExtension(fileobj.FileName);
            if (imgext == ".jpg" || imgext == ".png")
            {
                var uploadImg = Path.Combine(hosting.WebRootPath, "Images", fileobj.FileName);
                var stream = new FileStream(uploadImg, FileMode.Create);
                await fileobj.CopyToAsync(stream);
                stream.Close();

                //Upload Image into Database
                vModel.ImageName = fileobj.FileName;
                vModel.picturePath = uploadImg;
                await db.Students.AddAsync(vModel);
                //await db.Movies.AddAsync(movie);
                await db.SaveChangesAsync();
            }
            else
            {

            }
            if (ModelState.IsValid)
            {
                db.Students.Add(vModel);
                await db.SaveChangesAsync();
                return PartialView("_success");
            }
            return PartialView("_error");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var displayImageDetails = db.Students.Find(id);
            if (displayImageDetails == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = db.departments.ToList();
            return View(displayImageDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(IFormFile fileobj, SVModel vModel , string fname, int id)
        {
            //Edit in Folder
            var getImageDetails = await db.Students.FindAsync(id);
            db.Students.Remove(getImageDetails);
            fname = Path.Combine(hosting.WebRootPath, "Images", getImageDetails.picturePath);
            FileInfo fi = new FileInfo(fname);
            if (fi.Exists)
            {
                System.IO.File.Delete(fname);
                fi.Delete();
            }

            //Edit in Database

            //if (ModelState.IsValid)
            //{

            //}
            var imgtxt = Path.GetExtension(fileobj.FileName);
            if (imgtxt == ".jpg" || imgtxt == ".gif")
            {
                var uploadImg = Path.Combine(hosting.WebRootPath, "Images", fileobj.FileName);
                var stream = new FileStream(uploadImg, FileMode.Create);
                await fileobj.CopyToAsync(stream);
                stream.Close();

                //Uploading Image into Database
                vModel.ImageName = fileobj.FileName;
                vModel.picturePath = uploadImg;
                db.Students.Update(vModel);
                await db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var displayImageDetails = db.Students.Find(id);
            if (displayImageDetails == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = db.departments.ToList();
            return View(displayImageDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string fname, int id)
        {
            var getImageDetails = await db.Students.FindAsync(id);
            db.Students.Remove(getImageDetails);
            fname = Path.Combine(hosting.WebRootPath, "Images", getImageDetails.picturePath);
            FileInfo fi = new FileInfo(fname);
            if (fi.Exists)
            {
                System.IO.File.Delete(fname);
                fi.Delete();
            }
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}