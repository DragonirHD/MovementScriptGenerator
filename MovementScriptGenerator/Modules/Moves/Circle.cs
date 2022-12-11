using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Circle : Move
    {
        private float rotX;
        private float rotZ;
        private float distance;
        private float startingPointDegree;
        private float sectorDegrees;
        private int iterations;
        private bool rotateClockwise;
        public Circle(
            string name,
            int fov,
            float duration,
            float height,
            float rotX,
            float rotZ,
            float distance,
            float startingPointDegree,
            float sectorDegrees,
            int iterations,
            bool rotateClockwise) : base(name, fov, duration, height)
        {
            Name = name ?? "circleMove";
            Fov = fov;
            Duration = duration;
            Height = height;
            this.rotX = rotX;
            this.rotZ = rotZ;
            this.distance = distance;
            this.startingPointDegree = startingPointDegree;
            this.sectorDegrees = sectorDegrees;
            this.iterations = iterations;
            this.rotateClockwise = rotateClockwise;
        }
        public override List<Frame> GenerateFrames()
        {
            List<Frame> frames = new List<Frame>();

            float initialDegree = 0;
            float maxDegrees = sectorDegrees - 1;
            float initialDegreeAddend = 1;

            if (!rotateClockwise) {
                initialDegree *= -1;
                maxDegrees *= -1;
                initialDegreeAddend *= -1;
            }

            for (float i = initialDegree; (rotateClockwise && i <= maxDegrees) || (!rotateClockwise && i >= maxDegrees); i += (float)initialDegreeAddend / iterations)
            {
                float usedDegree = i + startingPointDegree;
                double radiant = usedDegree * Math.PI / 180;

                Frame frame = new Frame();
                frame.Position = new Position();
                frame.Rotation = new Rotation();

                frame.Position.X = (float)Math.Sin(radiant) * distance;
                frame.Position.Y = Height;
                frame.Position.Z = (float)Math.Cos(radiant) * distance;

                frame.Rotation.Z = rotZ;
                frame.Rotation.X = rotX;
                frame.Rotation.Y = usedDegree -180;

                if (usedDegree == 0 || usedDegree == 180 || usedDegree == 360)
                {
                    frame.Position.X = 0;
                }
                if (usedDegree == 90 || usedDegree == 270)
                {
                    frame.Position.Z = 0;
                }


                frame.Duration = Duration / Math.Abs(maxDegrees) / iterations;

                if(Fov > 0)
                {
                    frame.Fov = Fov;
                }

                frames.Add(frame);
            }

            return frames;
        }
    }
}
