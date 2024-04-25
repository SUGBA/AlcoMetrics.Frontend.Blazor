using Blazored.LocalStorage;
using Blazored.Modal;
using Client.Auth.Abstract;
using Client.Auth.PasswordAuthentification;
using Client.Auth.PasswordAuthentification.Abstract;
using Client.Auth.Share;
using Client.Configuration.ApiConfiguration;
using Client.Pages.ProjectsPage.Services;
using Client.Pages.TimeLinePage.Services;
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

            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddTransient<ITokenProviderService, TokenProviderService>();
            builder.Services.AddTransient<IClaimsPrincipalConverterService, PasswordClaimsPrincipalConverterService>();
            builder.Services.AddScoped<IAuthorizeAPI, PasswordAuthorizeAPI>();

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, IdentityAuthenticationStateProvider>();

            builder.Services.AddBlazoredLocalStorage();

            builder.Services.AddTransient<AuthHttpClientHandler>();
            builder.Services.AddHttpClient(AuthApiConfiguration.ApiName,
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<AuthHttpClientHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
                .CreateClient(AuthApiConfiguration.ApiName));

            builder.Services.AddBlazoredModal();

            builder.Services.AddTransient<IProjectPageApiService, ProjectPageApiService>();
            builder.Services.AddTransient<ITimeLineApiService, TimeLineApiService>();

            await builder.Build().RunAsync();
        }
    }
}
