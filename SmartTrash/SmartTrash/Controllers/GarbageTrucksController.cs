using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SmartTrash.Data;
using SmartTrash.Models;

namespace SmartTrash.Controllers
{
    [Route("garbagetrucks")]
    public class GarbageTrucksController : Controller
    {
        private readonly TrashContext _context;

        public GarbageTrucksController(TrashContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.GarbageTrucks.ToListAsync());
        }

        [Route("admin/add")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("admin/add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberPlate,Model,Volume,MaintananceCostFactor")] GarbageTruck garbageTruck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garbageTruck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garbageTruck);
        }

        [HttpGet]
        [Route("admin/edit/{id:int}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageTruck = await _context.GarbageTrucks.FindAsync(id);
            if (garbageTruck == null)
            {
                return NotFound();
            }
            return View(garbageTruck);
        }

        [HttpPost]
        [Route("admin/edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumberPlate,Model,Volume,MaintananceCostFactor")] GarbageTruck garbageTruck)
        {
            if (id != garbageTruck.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garbageTruck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarbageTruckExists(garbageTruck.Id))
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
            return View(garbageTruck);
        }

        [Route("admin/del/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garbageTruck = await _context.GarbageTrucks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (garbageTruck == null)
            {
                return NotFound();
            }

            return View(garbageTruck);
        }

        [HttpPost]
        [Route("admin/del/{id:int}/confirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garbageTruck = await _context.GarbageTrucks.FindAsync(id);
            _context.GarbageTrucks.Remove(garbageTruck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarbageTruckExists(int id)
        {
            return _context.GarbageTrucks.Any(e => e.Id == id);
        }
    }
}
