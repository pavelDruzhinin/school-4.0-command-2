using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTrash.Data;
using SmartTrash.Models;

namespace SmartTrash.Controllers
{
    [Route("areas")]
    public class WasteCollectionAreasController : Controller
    {
        public TrashContext _db;
        public WasteCollectionAreasController(TrashContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index(int? minFill, int? maxFill)
        {
            if (!minFill.HasValue)
            {
                minFill = 0;
            }
            if (!maxFill.HasValue)
            {
                maxFill = 100;
            }
            List<WasteCollectionArea> areas = await _db.WasteCollectionAreas
                .Where(a => a.PercentOfFill >= minFill)
                .Where(a => a.PercentOfFill <= maxFill)
                .ToListAsync();

            return Json(areas);
        }

        [Route("admin")]
        public IActionResult Admin()
        {
            var model = _db.WasteCollectionAreas.ToList();
            return View(model);
        }

        [HttpGet]
        [Route("admin/add")]
        [Route("admin/edit/")]
        public async Task<IActionResult> TrashPoints(int? id)
        {
            if (!id.HasValue)
                return View();

            var area = await _db.WasteCollectionAreas.FirstOrDefaultAsync(x => x.Id == id);
            var existarea = new AreaEdit { Id = area.Id, Name = area.Name, Latitude = area.Latitude, Longitude = area.Longitude, Volume = area.Volume };
            return View(existarea);
        }

        [HttpPost]
        [Route("admin/add")]
        [Route("admin/edit/")]
        public async Task<IActionResult> TrashPoints(AreaEdit area)
        {
            if (ModelState.IsValid)
            {
                if (area.Id == default(int))
                    _db.WasteCollectionAreas.Add(new WasteCollectionArea
                    {
                        Name = area.Name,
                        Latitude = (float)area.Latitude,
                        Longitude = (float)area.Longitude,
                        Volume = (decimal)area.Volume
                    });
                else
                {
                    var existingarea = await _db.WasteCollectionAreas.FirstOrDefaultAsync(x => x.Id == area.Id);
                    existingarea.Name = area.Name;
                    existingarea.Latitude = (float)area.Latitude;
                    existingarea.Longitude = (float)area.Longitude;
                    existingarea.Volume = (decimal)area.Volume;
                    _db.WasteCollectionAreas.Update(existingarea);
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("admin");
            }
            else
            {
                if (area.Latitude == 0)
                    ModelState.AddModelError("Latitude", "Точка не может равняться нулю так как она находится вне города");
                if (area.Longitude == 0)
                    ModelState.AddModelError("Longitude", "Точка не может равняться нулю так как она находится вне города");
                if (area.Volume == 0)
                    ModelState.AddModelError("Volume","Объём мусорки не может быть нулевым");
            }
            return View(area);
        }

        [Route("admin/del/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var area = await _db.WasteCollectionAreas.FirstOrDefaultAsync(x => x.Id == id);
            if (area != null)
            {
                _db.WasteCollectionAreas.Remove(area);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("admin");
        }
    }
}