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

        //general settings
        public int Fov { get; set; }
        public float Duration { get; set; }
        public float Height { get; set; }

        //rotation of the camera itself (euler angles)
        //pitch
        public float RotX { get; set; }
        //yaw
        public float RotY { get; set; }
        //roll
        public float RotZ { get; set; }

        //rotation of the camera around the object (Orbiting)
        public float RotHorizontal { get; set; }
        public float RotVertical { get; set; }

        public abstract List<Frame> GenerateFrames();
    }
}
