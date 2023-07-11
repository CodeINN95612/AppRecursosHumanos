using Microsoft.Extensions.Options;
using Moq;
using RecursosHumanos.Api.Auth;
using RecursosHumanos.Api.Constants;
using RecursosHumanos.Api.Services.Authentication;
using RecursosHumanos.Api.Settings;

namespace RecursosHumanos.Test.Api;

public class AuthTests
{
    private Mock<IHttpClientFactory> _mockHttpClientFactory;
    private IAuthenticationService _authService;

    [SetUp]
    public void Setup()
    {
        _mockHttpClientFactory = new Mock<IHttpClientFactory>();
        _mockHttpClientFactory.Setup(x => x.CreateClient(HttpConstants.HttpClientName))
            .Returns(new HttpClient
            {
                BaseAddress = new Uri("http://apiservicios.ecuasolmovsa.com:3009/api/")
            });

        var settings = new JwtSettings
        {
            Audience = "RRHH",
            ExpiryMinutes = 60,
            Issuer = "RRHH",
            Secret = "super-secret-key"
        };

        var mockOptions = new Mock<IOptions<JwtSettings>>();
        mockOptions.Setup(x => x.Value).Returns(settings);
        var jwtGenerator = new JwtTokenGenerator(mockOptions.Object);

        _authService = new AuthenticationService(_mockHttpClientFactory.Object, jwtGenerator);
    }

    [Test]
    public async Task Should_ReturnUser_When_ValidCredentials()
    {
        var result = await _authService.LogIn("5004", "5004u", 2);
        Assert.IsFalse(result.IsError);
        Assert.Pass();
    }

    [Test]
    public async Task Should_ReturnError_When_InvalidCredentials()
    {
        var result = await _authService.LogIn("500", "5004", 1);
        Assert.IsTrue(result.IsError);
        Assert.Pass();
    }

    [Test]
    public async Task Should_ReturnError_When_InvalidUser()
    {
        var result = await _authService.LogIn("500", "5004u", 2);
        Assert.IsTrue(result.IsError);
        Assert.Pass();
    }

    [Test]
    public async Task Should_ReturnError_When_InvalidPassword()
    {
        var result = await _authService.LogIn("5004", "5004", 2);
        Assert.IsTrue(result.IsError);
        Assert.Pass();
    }

    [Test]
    public async Task Should_ReturnError_When_InvalidEmisor()
    {
        var result = await _authService.LogIn("5004", "5004u", 1);
        Assert.IsTrue(result.IsError);
        Assert.Pass();
    }
}