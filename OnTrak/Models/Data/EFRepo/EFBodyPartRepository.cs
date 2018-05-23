using OnTrak.Models.Entities;
using OnTrak.Models.Repository.BodyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Repository.EFRepository
{
    public class EFBodyPartRepository : IBodyPartRepository
    {
        private ApplicationDbContext context;

        public EFBodyPartRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<BodyPart> BodyParts => context.BodyParts;

        public BodyPart getBodyPartById(int? Id)
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
                dbEntry.NumberOfParts += 1;
            }
            else
            {
            //    BodyArea dbEntry = context.BodyAreas.FirstOrDefault(ba => ba.Id == bodyArea.Id);
            //    if (dbEntry != null)
            //    {
            //        dbEntry.Image = bodyArea.Image;
            //        dbEntry.Name = bodyArea.Name;
            //        dbEntry.NumberOfParts = bodyArea.NumberOfParts;
            //        dbEntry.Description = bodyArea.Description;
            //        dbEntry.NumberOfParts = bodyArea.NumberOfParts;
            //    }

            }
            context.SaveChanges();
        }

    }
}
