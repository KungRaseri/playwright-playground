namespace Playwright.Tests.swapi
{
    public class GetPlanetsResult
    {
        public required int count;
        public required string? next;
        public required string? previous;
        public required Planet[] results;

    }
}