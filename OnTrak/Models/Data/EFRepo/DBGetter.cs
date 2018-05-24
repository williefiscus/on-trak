using OnTrak.Models.Data.Repository;
using OnTrak.Models.Repository.BodyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;

namespace OnTrak.Models.Data.EFRepo
{
    public class DBGetter
    {
        public List<Muscle> muscles;
        public List<BodyArea> bodyAreas;
        public List<BodyPart> bodyParts;
        public DBGetter() {
           

        }

        public void AssignData(List<Muscle> muscleRepo, List<BodyArea> bAreaRepo, List<BodyPart> bPartRepo)
        {
            muscles = muscleRepo;
            bodyParts = bPartRepo;
            bodyAreas = bAreaRepo;
        }
    }
}
