﻿using Microsoft.AspNetCore.Mvc;
using RecursosHumanos.Api.Services.Authentication;
using RecursosHumanos.Shared.Requests;

namespace RecursosHumanos.Api.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : RecursosHumanosApi
{
    private IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LogIn(LoginRequest loginRequest)
    {
        var loginResult = await _authenticationService.LogIn(
            loginRequest.usuario, 
            loginRequest.password, 
            loginRequest.codigoEmisor);

        return loginResult.Match(Ok, Problem);
    }

    [HttpPost("getByJwt")]
    public async Task<IActionResult> GetByJwt(JwtUserRequest request)
    {
        var usuarioResult = await _authenticationService.GetByJwt(request.jwtToken);
        return usuarioResult.Match(Ok, Problem);
    }
}
