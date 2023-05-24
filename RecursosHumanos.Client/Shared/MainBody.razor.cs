using Microsoft.AspNetCore.Components;
using RecursosHumanos.Shared.Models;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Client.Shared
{
    public partial class MainBody
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private bool _drawerOpen = true;
        private Usuario _usuario = new("Loading", "Loading", DateTime.Today);
        private void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadDataAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            if (user == null)
                return;
            if (!(user.Identity?.IsAuthenticated ?? false))
            {
                await _sessionService.RemoveJwtToken();
                _stateProvider.MarkUserAsLoggedOut();
                return;
            }

            var token = await _sessionService.GetJwtTokenAsync();
            token ??= "";
            JwtUserRequest request = new(token);
            try
            {
                var usuario = await _authService.GetFromJwt(request);
                if (usuario is null)
                {
                    throw new();
                }

                _usuario = usuario;
            }
            catch
            {
                await _sessionService.RemoveJwtToken();
                _stateProvider.MarkUserAsLoggedOut();
            }
            StateHasChanged();
        }

        private async void Salir()
        {
            await _sessionService.RemoveJwtToken();
            _stateProvider.MarkUserAsLoggedOut();
        }
    }
}