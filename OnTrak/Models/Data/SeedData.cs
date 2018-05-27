using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.BodyAreas.Any())
            {
                context.BodyAreas.AddRange(
                      new BodyArea { Name = "Upper Body",Description = "", Image = null },
                      new BodyArea { Name = "Lower Body",Description = "", Image = null },
                      new BodyArea { Name = "Core",Description = "", Image = null }
                    );

                context.SaveChanges();
            }
        }
    }
}
