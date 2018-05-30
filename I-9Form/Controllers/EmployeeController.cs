using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using I_9Form.Data;
using I_9Form.Models;
using I_9Form.ViewModels.EmployeeViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View(_db.EmployeeViewModels.ToList());
        }
        //GET:Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Add(employeeViewModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeDetails = await _db.EmployeeViewModels.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeDetails == null)
            {
                return NotFound();
            }
            return View(employeeDetails);
        }

        //Edit: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _db.EmployeeViewModels.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }


        //Edit: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.EmployeeID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(employeeViewModel);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeViewModel);
        }


        //POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveEmployee (int id)
        {
            var employeeToDelete = await _db.EmployeeViewModels.SingleOrDefaultAsync(m => m.EmployeeID == id);
            _db.EmployeeViewModels.Remove(employeeToDelete);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeToDel = await _db.EmployeeViewModels.SingleOrDefaultAsync(m => m.EmployeeID == id);
            if (employeeToDel == null)
            {
                return NotFound();
            }
            return View(employeeToDel);
        }

        //public async Task<EmployeeViewModel> GetBeneficaryByUserId(string id)
        //{
        //    var ben = await _db.EmployeeViewModels.FirstOrDefaultAsync(a => a.EmployeeID == id);
        //    return ben;
        //}

        //private async Task<int> GetEmpID(string userid)
        //{
        //    var ben = await _db.EmployeeOtherDetailsViewModels.FirstOrDefaultAsync(m => m.EmployeeID == userid);
        //    return ben;
        //    //return m.Em;
        //}

        public IActionResult OtherDetails()
        {
            return View();
        }

        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public async Task<IActionResult> OtherDetails(EmployeeOtherDetailsViewModel emp)
        //{
        //    var id = this.User.GetUserID();
        //    emp.EmployeeID = await _db.EmployeeViewModels.FirstOrDefaultAsync(m => m.EmployeeID == emp.EmployeeID)
        //    if (ModelState.IsValid)
        //    {


        //        TempData["Success"] = "Data Was Saved Successfully";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    return View("OtherDetails");
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
        }
    }
}