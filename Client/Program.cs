using Blazored.LocalStorage;
using Blazored.Modal;
using Client.Auth;
using Client.Auth.Abstract;
using Client.Auth.PasswordAuthentification;
using Client.Auth.PasswordAuthentification.Abstract;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services.AddTransient<ITokenProviderService, TokenProviderService>();
            builder.Services.AddTransient<IClaimsPrincipalConverterService, PasswordClaimsPrincipalConverterService>();

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7208/") });
            builder.Services.AddScoped<IAuthorizeAPI, PasswordAuthorizeAPI>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddBlazoredModal();

            await builder.Build().RunAsync();
        }
    }
}
