using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Entities
{
    public class BodyArea
    {
        public int Id { get; set; }
        public int NumberOfParts { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Byte[] Image { get; set; }

    }
}
