using Microsoft.Playwright;

namespace UnderstandingScreenplay.Sut.ERNIWeb;

public class ERNIWeb
{
    public static readonly string url = "https://www.betterask.erni/";
    public static readonly Locator CareersSection = new(page => page.GetByRole(AriaRole.Link, new() { Name = "Careers" }));
    public static readonly Locator JobPositionBtn = new(page => page.GetByRole(AriaRole.Link, new() { Name = "View job positions" }));
    public static readonly Locator JobOpportunities = new(page => page.GetByRole(AriaRole.Link).Filter(new() { HasText = "View job opportunities" }));
    public static readonly Locator SiteCardHeader = new(page => page.GetByRole(AriaRole.Heading, new() { Level = 3, NameRegex = new(@"ERNI [a-zA-Z]+$") }));
    public static readonly Locator Opportunities = new(page => page.Locator(".offer-wrapper"));
}
