using BreederBlazor.Services.Auth;
using BreederBlazor.Services.PageHistory;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

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

            Console.WriteLine("BasePageComponent, Key: " + AuthService.user.Key);

            if (!CheckKey())
            {
                AuthService.user.Key = await ReadFromLocalStorage("key");
            }


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

        protected void PushCurrentPageToHistory()
        {
            PageHistory.PushPage("/" + NavigationManager.ToBaseRelativePath(NavigationManager.Uri));
        }

        protected string GetLastHistoryPage()
        {
            return PageHistory.PopPage();
        }

        public async Task SaveToLocalStorage(string name, string value)
        {
            await JSRuntime.InvokeVoidAsync("localStorage.setItem", name, value);
        }

        public async Task<string> ReadFromLocalStorage(string name)
        {
            return await JSRuntime.InvokeAsync<string>("localStorage.getItem", name);
        }

        public bool CheckKey()
        {
            if (AuthService.user.Key == "" || AuthService.user.Key == null) return false;
            return true;

        }

    }
}
