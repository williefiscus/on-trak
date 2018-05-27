using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.Entities;

namespace OnTrak.Models.Repository.BodyData
{
    public interface IBodyPartRepository
    {
        IQueryable<BodyPart> BodyParts { get; }
        BodyPart getBodyPartById(int? Id);
        void SaveBodyPart(BodyPart bodyPart);
    }
}
