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
using Microsoft.Extensions.Configuration;

namespace BreederBlazor.Services.Contacts
{
    public class ContactService : IContactService
    {

        private readonly HttpClient Http;
        private readonly IConfiguration config;
        private string ApiUrl;

        public ContactService(HttpClient _http, IConfiguration _config)
        {
            Http = _http;
            config = _config;
            ApiUrl = config.GetSection("api").Value;
        }

        public async Task<List<Contact>> CreateContact(CreateContactDto newContact, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.PostAsJsonAsync<CreateContactDto>(ApiUrl + "/Contact", newContact);

            ServiceResponse<List<Contact>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Contact>>>();

            return content.Data;
        }

        public async Task<List<Contact>> DeleteContact(int id, string key)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Contact>> GetAllContacts(string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Contact");

            ServiceResponse<List<Contact>> content = await response.Content.ReadFromJsonAsync<ServiceResponse<List<Contact>>>();

            return content.Data;
        }

        public async Task<Contact> GetContactById(int id, string key)
        {
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", key);

            var response = await Http.GetAsync(ApiUrl + "/Contact/" + id.ToString());

            ServiceResponse<Contact> content = await response.Content.ReadFromJsonAsync<ServiceResponse<Contact>>();

            return content.Data;
        }

        public async Task<Contact> UpdateContact(UpdateContactDto updatedContact, string key)
        {
            throw new NotImplementedException();
        }
    }
}
