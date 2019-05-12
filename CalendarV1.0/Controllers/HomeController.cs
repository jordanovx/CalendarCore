using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalendarV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting.Internal;

namespace CalendarV1.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext myContext)
        {
            _context = myContext;




        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEvents()
        {

             var events = _context.Events.ToList();
             return new OkObjectResult(events);
        }
        [HttpPost]
        public IActionResult SaveEvent(Events e)
        {
            var status = false;
                if (e.EventID > 0)
                {
                    //Update the event 
                    var v = _context.Events.FirstOrDefault(a => a.EventID == e.EventID);
                    if (v != null)
                    {
                        v.Subject = e.Subject;
                        v.Start = e.Start;
                        v.End = e.End;
                        v.Description = e.Description;
                        v.IsFullDay = e.IsFullDay;
                        v.ThemeColor = e.ThemeColor;
                    }
                }
                else
                {
                    _context.Events.Add(e);
                }
                _context.SaveChanges();
                status = true;
            
            return new OkObjectResult( new { status = status });

        }
        [HttpPost]
        public IActionResult DelteEvent(int EventID)
        {
            var status = false;
                var v = _context.Events.FirstOrDefault(a => a.EventID == EventID);
                if (v != null)
                {
                    _context.Events.Remove(v);
                    _context.SaveChanges();
                    status = true;
                }

            return new OkObjectResult(new { status = status });


        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
    }
}
