using Microsoft.Playwright;
using UnderstandingScreenplay.POM;
using UnderstandingScreenplay.POM.ERNIWeb;
using UnderstandingScreenplay.Screenplay.Abilities;
using UnderstandingScreenplay.Screenplay.Behaviours;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Interactions;
using UnderstandingScreenplay.Screenplay.Questions;
using UnderstandingScreenplay.Sut.ERNIWeb;

namespace UnderstandingScreenplay.Tests;
[TestClass]
public class ERNIWebTest
{

    /// <summary>
    /// Test using Screenplay pattern that ensure ERNI Spain site has job opportunities
    /// </summary>
    [TestMethod]
    public async Task ScreenPlay()
    {
        var surfTheWeb = BrowseTheWeb.WithNewSession();

        var candidate = new Candidate("Diego de la Vega", "ERNI Spain");

        candidate.HasAbility(surfTheWeb)
            .Performs(Navigate.To(ERNIWeb.url))
            .Performs(Click.On(ERNIWeb.CareersSection))
            .Answers(Location.Of(ERNIWeb.SiteCardHeader).WithText(candidate.Site), out var position)
            .Performs(NavigateToSiteCareers.WithIndex(position))
            .Answers(Count.Of(ERNIWeb.Opportunities), out var opportunities);
        
        Assert.IsTrue(opportunities > 0);

        surfTheWeb.Dispose();
    }


    /// <summary>
    /// Test using page object model that ensure ERNI Spain site has job opportunities
    /// </summary>
    [TestMethod]
    public async Task PageObjectModel()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 50,
        });
        var context = await browser.NewContextAsync();
        await context.AddCookiesAsync(new[] {
            new Cookie() {
                Name = "geot_rocket_country",
                Value = "",
                Url = "https://www.betterask.erni/"
            }
        });
        var page = await context.NewPageAsync();

        var homePage = new HomePage(page);
        var careersPage = new CareersPage(page);
        var spainCareersPage = new SpainCareersPage(page);
        var jobOpportunitiesPage = new JobOpportunitiesPage(page);

        await homePage.Navigate();
        await homePage.AccessToCareers();
        await careersPage.GoToJobPositionsFrom("ERNI Spain");
        await spainCareersPage.GoToJobOportunities();
        var opportunities = await jobOpportunitiesPage.GetNumberOfOpportunities();
        Assert.IsTrue(opportunities > 0);

        await browser.DisposeAsync();
        playwright.Dispose();
    }


    /// <summary>
    /// Linear Script Test that ensure ERNI Spain site has job opportunities
    /// </summary>
    [TestMethod]
    public async Task  LinearScript()
    {
        var url = "https://www.betterask.erni/";

        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            SlowMo = 50,
        });
        var context = await browser.NewContextAsync();
        await context.AddCookiesAsync(new[] {
            new Cookie() {
                Name = "geot_rocket_country",
                Value = "",
                Url = "https://www.betterask.erni/"
            }
        });
        var page = await context.NewPageAsync();
       
        await page.GotoAsync(url);
        await page.GetByRole(AriaRole.Link, new() { Name = "Careers" }).ClickAsync();
        await page.Locator(".elementor-element", new ()
            {
                Has = page.GetByRole(AriaRole.Heading, new() { Name = "ERNI Spain" }),
                HasText = "View job positions"
            }).Last
            .GetByRole(AriaRole.Link).First.ClickAsync();

        await page.GetByRole(AriaRole.Link).Filter(new() { HasText = "View job opportunities" }).First.ClickAsync();
        await Assertions.Expect(page.Locator(".offer-wrapper").First).ToBeVisibleAsync();
        var opportunities = await page.Locator(".offer-wrapper").AllAsync();
        Assert.IsTrue(opportunities.Count > 0);
        await browser.DisposeAsync();
        playwright.Dispose();
    }

}
