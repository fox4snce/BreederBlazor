using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.ContactDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Contacts
{
    public interface IContactService
    {
        // Create
        Task<List<Contact>> CreateContact(CreateContactDto newContact);

        // Read
        Task<List<Contact>> GetAllContacts(string key);

        Task<Contact> GetContactById(string key, int id);

        // Update
        Task<Contact> UpdateContact(UpdateContactDto updatedContact);

        // Delete
        Task<List<Contact>> DeleteContact(int id);
    }
}
