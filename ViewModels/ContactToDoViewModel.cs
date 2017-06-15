using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Titan.Models;

namespace Titan.ViewModels
{
    public class ContactToDoViewModel
    {
        public Contact Contact { get; set; }
        public List<Task> ToDos { get; set; }

    }
}   