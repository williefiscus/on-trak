using OnTrak.Models.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;
using OnTrak.Models.Entities.Activities;

namespace OnTrak.Models.Data.EFRepo
{
    public class DBGetter
    {
        public List<Muscle> muscles;
        public List<BodyArea> bodyAreas;
        public List<BodyPart> bodyParts;
        public List<Exercise> Exercises; 
        public DBGetter() {
           

        }

        public void AssignData(List<Muscle> muscleRepo, List<BodyArea> bAreaRepo, List<BodyPart> bPartRepo)
        {
            muscles = muscleRepo;
            bodyParts = bPartRepo;
            bodyAreas = bAreaRepo;
        }

        public void AssignData(List<Muscle> muscleRepo, List<BodyArea> bAreaRepo, List<BodyPart> bPartRepo, List<Exercise> exerciseRepo)
        {
            muscles = muscleRepo;
            bodyParts = bPartRepo;
            bodyAreas = bAreaRepo;
            Exercises = exerciseRepo;
        }
    }
}
