﻿using RecursosHumanos.App.Services.Http;
using RecursosHumanos.Shared.Models;

namespace RecursosHumanos.App.Services.EmisorService;

public class EmisorService : IEmisorService
{
    private IRestClientService _restClientService;

    public EmisorService(IRestClientService restClientService)
    {
        _restClientService = restClientService;
    }

    public async Task<List<Emisor>> GetAll()
    {
        return (await _restClientService.Get<List<Emisor>>("emisor")) ?? new();
    }
}
