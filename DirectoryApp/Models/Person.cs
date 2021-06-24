using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DirectoryApp.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Job { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
    }
}
