using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Entities.Body
{
    public class Muscle
    {
        public int BodyPartId { get; set; }
        [Required]
        public int MuscleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
    }
}
