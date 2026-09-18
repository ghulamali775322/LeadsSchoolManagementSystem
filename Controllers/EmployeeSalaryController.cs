using Microsoft.AspNetCore.Mvc;
using LeadsSMS.Models;
using System.Collections.Generic;

namespace LeadsSMS.Controllers
{
    public class EmployeeSalaryController : Controller
    {
        private static List<EmployeeSalary> salaryList = new List<EmployeeSalary>();
        private static List<Employee> employeeList = EmployeeController.employees;

        public IActionResult Index()
        {
            return View(salaryList);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = employeeList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeSalary salary)
        {
            if (ModelState.IsValid)
            {
                salary.Id = salaryList.Count + 1;
                salaryList.Add(salary);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = employeeList;
            return View(salary);
        }
    }
}
