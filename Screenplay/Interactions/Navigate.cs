using Microsoft.Playwright;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Sut;

namespace UnderstandingScreenplay.Screenplay.Interactions;




public class Navigate : Interaction<IPage>
{
    private string _url;

    public static Navigate To(string url)
    {
        return new Navigate() { _url = url };
    }
    public override Navigate PerformedBy(IActor _)
    {
        Enabler.GotoAsync(_url).Wait();
        return this;
    }
}
