using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using test2.Models;
using Microsoft.EntityFrameworkCore;

namespace test2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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




        [HttpGet]
        public IActionResult Read(Test t)
        {
            try
            {
                var read = _context.Test.ToList();
              
                if (!read.Any())
                {
                    return NotFound();
                }
                return View(read);
            }
            catch (Exception ex) {return BadRequest(ex); }
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Test t)
        {
            try
            {
                _context.Add(t);
                _context.SaveChanges();
                return RedirectToAction("Read");
            }catch (Exception ex) {return BadRequest(ex);}
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            try
            {
                var edit = _context.Test.FirstOrDefault(t => t.Id == id);
                if (edit == null)
                {
                    return NotFound();
                }
                return View(edit);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        public IActionResult Update(Test t)
        {
            if (!ModelState.IsValid)
            {
                return View(t);
            }
            try
            {
                _context.Update(t);
                _context.SaveChanges();
                return RedirectToAction("Read");

            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                var delete = _context.Test.FirstOrDefault(t => t.Id == id);
                if (delete == null)
                { return NotFound(); }
                return View(delete);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
        [HttpPost]
        public IActionResult Delete(Test t)
        {
            try
            {
                _context.Test.Remove(t);
                _context.SaveChanges();
                return RedirectToAction("Read");
            } catch (Exception ex) { return BadRequest(ex); } }
            


    }

}
