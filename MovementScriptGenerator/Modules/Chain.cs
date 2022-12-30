using System.Collections.Generic;

namespace MovementScriptGenerator.Modules
{
    public class Chain
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public string DirectoryPath { get; set; }
        public List<ChainElement> Elements { get; set; }
    }
}
