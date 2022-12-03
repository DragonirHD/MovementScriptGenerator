using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    class Circle
    {
        public List<Frame> GenerateFrames(
            int fov,
            float duration,
            float rotX,
            float rotZ,
            float distance,
            float startingPointDegree,
            float sectorDegrees,
            int iterations,
            float height,
            bool rotateClockwise
            )
        {
            List<Frame> frames = new List<Frame>();

            float initialDegree = 0;
            float maxDegrees = sectorDegrees - 1;
            //float maxDegrees = 359;
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
                frame.position = new Position();
                frame.rotation = new Rotation();

                frame.position.x = (float)Math.Sin(radiant) * distance;
                frame.position.y = height;
                frame.position.z = (float)Math.Cos(radiant) * distance;

                frame.rotation.z = rotZ;
                frame.rotation.x = rotX;
                frame.rotation.y = usedDegree -180;

                if (usedDegree == 0 || usedDegree == 180 || usedDegree == 360)
                {
                    frame.position.x = 0;
                }
                if (usedDegree == 90 || usedDegree == 270)
                {
                    frame.position.z = 0;
                }


                frame.duration = duration / Math.Abs(maxDegrees) / iterations;

                if(fov > 0)
                {
                    frame.fov = fov;
                }

                frames.Add(frame);
            }

            return frames;
        }
    }
}
