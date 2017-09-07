using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Titan.Models
{
    public class Portal
    {

        public int Id { get; set; }
        public String PortalName { get; set; }
        public String Description { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}