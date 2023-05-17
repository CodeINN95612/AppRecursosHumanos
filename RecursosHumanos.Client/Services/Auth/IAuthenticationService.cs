using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Client.Services.Auth;

public interface IAuthenticationService
{
    public Task<UsuarioAutenticado> Login(LoginRequest login);
    public Task<Usuario?> GetFromJwt(JwtUserRequest request);
    public Task<Usuario> LogInAutorizador(AutorizadorLoginRequest request); 
}
