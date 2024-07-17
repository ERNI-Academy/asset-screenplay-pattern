using Microsoft.Playwright;

namespace UnderstandingScreenplay.POM.ERNIWeb;


public class JobOpportunitiesPage : BasePage
{
    private readonly ILocator _jobOportunities;

    public JobOpportunitiesPage(IPage page) : base(page)
    {
        _jobOportunities = page.Locator(".offer-wrapper");
    }

    async public Task<int> GetNumberOfOpportunities()
    {
        await Assertions.Expect(_jobOportunities.First).ToBeVisibleAsync();
        var opportunities = await _jobOportunities.AllAsync();
        return opportunities.Count();
    }
}