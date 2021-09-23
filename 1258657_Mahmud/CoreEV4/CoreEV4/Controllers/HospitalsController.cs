﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreEV4.Models;

namespace CoreEV4.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly PatientsDbContext _context;

        public HospitalsController(PatientsDbContext context)
        {
            _context = context;
        }

        // GET: Hospitals
        public async Task<IActionResult> Index()
        {
            ViewBag.hActive = "active";
            return View(await _context.Hospitals.ToListAsync());
        }

        // GET: Hospitals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.hId == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        // GET: Hospitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hId,hName,hAddress")] Hospitals hospitals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitals);
        }

        // GET: Hospitals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals.FindAsync(id);
            if (hospitals == null)
            {
                return NotFound();
            }
            return View(hospitals);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("hId,hName,hAddress")] Hospitals hospitals)
        {
            if (id != hospitals.hId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalsExists(hospitals.hId))
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
            return View(hospitals);
        }

        // GET: Hospitals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hospitals = await _context.Hospitals
                .FirstOrDefaultAsync(m => m.hId == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hospitals = await _context.Hospitals.FindAsync(id);
            _context.Hospitals.Remove(hospitals);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalsExists(int id)
        {
            return _context.Hospitals.Any(e => e.hId == id);
        }
    }
}
