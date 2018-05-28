using OnTrak.Models.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.Repository
{
    public interface IExerciseRepository
    {
        IQueryable<Exercise> Exercise { get; }
        Exercise GetExerciseById(int? Id);
        void SaveExercise(Exercise exercise);
    }
}
