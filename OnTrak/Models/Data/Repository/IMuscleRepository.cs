using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.Repository
{
    public interface IMuscleRepository
    {
        IQueryable<Muscle> Muscles { get; }
        Muscle getMusceById(int? Id);
        void SaveMuscle(Muscle muscle);
    }
}
