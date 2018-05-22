using OnTrak.Models.Data.Repository;
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
        EFBodyAreaRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<BodyArea> BodyAreas => context.BodyAreas;
    }
}
