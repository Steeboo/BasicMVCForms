using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.DataAccess;
using Forms.Models;

namespace Forms.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(StudentRepository.Students);
        }

        public IActionResult Edit(int id)
        {
            if (StudentRepository.Students.Any(x => x.Id == id))
            {
                return View(StudentRepository.Students.First(x => x.Id == id));
            }
            return View("Edit", new Student());

        }

        public IActionResult Add()
        {
            return View("Edit", new Student());
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(Student student)
        {
            if (student.Id == 0)
            {
                student.Id = StudentRepository.GenerateId();
                StudentRepository.Students.Add(student);
            }
            else
            {
                var oldStudent = StudentRepository.Students.First(x => x.Id == student.Id);
                var index = StudentRepository.Students.IndexOf(oldStudent);
                StudentRepository.Students[index] = student;
            }

            return RedirectToAction("Index", "Student");
        }

    }
}
