using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MovementScriptGenerator.Modules;
using Newtonsoft.Json;

namespace MovementScriptGenerator
{
    public partial class Main : Form
    {
        CircleControl circleControl = new CircleControl();
        SpiralControl spiralControl = new SpiralControl();

        List<string> moveTypes = new List<string>()
            {
                "circle",
                "spiral",
                "J-Turn"
            };

        List<string> moveDescriptions = new List<string>()
            {
                "The camera will move in a circle around the player.",
                "The camera will move from the starting distance to the end distance while spinning around its axis, creating a spiralling shot.",
                "The camera will move from the given direction towards the player. Then at a surtain point, it will do a 180 degree turn, making the move into something that resembles a J.\nCurrently not implemented!"
            };

        public Main()
        {
            InitializeComponent();
            initializeComboBoxes();
            updateDescription();
            updateContent();
        }

        private void initializeComboBoxes()
        {
            cbType.DataSource = moveTypes;
            cbType.SelectedIndex = 0;
        }

        private void updateDescription()
        {
            lblMoveDescription.Text = moveDescriptions[cbType.SelectedIndex];
        }

        private void updateContent()
        {
            tlContent.Controls.Clear();
            switch (cbType.SelectedIndex)
            {
                case 0:
                    tlContent.Controls.Add(circleControl);
                    break;
                case 1:
                    tlContent.Controls.Add(spiralControl);
                    break;
            }
        }

        private bool GenerateMovementScriptFile(MovementScript script, string path)
        {
            try
            {
                using (StreamWriter file = File.CreateText(path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;

                    serializer.Serialize(file, script);
                }
                return true;
            }
            catch
            {
                MessageBox.Show($"File could not be generated.\nPlease dont use any special characters in the file name");
                return false;
            }

        }

        private bool AddToMovementScriptFile(MovementScript script, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!File.Exists(path))
            {
                MessageBox.Show("File doesn't exist!");
                return false;
            }

            string previousFileContent = File.ReadAllText(path);

            try
            {
                MovementScript previousMovementScript = JsonConvert.DeserializeObject<MovementScript>(previousFileContent);

                script.frames.InsertRange(0, previousMovementScript.frames);

                using (StreamWriter file = File.CreateText(path))
                {
                    serializer.Formatting = Formatting.Indented;

                    serializer.Serialize(file, script);
                }

                return true;
            }
            catch
            {
                MessageBox.Show("Move could not be added.\nMake sure that the file is a correct MovementScript file.");
                return false;
            };
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string filePath = $@"{txtPath.Text}{txtName.Text}.Json";

            if (txtName.Text.Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Filename is missing!");
                txtName.Focus();
                return;
            }
            MovementScript movementScript = new MovementScript();

            switch (cbType.SelectedIndex)
            {
                case 0:
                    movementScript = circleControl.CreateMovementScript();
                    break;
                case 1:
                    movementScript = spiralControl.CreateMovementScript();
                    break;
            }

            movementScript.syncToSong = checkSyncToSong.Checked;

            if (checkAddToScript.Checked)
            {
                if(AddToMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Move added to MovementScript");
                };
            }
            else
            {
                if(GenerateMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Movement Script generated");
                };
            }
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDescription();
            updateContent();
        }
    }
}
