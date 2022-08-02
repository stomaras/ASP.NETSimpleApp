using Bookingg.Data;
using Bookingg.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookingg.Controllers
{
    public class CoverTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CoverTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> coverTypesList = _db.CoverTypes.ToList();
            return View(coverTypesList);
        }
    }
}
