﻿using OnTrak.Models.Entities.Body;
using OnTrak.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.ViewModel
{
    public class BodyPartsViewModel
    {
        public int BodyPartId { get; set; }
        public int BodyAreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
        public ICollection<BodyArea> BodyAreas { get; set; }
        public ICollection<MuscleViewModel> Muscles { get; set; }

    }
}
