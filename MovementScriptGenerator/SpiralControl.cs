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

        private void SpiralControl_Load(object sender, EventArgs e)
        {
            ScrollEventDisable scrollEventDisable = new ScrollEventDisable();
            scrollEventDisable.DisableScrollForChainElementControls(sender, e, Controls[0]);
        }

        private void initializeComboBoxes()
        {
            cbSpiralRotation.DataSource = rotationTypes;
            cbSpiralRotation.SelectedIndex = 0;
        }

        public bool Populate(Spiral original)
        {
            try
            {
                numFOV.Value = original.Fov;
                numDuration.Value = (decimal)original.Duration;
                numHeight.Value = (decimal)original.Height;
                numRotX.Value = (decimal)original.RotX;
                numRotY.Value = (decimal)original.RotY;
                numRotZ.Value = (decimal)original.RotZ;
                numRotHorizontal.Value = (decimal)original.RotHorizontal;
                numRotVertical.Value = (decimal)original.RotVertical;
                numStartDistance.Value = (decimal)original.StartDistance;
                numEndDistance.Value = (decimal)original.EndDistance;
                numSpiralAmmount.Value = original.SpiralAmmount;
                cbSpiralRotation.SelectedIndex = original.SpiralClockwise ? 0 : 1;
                numStartHoldTime.Value = (decimal)original.StartHold;
                numEndHoldTime.Value = (decimal)original.EndHold;
                checkEase.Checked = original.Ease;
            }
            catch
            {
                return false;
            }

            return true;
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
                (float) numRotX.Value,
                (float) numRotY.Value,
                (float) numRotZ.Value,
                (float) numRotHorizontal.Value,
                (float) numRotVertical.Value,
                (float) numStartDistance.Value,
                (float) numEndDistance.Value,
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
