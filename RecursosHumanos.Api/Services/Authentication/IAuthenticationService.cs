using ErrorOr;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.Api.Services.Authentication
{
    public interface IAuthenticationService
    {
        public Task<ErrorOr<UsuarioAutenticado>> LogIn(string username, string password, int codigoEmisor);
        public Task<ErrorOr<Usuario>> GetByJwt(string jwtToken);
        public Task<ErrorOr<Usuario>> LogInAutorizador(string username, string password);
    }
}
