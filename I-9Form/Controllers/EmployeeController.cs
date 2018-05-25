using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I_9Form.Data;
using Microsoft.AspNetCore.Mvc;

namespace I_9Form.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}