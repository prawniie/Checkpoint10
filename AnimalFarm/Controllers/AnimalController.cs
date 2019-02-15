using AnimalFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AnimalFarm.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly SiteConfig _siteconfig;

        public AnimalController(DatabaseContext context, SiteConfig siteconfig)
        {
            _context = context;
            _siteconfig = siteconfig;
        }

        public IActionResult Index()
        {
            _context.Database.Migrate();
            return View(_context.Animals);
        }

        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            string[] allowedAnimalNames = _siteconfig.AllowedAnimalNames;
            if (allowedAnimalNames.Contains(animal.Name))
            {
                _context.Add(animal);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        //Detta funkar i postman http://localhost:55087/Animal/Delete men ej här

        [HttpPost] //Funkar när man ändrar till HttpPost
        public IActionResult Delete()
        {
            var animalsInDb = _context.Animals;
            _context.RemoveRange(animalsInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
