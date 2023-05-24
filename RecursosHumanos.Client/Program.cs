using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RecursosHumanos.Client;
using RecursosHumanos.Client.Components.Authorization;
using RecursosHumanos.Client.Constants;
using RecursosHumanos.Client.Services.AplicaIESSService;
using RecursosHumanos.Client.Services.AplicaImpuestoRentaService;
using RecursosHumanos.Client.Services.Auth;
using RecursosHumanos.Client.Services.CentroCostosService;
using RecursosHumanos.Client.Services.Common;
using RecursosHumanos.Client.Services.EmisorService;
using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Client.Services.MovimientoExcepcionService;
using RecursosHumanos.Client.Services.MovimientoPlanillaService;
using RecursosHumanos.Client.Services.Parametros;
using RecursosHumanos.Client.Services.TipoOperacionService;
using RecursosHumanos.Client.Services.TrabajadorService;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();

//This whole thing makes auth work btw
builder.Services
            .AddAuthorizationCore()
            .AddTransient<AuthenticationHeaderHandler>()
            .AddScoped(sp => sp
                .GetRequiredService<IHttpClientFactory>()
                .CreateClient(HttpConstants.HttpClientName)
                .EnableIntercept(sp))
            .AddHttpClient(HttpConstants.HttpClientName, c =>
            {
                c.BaseAddress = new Uri("https://recursoshumanosapi20230516111717.azurewebsites.net/api/");
                //c.BaseAddress = new Uri("https://localhost:7277/api/");
            })
            .AddHttpMessageHandler<AuthenticationHeaderHandler>();

builder.Services.AddHttpClientInterceptor();

//builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<IRestClientService, RestClientService>();
builder.Services.AddScoped<DialogMsgService>();

builder.Services.AddScoped<IEmisorService, EmisorService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ICentroCostosService, CentroCostosService>();
builder.Services.AddScoped<ITipoOperacionService, TipoOperacionService>();
builder.Services.AddScoped<IMovimientoExcepcionService, MovimientoExcepcionService>();
builder.Services.AddScoped<IAplicaIESSService, AplicaIESSService>();
builder.Services.AddScoped<IAplicaImpuestoRentaService, AplicaImpuestoRentaService>();
builder.Services.AddScoped<IMovimientoPlanillaService, MovimientoPlanillaService>();
builder.Services.AddScoped<IParametroTrabajadorService, ParametroTrabajadorService>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();

builder.Services.AddScoped<JwtAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p => p.GetRequiredService<JwtAuthenticationStateProvider>());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
