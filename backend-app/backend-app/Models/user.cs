using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend_app.Models
{
    public class user
    {

        public string FullName { get; set; }

        public DateTime Dob { get; set; }

        public int Contact { get; set; }

        public string EmailID { get; set; }

        public int Id { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string District { get; set; }

        public int Ward { get; set; }

        public int ISActive { get; set; }
    }
}