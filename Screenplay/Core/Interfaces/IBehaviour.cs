namespace UnderstandingScreenplay.Screenplay.Core.Interfaces;

public interface IBehaviour
{
    public IBehaviour PerformedAs(IActor actor);
}