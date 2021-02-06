using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.LitterDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Litters
{
    public interface ILitterService
    {
        // Create
        Task<List<Litter>> CreateLitter(CreateLitterDto newLitter);

        // Read
        Task<List<Litter>> GetAllLitters(string key);

        Task<Litter> GetLitterById(string key, int id);

        // Update
        Task<Litter> UpdateLitter(UpdateLitterDto updatedLitter);

        // Delete
        Task<List<Litter>> DeleteLitter(int id);
    }
}
