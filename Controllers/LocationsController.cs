using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IsabellaBirdBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace IsabellaBirdBlog.Controllers
{
    public class LocationsController : Controller
    {
        private IsabellaBirdBlogContext db = new IsabellaBirdBlogContext();
        public IActionResult Index()
        {
            return View(db.Locations.ToList());
        }

        public IActionResult Create()
        {
            List<SelectListItem> geoclasses = new List<SelectListItem>();
            geoclasses.Add(new SelectListItem() { Text = "City", Value = "City" });
            geoclasses.Add(new SelectListItem() { Text = "Country", Value = "Country" });
            geoclasses.Add(new SelectListItem() { Text = "Landmark", Value = "Landmark" });
            geoclasses.Add(new SelectListItem() { Text = "Region", Value = "Region" });
            ViewBag.Geoclasses = geoclasses;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            List<SelectListItem> geoclasses = new List<SelectListItem>();
            geoclasses.Add(new SelectListItem() { Text = "City", Value = "City" });
            geoclasses.Add(new SelectListItem() { Text = "Country", Value = "Country" });
            geoclasses.Add(new SelectListItem() { Text = "Landmark", Value = "Landmark" });
            geoclasses.Add(new SelectListItem() { Text = "Region", Value = "Region" });
            ViewBag.Geoclasses = geoclasses;

            var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost]
        public IActionResult Edit(Location location)
        {
            db.Entry(location).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            return View(thisLocation);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            db.Locations.Remove(thisLocation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var thisLocation = db.Locations.FirstOrDefault(locations => locations.LocationId == id);
            ViewBag.Experiences = db.Experiences.Where(experiences => experiences.LocationId == id).ToList();
            return View(thisLocation);
        }
    }
}
