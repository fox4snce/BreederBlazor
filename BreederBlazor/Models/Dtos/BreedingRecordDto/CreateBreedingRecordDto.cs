using BreederBlazor.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Dtos.BreedingRecordDto
{
    public class CreateBreedingRecordDto
    {
        public string Name { get; set; } = string.Empty;
        public Contact Owner { get; set; }
        public bool Public { get; set; } = false;
        public int BirthLitterId { get; set; }
        public DateTime Birthday { get; set; }
        public int Sex { get; set; }
        public Contact Breeder { get; set; }
        public DateTime DateOfAcquisition { get; set; }

        

    }
}
