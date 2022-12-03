using System;
using System.Collections.Generic;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    class Spiral
    {
        public List<Frame> GenerateFrames(
            float fov,
            float duration,
            float startDistance,
            float endDistance,
            float endHeight,
            float horizontalRot,
            float verticalRot,
            int spiralAmmount,
            bool spiralClockwise,
            float startHold,
            float endHold,
            bool ease
            )
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
                case 180:
                case -180:
                case 360:
                case -360:
                    //zVertical = 0;
                    break;
            }

            Frame startFrame = new Frame()
            {
                position = new Position()
                {
                    x = xHorizontal * zVertical * startDistance,
                    y = yVertical * startDistance + endHeight,
                    z = zHorizontal * zVertical * startDistance
                },

                rotation = new Rotation()
                {
                    x = verticalRot,
                    y = horizontalRot - 180,
                    z = 0
                },
                
                holdTime = startHold
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
                        position = new Position()
                        {
                            x = xHorizontal * zVertical * spiralFrameDistance,
                            y = yVertical * spiralFrameDistance + endHeight,
                            z = zHorizontal * zVertical * spiralFrameDistance
                        },

                        rotation = new Rotation()
                        {
                            x = verticalRot,
                            y = horizontalRot - 180,
                            z = spiralClockwise ? -rotation : rotation
                        },

                        duration = duration / spiralAmmount / 360
                    };

                    spiralFrames.Add(spiralFrame);
                }

                /*if(i != 0)
                {
                    Frame spiralStartFrame = new Frame()
                    {
                        position = new Position()
                        {
                            x = xHorizontal * zVertical * SpiralStartDistance,
                            y = yVertical * SpiralStartDistance + endHeight,
                            z = zHorizontal * zVertical * SpiralStartDistance
                        },

                        rotation = new Rotation()
                        {
                            x = verticalRot,
                            y = horizontalRot - 180,
                            z = 0
                        },
                    };

                    spiralFrames.Add(spiralStartFrame);
                }

                Frame spiralHalfwayFrame = new Frame()
                {
                    position = new Position()
                    {
                        x = xHorizontal * zVertical * spiralHalfwayDistance,
                        y = yVertical * spiralHalfwayDistance + endHeight,
                        z = zHorizontal * zVertical * spiralHalfwayDistance
                    },

                    rotation = new Rotation()
                    {
                        x = verticalRot,
                        y = horizontalRot - 180,
                        z = spiralClockwise ? 180 : -180
                    },

                    duration = duration / spiralAmmount / 2
                };

                spiralFrames.Add(spiralHalfwayFrame);

                if(i != spiralAmmount -1)
                {
                    Frame spiralEndFrame = new Frame()
                    {
                        position = new Position()
                        {
                            x = xHorizontal * zVertical * spiralEndDistance,
                            y = yVertical * spiralEndDistance + endHeight,
                            z = zHorizontal * zVertical * spiralEndDistance
                        },

                        rotation = new Rotation()
                        {
                            x = verticalRot,
                            y = horizontalRot - 180,
                            z = spiralClockwise ? 360 : -360
                        },

                        duration = duration / spiralAmmount / 2
                    };

                    spiralFrames.Add(spiralEndFrame);

                }*/

                frames.AddRange(spiralFrames);
            }

            Frame endFrame = new Frame()
            {
                position = new Position()
                {
                    x = xHorizontal * zVertical * endDistance,
                    y = yVertical * endDistance + endHeight,
                    z = zHorizontal * zVertical * endDistance
                },

                rotation = new Rotation()
                {
                    x = verticalRot,
                    y = horizontalRot - 180,
                    z = spiralAmmount > 0 ? (spiralClockwise ? -360 : 360) : 0
                },

                holdTime = endHold,

                transition = ease && spiralAmmount < 0 ? "Eased" : "Linear",

                duration = spiralAmmount > 0 ? (duration / spiralAmmount / 360) : duration
                //duration = spiralAmmount > 0 ? (duration / spiralAmmount / 2) : duration
            };
            frames.Add(endFrame);
            return frames;
        }
    }
}
