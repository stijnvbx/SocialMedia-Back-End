using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool GroupAdmin { get; set; }

        //Relations
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

    }
}
