using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using project.Data;
using project.Models;

namespace project.Controllers{
    public class EmployeeController : Controller{
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(){
            var employees = _context.Employees.Where(x=>x.RecStatus=='A').ToList();

            return View(employees);
        }

        [HttpGet]
        public IActionResult New(){
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult New(Employee employee){
            if(!ModelState.IsValid)
                return View(employee);

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id){
            var employee = _context.Employees.FirstOrDefault(x=>x.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}