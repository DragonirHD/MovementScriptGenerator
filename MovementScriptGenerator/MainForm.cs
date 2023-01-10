using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MovementScriptGenerator.Modules;
using MovementScriptGenerator.Modules.OtherChainElements;
using Newtonsoft.Json;
using Microsoft.WindowsAPICodePack.Dialogs;
using MovementScriptGenerator.Properties;


namespace MovementScriptGenerator
{
    public partial class Main : Form
    {
        //Move controls
        CircleControl circleControl = new CircleControl();
        SpiralControl spiralControl = new SpiralControl();

        //Other chain elements controls
        RepeatControl repeatControl = new RepeatControl();

        //Info for file generation
        private string savedChainFullName = Settings.Default.ChainFullName;
        private string savedChainDirectoryPath = string.IsNullOrEmpty(Settings.Default.ChainFullName) ? string.Empty : Path.GetDirectoryName(Settings.Default.ChainFullName);
        private string generateScriptPath = Settings.Default.GenerateScriptPath;
        private static readonly char[] illegalCharsForExplorer = "/<>:/\\\"|?*".ToCharArray();
        private static readonly string defaultInitialDirectory = "C:\\Users";

        //Info for Icons
        //Icon-Folder-Location changes in release version. That's why we check if we are currently in debug or release mode and change the path accordingly
#if DEBUG
        private static readonly DirectoryInfo iconsDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.GetDirectories().Where(directory => directory.Name == "Icons").FirstOrDefault();
#else
        private static readonly DirectoryInfo iconsDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).GetDirectories().Where(directory => directory.Name == "Icons").FirstOrDefault();
#endif
        private static readonly string iconsDataType = ".png";

        //Other Info
        private static readonly int maxStackDepth = 64;

        Chain chain = new Chain()
        {
            Elements = new List<ChainElement>()
        };

        List<string> elementDescriptions = new List<string>()
            {
                "The camera will move in a circle around the player.",
                "The camera will move from the starting distance to the end distance while spinning around its axis, creating a spiralling shot.",
                "The camera will move from the given direction towards the player. Then at a surtain point, it will do a 180 degree turn, making the move into something that resembles a J.\nCurrently not implemented!",
                "Repeats the elements that are in the given range. The start element and the end element will also be repeated."
            };

        public Main()
        {
            //TODO Create own form/implementation of MessageBox so that it can always be displayed in the middle of the parent window
            //TODO Find better name for "other Elements"
            //TODO Find name for Elements that change the behaviour of an existing move: modifier / modifying elements?
            InitializeComponent();
            InitializeComponentView();
            PopulateComponentsWithSavedSettings();
            InitializeComboBoxes();
            InitializeChainWindow();
            UpdateDescription();
            OnElementTypeChanged();
            UpdateChainWindow();
        }

        private void InitializeComponentView()
        {
            WindowState = (FormWindowState)Settings.Default.WindowState;
            if(Settings.Default.WindowLocation != new System.Drawing.Point())
            {
                StartPosition = FormStartPosition.Manual;
                Location = Settings.Default.WindowLocation;
            }
            Size = Settings.Default.WindowSize;
        }

        private void PopulateComponentsWithSavedSettings()
        {
            if(LoadLastChain())
            {
                InitializeTextBoxes();
            }
            else
            {
                if (savedChainFullName != string.Empty)
                {
                    MessageBox.Show("Couldn't load the last edited chain. Please open it yourself via the file tab.");
                }
            }
        }

        private bool LoadLastChain()
        {
            Chain loadedChain = TryLoadChainFromFile(savedChainFullName);
            if(loadedChain != null)
            {
                chain = loadedChain;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns null if there can't be a chain generated with the given fullName
        /// </summary>
        private Chain TryLoadChainFromFile(string fullName)
        {
            Chain loadedChain = null;
            if (File.Exists(fullName))
            {
                using (StreamReader file = File.OpenText(fullName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.TypeNameHandling = TypeNameHandling.All;
                    try
                    {
                        loadedChain = (Chain)serializer.Deserialize(file, typeof(Chain));
                    }
                    catch 
                    {
                        return null;
                    }
                    //Loaded file can't be a chain without fullName property
                    if(loadedChain.FullName == null)
                    {
                        return null;
                    }
                }
            }

            return loadedChain;
        }

        private void InitializeTextBoxes()
        {
            txtChainName.Text = chain.Name;
        }

        private void InitializeComboBoxes()
        {
            cbElementType.DataSource = Enum.GetNames(typeof(ChainElementsEnum));
            cbElementType.SelectedIndex = 0;
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
            lblElementDescription.Text = elementDescriptions[cbElementType.SelectedIndex];
        }

        private void OnElementTypeChanged()
        {
            tlpContent.Controls.Clear();
            switch (cbElementType.SelectedIndex)
            {
                case 0:
                    tlpContent.Controls.Add(circleControl);
                    break;
                case 1:
                    tlpContent.Controls.Add(spiralControl);
                    break;
                case 3:
                    tlpContent.Controls.Add(repeatControl);
                    break;
            }
        }

        private void ResetDisplayedElementSettings()
        {
            txtElementName.Text = string.Empty;
            if(tlpContent.Controls.Count == 0)
            {
                return;
            }
            switch (tlpContent.Controls[0])
            {
                case CircleControl _:
                    circleControl = new CircleControl();
                    break;
                case SpiralControl _:
                    spiralControl = new SpiralControl();
                    break;
                case RepeatControl _:
                    repeatControl = new RepeatControl();
                    break;
                default:
                    break;
            }
        }

        private void UpdateChainWindow()
        {
            tvChain.BeginUpdate();
            tvChain.Nodes.Clear();
            for (int i = 0; i < chain.Elements.Count; i++)
            {
                ChainElement currentElement = chain.Elements[i];
                tvChain.Nodes.Add(string.Empty, $"{i + 1}. {currentElement.Name}", currentElement.IconIndex, currentElement.IconIndex);
            }
            if (tvChain.Nodes.Count > 0)
            {
                tvChain.SelectedNode = tvChain.Nodes[tvChain.Nodes.Count - 1];
            }

            tvChain.EndUpdate();

            if (tvChain.SelectedNode == null)
            {
                DisableElementOptionsAll();
            }
            else
            {
                //Can't be done while in update block
                tvChain.SelectedNode.EnsureVisible();
            }
        }

        private void UpdateChainWindow(int indexOfNodeToBeSelected)
        {
            tvChain.BeginUpdate();
            tvChain.Nodes.Clear();
            for(int i = 0; i < chain.Elements.Count; i++)
            {
                ChainElement currentElement = chain.Elements[i];
                tvChain.Nodes.Add(string.Empty, $"{i + 1}. {currentElement.Name}", currentElement.IconIndex, currentElement.IconIndex);
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
            tvChain.EndUpdate();
            if (tvChain.SelectedNode == null)
            {
                DisableElementOptionsAll();
            }
            else
            {
                //Can't be done while in update block
                tvChain.SelectedNode.EnsureVisible();
            }
        }

        private bool GenerateMovementScriptFile(MovementScript script, string filePath)
        {
            if (File.Exists(filePath))
            {
                if(MessageBox.Show("A script with the given name already exists.\nWould you like to overwrite that file?", "Overwrite existing File", MessageBoxButtons.YesNo) == DialogResult.No)
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
                MessageBox.Show($"Something went wrong while generating the file.\nPlease make sure that the script name and script path are viable and don't contain any not allowed characters.");
                return false;
            }

        }

        private void cbElementType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription();
            OnElementTypeChanged();
        }

        private void btnAddElementToChain_Click(object sender, EventArgs e)
        {
            string ElementName = txtElementName.Text;
            if (!ElementNameValid(ElementName))
            {
                ElementName = null;
            }

            switch (cbElementType.SelectedIndex)
            {
                case (int)ChainElementsEnum.Circle:
                    Circle circle = circleControl.CreateMove(ElementName);
                    chain.Elements.Add(circle);
                    break;
                case (int)ChainElementsEnum.Spiral:
                    Spiral spiral = spiralControl.CreateMove(ElementName);
                    chain.Elements.Add(spiral);
                    break;
                case (int)ChainElementsEnum.Repeat:
                    if (repeatControl.ValidateInputs())
                    {
                        Repeat repeat = repeatControl.CreateElement(ElementName);
                        chain.Elements.Add(repeat);
                    }
                    else
                    {
                        MessageBox.Show("Start element can't be further in the chain than end element.");
                    }
                    break;
                default:
                    MessageBox.Show("can't add element to chain.");
                    return;
            }

            UpdateChainWindow();
        }

        private void btnGenerateScript_Click(object sender, EventArgs e)
        {
            if (txtScriptName.Text.Replace(" ", string.Empty) == string.Empty)
            {
                MessageBox.Show($"Can't generate a movement script without a script name.\nPlease enter a name for the movement script.");
                txtScriptName.Focus();
                return;
            }

            string scriptName = txtScriptName.Text;

            if (scriptName.IndexOfAny(illegalCharsForExplorer) != -1)
            {
                MessageBox.Show($"Couldn't generate the script because there are not allowed special characters in the script name.\nPlease make sure to not use any of these characters:\n{new string(illegalCharsForExplorer)}");
                txtScriptName.Focus();
                return;
            }

            if (!Directory.Exists(generateScriptPath))
            {
                MessageBox.Show("Couldn't find a directory at the given path.\nPlease make sure that the script path points to an existsing directory on your device.");
                btnEditScriptPath.Focus();
                return;
            }

            if(chain.Elements.Count <= 0)
            {
                MessageBox.Show("Can't create a movement script without any elements.\nPlease add elements to the chain before trying to generate a movement script.");
                cbElementType.Focus();
                return;
            }

            MovementScript movementScript = new MovementScript()
            {
                Frames = AddFramesToScript(chain),
                SyncToSong = checkSyncToSong.Checked,
                Loop = checkLoop.Checked
            };

            if(movementScript.Frames == null)
            {
                MessageBox.Show("Can't create movement script.\nPossible reasons:\n- a repeat element creates an endless loop\n- a repeat element points to elements that don't exist");
                return;
            }

            string filePath = $@"{generateScriptPath}\{scriptName}.Json";

            if (filePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                MessageBox.Show($"Couldn't generate the script because the scrpit path is invalid.\nPlease check that the script path is correct and pointing to the right directory/folder.");
                btnEditScriptPath.Focus();
                return;
            }

            if (checkAddToScript.Checked)
            {
                if (AddToMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Chain added to movement script");
                };
            }
            else
            {
                if (GenerateMovementScriptFile(movementScript, filePath))
                {
                    MessageBox.Show("Movement script generated");
                };
            }
        }

        /// <summary>
        /// Tries to create frames from the given chain elements.
        /// </summary>
        /// <param name="chainOfElements"></param>
        /// <returns>A List of Frames. If the script fails, it will return null</returns>
        public List<Frame> AddFramesToScript(Chain chainOfElements)
        {
            //TODO perfect place to implement other Elements that can be applied to moves, for example changing fov. Get the generated frames of the corresponding move, then apply the logic of the new other element.
            List<Frame> frames = new List<Frame>();
            foreach(ChainElement chainEl in chainOfElements.Elements)
            {
                switch (chainEl)
                {
                    case Move moveEl:
                        List<Frame> moveFrames = moveEl.GenerateFrames();
                        frames.AddRange(moveFrames);
                        break;
                    case Repeat repeatEl:
                        Chain repeatedPart = new Chain() {Elements = new List<ChainElement>()};
                        int ammountOfElementsToRepeat = repeatEl.EndElement + 1 - repeatEl.StartElement;
                        if(repeatEl.StartElement > chain.Elements.Count || repeatEl.EndElement > chain.Elements.Count)
                        {
                            return null;
                        }
                        List<ChainElement> toRepeat = chain.Elements.GetRange(repeatEl.StartElement - 1, ammountOfElementsToRepeat);
                        repeatedPart.Elements.AddRange(toRepeat);
                        List<Frame> framesOfRepeatedPart = AddFramesToScript(repeatedPart, 1);
                        if (framesOfRepeatedPart != null)
                        {
                            frames.AddRange(framesOfRepeatedPart);
                        }
                        else
                        {
                            return null;
                        }
                        break;
                    default:
                        break;
                }
            }

            return frames;
        }

        /// <summary>
        /// Only meant to be used in recursive part of the original function.
        /// The <paramref name="stackDepth"/> is used to check how far down in the recursion the program is,
        /// so that endless loops can be handled without throwing a stack overflow.
        /// </summary>
        /// <param name="chainOfElements"></param>
        /// <param name="stackDepth"></param>
        /// <returns>A List of Frames. If the script fails, it will return null</returns>
        public List<Frame> AddFramesToScript(Chain chainOfElements, int stackDepth)
        {
            List<Frame> frames = new List<Frame>();
            foreach (ChainElement chainEl in chainOfElements.Elements)
            {
                switch (chainEl)
                {
                    case Move moveEl:
                        List<Frame> moveFrames = moveEl.GenerateFrames();
                        frames.AddRange(moveFrames);
                        break;
                    case Repeat repeatEl:
                        Chain repeatedPart = new Chain() { Elements = new List<ChainElement>() };
                        int ammountOfElementsToRepeat = repeatEl.EndElement + 1 - repeatEl.StartElement;
                        List<ChainElement> toRepeat = chain.Elements.GetRange(repeatEl.StartElement - 1, ammountOfElementsToRepeat);
                        repeatedPart.Elements.AddRange(toRepeat);

                        if(stackDepth <= maxStackDepth)
                        {
                            List<Frame> framesOfRepeatedPart = AddFramesToScript(repeatedPart, stackDepth + 1);
                            if(framesOfRepeatedPart != null)
                            {
                                frames.AddRange(framesOfRepeatedPart);
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                        break;
                    default:
                        break;
                }
            }

            return frames;
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
                MessageBox.Show("Chain could not be added.\nMake sure that the file, where the chain will be added to, is a correct MovementScript file.");
                return false;
            };
        }

        private void btnResetMoveControl_Click(object sender, EventArgs e)
        {
            ResetDisplayedElementSettings();
            OnElementTypeChanged();
        }

        private void btnElementApplySettings_Click(object sender, EventArgs e)
        {
            string newElementName = txtElementName.Text;
            if (!ElementNameValid(newElementName))
            {
                newElementName = null;
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

                switch (cbElementType.SelectedIndex)
                {
                    case (int)ChainElementsEnum.Circle:
                        if(selectedElement is Circle)
                        {
                            Circle circle = circleControl.CreateMove(newElementName);
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
                            Spiral spiral = spiralControl.CreateMove(newElementName);
                            chain.Elements[selectedNode.Index] = spiral;
                        }
                        else
                        {
                            MessageBox.Show("Can't apply these settings to the currently selected chain element because the element is not a spiral move.");
                            return;
                        }
                        break;
                    case (int)ChainElementsEnum.Repeat:
                        if(selectedElement is Repeat)
                        {
                            if (repeatControl.ValidateInputs())
                            {
                                Repeat repeat = repeatControl.CreateElement(newElementName);
                                chain.Elements[selectedNode.Index] = repeat;
                            }
                            else
                            {
                                MessageBox.Show("Start element can't be further in the chain than end element.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can't apply these settings to the currently selected chain element because the element is not a repeat element.");
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

        private bool ElementNameValid(string elementName)
        {
            if (elementName.Replace(" ", string.Empty) == "")
            {
                return false;
            }

            return true;
        }

        private void btnElementGetSettings_Click(object sender, EventArgs e)
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
                    cbElementType.SelectedIndex = (int)ChainElementsEnum.Circle;
                    break;
                case Spiral spiralElement:
                    populatingOfFieldsSuccessful = spiralControl.Populate(spiralElement);
                    cbElementType.SelectedIndex = (int)ChainElementsEnum.Spiral;
                    break;
                case Repeat repeatElement:
                    populatingOfFieldsSuccessful = repeatControl.Populate(repeatElement);
                    cbElementType.SelectedIndex = (int)ChainElementsEnum.Repeat;
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
                txtElementName.Text = selectedElementInChain.Name;
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
            else
            {
                EnableElementOptionsOtherType();
            }
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

        private void EnableElementOptionsOtherType()
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
                case Repeat repeatElement:
                    selectedChainElement = repeatElement.Clone<Repeat>();
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = tvChain.SelectedNode;
            int insertIndex = selectedNode.Index + 1;
            if (selectedNode == null)
            {
                MessageBox.Show("No element selected.\nPlease select an element from the chain.");
                return;
            }

            string elementName = txtElementName.Text;
            if (!ElementNameValid(elementName))
            {
                elementName = null;
            }

            switch (cbElementType.SelectedIndex)
            {
                case (int)ChainElementsEnum.Circle:
                    Circle circle = circleControl.CreateMove(elementName);
                    chain.Elements.Insert(insertIndex, circle);
                    break;
                case (int)ChainElementsEnum.Spiral:
                    Spiral spiral = spiralControl.CreateMove(elementName);
                    chain.Elements.Insert(insertIndex, spiral);
                    break;
                case (int)ChainElementsEnum.Repeat:
                    Repeat repeat = repeatControl.CreateElement(elementName);
                    chain.Elements.Insert(insertIndex, repeat);
                    break;
                default:
                    MessageBox.Show("can't add element to chain.");
                    return;
            }

            UpdateChainWindow(insertIndex);
        }
        
        private void btnEditScriptPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.InitialDirectory = Directory.Exists(generateScriptPath) ? generateScriptPath: defaultInitialDirectory;
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                generateScriptPath = dialog.FileName;
            }
        }

        private void tvChain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            btnElementGetSettings_Click(sender, e);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckUnsavedChanges())
            {
                DialogResult saveChanges = MessageBox.Show("Would you like to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (saveChanges == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                if(saveChanges == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }

            //Saving general settings
            if(WindowState != FormWindowState.Minimized)
            {
                Settings.Default.WindowState = (int)WindowState;
                Settings.Default.WindowLocation = Location;
            }
            if (WindowState == FormWindowState.Normal)
            {
                Settings.Default.WindowSize = Size;
            }
            else
            {
                Settings.Default.WindowSize = RestoreBounds.Size;
            }
            Settings.Default.GenerateScriptPath = generateScriptPath;

            //Saving settings of current chain
            Settings.Default.ChainFullName = chain.FullName;
            Settings.Default.ChainDirectoryPath = Path.GetDirectoryName(chain.FullName);

            Settings.Default.Save();
        }

        private bool CheckUnsavedChanges()
        {
            //Checks if changes have been made to the chain
            Chain savedChain = TryLoadChainFromFile(chain.FullName);
            Chain currentChain = chain;
            if(currentChain == null)
            {
                return false;
            }

            if(savedChain == null)
            {
                if(currentChain.Elements.Count > 0 )
                {
                    return true;
                }

                if(currentChain.Name != string.Empty && currentChain.Name != null)
                {
                    return true;
                }

                return false;
            }
            //Compares saved and current chains to see if changes have been made since last save
            if (!CompareObject.Compare<Chain>(currentChain, savedChain))
            {
                return true;
            }
            return false;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(chain.FullName != string.Empty && File.Exists(chain.FullName))
            {
                SaveChain(chain.FullName);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommonSaveFileDialog dialog = new CommonSaveFileDialog();
            dialog.AllowPropertyEditing = false;
            dialog.AlwaysAppendDefaultExtension = true;
            dialog.DefaultExtension = "Json";
            if(txtChainName.Text.Replace(" ", string.Empty) == string.Empty)
            {
                txtChainName.Text = "NewChain";
            }
            dialog.DefaultFileName = txtChainName.Text;
            dialog.InitialDirectory = GetInitialDirectoryForChainFiles();
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                chain.FullName = dialog.FileName;
                SaveChain(chain.FullName);
            }
        }

        private bool SaveChain(string fullName)
        {
            try
            {
                using (StreamWriter file = File.CreateText(fullName))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.TypeNameHandling = TypeNameHandling.All;

                    serializer.Serialize(file, chain);
                }
                return true;
            }
            catch
            {
                MessageBox.Show($"Something went wrong while saving the chain.\nPlease make sure that the file path exists and that file path and file name dont contain any not allowed characters.");
                return false;
            }
        }

        private void txtChainName_TextChanged(object sender, EventArgs e)
        {
            if (txtChainName.Text.Replace(" ", string.Empty) != string.Empty)
            {
                chain.Name = txtChainName.Text;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedChanges())
            {
                DialogResult saveChanges = MessageBox.Show("Would you like to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (saveChanges == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                if (saveChanges == DialogResult.Cancel)
                {
                    return;
                }
            }

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = GetInitialDirectoryForChainFiles();
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Chain chainFromOpenedFile = TryLoadChainFromFile(dialog.FileName);
                if(chainFromOpenedFile != null)
                {
                    UseNewChain(chainFromOpenedFile, dialog);
                }
                else
                {
                    MessageBox.Show("Couldn't open the file.\nPlease make sure that the selected file is a saved chain and not a generated movement script file or other file.");
                }                
            }
        }

        private void UseNewChain(Chain newChain, CommonOpenFileDialog dialogOfNewChain)
        {
            chain = newChain;
            chain.FullName = dialogOfNewChain.FileName;
            txtChainName.Text = chain.Name;
            UpdateChainWindow();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedChanges())
            {
                DialogResult saveChanges = MessageBox.Show("Would you like to save your changes?", "Save changes", MessageBoxButtons.YesNoCancel);
                if (saveChanges == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                }
                if (saveChanges == DialogResult.Cancel)
                {
                    return;
                }
            }

            chain = new Chain()
            {
                Elements = new List<ChainElement>()
            };
            txtChainName.Text = chain.Name;
            UpdateChainWindow();
        }

        private string GetInitialDirectoryForChainFiles()
        {
            if (Directory.Exists(Path.GetDirectoryName(chain.FullName)))
            {
                return Path.GetDirectoryName(chain.FullName);
            }

            if (Directory.Exists(savedChainDirectoryPath))
            {
                return savedChainDirectoryPath;
            }

            return defaultInitialDirectory;
        }
    }
}
