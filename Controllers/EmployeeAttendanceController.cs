using Microsoft.AspNetCore.Mvc;
using LeadsSMS.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeadsSMS.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        public static List<EmployeeAttendance> attendanceList = new List<EmployeeAttendance>();
        public static List<Employee> employeeList = EmployeeController.employees; // using static list

        public IActionResult Index()
        {
            return View(attendanceList);
        }

        public IActionResult Create()
        {
            ViewBag.Employees = employeeList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeAttendance attendance)
        {
            if (ModelState.IsValid)
            {
                attendance.Id = attendanceList.Count + 1;
                attendanceList.Add(attendance);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Employees = employeeList;
            return View(attendance);
        }
    }
}
