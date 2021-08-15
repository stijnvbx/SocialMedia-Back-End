using AngularProjectAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Models
{
    public class DBInitializer
    {
        public static void Initialize(SocialContext context)
        {
            context.Database.EnsureCreated();

            // Look for any user.
            if (context.Roles.Any())
            {
                return;   // DB has been seeded
            }

            context.Roles.AddRange(
              new Role { Name = "User" },
              new Role { Name = "Admin" },
              new Role { Name = "GroupAdmin" },
              new Role { Name = "GroupMember" },
              new Role { Name = "Employee" },
              new Role { Name = "SuperAdmin" });
            context.SaveChanges();

            context.Users.AddRange(
                new User { FirstName = "Stijn", LastName = "Van Braband", Email ="vanbrabandstijn@gmail.com", GroupAdmin = true, RoleID = 6, Password = "test"}
                );
            context.SaveChanges();

            context.Company.AddRange(
                new Company { Name = "SVB Solutions", Description = "blabla", Location = "Rijkevorsel", PhotoURL = "Photo" }
                );
            context.SaveChanges();

        }
    }
}
