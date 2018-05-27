using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.EFRepo
{
    public class EFMuscleRepository : IMuscleRepository
    {

        public IQueryable<Muscle> Muscles => context.Muscles;

        public Muscle getMusceById(int? Id)
        {
            var muscle = context.Muscles.Find(Id);
            return muscle;
        }

        public void SaveMuscle(Muscle muscle)
        {
            if (muscle.MuscleId == 0)
            {
                context.Muscles.Add(muscle);
                Muscle dbEntry = context.Muscles.FirstOrDefault(ba => ba.MuscleId == muscle.MuscleId);
            }
            else
            {
                Muscle dbEntry = context.Muscles.FirstOrDefault(mus => mus.MuscleId == muscle.MuscleId);
                if (dbEntry != null)
                {
                    dbEntry.Name = muscle.Name;
                    dbEntry.Description = muscle.Description;
                    dbEntry.BodyPartId = muscle.BodyPartId;
                    dbEntry.Image = muscle.Image;
                    dbEntry.MuscleId = muscle.MuscleId;
                };

            }
            context.SaveChanges();
        }


        private ApplicationDbContext context;

        public EFMuscleRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

    }
}
