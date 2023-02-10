using CaseProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CaseProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PersonContext _context;


        public HomeController(ILogger<HomeController> logger, PersonContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.PersonList = _context.Persons.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Index(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var updatePerson = _context.Persons.Find(id);

            return View(updatePerson);
        }
        [HttpPost]
        public IActionResult Update(Person person)
        {
            _context.Update(person);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var deletePerson = await _context.Persons.FindAsync(id);
            _context.Remove(deletePerson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
