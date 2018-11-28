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
    }
}