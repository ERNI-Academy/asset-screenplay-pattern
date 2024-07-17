using UnderstandingScreenplay.Screenplay.Core.Interfaces;

namespace UnderstandingScreenplay.Screenplay.Core.Bases;

public abstract class Behaviour : IBehaviour
{
    public abstract IBehaviour PerformedAs(IActor actor);
}

