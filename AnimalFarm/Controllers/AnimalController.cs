using AnimalFarm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimalFarm.Controllers
{
    public class AnimalController : Controller
    {
        private readonly DatabaseContext _context;

        public AnimalController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            _context.Database.Migrate();
            return View(_context.Animals);
        }

        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            _context.Add(animal);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}
