using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Titan.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        public byte[] Image { get; set; }
        public string Telephone { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Task> TaskList { get; set; }
    }
}