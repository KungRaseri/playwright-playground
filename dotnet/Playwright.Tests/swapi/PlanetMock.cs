namespace Playwright.Tests.swapi
{
    public class PlanetMock
    {
        public string name = "Tatooine";

        public string rotation_period = "23";

        public string orbital_period = "304";

        public string diameter = "10465";

        public string climate = "arid";

        public string gravity = "1 standard";

        public string terrain = "desert";

        public string surface_water = "1";

        public string population = "200000";

        public string[] residents = [
            "https://swapi.dev/api/people/1/",
            "https://swapi.dev/api/people/2/",
            "https://swapi.dev/api/people/4/",
            "https://swapi.dev/api/people/6/",
            "https://swapi.dev/api/people/7/",
            "https://swapi.dev/api/people/8/",
            "https://swapi.dev/api/people/9/",
            "https://swapi.dev/api/people/11/",
            "https://swapi.dev/api/people/43/",
            "https://swapi.dev/api/people/62/"
        ];

        public string[] films = [
            "https://swapi.dev/api/films/1/",
            "https://swapi.dev/api/films/3/",
            "https://swapi.dev/api/films/4/",
            "https://swapi.dev/api/films/5/",
            "https://swapi.dev/api/films/6/"
        ];

        public string created = "2014-12-09T13:50:49.641000Z";

        public string edited = "2014-12-20T20:58:18.411000Z";

        public string url = "https://swapi.dev/api/planets/1/";
    }
}