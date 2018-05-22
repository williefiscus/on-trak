using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnTrak.Models.Entities.Body
{
    public class BodyArea
    {
        public int Id { get; set; }
        public int NumberOfParts { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Byte[] Image { get; set; }
    }
}
