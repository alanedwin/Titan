using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using titan.Models;

namespace Titan.Controllers
{
    public class PortalsController : Controller
    {
        private ApplicationDbContext _context;

        public PortalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        public ActionResult Index(int? PageIndex, string SortBy)
        {
            if (!PageIndex.HasValue)
                PageIndex = 1;
            if (string.IsNullOrWhiteSpace(SortBy))
                SortBy = "Name";
            //var Portals = _context.Contacts.SingleOrDefault(c => c.Surname == "Beattie").TaskList;
            var Portals = _context.Portals;


            return View(Portals);
        }

        public ActionResult New()
        {
            return View();
        }
    }
}