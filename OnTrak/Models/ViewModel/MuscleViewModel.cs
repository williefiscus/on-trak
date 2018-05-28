using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Activities;

namespace OnTrak.Models.ViewModel
{
    public class MuscleViewModel
    {
        public int BodyAreaId { get; set; }
        public int MuscleId { get; set; }
        public int BodyPartId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
        public ICollection<BodyPart> BodyParts { get; set; }
        public ICollection<BodyArea> BodyAreas { get; set; }
    }
}
