using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.EFRepo
{
    public class EFBodyPartRepository : IBodyPartRepository
    {
        private ApplicationDbContext context;

        public EFBodyPartRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<BodyPart> BodyParts => context.BodyParts;

        public BodyPart GetBodyPartById(int? Id)
        {
            var bodyPart = context.BodyParts.Find(Id);
            return bodyPart;
        }

        public void SaveBodyPart(BodyPart bodyPart)
        {
            if (bodyPart.BodyPartId == 0)
            {
                context.BodyParts.Add(bodyPart);
                BodyArea dbEntry = context.BodyAreas.FirstOrDefault(ba => ba.BodyAreaId == bodyPart.BodyAreaId);
            }
            else
            {
                BodyPart dbEntry = context.BodyParts.FirstOrDefault(bP => bP.BodyPartId == bodyPart.BodyPartId);
                if (dbEntry != null)
                {
                    dbEntry.Name = bodyPart.Name;
                    dbEntry.Description = bodyPart.Description;
                    dbEntry.BodyAreaId = bodyPart.BodyAreaId;
                    dbEntry.Image = bodyPart.Image;
                }

            }
            context.SaveChanges();
        }

    }
}
