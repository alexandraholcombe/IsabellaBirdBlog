using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IsabellaBirdBlog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IsabellaBirdBlog.Controllers
{
    public class PeopleController : Controller
    {
        private IsabellaBirdBlogContext db = new IsabellaBirdBlogContext();

        public IActionResult Index()
        {
            var allPeople = db.Persons
                .Include(person => person.Location)
                .ToList();
            return View(db.Persons.ToList());
        }
    }
}
