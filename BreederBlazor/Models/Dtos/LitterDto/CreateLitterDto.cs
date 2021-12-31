using BreederBlazor.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Dtos.LitterDto
{
    public class CreateLitterDto
    {
        public string Name { get; set; }
        public bool Public { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public int BreederId { get; set; }
    }
}

