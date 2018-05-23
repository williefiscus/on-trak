using OnTrak.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Repository.BodyData
{
    public interface IBodyPartRepository
    {
        IQueryable<BodyPart> BodyParts { get; }
        BodyPart getBodyPartById(int? Id);
        void SaveBodyPart(BodyPart bodyPart);
    }
}
