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
        Task<List<Contact>> CreateContact(CreateContactDto newContact, string key);

        // Read
        Task<List<Contact>> GetAllContacts(string key);

        Task<Contact> GetContactById(int id, string key);

        // Update
        Task<Contact> UpdateContact(UpdateContactDto updatedContact, string key);

        // Delete
        Task<List<Contact>> DeleteContact(int id, string key);
    }
}
