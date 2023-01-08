using System.Collections.Generic;
using System.Windows.Forms;

namespace MovementScriptGenerator
{
    public partial class CircleControl : UserControl
    {

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

        private void CircleControl_Load(object sender, System.EventArgs e)
        {
            ScrollEventDisable scrollEventDisable = new ScrollEventDisable();
            scrollEventDisable.DisableScrollForChainElementControls(sender, e, Controls[0]);
        }

        private void initializeComboBoxes()
        {
            cbRotation.DataSource = rotationTypes;
            cbRotation.SelectedIndex = 0;
        }

        public bool Populate(Circle original)
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
                numDistance.Value = (decimal)original.Distance;
                numSector.Value = (decimal)original.SectorDegrees;
                numIterations.Value = original.Iterations;
                cbRotation.SelectedIndex = original.RotateClockwise ? 0 : 1;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public Circle CreateMove(string moveName)
        {
            Circle circle = new Circle(
                moveName,
                (int)numFOV.Value,
                (float)numDuration.Value,
                (float)numHeight.Value,
                (float)numRotX.Value,
                (float)numRotY.Value,
                (float)numRotZ.Value,
                (float)numRotHorizontal.Value,
                (float)numRotVertical.Value,
                (float)numDistance.Value,
                (float)numSector.Value,
                (int)numIterations.Value,
                cbRotation.SelectedIndex == 0
                );

            return circle;
        }
    }
}
