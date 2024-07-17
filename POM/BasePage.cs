using Microsoft.Playwright;

namespace UnderstandingScreenplay.POM;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }
}
