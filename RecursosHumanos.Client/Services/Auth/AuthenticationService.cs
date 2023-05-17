using RecursosHumanos.Client.Components.Authorization;
using RecursosHumanos.Client.Services.Http;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;
using System.Net.Http.Headers;

namespace RecursosHumanos.Client.Services.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly IRestClientService _restClientService;
    private readonly ISessionService _sessionService;
    private readonly JwtAuthenticationStateProvider _stateProvider;
    private readonly HttpClient _httpClient;

    public AuthenticationService(IRestClientService restClientService, ISessionService sessionService, JwtAuthenticationStateProvider stateProvider, HttpClient httpClient)
    {
        _restClientService = restClientService;
        _sessionService = sessionService;
        _stateProvider = stateProvider;
        _httpClient = httpClient;
    }

    public async Task<UsuarioAutenticado> Login(LoginRequest login)
    {
        var usuario = await _restClientService.Post<UsuarioAutenticado, LoginRequest>("authentication/login", login);
        var token = usuario.JwtToken;
        await _sessionService.SaveJwtToken(token);
        await _stateProvider.StateChangedAsync();
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return usuario;
    }

    public async Task<Usuario?> GetFromJwt(JwtUserRequest request)
    {
        var usuario = await _restClientService.Post<Usuario, JwtUserRequest>($"Authentication/getByJwt", request);
        return usuario;
    }

    public async Task<Usuario> LogInAutorizador(AutorizadorLoginRequest request)
    {
        var usuario = await _restClientService.Post<Usuario, AutorizadorLoginRequest>($"Authentication/logInAutorizador", request);
        return usuario;
    }
}
