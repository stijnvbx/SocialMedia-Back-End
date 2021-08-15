using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class Role
    {
        public int RoleID { get; set; }
        public string Name { get; set; }

        //Relations
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
    }
}
