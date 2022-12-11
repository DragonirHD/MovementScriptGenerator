using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public class Spiral : Move
    {
        private float startDistance;
        private float endDistance;
        private float horizontalRot;
        private float verticalRot;
        private float spiralAmmount;
        private bool spiralClockwise;
        private float startHold;
        private float endHold;
        private bool ease;
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
            this.startDistance = startDistance;
            this.endDistance = endDistance;
            this.horizontalRot = horizontalRot;
            this.verticalRot = verticalRot;
            this.spiralAmmount = spiralAmmount;
            this.spiralClockwise = spiralClockwise;
            this.startHold = startHold;
            this.endHold = endHold;
            this.ease = ease;
        }
        public override List<Frame> GenerateFrames()
        {
            List<Frame> frames = new List<Frame>();

            double horizontalRadiant = horizontalRot * Math.PI / 180;

            float xHorizontal = (float)Math.Sin(horizontalRadiant);
            float zHorizontal = (float)Math.Cos(horizontalRadiant);

            double verticalRadiant = verticalRot * Math.PI / 180;

            float yVertical = (float)Math.Sin(verticalRadiant);
            float zVertical = (float)Math.Cos(verticalRadiant);

            float pathLength = startDistance - endDistance;
            float spiralLength = pathLength / spiralAmmount;

            switch (horizontalRot)
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

            switch (verticalRot)
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
                    X = xHorizontal * zVertical * startDistance,
                    Y = yVertical * startDistance + Height,
                    Z = zHorizontal * zVertical * startDistance
                },

                Rotation = new Rotation()
                {
                    X = verticalRot,
                    Y = horizontalRot - 180,
                    Z = 0
                },
                
                HoldTime = startHold,

                Fov = Fov
            };
            frames.Add(startFrame);

            for(int i = 0; i < spiralAmmount; i++)
            {
                List<Frame> spiralFrames = new List<Frame>();

                float SpiralStartDistance = startDistance - (i*spiralLength);
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
                            X = verticalRot,
                            Y = horizontalRot - 180,
                            Z = spiralClockwise ? -rotation : rotation
                        },

                        Duration = Duration / spiralAmmount / 360,

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
                    X = xHorizontal * zVertical * endDistance,
                    Y = yVertical * endDistance + Height,
                    Z = zHorizontal * zVertical * endDistance
                },

                Rotation = new Rotation()
                {
                    X = verticalRot,
                    Y = horizontalRot - 180,
                    Z = spiralAmmount > 0 ? (spiralClockwise ? -360 : 360) : 0
                },

                HoldTime = endHold,

                Transition = ease && spiralAmmount <= 0 ? "Eased" : "Linear",

                Duration = spiralAmmount > 0 ? (Duration / spiralAmmount / 360) : Duration,

                Fov = Fov
            };
            frames.Add(endFrame);
            return frames;
        }
    }
}
