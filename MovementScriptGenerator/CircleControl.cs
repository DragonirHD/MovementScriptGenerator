using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovementScriptGenerator.Modules;

namespace MovementScriptGenerator
{
    public partial class CircleControl : UserControl
    {
        private static Circle circle = new Circle();

        List<string> rotationTypes = new List<string>()
            {
                "clockwise",
                "counterclockwise"
            };

        public CircleControl()
        {
            InitializeComponent();
            initializeComboBoxes();
        }

        private void initializeComboBoxes()
        {
            cbRotation.DataSource = rotationTypes;
            cbRotation.SelectedIndex = 0;
        }

        public MovementScript CreateMovementScript()
        {
            MovementScript movementScript = new MovementScript();
            bool rotateClockwise = false;
            if (cbRotation.SelectedIndex == 0)
            {
                rotateClockwise = true;
            }
            movementScript.frames = circle.GenerateFrames(
                (int)numFOV.Value,
                (float)numDuration.Value,
                (float)numRotX.Value,
                (float)numRotZ.Value,
                (float)numDistance.Value,
                (float)numStartingPoint.Value,
                (float)numSector.Value,
                (int)numIterations.Value,
                (float)numHeight.Value,
                rotateClockwise
            );

            return movementScript;
        }
    }
}
