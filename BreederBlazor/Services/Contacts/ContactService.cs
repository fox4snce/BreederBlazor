using BreederBlazor.Models.Base;
using BreederBlazor.Models.Dtos.ContactDto;
using BreederBlazor.Services.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BreederBlazor.Services.Contacts
{
    public class ContactService : IContactService
    {

        private readonly HttpClient Http;

        public ContactService(HttpClient _http)
        {
            Http = _http;
        }

        public async Task<List<Contact>> CreateContact(CreateContactDto newContact)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> GetAllContacts(string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync("http://localhost:5050/Contact");

            ServiceResponse<List<Contact>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Contact>>>();

            return content.Data;
        }

        public async Task<Contact> GetContactById(string key, int id)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync("http://localhost:5050/Contact/" + id.ToString());

            ServiceResponse<Contact> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Contact>>();

            return content.Data;
        }

        public async Task<Contact> UpdateContact(UpdateContactDto updatedContact)
        {
            throw new NotImplementedException();
        }
    }
}
