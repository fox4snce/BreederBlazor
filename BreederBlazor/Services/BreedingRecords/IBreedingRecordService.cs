using BreederBlazor.Models.Base;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.BreedingRecords
{
    public interface IBreedingRecordService
    {
        // Create
        Task<List<BreedingRecord>> CreateBreedingRecord(BreedingRecord newBreedingRecord);

        // Read
        Task<List<BreedingRecord>> GetAllBreedingRecords(string key);

        Task<BreedingRecord> GetBreedingRecordById(string key, int id);

        // Update
        Task<BreedingRecord> UpdateBreedingRecord(BreedingRecord updatedBreedingRecord);

        // Delete
        Task<List<BreedingRecord>> DeleteBreedingRecord(int id);
    }
}
