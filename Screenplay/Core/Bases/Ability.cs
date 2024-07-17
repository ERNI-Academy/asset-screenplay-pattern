using UnderstandingScreenplay.Screenplay.Core.Interfaces;

namespace UnderstandingScreenplay.Screenplay.Core.Bases;
public abstract class Ability<T> : IAbility<T>
{
    protected T Enabler;
    public virtual T GetEnabler()
    {
        return Enabler;
    }
}

