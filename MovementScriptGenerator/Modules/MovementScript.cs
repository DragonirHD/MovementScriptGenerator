using System.Collections.Generic;

namespace MovementScriptGenerator.Modules
{
    public class MovementScript
    {
        public bool SyncToSong { get; set; }

        public bool Loop { get; set; }
        public List<Frame> Frames { get; set; }
    }
}
