using Microsoft.Playwright;

namespace UnderstandingScreenplay.POM.ERNIWeb;


public class SpainCareersPage : BasePage
{
    private readonly ILocator _jobOportunities;

    public SpainCareersPage(IPage page) : base(page)
    {
        _jobOportunities = page.GetByRole(AriaRole.Link).Filter(new() { HasText = "View job opportunities" }).First;
    }

    async public Task GoToJobOportunities()
    {
        await _jobOportunities.ClickAsync();
    }
}
