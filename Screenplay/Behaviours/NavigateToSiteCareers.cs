using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Screenplay.Interactions;
using UnderstandingScreenplay.Sut.ERNIWeb;

namespace UnderstandingScreenplay.Screenplay.Behaviours;

public class NavigateToSiteCareers : Behaviour
{
    private int _siteIndex;

    public static NavigateToSiteCareers WithIndex(int site)
    {
        return new NavigateToSiteCareers() { _siteIndex = site };
    }

    public override NavigateToSiteCareers PerformedAs(IActor actor)
    {
        actor
            .Performs(Click.On(ERNIWeb.JobPositionBtn).WithPosition(_siteIndex))
            .Performs(Click.On(ERNIWeb.JobOpportunities));
        return this;
    }

}
