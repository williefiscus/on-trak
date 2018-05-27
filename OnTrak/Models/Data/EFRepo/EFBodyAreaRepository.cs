using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.EFRepo
{
    public class EFBodyAreaRepository : IBodyAreaRepository
    {
        private ApplicationDbContext context;

        public EFBodyAreaRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public void SaveBodyArea(BodyArea bodyArea)
        {
            if (bodyArea.BodyAreaId == 0)
            {
                context.BodyAreas.Add(bodyArea);
            }
            else
            {
                BodyArea dbEntry = context.BodyAreas.FirstOrDefault(ba => ba.BodyAreaId == bodyArea.BodyAreaId);
                if (dbEntry != null)
                {
                    dbEntry.Image = bodyArea.Image;
                    dbEntry.Name = bodyArea.Name;
                    dbEntry.Description = bodyArea.Description;
                }
                
            }
            context.SaveChanges();

        }

        public BodyArea getBodyAreaById(int? Id)
        {
            var bodyArea = context.BodyAreas.Find(Id);
            return bodyArea;
        }

        public IQueryable<BodyArea> BodyAreas => context.BodyAreas;
    }
}
