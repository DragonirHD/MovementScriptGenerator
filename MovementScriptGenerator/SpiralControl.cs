using MovementScriptGenerator.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovementScriptGenerator
{
    public partial class SpiralControl : UserControl
    {
        private static Spiral spiral = new Spiral();

        List<string> rotationTypes = new List<string>()
            {
                "clockwise",
                "counterclockwise"
            };

        public SpiralControl()
        {
            InitializeComponent();
            initializeComboBoxes();
        }

        private void initializeComboBoxes()
        {
            cbSpiralRotation.DataSource = rotationTypes;
            cbSpiralRotation.SelectedIndex = 0;
        }

        private void numSpiralAmmount_ValueChanged(object sender, EventArgs e)
        {
            if (numSpiralAmmount.Value > 0)
            {
                checkEase.Checked = false;
                checkEase.Enabled = false;
                cbSpiralRotation.Enabled = true;
            }
            else
            {
                checkEase.Enabled = true;
                cbSpiralRotation.Enabled = false;
            }
        }

        public MovementScript CreateMovementScript()
        {
            MovementScript movementScript = new MovementScript();
            bool spiralClockwise = false;
            if (cbSpiralRotation.SelectedIndex == 0)
            {
                spiralClockwise = true;
            }
            movementScript.frames = spiral.GenerateFrames(
                (int)numFOV.Value,
                (float)numDuration.Value,
                (float)numStartDistance.Value,
                (float)numEndDistance.Value,
                (float)numEndHeight.Value,
                (float)numHorizontalRot.Value,
                (float)numVerticalRot.Value,
                (int)numSpiralAmmount.Value,
                spiralClockwise,
                (float)numStartHoldTime.Value,
                (float)numEndHoldTime.Value,
                checkEase.Checked
            );

            return movementScript;
        }
    }
}
