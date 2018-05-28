using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.Entities;

namespace OnTrak.Models.Data.Repository
{
    public interface IBodyPartRepository
    {
        IQueryable<BodyPart> BodyParts { get; }
        BodyPart GetBodyPartById(int? Id);
        void SaveBodyPart(BodyPart bodyPart);
    }
}
