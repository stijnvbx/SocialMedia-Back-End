using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }

        //Relations
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
