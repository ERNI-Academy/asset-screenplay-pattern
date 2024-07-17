using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnderstandingScreenplay.Screenplay.Core.Bases;
using UnderstandingScreenplay.Screenplay.Core.Interfaces;
using UnderstandingScreenplay.Sut;

namespace UnderstandingScreenplay.Screenplay.Questions;

public class Location : Question<IPage, int>
{
    private Locator _locator;
    private string _text;

    public static Location Of(Locator locator)
    {
        return new Location() { _locator = locator };
    }

    public Location WithText(string text) 
    {
        _text = text;
        return this;
    }

    public override Location AnsweredTo(IActor _, out int response)
    {
        Assertions.Expect(_locator[Enabler!].First).ToBeVisibleAsync().Wait();
        var elements = _locator[Enabler!].AllTextContentsAsync().Result;
        response =  elements.ToList().IndexOf(_text);
        return this;
    }
}
