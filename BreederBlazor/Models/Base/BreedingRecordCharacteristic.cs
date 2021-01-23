using BreederBlazor.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Models.Base
{
    public class BreedingRecordCharacteristic
    {
        public int BreedingRecordId { get; set; }
        public BreedingRecord BreedingRecord { get; set; }

        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
    }
}
