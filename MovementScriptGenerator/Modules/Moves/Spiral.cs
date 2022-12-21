using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Spiral : Move
    {
        public float StartDistance { get; }
        public float EndDistance { get; }
        public float HorizontalRot { get; }
        public float VerticalRot { get; }
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
            float startDistance,
            float endDistance,
            float horizontalRot,
            float verticalRot,
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
            StartDistance = startDistance;
            EndDistance = endDistance;
            HorizontalRot = horizontalRot;
            VerticalRot = verticalRot;
            SpiralAmmount = spiralAmmount;
            SpiralClockwise = spiralClockwise;
            StartHold = startHold;
            EndHold = endHold;
            Ease = ease;
        }
        public override List<Frame> GenerateFrames()
        {
            List<Frame> frames = new List<Frame>();

            double horizontalRadiant = HorizontalRot * Math.PI / 180;

            float xHorizontal = (float)Math.Sin(horizontalRadiant);
            float zHorizontal = (float)Math.Cos(horizontalRadiant);

            double verticalRadiant = VerticalRot * Math.PI / 180;

            float yVertical = (float)Math.Sin(verticalRadiant);
            float zVertical = (float)Math.Cos(verticalRadiant);

            float pathLength = StartDistance - EndDistance;
            float spiralLength = pathLength / SpiralAmmount;

            switch (HorizontalRot)
            {
                case 0:
                    zHorizontal = 1;
                    break;
                case 90:
                case -90:
                case 270:
                case -270:
                    zHorizontal = 0;
                    break;
                case 180:
                case -180:
                case 360:
                case -360:
                    xHorizontal = 0;
                    break;
            }

            switch (VerticalRot)
            {
                case 0:
                    yVertical = 0;
                    break;
                case 90:
                case -90:
                case 270:
                case -270:
                    zVertical = 0;
                    break;
            }

            Frame startFrame = new Frame()
            {
                Position = new Position()
                {
                    X = xHorizontal * zVertical * StartDistance,
                    Y = yVertical * StartDistance + Height,
                    Z = zHorizontal * zVertical * StartDistance
                },

                Rotation = new Rotation()
                {
                    X = VerticalRot,
                    Y = HorizontalRot - 180,
                    Z = 0
                },
                
                HoldTime = StartHold,

                Fov = Fov
            };
            frames.Add(startFrame);

            for(int i = 0; i < SpiralAmmount; i++)
            {
                List<Frame> spiralFrames = new List<Frame>();

                float SpiralStartDistance = StartDistance - (i*spiralLength);
                float spiralHalfwayDistance = SpiralStartDistance - (spiralLength / 2);
                float spiralEndDistance = spiralHalfwayDistance - (spiralLength / 2);

                for(int rotation = 1; rotation < 360; rotation++)
                {
                    float spiralFrameDistance = SpiralStartDistance - (spiralLength / 360 * rotation);

                    Frame spiralFrame = new Frame()
                    {
                        Position = new Position()
                        {
                            X = xHorizontal * zVertical * spiralFrameDistance,
                            Y = yVertical * spiralFrameDistance + Height,
                            Z = zHorizontal * zVertical * spiralFrameDistance
                        },

                        Rotation = new Rotation()
                        {
                            X = VerticalRot,
                            Y = HorizontalRot - 180,
                            Z = SpiralClockwise ? -rotation : rotation
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
                    X = xHorizontal * zVertical * EndDistance,
                    Y = yVertical * EndDistance + Height,
                    Z = zHorizontal * zVertical * EndDistance
                },

                Rotation = new Rotation()
                {
                    X = VerticalRot,
                    Y = HorizontalRot - 180,
                    Z = SpiralAmmount > 0 ? (SpiralClockwise ? -360 : 360) : 0
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
