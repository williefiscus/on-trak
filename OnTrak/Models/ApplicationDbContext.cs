using Microsoft.EntityFrameworkCore;
using OnTrak.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public ApplicationDbContext() { }

        public DbSet<BodyArea> BodyAreas { get; set; }
        public DbSet<BodyPart> BodyParts { get; set; }
    }
}
