using Microsoft.AspNetCore.Mvc;
using SiinGroup.Models;
using System;
using System.Diagnostics;
using System.Linq;

namespace SiinGroup.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            @TempData["message"] = "Save success!";
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SaveEdit(Student student)
        {
            var author = _context.Students.Find(student.Id);
            author.Name = student.Name;
            author.RollNumber = student.RollNumber;
            _context.SaveChanges();
            @TempData["message"] = "Edit student " + author.RollNumber + " success!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit()
        {
            var item = _context.Students.Find(Int32.Parse(HttpContext.Request.Query["id"].ToString()));
            return View(item);
        }
        
        public IActionResult Delete()
        {
            _context.Remove(_context.Students.Single(a => a.Id == Int32.Parse(HttpContext.Request.Query["id"].ToString())));
            _context.SaveChanges();
            @TempData["message"] = "Delete success!";
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
