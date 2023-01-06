using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Circle : Move
    {
        public float RotX { get; }
        public float RotZ { get; }
        public float Distance { get; }
        public float StartingPointDegree { get; }
        public float SectorDegrees { get; }
        public int Iterations { get; }
        public bool RotateClockwise { get; }
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
            RotX = rotX;
            RotZ = rotZ;
            Distance = distance;
            StartingPointDegree = startingPointDegree;
            SectorDegrees = sectorDegrees;
            Iterations = iterations;
            RotateClockwise = rotateClockwise;
        }

        public override List<Frame> GenerateFrames()
        {
            List<Frame> frames = new List<Frame>();

            float initialDegree = 0;
            float maxDegrees = SectorDegrees - 1;
            float initialDegreeAddend = 1;

            if (!RotateClockwise) {
                initialDegree *= -1;
                maxDegrees *= -1;
                initialDegreeAddend *= -1;
            }

            for (float i = initialDegree; (RotateClockwise && i <= maxDegrees) || (!RotateClockwise && i >= maxDegrees); i += (float)initialDegreeAddend / Iterations)
            {
                float usedDegree = i + StartingPointDegree;
                double radiant = usedDegree * Math.PI / 180;

                Frame frame = new Frame();
                frame.Position = new Position();
                frame.Rotation = new Rotation();

                frame.Position.x = (float)Math.Sin(radiant) * Distance;
                frame.Position.y = Height;
                frame.Position.z = (float)Math.Cos(radiant) * Distance;

                frame.Rotation.z = RotZ;
                frame.Rotation.x = RotX;
                frame.Rotation.y = usedDegree -180;

                if (usedDegree == 0 || usedDegree == 180 || usedDegree == 360)
                {
                    frame.Position.x = 0;
                }
                if (usedDegree == 90 || usedDegree == 270)
                {
                    frame.Position.z = 0;
                }


                frame.Duration = Duration / Math.Abs(maxDegrees) / Iterations;

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
