using System.Collections.Generic;

namespace MovementScriptGenerator.Modules
{
    public abstract class Move : ChainElement
    {

        public Move(string name, int fov, float duration, float height) : base(name)
        {
            Fov = fov;
            Duration = duration;
            Height = height;
        }

        public int Fov { get; set; }
        public float Duration { get; set; }
        public float Height { get; set; }

        public abstract List<Frame> GenerateFrames();
    }
}
