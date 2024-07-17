namespace UnderstandingScreenplay.Screenplay.Core.Interfaces;

public interface IInteraction<T>
{
    public IInteraction<T> PerformedBy(IActor actor);
    public IInteraction<T> EnabledBy(T enabler);
}
