using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.BreedingRecordDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Dtos.LitterDto
{
    public class GetLitterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Public { get; set; } = false;
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Contact Breeder { get; set; }

        public List<GetBreedingRecordDto> Parents { get; set; }
        public List<GetBreedingRecordDto> Siblings { get; set; }
    }
}
