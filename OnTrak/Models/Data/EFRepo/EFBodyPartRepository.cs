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
    }
}
