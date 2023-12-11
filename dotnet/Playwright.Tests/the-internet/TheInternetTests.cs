using NUnit.Framework.Constraints;

namespace Playwright.Tests;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class TheInternetTests : PageTest
{
    [SetUp]
    public async Task Setup()
    {
        await Page.GotoAsync("http://the-internet.herokuapp.com/");
    }

    [Test]
    public async Task ABTesting()
    {
        await Page.GetByRole(AriaRole.Link, new() { Name = "A/B Testing" }).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Heading)).ToContainTextAsync("A/B Test");
        await Expect(Page.GetByRole(AriaRole.Paragraph)).ToContainTextAsync("Also known as split testing. This is a way in which businesses are able to simultaneously test and learn different versions of a page to see which text and/or functionality works best towards a desired outcome (e.g. a user action such as a click-through).");
    }

    [Test]
    public async Task AddAndRemoveElements()
    {
        await Page.GetByRole(AriaRole.Link, new() {Name = "Add/Remove Elements"}).ClickAsync();

        await Page.GetByRole(AriaRole.Button, new() {Name = "Add Element"}).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() {Name = "Add Element"}).ClickAsync();
        await Page.GetByRole(AriaRole.Button, new() {Name = "Add Element"}).ClickAsync();

        await Expect(Page.GetByRole(AriaRole.Button, new() {Name = "Delete"})).ToHaveCountAsync(3);

        await Page.GetByRole(AriaRole.Button, new() {Name = "delete"}).Nth(1).ClickAsync();
     
        await Expect(Page.GetByRole(AriaRole.Button, new() {Name = "Delete"})).ToHaveCountAsync(2);
    }

    [Test]
    public async Task BasicAuthentication()
    {
        await Page.GetByRole(AriaRole.Link, new() {Name = "Basic Auth"}).ClickAsync();
    }
}