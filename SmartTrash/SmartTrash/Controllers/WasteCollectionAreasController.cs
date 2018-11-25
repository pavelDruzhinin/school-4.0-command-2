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
        public async Task<IActionResult> Index()
        {
            List<WasteCollectionArea> areas = await _db.WasteCollectionAreas.ToListAsync();

            return Json(areas);
        }
    }
}