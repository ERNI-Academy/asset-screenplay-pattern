using Microsoft.Playwright;

namespace UnderstandingScreenplay.POM.ERNIWeb;


public class HomePage : BasePage
{
    private readonly string _url = "https://www.betterask.erni/";
    private readonly ILocator _careers;
    public HomePage(IPage page) : base(page)
    {
        _careers = page.GetByRole(AriaRole.Link, new() { Name = "Careers" });
    }

    async public Task Navigate()
    {
        await Page.GotoAsync(_url);
    }

    async public Task AccessToCareers()
    {
        await _careers.ClickAsync();
    }
}
