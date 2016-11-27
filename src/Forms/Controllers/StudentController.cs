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
            return RedirectToAction("Edit", "Form", new { id });
        }

        public IActionResult Add()
        {
            return RedirectToAction("Add", "Form");
        }

    }
}
