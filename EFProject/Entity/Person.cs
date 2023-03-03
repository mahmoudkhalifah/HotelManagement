using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Entity
{
    abstract class Person
    {
        [Key]
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
