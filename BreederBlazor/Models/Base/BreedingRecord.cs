using BreederBlazor.Models.Auth;
using System;
using System.Collections.Generic;

namespace BreederBlazor.Models.Base
{
    public class BreedingRecord
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Name { get; set; } = string.Empty;
        public Contact Owner { get; set; }
        public bool Public { get; set; } = false;
        public DateTime Birthday { get; set; }
        public Gender Sex { get; set; }
        public Contact Breeder { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public Litter BirthLitter { get; set; }

        public ICollection<Characteristic> Characteristics { get; set; }

        public ICollection<BreedingRecordNote> Notes { get; set; }

    }
}
