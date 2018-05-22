using OnTrak.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.Repository
{
    public interface IBodyAreaRepository
    {
        IQueryable<BodyArea> BodyAreas { get; }
        BodyArea getBodyAreaById(int? index);
        void SaveBodyArea(BodyArea bodyArea);
    }
}
