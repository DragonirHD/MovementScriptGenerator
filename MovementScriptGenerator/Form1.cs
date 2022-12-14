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
        //Move Controls
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
            OnMoveTypeChanged();
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

        private void OnMoveTypeChanged()
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

        private void ResetContent()
        {
            txtMoveName.Text = string.Empty;
            switch (tlContent.Controls[0])
            {
                case CircleControl _:
                    circleControl = new CircleControl();
                    break;
                case SpiralControl _:
                    spiralControl = new SpiralControl();
                    break;
            }
        }

        private void UpdateChainWindow()
        {
            tvChain.Nodes.Clear();
            foreach (ChainElement el in chain.Elements)
            {
                tvChain.BeginUpdate();
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
            OnMoveTypeChanged();
        }

        private void btnAddMoveToChain_Click(object sender, EventArgs e)
        {
            string moveName = txtMoveName.Text;
            if (!MoveNameValid(moveName))
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
                default:
                    MessageBox.Show("can't add move to chain.");
                    return;
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

        private void btnResetMoveControl_Click(object sender, EventArgs e)
        {
            ResetContent();
            OnMoveTypeChanged();
        }

        private void btnElementApplySettings_Click(object sender, EventArgs e)
        {
            string newMoveName = txtMoveName.Text;
            if (!MoveNameValid(newMoveName))
            {
                newMoveName = null;
            }
            try
            {
                TreeNode selectedNode = tvChain.SelectedNode;
                if(selectedNode == null)
                {
                    MessageBox.Show("Couldn't apply settings. Make sure that you have selected an element of the chain.");
                    return;
                }
                ChainElement selectedElement = chain.Elements[selectedNode.Index];

                switch (cbType.SelectedIndex)
                {
                    case 0:
                        if(selectedElement is Circle)
                        {
                            Circle circle = circleControl.CreateMove(newMoveName);
                            chain.Elements[selectedNode.Index] = circle;
                            selectedElement = circle;
                        }
                        else
                        {
                            MessageBox.Show("Can't apply these settings to the currently selected chain element because the element is not a circle move.");
                            return;
                        }
                        break;
                    case 1:
                        if(selectedElement is Spiral)
                        {
                            Spiral spiral = spiralControl.CreateMove(newMoveName);
                            selectedElement = spiral;
                        }
                        else
                        {
                            MessageBox.Show("Can't apply these settings to the currently selected chain element because the element is not a spiral move.");
                            return;
                        }
                        break;

                    default:
                        MessageBox.Show("Can't apply these settings to the currently selected chain element.");
                        return;
                }

                UpdateChainWindow();
            }
            catch
            {
                MessageBox.Show("Couldn't apply settings. Make sure that you have selected an element of the chain that is the same type of element as your settings.");
            }
        }

        private bool MoveNameValid(string moveName)
        {
            if (moveName.Replace(" ", String.Empty) == "")
            {
                return false;
            }

            return true;
        }

        private void btnElementEditSettings_Click(object sender, EventArgs e)
        {
            if(tvChain.SelectedNode == null)
            {
                MessageBox.Show("No element selected to edit.\nPlease select an element from the chain.");
                return;
            }
            ChainElement selectedElementInChain = chain.Elements[tvChain.SelectedNode.Index];
            bool populatingOfFieldsSuccessful = true;
            switch (selectedElementInChain)
            {
                case Circle circleElement:
                    populatingOfFieldsSuccessful = circleControl.Populate(circleElement);
                    break;
                case Spiral spiralElement:
                    populatingOfFieldsSuccessful = spiralControl.Populate(spiralElement);
                    break;
                default:
                    MessageBox.Show("Can't get the settings of the selected element.");
                    return;
            }
            if (!populatingOfFieldsSuccessful)
            {
                MessageBox.Show("Couldn't edit the selected element.");
            }
            else
            {
                txtMoveName.Text = selectedElementInChain.Name;
            }
        }

        private void tvChain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ChainElement selectedElementInChain = chain.Elements[tvChain.SelectedNode.Index];

            if (typeof(Move).IsInstanceOfType(selectedElementInChain))
            {
                EnableElementOptionsMoveType();
                return;
            }

            DisableElementOptionsAll();
        }

        private void EnableElementOptionsMoveType()
        {
            btnElementMoveUp.Enabled = true;
            btnElementMoveDown.Enabled = true;
            btnElementEditSettings.Enabled = true;
            btnElementApplySettings.Enabled = true;
            btnElementDuplicate.Enabled = true;
            btnElementDelete.Enabled = true;
        }

        private void DisableElementOptionsAll()
        {
            btnElementMoveUp.Enabled = false;
            btnElementMoveDown.Enabled = false;
            btnElementEditSettings.Enabled = false;
            btnElementApplySettings.Enabled = false;
            btnElementDuplicate.Enabled = false;
            btnElementDelete.Enabled = false;
        }

        private void btnElementMoveUp_Click(object sender, EventArgs e)
        {
            if(tvChain.SelectedNode.Index != 0)
            {
                TreeNode selectedTreeElement = tvChain.SelectedNode;
                ChainElement selectedChainElement = chain.Elements[selectedTreeElement.Index];

                chain.Elements.Remove(selectedChainElement);
                chain.Elements.Insert(selectedTreeElement.Index - 1, selectedChainElement);

                tvChain.BeginUpdate();
                tvChain.Nodes.Remove(selectedTreeElement);
                tvChain.Nodes.Insert(selectedTreeElement.Index - 1, selectedTreeElement);
                tvChain.SelectedNode = selectedTreeElement;
                tvChain.EndUpdate();
            }
        }

        private void btnElementMoveDown_Click(object sender, EventArgs e)
        {
            if (tvChain.SelectedNode.Index != tvChain.Nodes.Count -1)
            {
                TreeNode selectedTreeElement = tvChain.SelectedNode;
                ChainElement selectedChainElement = chain.Elements[selectedTreeElement.Index];

                chain.Elements.Remove(selectedChainElement);
                chain.Elements.Insert(selectedTreeElement.Index + 1, selectedChainElement);

                tvChain.BeginUpdate();
                tvChain.Nodes.Remove(selectedTreeElement);
                tvChain.Nodes.Insert(selectedTreeElement.Index + 1, selectedTreeElement);
                tvChain.SelectedNode = selectedTreeElement;
                tvChain.EndUpdate();
            }
        }
    }
}
