using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using titan.Models;
using Titan.Models;

namespace Titan.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        private ApplicationDbContext _context;

        public TasksController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index()
        {
            var Tasks = _context.Tasks;
            return View(Tasks);
        }

        public ActionResult Details(int id)

        {
            var task = _context.Tasks.SingleOrDefault(c => c.Id == id);
            if (task == null)
                return HttpNotFound();
            return View(task);
        }
    }
}