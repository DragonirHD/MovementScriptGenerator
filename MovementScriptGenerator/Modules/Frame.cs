using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovementScriptGenerator.Modules
{
    public class Frame
    {
        public Position position { get; set; }
        public Rotation rotation { get; set; }
        public float duration { get; set; }
        public float holdTime { get; set; }
        public string transition { get; set; }
        public float fov { get; set; }
    }
}
