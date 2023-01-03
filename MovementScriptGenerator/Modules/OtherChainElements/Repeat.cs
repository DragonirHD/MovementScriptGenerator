using System;
using System.Collections.Generic;

namespace MovementScriptGenerator.Modules.OtherChainElements
{
    public class Repeat : ChainElement
    {
        public int StartElement { get; }
        public int EndElement { get; }
        public Repeat(string name, int startElement, int endElement) : base(name)
        {
            Name = name ?? "Repeat";
            StartElement = startElement;
            EndElement = endElement;
        }
    }
}
