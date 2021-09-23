using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreEV4.Models;
using CoreEV4.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace CoreEV4.Controllers
{
    public class PatientsController : Controller
    {
        private readonly PatientsDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PatientsController(PatientsDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Patients
        public async Task<IActionResult> Index()
        {
            ViewBag.rActive = "active";
            var patientsDbContext = _context.Patients.Include(p => p.Hospitals);
            return View(await patientsDbContext.ToListAsync());
        }

        // GET: Patients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients
                .Include(p => p.Hospitals)
                .FirstOrDefaultAsync(m => m.pId == id);
            if (patients == null)
            {
                return NotFound();
            }
            // PartialView("Details", patients);
            return View(patients);
        }

        // GET: Patients/Create
        public IActionResult Create()
        {
            ViewData["hId"] = new SelectList(_context.Hospitals, "hId", "hName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("pId,pName,pEmail,bGroup,Dob,Address,pImage,pStatus,hId")] PatientMV patients,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (file != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "img");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Patients patients1 = new Patients
                {
                    pName = patients.pName,
                    pEmail=patients.pEmail,
                    bGroup = patients.bGroup,
                    Dob = patients.Dob,
                    Address = patients.Address,
                    pImage = uniqueFileName,
                    pStatus=patients.pStatus,
                    hId=patients.hId
                };

                _context.Add(patients1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["hId"] = new SelectList(_context.Hospitals, "hId", "hName", patients.hId);
            return View(patients);
        }

        // GET: Patients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients.FindAsync(id);
            if (patients == null)
            {
                return NotFound();
            }
            else
            {
                PatientMV mv = new PatientMV
                {
                    pId = patients.pId,
                    pName=patients.pName,
                    pEmail=patients.pEmail,
                    Dob=patients.Dob,
                    bGroup=patients.bGroup,
                    Address=patients.Address,
                    img=patients.pImage,
                    pStatus=patients.pStatus,
                    hId=patients.hId
                };
                ViewData["hId"] = new SelectList(_context.Hospitals, "hId", "hName", patients.hId);
                return View(mv);
            }
            
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("pId,pName,pEmail,bGroup,Dob,Address,pImage,pStatus,hId")] Patients patients, IFormFile file)
        {
            if (id != patients.pId)
            {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var delImg = await _context.Patients.FindAsync(id);
                string uniqueFileName = delImg.pImage;
                if (file != null)
                {
                    string folder = Path.Combine(_env.WebRootPath, "img");
                    string path = Path.Combine(folder, delImg.pImage);
                    System.IO.File.Delete(path);

                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(folder, uniqueFileName);
                    file.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                try
                {
                    Patients patients1 = new Patients
                    {
                        pName = patients.pName,
                        pEmail=patients.pEmail,
                        bGroup = patients.bGroup,
                        Dob = patients.Dob,
                        Address = patients.Address,
                        pImage = uniqueFileName,
                        pStatus = patients.pStatus,
                        hId = patients.hId
                    }; 
                    _context.Patients.Remove(delImg);
                    _context.Update(patients1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientsExists(patients.pId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["hId"] = new SelectList(_context.Hospitals, "hId", "hName", patients.hId);
            return View(patients);
        }

        // GET: Patients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patients = await _context.Patients.FindAsync(id);

            string folder = Path.Combine(_env.WebRootPath, "img");
            string path = Path.Combine(folder, patients.pImage);
            System.IO.File.Delete(path);

            _context.Patients.Remove(patients);
            await _context.SaveChangesAsync();

            if (patients == null)
            {
                return NotFound();
            }

            return View(patients);
        }

        //// POST: Patients/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var patients = await _context.Patients.FindAsync(id);
        //    _context.Patients.Remove(patients);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool PatientsExists(int id)
        {
            return _context.Patients.Any(e => e.pId == id);
        }
    }
}
