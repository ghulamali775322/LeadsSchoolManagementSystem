using LeadsSMS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeadsSMS.Controllers
{
    public class StudentFeeController : Controller
    {
        // Temporary in-memory list
        private static List<StudentFee> studentFees = new List<StudentFee>();

        // GET: /StudentFee
        public IActionResult Index()
        {
            return View(studentFees);
        }

        // GET: /StudentFee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /StudentFee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentFee studentFee)
        {
            if (ModelState.IsValid)
            {
                studentFee.Id = studentFees.Count + 1;
                studentFees.Add(studentFee);
                return RedirectToAction("Index");
            }
            return View(studentFee);
        }
    }
}