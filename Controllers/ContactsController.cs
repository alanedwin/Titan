using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using titan.Models;
using Titan.Models;
using Titan.ViewModels;

namespace Titan.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Customers

        private ApplicationDbContext _context;

        public ContactsController()
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
            var Contacts = _context.Contacts;
            return View(Contacts);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Save(Contact contact)

        {
        
            if (contact.Id == 0)
                _context.Contacts.Add(contact);
            else

            {
                var contactInDb = _context.Contacts.Single(c => c.Id == contact.Id);
                contactInDb.Forename = contact.Forename;
               
            }

            SmtpClient smtpClient = new SmtpClient();
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("alanb@631three.co.uk");
                message.To.Add(new MailAddress("beattie.edwin@gmail.com"));
                message.Subject = "test";
                message.Body = "This is test";
                SmtpClient smtp = new SmtpClient("smtpout.secureserver.net");
                smtp.Credentials = new System.Net.NetworkCredential("alanb@631three.co.uk", "alan6313");
                smtp.Port = 25;
                smtp.EnableSsl = false;
                smtp.Send(message);

            }
            catch (Exception ex) { }


            return RedirectToAction("Index", "Contacts");
        }

        public ActionResult Details(int id,string returnUrl)

        {
            ViewBag.ReturnUrl = returnUrl;
            var customer = _context.Contacts.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

    }

    
}