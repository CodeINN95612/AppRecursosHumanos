using RecursosHumanos.Api.Auth;
using RecursosHumanos.Api.Services.AplicaIESSService;
using RecursosHumanos.Api.Services.AplicaImpuestoRentaService;
using RecursosHumanos.Api.Services.Authentication;
using RecursosHumanos.Api.Services.CentroCostosService;
using RecursosHumanos.Api.Services.EmisorService;
using RecursosHumanos.Api.Services.MovimientoExcepcionService;
using RecursosHumanos.Api.Services.MovimientoPlanillaService;
using RecursosHumanos.Api.Services.Parametros;
using RecursosHumanos.Api.Services.TipoOperacionService;
using RecursosHumanos.Api.Services.TrabajadorService;
using RecursosHumanos.Api.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    var configuration = builder.Configuration;
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthentication();

    builder.Services
        .AddSettings(configuration)
        .AddAuth(configuration);

    builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
    builder.Services.AddScoped<IEmisorService, EmisorService>();
    builder.Services.AddScoped<ICentroCostosService, CentroCostosService>();
    builder.Services.AddScoped<ITipoOperacionService, TipoOperacionService>();
    builder.Services.AddScoped<IMovimientoExcepcionService, MovimientoExcepcionService>();
    builder.Services.AddScoped<IAplicaIESSService, AplicaIESSService>();
    builder.Services.AddScoped<IAplicaImpuestoRentaService, AplicaImpuestoRentaService>();
    builder.Services.AddScoped<IMovimientoPlanillaService, MovimientoPlanillaService>();
    builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
    builder.Services.AddScoped<IParametrosTrabajadorService, ParametrosTrabajadorService>();

    builder.Services.AddCors(c =>
    {
        c.AddPolicy("MyPolicy", p =>
        {
            p.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
        });
    });
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.UseCors("MyPolicy");

    app.Run();
}