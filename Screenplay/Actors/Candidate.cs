
namespace UnderstandingScreenplay.Screenplay.Core.Bases;

public class Candidate(string name, string site) : Actor() 
{
    public string Name = name;
    public string Site = site;
}