using BreederBlazor.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Base
{
    public class Characteristic
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Category { get; set; }
        public string Feature { get; set; }

        public List<BreedingRecordCharacteristic> BreedingRecordCharacteristics { get; set; }
    }
}
