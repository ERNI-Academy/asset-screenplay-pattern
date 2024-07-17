using Microsoft.Playwright;

namespace UnderstandingScreenplay.Sut;

public class Locator
{
    private Func<IPage, ILocator> _getter;
    public ILocator this[IPage page]
    {
        get => _getter(page);
    }

    public Locator(Func<IPage, ILocator> getter)
    {
        _getter = getter;
    }
}

