using OnTrak.Models.Data.Repository;
using OnTrak.Models.Entities.Activities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Data.EFRepo
{
    public class EFExerciseRepository : IExerciseRepository
    {
        public IQueryable<Exercise> Exercise => context.Exercises;

        public Exercise GetExerciseById(int? Id)
        {
            var exercise = context.Exercises.Find(Id);
            return exercise;
        }

        public void SaveExercise(Exercise exercise)
        {
            if (exercise.ExerciseId == 0)
            {
                context.Exercises.Add(exercise);
            }
            else
            {
                Exercise dbEntry = context.Exercises.FirstOrDefault(ex => ex.ExerciseId == exercise.ExerciseId);
                if (dbEntry != null)
                {
                    dbEntry.ExerciseId = exercise.ExerciseId;
                    dbEntry.Name = exercise.Name;
                    dbEntry.Description = exercise.Description;
                    dbEntry.Image = exercise.Image;
                }

            }
            context.SaveChanges();
        }

        private ApplicationDbContext context;

        public EFExerciseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
     
    }
}
