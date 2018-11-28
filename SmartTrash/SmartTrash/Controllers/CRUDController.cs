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
    [Route("CRUD")]
    public class CRUDController : Controller
    {
        public TrashContext _db;
        public CRUDController(TrashContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var model = _db.WasteCollectionAreas.ToList();
            return View(model);
        }

        [Route("add")]
        [Route("edit/{id:int}")]
        public async Task<IActionResult> TrashPoints(int? id)
        {
            if (!id.HasValue)
                return View();

            var area = await _db.WasteCollectionAreas.FirstOrDefaultAsync(x => x.Id == id);
            return View(area);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save(WasteCollectionArea area)
        {
            if (area.Id == default(int))
                _db.WasteCollectionAreas.Add(area);
            else
            {
                _db.WasteCollectionAreas.Attach(area);
                _db.Entry(area).State = EntityState.Modified;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Route("del/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var area = await _db.WasteCollectionAreas.FirstOrDefaultAsync(x => x.Id == id);
            if (area != null)
            {
                _db.WasteCollectionAreas.Remove(area);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}