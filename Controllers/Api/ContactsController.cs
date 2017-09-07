using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Titan.Models;
using titan.Models;
using titan;

namespace Titan.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }

        public Contact GetContact(int Id)
        {
            var Contact = _context.Contacts.SingleOrDefault(c => c.Id == Id);

            if (Contact == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Contact;
        }

        [HttpPost]
        public Contact CreateContact(Contact contact)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return contact;

        }
        [HttpPut]
        public void UpdateContact(int Id, Contact contact)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var ContactInDb = _context.Contacts.SingleOrDefault(c => c.Id == Id);

            if (ContactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ContactInDb.Forename = contact.Forename;
            ContactInDb.Surname = contact.Surname;
            ContactInDb.Telephone = contact.Telephone;
            ContactInDb.Image = contact.Image;

        }

        [HttpDelete]
        public void DeleteContact(int Id)
        {
            var ContactInDb = _context.Contacts.SingleOrDefault(c => c.Id == Id);

            if (ContactInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Contacts.Remove(ContactInDb);
            _context.SaveChanges();


        }

    }

}
