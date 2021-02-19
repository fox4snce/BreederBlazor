using BreederBlazor.Services.Auth;
using BreederBlazor.Services.PageHistory;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BreederBlazor.Components
{
    public class BasePageComponent : ComponentBase
    {
        [Inject]
        protected IAuthService AuthService { get; set; }

        [Inject]
        protected HttpClient Http { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected IPageHistoryService PageHistory { get; set; }

        protected bool Loaded = false;



        public BasePageComponent(IAuthService Auth, HttpClient httpClient, NavigationManager nav)
        {
            AuthService = Auth;
            Http = httpClient;
            NavigationManager = nav;
        }

        public BasePageComponent()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            if (AuthService.user.Key != "" && AuthService.user.Key != null)
            {
                Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthService.user.Key);

                var response = await Http.GetAsync("http://localhost:5050/auth/Verify");

                if (!response.IsSuccessStatusCode)
                {
                    AuthService.user.Username = "";
                    AuthService.user.Key = "";
                    NavigationManager.NavigateTo("/");
                }
            }
            else
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
