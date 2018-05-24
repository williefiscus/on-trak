using OnTrak.Models.Entities;
using OnTrak.Models.Entities.Body;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.ViewModels
{
    public class BodyAreaViewModel
    {

        public int BodyAreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
        public ICollection<BodyPartsViewModel> BodyParts { get; set; }
    }
}
