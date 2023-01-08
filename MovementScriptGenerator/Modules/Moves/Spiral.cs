using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Spiral : Move
    {
        public float StartDistance { get; }
        public float EndDistance { get; }
        public int SpiralAmmount { get; }
        public bool SpiralClockwise { get; }
        public float StartHold { get; }
        public float EndHold { get; }
        public bool Ease { get; }
        public Spiral(
            string name,
            int fov,
            float duration,
            float height,
            float rotX,
            float rotY,
            float rotZ,
            float horizontalRot,
            float verticalRot,
            float startDistance,
            float endDistance,
            int spiralAmmount,
            bool spiralClockwise,
            float startHold,
            float endHold,
            bool ease) : base(name, fov, duration, height)
        {
            Name = name ?? "spiralMove";
            Fov = fov;
            Duration = duration;
            Height = height;
            RotX = rotX;
            RotY = rotY;
            RotZ = rotZ;
            RotHorizontal = horizontalRot;
            RotVertical = verticalRot;
            StartDistance = startDistance;
            EndDistance = endDistance;
            SpiralAmmount = spiralAmmount;
            SpiralClockwise = spiralClockwise;
            StartHold = startHold;
            EndHold = endHold;
            Ease = ease;
        }
        public override List<Frame> GenerateFrames()
        {
            List<Frame> frames = new List<Frame>();

            double horizontalRadiant = RotHorizontal * Math.PI / 180;

            float xHorizontal = (float)Math.Sin(horizontalRadiant);
            float zHorizontal = (float)Math.Cos(horizontalRadiant);

            double verticalRadiant = RotVertical * Math.PI / 180;

            float yVertical = (float)Math.Sin(verticalRadiant);
            float zVertical = (float)Math.Cos(verticalRadiant);

            float pathLength = StartDistance - EndDistance;
            float spiralLength = pathLength / SpiralAmmount;

            Frame startFrame = new Frame()
            {
                Position = new Position()
                {
                    x = xHorizontal * zVertical * StartDistance,
                    y = yVertical * StartDistance + Height,
                    z = zHorizontal * zVertical * StartDistance
                },

                Rotation = new Rotation()
                {
                    x = RotVertical + RotX,
                    y = RotHorizontal + RotY - 180,
                    z = 0 + RotZ
                },
                
                HoldTime = StartHold,

                Fov = Fov
            };
            frames.Add(startFrame);

            for(int i = 0; i < SpiralAmmount; i++)
            {
                List<Frame> spiralFrames = new List<Frame>();

                float currentSpiralStartDistance = StartDistance - (i*spiralLength);

                for(int rotation = 1; rotation < 360; rotation++)
                {
                    float spiralFrameDistance = currentSpiralStartDistance - (spiralLength / 360 * rotation);

                    Frame spiralFrame = new Frame()
                    {
                        Position = new Position()
                        {
                            x = xHorizontal * zVertical * spiralFrameDistance,
                            y = yVertical * spiralFrameDistance + Height,
                            z = zHorizontal * zVertical * spiralFrameDistance
                        },

                        Rotation = new Rotation()
                        {
                            x = RotVertical + RotX,
                            y = RotHorizontal + RotY - 180,
                            z = SpiralClockwise ? -rotation + RotZ : rotation + RotZ
                        },

                        Duration = Duration / SpiralAmmount / 360,

                        Fov = Fov
                    };

                    spiralFrames.Add(spiralFrame);
                }

                frames.AddRange(spiralFrames);
            }

            Frame endFrame = new Frame()
            {
                Position = new Position()
                {
                    x = xHorizontal * zVertical * EndDistance,
                    y = yVertical * EndDistance + Height,
                    z = zHorizontal * zVertical * EndDistance
                },

                Rotation = new Rotation()
                {
                    x = RotVertical + RotX,
                    y = RotHorizontal + RotY - 180,
                    z = SpiralAmmount > 0 ? (SpiralClockwise ? -360 + RotZ : 360 + RotZ) : 0 + RotZ
                },

                HoldTime = EndHold,

                Transition = Ease && SpiralAmmount <= 0 ? "Eased" : "Linear",

                Duration = SpiralAmmount > 0 ? (Duration / SpiralAmmount / 360) : Duration,

                Fov = Fov
            };
            frames.Add(endFrame);
            return frames;
        }
    }
}
