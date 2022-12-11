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

        private void initializeComboBoxes()
        {
            cbRotation.DataSource = rotationTypes;
            cbRotation.SelectedIndex = 0;
        }

        public Circle CreateMove(string moveName)
        {
            Circle circle = new Circle(
                moveName,
                (int)numFOV.Value,
                (float)numDuration.Value,
                (float)numHeight.Value,
                (float)numRotX.Value,
                (float)numRotZ.Value,
                (float)numDistance.Value,
                (float)numStartingPoint.Value,
                (float)numSector.Value,
                (int)numIterations.Value,
                cbRotation.SelectedIndex == 0 ? true : false
                );

            return circle;
        }
    }
}
