using BreederBlazor.Services.Auth;
using BreederBlazor.Services.BreedingRecords;
using BreederBlazor.Services.Contacts;
using BreederBlazor.Services.Litters;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BreederBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IBreedingRecordService, BreedingRecordService>();
            builder.Services.AddSingleton<IContactService, ContactService>();
            builder.Services.AddSingleton<ILitterService, LitterService>();
            builder.Services.AddSingleton(
                sp => new HttpClient 
                { 
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

                });

            await builder.Build().RunAsync();
        }
    }
}
