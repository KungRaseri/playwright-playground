
using System.Text.Json;
using Newtonsoft.Json;
using Playwright.Tests.swapi;

namespace Playwright.Tests;

[TestFixture]
public class StarWarsAPITests : PlaywrightTest
{
    private IAPIRequestContext Request = null;

    [SetUp]
    public async Task Setup()
    {
        await CreateAPIRequestContext();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Request.DisposeAsync();
    }


    [Test]
    public async Task GetPlanets_ShouldReturnGetPlanetsResult()
    {
        var response = await Request.GetAsync("planets");

        var planetsResult = await response.TextAsync();

        var planets = JsonConvert.DeserializeObject<GetPlanetsResult>(planetsResult);

        Assert.That(planets?.count, Is.EqualTo(60));
        Assert.That(planets?.results.Length, Is.EqualTo(10));

        Assert.True(response.Ok);
    }

    [Test]
    public async Task GetPlanet_ShouldReturnPlanet()
    {
        var response = await Request.GetAsync("planets/1");

        var planetResult = await response.TextAsync();

        var planet = JsonConvert.DeserializeObject<Planet>(planetResult);

        Assert.That(planet, Is.Not.Null);
        Assert.That(planet.name, Is.EqualTo("Tatooine"));
        Assert.That(planet.population, Is.EqualTo("200000"));

        Assert.True(response.Ok);
    }

    private async Task CreateAPIRequestContext()
    {
        var headers = new Dictionary<string, string>
        {
            { "Accept", "application/json" }
        };

        Request = await Playwright.APIRequest.NewContextAsync(new()
        {
            BaseURL = "https://swapi.dev/api/",
            ExtraHTTPHeaders = headers
        });
    }
}