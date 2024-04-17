using Blazored.LocalStorage;
using Blazored.Modal;
using Client.Auth.Abstract;
using Client.Auth.PasswordAuthentification;
using Client.Auth.PasswordAuthentification.Abstract;
using Client.Auth.Share;
using Client.Extensions;
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

            builder.Services.AddScoped<AuthHttpClientHandler>();
            builder.Services.AddHttpClient(builder.Configuration.TryGetValue("ApiSettings:HttpClientName", "Имя HttpClient не указано в конфигурации"),
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthHttpClientHandler>();

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
