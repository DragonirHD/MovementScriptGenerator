using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MovementScriptGenerator.Modules;
using Newtonsoft.Json;

namespace MovementScriptGenerator
{
    public partial class Main : Form
    {
        CircleControl circleControl = new CircleControl();
        SpiralControl spiralControl = new SpiralControl();

        private static readonly char[] illegalCharsForExplorer = "/<>:/\\\"|?*".ToCharArray();

        Chain chain = new Chain()
        {
            Elements = new List<ChainElement>()
        };

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
            InitializeComboBoxes();
            UpdateDescription();
            UpdateContent();
            UpdateChainWindow();
        }

        private void InitializeComboBoxes()
        {
            cbType.DataSource = moveTypes;
            cbType.SelectedIndex = 0;
        }

        private void UpdateDescription()
        {
            lblMoveDescription.Text = moveDescriptions[cbType.SelectedIndex];
        }

        private void UpdateContent()
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

        private void UpdateChainWindow()
        {
            foreach(ChainElement el in chain.Elements)
            {
                tvChain.BeginUpdate();
                tvChain.Nodes.Clear();
                tvChain.Nodes.Add(el.Name);
                tvChain.EndUpdate();
            }
        }

        private bool GenerateMovementScriptFile(MovementScript script, string filePath)
        {
            if (File.Exists(filePath))
            {
                if(MessageBox.Show("A file with the given name already exists.\nWould you like to overwrite that file?", "Overwrite existing File", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return false;
                }
            }

            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;

                    serializer.Serialize(file, script);
                }
                return true;
            }
            catch
            {
                MessageBox.Show($"Something went wrong while generating the file.\nPlease make sure that the file name and file path are viable and don't contain any not allowed characters.");
                return false;
            }

        }

        private bool AddToMovementScriptFile(MovementScript script, string filePath)
        {
            JsonSerializer serializer = new JsonSerializer();

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File doesn't exist!");
                return false;
            }

            string previousFileContent = File.ReadAllText(filePath);

            try
            {
                MovementScript previousMovementScript = JsonConvert.DeserializeObject<MovementScript>(previousFileContent);

                script.Frames.InsertRange(0, previousMovementScript.Frames);

                using (StreamWriter file = File.CreateText(filePath))
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

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription();
            UpdateContent();
        }

        private void btnAddMoveToChain_Click(object sender, EventArgs e)
        {
            string moveName = txtMoveName.Text;
            if (moveName.Replace(" ", String.Empty) == "")
            {
                moveName = null;
            }
            switch (cbType.SelectedIndex)
            {
                case 0:
                    Circle circle = circleControl.CreateMove(moveName);
                    chain.Elements.Add(circle);
                    break;
                case 1:
                    Spiral spiral = spiralControl.CreateMove(moveName);
                    chain.Elements.Add(spiral);
                    break;
            }

            tvChain.Nodes.Add(chain.Elements.Last().Name);
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            string filePath = $@"{txtPath.Text}{txtFileName.Text}.Json";

            if (txtFileName.Text.Replace(" ", String.Empty) == "")
            {
                MessageBox.Show("Filename is missing!");
                txtFileName.Focus();
                return;
            }

            if (txtFileName.Text.IndexOfAny(illegalCharsForExplorer) != -1)
            {
                MessageBox.Show($"Couldn't generate the file because there are not allowed special characters in the filename.\nPlease make sure to not use any of these characters:\n{new string(illegalCharsForExplorer)}");
                return;
            }

            if (filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                MessageBox.Show($"Couldn't generate the file because the file path is invalid.\nPlease check that the file path is correct and pointing to the right folder.");
                return;
            }

            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("Couldn't find a directory at the given path.\nPlease make sure that the path points to an existsing directory on your device.");
                return;
            }

            if(chain.Elements.Count <= 0)
            {
                MessageBox.Show("Can't create a movement script without any moves.\nPlease add moves to the chain before trying to generate a movement script.");
                return;
            }

            List<Frame> scriptFrames = new List<Frame>();

            foreach (ChainElement chainEl in chain.Elements)
            {
                if (chainEl is Move moveEl)
                {
                    List<Frame> moveFrames = moveEl.GenerateFrames();
                    scriptFrames.AddRange(moveFrames);
                }
            }

            MovementScript movementScript = new MovementScript()
            {
                Frames = scriptFrames,
                SyncToSong = checkSyncToSong.Checked,
                Loop = checkLoop.Checked
            };


            if (checkAddToScript.Checked)
            {
                if (AddToMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Chain added to Movement Script");
                };
            }
            else
            {
                if (GenerateMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Movement Script generated");
                };
            }
        }
    }
}
