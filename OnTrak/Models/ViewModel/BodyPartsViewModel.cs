
using OnTrak.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.ViewModels
{
    public class BodyPartsViewModel
    {
        public int Id { get; set; }
        public int BodyAreaId { get; set; }
        public int NumberOfMuscles { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
        public ICollection<BodyArea> BodyAreas { get; set; }

    }
}
