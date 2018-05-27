using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Entities.Body
{
    public class BodyPart
    {
        public int BodyPartId { get; set; }
        public int BodyAreaId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }
    }
}
