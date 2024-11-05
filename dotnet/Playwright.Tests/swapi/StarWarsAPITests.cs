
using Newtonsoft.Json;
using Playwright.Tests.swapi;

namespace Playwright.Tests;

[TestFixture]
public class StarWarsAPITests : PageTest
{
    public required IAPIRequestContext Request;

    [SetUp]
    public async Task Setup()
    {
        await Context.Tracing.StartAsync(new()
        {
            Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

        await CreateAPIRequestContext();
    }

    [TearDown]
    public async Task TearDown()
    {
        await Context.Tracing.StopAsync(new()
        {
            Path = Path.Combine(
             TestContext.CurrentContext.WorkDirectory,
             "playwright-traces",
             $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
         )
        });

        await Request.DisposeAsync();
    }


    [Test]
    public async Task GetPlanets_ShouldReturnGetPlanetsResult()
    {
        await Page.RouteAsync("*/**/api/planets", async route =>
        {
            var json = JsonConvert.SerializeObject(new PlanetMock());

            await route.FulfillAsync(new()
            {
                Json = json
            });
        });

        await Page.GotoAsync("https://swapi.dev");
        await Page.GetByPlaceholder("people/1/").FillAsync("planets/1/");
        await Page.GetByText("request").ClickAsync();

        await Expect(Page.GetByText("Tatooine")).ToBeVisibleAsync();

        // var response = await Request.GetAsync("planets");

        // var planetsResult = await response.TextAsync();

        // var planets = JsonConvert.DeserializeObject<GetPlanetsResult>(planetsResult);

        // Assert.Multiple(() =>
        // {
        //     Assert.That(planets?.count, Is.EqualTo(60));
        //     Assert.That(planets?.results.Length, Is.EqualTo(10));
        //     Assert.That(response.Ok, Is.True);
        // });
    }

    [Test]
    public async Task GetPlanet_ShouldReturnPlanet()
    {
        var response = await Request.GetAsync("planets/1");

        var planetResult = await response.TextAsync();

        var planet = JsonConvert.DeserializeObject<Planet>(planetResult);

        Assert.That(planet, Is.Not.Null);

        Assert.Multiple(() =>
        {
            Assert.That(planet.name, Is.EqualTo("Tatooine"));
            Assert.That(planet.population, Is.EqualTo("200000"));
            Assert.That(response.Ok, Is.True);
        });
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