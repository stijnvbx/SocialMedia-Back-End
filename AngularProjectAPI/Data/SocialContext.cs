using AngularProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularProjectAPI.Data
{
    public class SocialContext : DbContext
    {
        public SocialContext(DbContextOptions<SocialContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Post> Post { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Post>().ToTable("Post");
        }

        

    }
}
