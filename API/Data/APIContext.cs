#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API;

namespace API.Data
{
    public class APIContext : DbContext
    {
        public APIContext (DbContextOptions<APIContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasKey("Id", "Username");
        }

        public DbSet<API.Contact> Contact { get; set; }

        public DbSet<API.Invitation> Invitation { get; set; }

        public DbSet<API.Transfer> Transfer { get; set; }

        public DbSet<API.Message> Message { get; set; }

        public DbSet<API.User> User { get; set; }
    }
}
