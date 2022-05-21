using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rating.Models;

namespace Rating.Data
{
    public class RatingContext : DbContext
    {
        public RatingContext (DbContextOptions<RatingContext> options)
            : base(options)
        {
        }

        public DbSet<Rating.Models.Feedback> Feedback { get; set; }
    }
}
