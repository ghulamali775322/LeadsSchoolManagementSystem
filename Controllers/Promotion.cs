using LeadsSMS.Data;
using LeadsSMS.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace LeadsSMS.Controllers
{
    public class PromotionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PromotionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Promotion
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: /Promotion/Create
        public IActionResult Create()
        {
            // Provide a dropdown of students
            ViewBag.Students = _context.Students
                .Select(s => new { s.Id, s.FullName })
                .ToList();
            return View();
        }

        // POST: /Promotion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int studentId, string toClass, DateTime promotionDate)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null) return NotFound();

            var promotion = new Promotion
            {
                StudentId = student.Id,
                FromClass = student.ClassName,
                ToClass = toClass,
                PromotionDate = promotionDate
            };

            // Update student’s current class
            student.ClassName = toClass;

            _context.Promotions.Add(promotion);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // (Optional) inline Promote action you already have
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Promote(int studentId, string toClass)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null) return NotFound();

            var promotion = new Promotion
            {
                StudentId = student.Id,
                FromClass = student.ClassName,
                ToClass = toClass,
                PromotionDate = DateTime.Now
            };

            student.ClassName = toClass;

            _context.Promotions.Add(promotion);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
