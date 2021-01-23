using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Base
{
    public class SiblingRecord
    {
        public int SiblingId { get; set; }
        public BreedingRecord Sibling { get; set; }
        public int LitterId { get; set; }
        public Litter Litter { get; set; }
    }
}
