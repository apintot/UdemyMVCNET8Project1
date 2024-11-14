using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UdemyMVC1.Data;
using UdemyMVC1.Models;

namespace UdemyMVC1.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger; nologin yet

        private readonly ApplicationDBContext _context;//use data base

        public HomeController(ApplicationDBContext context)
        {
            //_logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
          
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contact contact)
        {
            if(ModelState.IsValid)
            {
                _context.Contact.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Contact contact = _context.Contact.Find(id);

            if(contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contact contact = _context.Contact.Find(id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteForm(int? id)
        {
            Contact contact = await _context.Contact.FindAsync(id);

            if(contact == null)
                return View();

            _context.Contact.Remove(contact);
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
