using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Circle : Move
    {
        public float Distance { get; }
        public float SectorDegrees { get; }
        public int Iterations { get; }
        public bool RotateClockwise { get; }
        public Circle(
            string name,
            int fov,
            float duration,
            float height,
            float rotX,
            float rotY,
            float rotZ,
            float rotHorizontal,
            float rotVertical,
            float distance,
            float sectorDegrees,
            int iterations,
            bool rotateClockwise) : base(name, fov, duration, height)
        {
            Name = name ?? "circleMove";
            Fov = fov;
            Duration = duration;
            Height = height;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;
            RotHorizontal = rotHorizontal;
            RotVertical = rotVertical;
            Distance = distance;
            SectorDegrees = sectorDegrees;
            Iterations = iterations;
            RotateClockwise = rotateClockwise;
        }

        public override List<Frame> GenerateFrames()
        {
            //TODO Can this be simplified? Less inversion / *-1
            List<Frame> frames = new List<Frame>();

            double verticalRadiant = RotVertical * Math.PI / 180;

            float yVertical = (float)Math.Sin(verticalRadiant);
            float zVertical = (float)Math.Cos(verticalRadiant);

            float initialDegree = 0;
            float maxDegrees = SectorDegrees - 1;
            float initialDegreeAdded = 1;

            if (RotateClockwise) {
                initialDegree *= -1;
                maxDegrees *= -1;
                initialDegreeAdded *= -1;
            }

            for (float i = initialDegree; (!RotateClockwise && i <= maxDegrees) || (RotateClockwise && i >= maxDegrees); i += (float)initialDegreeAdded / Iterations)
            {
                float currentHorizontalDegree = i + RotHorizontal;
                double currentHorizontalRadiant = currentHorizontalDegree * Math.PI / 180;

                float xHorizontal = (float)Math.Sin(currentHorizontalRadiant);
                float zHorizontal = (float)Math.Cos(currentHorizontalRadiant);

                Frame frame = new Frame();
                frame.Position = new Position();
                frame.Rotation = new Rotation();

                frame.Position.x = xHorizontal * zVertical * Distance;
                frame.Position.y = yVertical * Distance + Height;
                frame.Position.z = (zHorizontal * -1) * zVertical * Distance;

                frame.Rotation.x = RotVertical + (RotX * -1);
                frame.Rotation.y = (currentHorizontalDegree * -1) + RotY;
                frame.Rotation.z = (RotZ * -1);

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
