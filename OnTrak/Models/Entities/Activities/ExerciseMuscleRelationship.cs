using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Entities.Activities
{
    public class ExerciseMuscleRelationship
    {
        [Key]
        public int ExerciseId { get; set; }
        public int MuscleIdS { get; set; }
    }
}
