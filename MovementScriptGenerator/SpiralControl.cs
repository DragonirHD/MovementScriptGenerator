using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MovementScriptGenerator
{
    public partial class SpiralControl : UserControl
    {

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

        public Spiral CreateMove(string moveName)
        {
            Spiral spiral = new Spiral(
                moveName,
                (int) numFOV.Value,
                (float) numDuration.Value,
                (float) numHeight.Value,
                (float) numStartDistance.Value,
                (float) numEndDistance.Value,
                (float) numHorizontalRot.Value,
                (float) numVerticalRot.Value,
                (int) numSpiralAmmount.Value,
                cbSpiralRotation.SelectedIndex == 0 ? true : false,
                (float) numStartHoldTime.Value,
                (float) numEndHoldTime.Value,
                checkEase.Checked
                );

            return spiral;
        }
    }
}
