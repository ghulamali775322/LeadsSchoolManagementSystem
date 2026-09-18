using Microsoft.AspNetCore.Mvc;
using LeadsSMS.Models;

namespace LeadsSMS.Controllers
{
    public class EmployeeController : Controller
    {
        // This would be replaced with DB context later
        public static List<Employee> employees = new List<Employee>();

        public IActionResult Index()
        {
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = employees.Count + 1; // Temporary ID assignment
                employees.Add(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
    }
}
