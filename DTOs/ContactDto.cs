using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Titan.Models;

namespace Titan.DTOs
{
    public class ContactDto
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