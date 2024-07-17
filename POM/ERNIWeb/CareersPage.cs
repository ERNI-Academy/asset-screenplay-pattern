using Microsoft.Playwright;

namespace UnderstandingScreenplay.POM.ERNIWeb;


public class CareersPage : BasePage
{
    private readonly ILocator _jobPosition;
    private readonly ILocator _siteCards;
    public CareersPage(IPage page) : base(page)
    {
        _jobPosition = page.GetByRole(AriaRole.Link);
        _siteCards = page.Locator(".elementor-element", new()
        {
            HasText = "View job positions"
        });
    }

    async public Task GoToJobPositionsFrom(string site)
    {
        await _siteCards
            .Filter(new() { Has = Page.GetByRole(AriaRole.Heading, new() { Name = site }) })
            .Last
            .Locator(_jobPosition).First.ClickAsync();
    }
}
