using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MovementScriptGenerator.Modules;
using Newtonsoft.Json;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace MovementScriptGenerator
{
    public partial class Main : Form
    {
        //Move Controls
        CircleControl circleControl = new CircleControl();
        SpiralControl spiralControl = new SpiralControl();

        private static readonly char[] illegalCharsForExplorer = "/<>:/\\\"|?*".ToCharArray();

        private static readonly DirectoryInfo iconsDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.GetDirectories().Where(directory => directory.Name == "Icons").FirstOrDefault();
        private static readonly string iconsDataType = ".png";

        Chain chain = new Chain()
        {
            Elements = new List<ChainElement>()
        };

        List<string> moveDescriptions = new List<string>()
            {
                "The camera will move in a circle around the player.",
                "The camera will move from the starting distance to the end distance while spinning around its axis, creating a spiralling shot.",
                "The camera will move from the given direction towards the player. Then at a surtain point, it will do a 180 degree turn, making the move into something that resembles a J.\nCurrently not implemented!",
                "Groups multiple moves together.\nCurrently not implemented!"
            };

        public Main()
        {
            InitializeComponent();
            InitializeComboBoxes();
            InitializeChainWindow();
            UpdateDescription();
            OnMoveTypeChanged();
            UpdateChainWindow();
        }

        private void InitializeComboBoxes()
        {
            cbType.DataSource = Enum.GetNames(typeof(ChainElementsEnum));
            cbType.SelectedIndex = 0;
        }

        private void InitializeChainWindow()
        {
            ImageList chainElementIcons = new ImageList();
            chainElementIcons.ImageSize = new System.Drawing.Size(32, 32);
            FileInfo[] archives = iconsDirectory.GetFiles($"*{iconsDataType}");
            foreach(FileInfo iconInfo in archives)
            {
                chainElementIcons.Images.Add(System.Drawing.Image.FromFile(iconInfo.FullName));
            }
            tvChain.ImageList = chainElementIcons;
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
            if(tlContent.Controls.Count == 0)
            {
                return;
            }
            switch (tlContent.Controls[0])
            {
                case CircleControl _:
                    circleControl = new CircleControl();
                    break;
                case SpiralControl _:
                    spiralControl = new SpiralControl();
                    break;
                default:
                    break;
            }
        }

        private void UpdateChainWindow()
        {
            tvChain.BeginUpdate();
            tvChain.Nodes.Clear();
            foreach (ChainElement el in chain.Elements)
            {
                tvChain.Nodes.Add(string.Empty, el.Name, el.IconIndex, el.IconIndex);
            }
            if (tvChain.Nodes.Count > 0)
            {
                tvChain.SelectedNode = tvChain.Nodes[tvChain.Nodes.Count - 1];
            }
            if (tvChain.SelectedNode == null)
            {
                DisableElementOptionsAll();
            }
            tvChain.EndUpdate();
        }

        private void UpdateChainWindow(int indexOfNodeToBeSelected)
        {
            //TODO Dont scroll to top on update
            tvChain.BeginUpdate();
            tvChain.Nodes.Clear();
            foreach (ChainElement el in chain.Elements)
            {
                tvChain.Nodes.Add(string.Empty, el.Name, el.IconIndex, el.IconIndex);
            }
            if(indexOfNodeToBeSelected < tvChain.Nodes.Count)
            {
                tvChain.SelectedNode = tvChain.Nodes[indexOfNodeToBeSelected];
            }
            else
            {
                if(tvChain.Nodes.Count > 0)
                {
                    tvChain.SelectedNode = tvChain.Nodes[tvChain.Nodes.Count - 1];
                }
            }
            if(tvChain.SelectedNode == null)
            {
                DisableElementOptionsAll();
            }
            tvChain.EndUpdate();
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
                case (int)ChainElementsEnum.Circle:
                    Circle circle = circleControl.CreateMove(moveName);
                    chain.Elements.Add(circle);
                    break;
                case (int)ChainElementsEnum.Spiral:
                    Spiral spiral = spiralControl.CreateMove(moveName);
                    chain.Elements.Add(spiral);
                    break;
                default:
                    MessageBox.Show("can't add move to chain.");
                    return;
            }

            UpdateChainWindow();
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            string filePath = $@"{txtPath.Text}\{txtFileName.Text}.Json";

            if (txtFileName.Text.Replace(" ", string.Empty) == "")
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
                    case (int)ChainElementsEnum.Circle:
                        if(selectedElement is Circle)
                        {
                            Circle circle = circleControl.CreateMove(newMoveName);
                            chain.Elements[selectedNode.Index] = circle;
                        }
                        else
                        {
                            MessageBox.Show("Can't apply these settings to the currently selected chain element because the element is not a circle move.");
                            return;
                        }
                        break;
                    case (int)ChainElementsEnum.Spiral:
                        if(selectedElement is Spiral)
                        {
                            Spiral spiral = spiralControl.CreateMove(newMoveName);
                            chain.Elements[selectedNode.Index] = spiral;
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

                UpdateChainWindow(selectedNode.Index);
            }
            catch
            {
                MessageBox.Show("Couldn't apply settings. Make sure that you have selected an element of the chain that is the same type of element as your settings.");
            }
        }

        private bool MoveNameValid(string moveName)
        {
            if (moveName.Replace(" ", string.Empty) == "")
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
            bool populatingOfFieldsSuccessful;
            switch (selectedElementInChain)
            {
                case Circle circleElement:
                    populatingOfFieldsSuccessful = circleControl.Populate(circleElement);
                    cbType.SelectedIndex = (int)ChainElementsEnum.Circle;
                    break;
                case Spiral spiralElement:
                    populatingOfFieldsSuccessful = spiralControl.Populate(spiralElement);
                    cbType.SelectedIndex = (int)ChainElementsEnum.Spiral;
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
            btnElementGetSettings.Enabled = true;
            btnElementApplySettings.Enabled = true;
            btnElementDuplicate.Enabled = true;
            btnElementDelete.Enabled = true;
            btnInsert.Enabled = true;
        }

        private void DisableElementOptionsAll()
        {
            btnElementMoveUp.Enabled = false;
            btnElementMoveDown.Enabled = false;
            btnElementGetSettings.Enabled = false;
            btnElementApplySettings.Enabled = false;
            btnElementDuplicate.Enabled = false;
            btnElementDelete.Enabled = false;
            btnInsert.Enabled = false;
        }

        private void btnElementMoveUp_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }
            if (selectedNode.Index != 0)
            {
                ChainElement selectedChainElement = chain.Elements[selectedNode.Index];

                chain.Elements.Remove(selectedChainElement);
                chain.Elements.Insert(selectedNode.Index - 1, selectedChainElement);

                UpdateChainWindow(selectedNode.Index - 1);
            }
        }

        private void btnElementMoveDown_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }
            if (selectedNode.Index != tvChain.Nodes.Count -1)
            {
                ChainElement selectedChainElement = chain.Elements[selectedNode.Index];

                chain.Elements.Remove(selectedChainElement);
                chain.Elements.Insert(selectedNode.Index + 1, selectedChainElement);

                UpdateChainWindow(selectedNode.Index + 1);
            }
        }

        private void btnElementDuplicate_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }
            ChainElement selectedChainElement = chain.Elements[selectedNode.Index];
            switch (selectedChainElement)
            {
                case Circle circleElement:
                    selectedChainElement = circleElement.Clone<Circle>();
                    break;
                case Spiral spiralElement:
                    selectedChainElement = spiralElement.Clone<Spiral>();
                    break;
                default:
                    MessageBox.Show("Can't duplicate the selected element.");
                    return;
            }

            if (selectedNode.Index == tvChain.Nodes.Count - 1)
            {
                chain.Elements.Add(selectedChainElement);
            }
            else
            {
                chain.Elements.Insert(selectedNode.Index + 1, selectedChainElement);
            }

            UpdateChainWindow(selectedNode.Index);
        }

        private void btnElementDelete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }
            chain.Elements.RemoveAt(selectedNode.Index);

            if(selectedNode.Index == 0)
            {
                UpdateChainWindow();
            }
            else
            {
                UpdateChainWindow(selectedNode.Index -1);
            }
        }

        private void btnEditPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = "C:\\Users";
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txtPath.Text = dialog.FileName;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            int insertIndex = selectedNode.Index + 1;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }

            string moveName = txtMoveName.Text;
            if (!MoveNameValid(moveName))
            {
                moveName = null;
            }

            switch (cbType.SelectedIndex)
            {
                case (int)ChainElementsEnum.Circle:
                    Circle circle = circleControl.CreateMove(moveName);
                    chain.Elements.Insert(insertIndex, circle);
                    break;
                case (int)ChainElementsEnum.Spiral:
                    Spiral spiral = spiralControl.CreateMove(moveName);
                    chain.Elements.Insert(insertIndex, spiral);
                    break;
                default:
                    MessageBox.Show("can't add move to chain.");
                    return;
            }

            UpdateChainWindow(insertIndex);
        }
    }
}
