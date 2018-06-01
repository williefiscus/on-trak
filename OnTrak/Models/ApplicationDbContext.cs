using Microsoft.EntityFrameworkCore;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Activities;
using OnTrak.Models.Entities.Body;
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
        public DbSet<Muscle> Muscles { get; set; }
        public DbSet <Exercise> Exercises { get; set; }
        public DbSet<ExerciseMuscleRelationship> ExercisesToMuscles { get; set; }
    }
}
