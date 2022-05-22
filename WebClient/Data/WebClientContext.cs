using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebClient.Models;

namespace WebClient.Data
{
    public class WebClientContext : DbContext
    {
        public WebClientContext (DbContextOptions<WebClientContext> options)
            : base(options)
        {
        }

        public DbSet<WebClient.Models.Feedback>? Feedback { get; set; }
    }
}
