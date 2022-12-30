
namespace MovementScriptGenerator
{
    partial class Main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tlpContentAndMargin = new System.Windows.Forms.TableLayoutPanel();
            this.tlpElementSettingsAndChainSettings = new System.Windows.Forms.TableLayoutPanel();
            this.tlpChain = new System.Windows.Forms.TableLayoutPanel();
            this.flpScriptOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGenerateScript = new System.Windows.Forms.Button();
            this.btnEditScriptPath = new System.Windows.Forms.Button();
            this.txtScriptName = new System.Windows.Forms.TextBox();
            this.lblScriptName = new System.Windows.Forms.Label();
            this.checkSyncToSong = new System.Windows.Forms.CheckBox();
            this.lblSyncToSong = new System.Windows.Forms.Label();
            this.checkAddToScript = new System.Windows.Forms.CheckBox();
            this.lblAddToScript = new System.Windows.Forms.Label();
            this.checkLoop = new System.Windows.Forms.CheckBox();
            this.lblLoop = new System.Windows.Forms.Label();
            this.lblChainTitle = new System.Windows.Forms.Label();
            this.flpChainSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChainName = new System.Windows.Forms.Label();
            this.txtChainName = new System.Windows.Forms.TextBox();
            this.tlpChainTreeAndElementOptions = new System.Windows.Forms.TableLayoutPanel();
            this.tvChain = new System.Windows.Forms.TreeView();
            this.tlpElementSelectedOptions = new System.Windows.Forms.TableLayoutPanel();
            this.lblElementSelectedOptions = new System.Windows.Forms.Label();
            this.flpElementSelectedOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpElementSelectedOptionMoveUpAndDown = new System.Windows.Forms.TableLayoutPanel();
            this.btnElementMoveDown = new System.Windows.Forms.Button();
            this.btnElementMoveUp = new System.Windows.Forms.Button();
            this.btnElementDuplicate = new System.Windows.Forms.Button();
            this.btnElementGetSettings = new System.Windows.Forms.Button();
            this.btnElementDelete = new System.Windows.Forms.Button();
            this.tlpElementSettings = new System.Windows.Forms.TableLayoutPanel();
            this.flpElementOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddMoveToChain = new System.Windows.Forms.Button();
            this.btnElementApplySettings = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnResetMoveSettings = new System.Windows.Forms.Button();
            this.lblElementTitle = new System.Windows.Forms.Label();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.lblElementDescriptionTitle = new System.Windows.Forms.Label();
            this.lblElementDescription = new System.Windows.Forms.Label();
            this.lblElementSettingsTitle = new System.Windows.Forms.Label();
            this.lblElementDescriptionHint = new System.Windows.Forms.Label();
            this.tlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.flpElementGeneralSettings = new System.Windows.Forms.FlowLayoutPanel();
            this.tlpElementSettingType = new System.Windows.Forms.TableLayoutPanel();
            this.lblType = new System.Windows.Forms.Label();
            this.cbElementType = new System.Windows.Forms.ComboBox();
            this.tlpElementSettingName = new System.Windows.Forms.TableLayoutPanel();
            this.txtElementName = new System.Windows.Forms.TextBox();
            this.lblMoveName = new System.Windows.Forms.Label();
            this.menuStripSettings = new System.Windows.Forms.MenuStrip();
            this.toolStripFileOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tlpMenuAndContent = new System.Windows.Forms.TableLayoutPanel();
            this.tlpContentAndMargin.SuspendLayout();
            this.tlpElementSettingsAndChainSettings.SuspendLayout();
            this.tlpChain.SuspendLayout();
            this.flpScriptOptions.SuspendLayout();
            this.flpChainSettings.SuspendLayout();
            this.tlpChainTreeAndElementOptions.SuspendLayout();
            this.tlpElementSelectedOptions.SuspendLayout();
            this.flpElementSelectedOptions.SuspendLayout();
            this.tlpElementSelectedOptionMoveUpAndDown.SuspendLayout();
            this.tlpElementSettings.SuspendLayout();
            this.flpElementOptions.SuspendLayout();
            this.flpContent.SuspendLayout();
            this.flpElementGeneralSettings.SuspendLayout();
            this.tlpElementSettingType.SuspendLayout();
            this.tlpElementSettingName.SuspendLayout();
            this.menuStripSettings.SuspendLayout();
            this.tlpMenuAndContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContentAndMargin
            // 
            this.tlpContentAndMargin.ColumnCount = 3;
            this.tlpContentAndMargin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContentAndMargin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContentAndMargin.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContentAndMargin.Controls.Add(this.tlpElementSettingsAndChainSettings, 1, 0);
            this.tlpContentAndMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContentAndMargin.Location = new System.Drawing.Point(3, 23);
            this.tlpContentAndMargin.Name = "tlpContentAndMargin";
            this.tlpContentAndMargin.RowCount = 2;
            this.tlpContentAndMargin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tlpContentAndMargin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpContentAndMargin.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContentAndMargin.Size = new System.Drawing.Size(1099, 689);
            this.tlpContentAndMargin.TabIndex = 1;
            // 
            // tlpElementSettingsAndChainSettings
            // 
            this.tlpElementSettingsAndChainSettings.ColumnCount = 2;
            this.tlpElementSettingsAndChainSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 310F));
            this.tlpElementSettingsAndChainSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettingsAndChainSettings.Controls.Add(this.tlpChain, 1, 0);
            this.tlpElementSettingsAndChainSettings.Controls.Add(this.tlpElementSettings, 0, 0);
            this.tlpElementSettingsAndChainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElementSettingsAndChainSettings.Location = new System.Drawing.Point(23, 3);
            this.tlpElementSettingsAndChainSettings.Name = "tlpElementSettingsAndChainSettings";
            this.tlpElementSettingsAndChainSettings.RowCount = 1;
            this.tlpElementSettingsAndChainSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettingsAndChainSettings.Size = new System.Drawing.Size(1053, 648);
            this.tlpElementSettingsAndChainSettings.TabIndex = 1;
            // 
            // tlpChain
            // 
            this.tlpChain.ColumnCount = 1;
            this.tlpChain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChain.Controls.Add(this.flpScriptOptions, 0, 3);
            this.tlpChain.Controls.Add(this.lblChainTitle, 0, 0);
            this.tlpChain.Controls.Add(this.flpChainSettings, 0, 1);
            this.tlpChain.Controls.Add(this.tlpChainTreeAndElementOptions, 0, 2);
            this.tlpChain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChain.Location = new System.Drawing.Point(313, 0);
            this.tlpChain.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.tlpChain.Name = "tlpChain";
            this.tlpChain.RowCount = 4;
            this.tlpChain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpChain.Size = new System.Drawing.Size(740, 648);
            this.tlpChain.TabIndex = 2;
            // 
            // flpScriptOptions
            // 
            this.flpScriptOptions.Controls.Add(this.btnGenerateScript);
            this.flpScriptOptions.Controls.Add(this.btnEditScriptPath);
            this.flpScriptOptions.Controls.Add(this.txtScriptName);
            this.flpScriptOptions.Controls.Add(this.lblScriptName);
            this.flpScriptOptions.Controls.Add(this.checkSyncToSong);
            this.flpScriptOptions.Controls.Add(this.lblSyncToSong);
            this.flpScriptOptions.Controls.Add(this.checkAddToScript);
            this.flpScriptOptions.Controls.Add(this.lblAddToScript);
            this.flpScriptOptions.Controls.Add(this.checkLoop);
            this.flpScriptOptions.Controls.Add(this.lblLoop);
            this.flpScriptOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpScriptOptions.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpScriptOptions.Location = new System.Drawing.Point(0, 617);
            this.flpScriptOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpScriptOptions.MinimumSize = new System.Drawing.Size(0, 30);
            this.flpScriptOptions.Name = "flpScriptOptions";
            this.flpScriptOptions.Size = new System.Drawing.Size(740, 31);
            this.flpScriptOptions.TabIndex = 4;
            // 
            // btnGenerateScript
            // 
            this.btnGenerateScript.AutoSize = true;
            this.btnGenerateScript.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGenerateScript.Location = new System.Drawing.Point(622, 3);
            this.btnGenerateScript.MinimumSize = new System.Drawing.Size(115, 0);
            this.btnGenerateScript.Name = "btnGenerateScript";
            this.btnGenerateScript.Size = new System.Drawing.Size(115, 23);
            this.btnGenerateScript.TabIndex = 10;
            this.btnGenerateScript.Text = "Generate Script";
            this.btnGenerateScript.UseVisualStyleBackColor = true;
            this.btnGenerateScript.Click += new System.EventHandler(this.btnGenerateScript_Click);
            // 
            // btnEditScriptPath
            // 
            this.btnEditScriptPath.AutoSize = true;
            this.btnEditScriptPath.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditScriptPath.Location = new System.Drawing.Point(526, 3);
            this.btnEditScriptPath.Name = "btnEditScriptPath";
            this.btnEditScriptPath.Size = new System.Drawing.Size(90, 23);
            this.btnEditScriptPath.TabIndex = 9;
            this.btnEditScriptPath.Text = "Edit Script Path";
            this.ToolTip.SetToolTip(this.btnEditScriptPath, resources.GetString("btnEditScriptPath.ToolTip"));
            this.btnEditScriptPath.UseVisualStyleBackColor = true;
            this.btnEditScriptPath.Click += new System.EventHandler(this.btnEditScriptPath_Click);
            // 
            // txtScriptName
            // 
            this.txtScriptName.Location = new System.Drawing.Point(371, 3);
            this.txtScriptName.Name = "txtScriptName";
            this.txtScriptName.Size = new System.Drawing.Size(149, 20);
            this.txtScriptName.TabIndex = 8;
            // 
            // lblScriptName
            // 
            this.lblScriptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblScriptName.AutoSize = true;
            this.lblScriptName.Location = new System.Drawing.Point(300, 0);
            this.lblScriptName.Name = "lblScriptName";
            this.lblScriptName.Size = new System.Drawing.Size(65, 29);
            this.lblScriptName.TabIndex = 7;
            this.lblScriptName.Text = "Script Name";
            this.lblScriptName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblScriptName, "defines the name of the movement script file that will be generated / added to.\r\n" +
        "Add this name to the script list in your camera\'s Json file to make the camera u" +
        "se this script.\r\n");
            // 
            // checkSyncToSong
            // 
            this.checkSyncToSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkSyncToSong.AutoSize = true;
            this.checkSyncToSong.Checked = true;
            this.checkSyncToSong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSyncToSong.Location = new System.Drawing.Point(279, 3);
            this.checkSyncToSong.Name = "checkSyncToSong";
            this.checkSyncToSong.Size = new System.Drawing.Size(15, 23);
            this.checkSyncToSong.TabIndex = 6;
            this.checkSyncToSong.UseVisualStyleBackColor = true;
            // 
            // lblSyncToSong
            // 
            this.lblSyncToSong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSyncToSong.AutoSize = true;
            this.lblSyncToSong.Location = new System.Drawing.Point(198, 0);
            this.lblSyncToSong.Name = "lblSyncToSong";
            this.lblSyncToSong.Size = new System.Drawing.Size(75, 29);
            this.lblSyncToSong.TabIndex = 5;
            this.lblSyncToSong.Text = "Sync To Song";
            this.lblSyncToSong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblSyncToSong, resources.GetString("lblSyncToSong.ToolTip"));
            // 
            // checkAddToScript
            // 
            this.checkAddToScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkAddToScript.AutoSize = true;
            this.checkAddToScript.Location = new System.Drawing.Point(177, 3);
            this.checkAddToScript.Name = "checkAddToScript";
            this.checkAddToScript.Size = new System.Drawing.Size(15, 23);
            this.checkAddToScript.TabIndex = 4;
            this.checkAddToScript.UseVisualStyleBackColor = true;
            // 
            // lblAddToScript
            // 
            this.lblAddToScript.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAddToScript.AutoSize = true;
            this.lblAddToScript.Location = new System.Drawing.Point(61, 0);
            this.lblAddToScript.Name = "lblAddToScript";
            this.lblAddToScript.Size = new System.Drawing.Size(110, 29);
            this.lblAddToScript.TabIndex = 3;
            this.lblAddToScript.Text = "Add To existing Script";
            this.lblAddToScript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblAddToScript, resources.GetString("lblAddToScript.ToolTip"));
            // 
            // checkLoop
            // 
            this.checkLoop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkLoop.AutoSize = true;
            this.checkLoop.Checked = true;
            this.checkLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkLoop.Location = new System.Drawing.Point(40, 3);
            this.checkLoop.Name = "checkLoop";
            this.checkLoop.Size = new System.Drawing.Size(15, 23);
            this.checkLoop.TabIndex = 2;
            this.checkLoop.UseVisualStyleBackColor = true;
            // 
            // lblLoop
            // 
            this.lblLoop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLoop.AutoSize = true;
            this.lblLoop.Location = new System.Drawing.Point(3, 0);
            this.lblLoop.Name = "lblLoop";
            this.lblLoop.Size = new System.Drawing.Size(31, 29);
            this.lblLoop.TabIndex = 1;
            this.lblLoop.Text = "Loop";
            this.lblLoop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblLoop, "On -> The movement script will repeat from the start, if the last move is finishe" +
        "d.\r\nOff -> The camera will stay on the end position of the last move.");
            // 
            // lblChainTitle
            // 
            this.lblChainTitle.AutoSize = true;
            this.lblChainTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChainTitle.Location = new System.Drawing.Point(3, 0);
            this.lblChainTitle.Name = "lblChainTitle";
            this.lblChainTitle.Size = new System.Drawing.Size(734, 29);
            this.lblChainTitle.TabIndex = 1;
            this.lblChainTitle.Text = "Chain";
            this.lblChainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpChainSettings
            // 
            this.flpChainSettings.Controls.Add(this.lblChainName);
            this.flpChainSettings.Controls.Add(this.txtChainName);
            this.flpChainSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpChainSettings.Location = new System.Drawing.Point(0, 29);
            this.flpChainSettings.Margin = new System.Windows.Forms.Padding(0);
            this.flpChainSettings.MinimumSize = new System.Drawing.Size(0, 30);
            this.flpChainSettings.Name = "flpChainSettings";
            this.flpChainSettings.Size = new System.Drawing.Size(740, 30);
            this.flpChainSettings.TabIndex = 2;
            // 
            // lblChainName
            // 
            this.lblChainName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblChainName.AutoSize = true;
            this.lblChainName.Location = new System.Drawing.Point(3, 0);
            this.lblChainName.Name = "lblChainName";
            this.lblChainName.Size = new System.Drawing.Size(35, 26);
            this.lblChainName.TabIndex = 1;
            this.lblChainName.Text = "Name";
            this.lblChainName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblChainName, "defines the name of movement script file that will be generated / added to.\r\nAdd " +
        "this name to the script list in your camera script to make the camera use this s" +
        "cript.\r\n");
            // 
            // txtChainName
            // 
            this.txtChainName.Location = new System.Drawing.Point(44, 3);
            this.txtChainName.Name = "txtChainName";
            this.txtChainName.Size = new System.Drawing.Size(149, 20);
            this.txtChainName.TabIndex = 2;
            this.txtChainName.TextChanged += new System.EventHandler(this.txtChainName_TextChanged);
            // 
            // tlpChainTreeAndElementOptions
            // 
            this.tlpChainTreeAndElementOptions.ColumnCount = 2;
            this.tlpChainTreeAndElementOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChainTreeAndElementOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 121F));
            this.tlpChainTreeAndElementOptions.Controls.Add(this.tvChain, 0, 0);
            this.tlpChainTreeAndElementOptions.Controls.Add(this.tlpElementSelectedOptions, 1, 0);
            this.tlpChainTreeAndElementOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpChainTreeAndElementOptions.Location = new System.Drawing.Point(0, 59);
            this.tlpChainTreeAndElementOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpChainTreeAndElementOptions.Name = "tlpChainTreeAndElementOptions";
            this.tlpChainTreeAndElementOptions.RowCount = 1;
            this.tlpChainTreeAndElementOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpChainTreeAndElementOptions.Size = new System.Drawing.Size(740, 558);
            this.tlpChainTreeAndElementOptions.TabIndex = 3;
            // 
            // tvChain
            // 
            this.tvChain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvChain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvChain.HideSelection = false;
            this.tvChain.Location = new System.Drawing.Point(3, 3);
            this.tvChain.Name = "tvChain";
            this.tvChain.Size = new System.Drawing.Size(613, 552);
            this.tvChain.TabIndex = 1;
            this.tvChain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvChain_AfterSelect);
            this.tvChain.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvChain_NodeMouseDoubleClick);
            // 
            // tlpElementSelectedOptions
            // 
            this.tlpElementSelectedOptions.ColumnCount = 1;
            this.tlpElementSelectedOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSelectedOptions.Controls.Add(this.lblElementSelectedOptions, 0, 0);
            this.tlpElementSelectedOptions.Controls.Add(this.flpElementSelectedOptions, 0, 1);
            this.tlpElementSelectedOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElementSelectedOptions.Location = new System.Drawing.Point(619, 0);
            this.tlpElementSelectedOptions.Margin = new System.Windows.Forms.Padding(0);
            this.tlpElementSelectedOptions.Name = "tlpElementSelectedOptions";
            this.tlpElementSelectedOptions.RowCount = 2;
            this.tlpElementSelectedOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpElementSelectedOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSelectedOptions.Size = new System.Drawing.Size(121, 558);
            this.tlpElementSelectedOptions.TabIndex = 2;
            // 
            // lblElementSelectedOptions
            // 
            this.lblElementSelectedOptions.AutoSize = true;
            this.lblElementSelectedOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblElementSelectedOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementSelectedOptions.Location = new System.Drawing.Point(3, 0);
            this.lblElementSelectedOptions.MaximumSize = new System.Drawing.Size(0, 59);
            this.lblElementSelectedOptions.Name = "lblElementSelectedOptions";
            this.lblElementSelectedOptions.Size = new System.Drawing.Size(115, 50);
            this.lblElementSelectedOptions.TabIndex = 1;
            this.lblElementSelectedOptions.Text = "Element Options";
            this.lblElementSelectedOptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpElementSelectedOptions
            // 
            this.flpElementSelectedOptions.AutoScroll = true;
            this.flpElementSelectedOptions.Controls.Add(this.tlpElementSelectedOptionMoveUpAndDown);
            this.flpElementSelectedOptions.Controls.Add(this.btnElementDuplicate);
            this.flpElementSelectedOptions.Controls.Add(this.btnElementGetSettings);
            this.flpElementSelectedOptions.Controls.Add(this.btnElementDelete);
            this.flpElementSelectedOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpElementSelectedOptions.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpElementSelectedOptions.Location = new System.Drawing.Point(0, 50);
            this.flpElementSelectedOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpElementSelectedOptions.Name = "flpElementSelectedOptions";
            this.flpElementSelectedOptions.Size = new System.Drawing.Size(121, 508);
            this.flpElementSelectedOptions.TabIndex = 2;
            this.flpElementSelectedOptions.WrapContents = false;
            // 
            // tlpElementSelectedOptionMoveUpAndDown
            // 
            this.tlpElementSelectedOptionMoveUpAndDown.ColumnCount = 2;
            this.tlpElementSelectedOptionMoveUpAndDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpElementSelectedOptionMoveUpAndDown.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpElementSelectedOptionMoveUpAndDown.Controls.Add(this.btnElementMoveDown, 1, 0);
            this.tlpElementSelectedOptionMoveUpAndDown.Controls.Add(this.btnElementMoveUp, 0, 0);
            this.tlpElementSelectedOptionMoveUpAndDown.Location = new System.Drawing.Point(0, 0);
            this.tlpElementSelectedOptionMoveUpAndDown.Margin = new System.Windows.Forms.Padding(0);
            this.tlpElementSelectedOptionMoveUpAndDown.Name = "tlpElementSelectedOptionMoveUpAndDown";
            this.tlpElementSelectedOptionMoveUpAndDown.RowCount = 1;
            this.tlpElementSelectedOptionMoveUpAndDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSelectedOptionMoveUpAndDown.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpElementSelectedOptionMoveUpAndDown.Size = new System.Drawing.Size(121, 32);
            this.tlpElementSelectedOptionMoveUpAndDown.TabIndex = 1;
            // 
            // btnElementMoveDown
            // 
            this.btnElementMoveDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementMoveDown.Enabled = false;
            this.btnElementMoveDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementMoveDown.Location = new System.Drawing.Point(63, 3);
            this.btnElementMoveDown.Name = "btnElementMoveDown";
            this.btnElementMoveDown.Size = new System.Drawing.Size(55, 26);
            this.btnElementMoveDown.TabIndex = 2;
            this.btnElementMoveDown.Text = "↓";
            this.btnElementMoveDown.UseVisualStyleBackColor = true;
            this.btnElementMoveDown.Click += new System.EventHandler(this.btnElementMoveDown_Click);
            // 
            // btnElementMoveUp
            // 
            this.btnElementMoveUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementMoveUp.Enabled = false;
            this.btnElementMoveUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementMoveUp.Location = new System.Drawing.Point(3, 3);
            this.btnElementMoveUp.Name = "btnElementMoveUp";
            this.btnElementMoveUp.Size = new System.Drawing.Size(54, 26);
            this.btnElementMoveUp.TabIndex = 1;
            this.btnElementMoveUp.Text = "↑";
            this.btnElementMoveUp.UseVisualStyleBackColor = true;
            this.btnElementMoveUp.Click += new System.EventHandler(this.btnElementMoveUp_Click);
            // 
            // btnElementDuplicate
            // 
            this.btnElementDuplicate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementDuplicate.Enabled = false;
            this.btnElementDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementDuplicate.Location = new System.Drawing.Point(3, 35);
            this.btnElementDuplicate.MinimumSize = new System.Drawing.Size(115, 0);
            this.btnElementDuplicate.Name = "btnElementDuplicate";
            this.btnElementDuplicate.Size = new System.Drawing.Size(115, 23);
            this.btnElementDuplicate.TabIndex = 2;
            this.btnElementDuplicate.Text = "Duplicate";
            this.btnElementDuplicate.UseVisualStyleBackColor = true;
            this.btnElementDuplicate.Click += new System.EventHandler(this.btnElementDuplicate_Click);
            // 
            // btnElementGetSettings
            // 
            this.btnElementGetSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementGetSettings.Enabled = false;
            this.btnElementGetSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementGetSettings.Location = new System.Drawing.Point(3, 64);
            this.btnElementGetSettings.MinimumSize = new System.Drawing.Size(115, 0);
            this.btnElementGetSettings.Name = "btnElementGetSettings";
            this.btnElementGetSettings.Size = new System.Drawing.Size(115, 23);
            this.btnElementGetSettings.TabIndex = 3;
            this.btnElementGetSettings.Text = "Get Settings";
            this.btnElementGetSettings.UseVisualStyleBackColor = true;
            this.btnElementGetSettings.Click += new System.EventHandler(this.btnElementGetSettings_Click);
            // 
            // btnElementDelete
            // 
            this.btnElementDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementDelete.Enabled = false;
            this.btnElementDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementDelete.Location = new System.Drawing.Point(3, 93);
            this.btnElementDelete.MinimumSize = new System.Drawing.Size(115, 0);
            this.btnElementDelete.Name = "btnElementDelete";
            this.btnElementDelete.Size = new System.Drawing.Size(115, 23);
            this.btnElementDelete.TabIndex = 4;
            this.btnElementDelete.Text = "Delete";
            this.btnElementDelete.UseVisualStyleBackColor = true;
            this.btnElementDelete.Click += new System.EventHandler(this.btnElementDelete_Click);
            // 
            // tlpElementSettings
            // 
            this.tlpElementSettings.ColumnCount = 1;
            this.tlpElementSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettings.Controls.Add(this.flpElementOptions, 0, 3);
            this.tlpElementSettings.Controls.Add(this.lblElementTitle, 0, 0);
            this.tlpElementSettings.Controls.Add(this.flpContent, 0, 2);
            this.tlpElementSettings.Controls.Add(this.flpElementGeneralSettings, 0, 1);
            this.tlpElementSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElementSettings.Location = new System.Drawing.Point(0, 0);
            this.tlpElementSettings.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.tlpElementSettings.Name = "tlpElementSettings";
            this.tlpElementSettings.RowCount = 4;
            this.tlpElementSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpElementSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpElementSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpElementSettings.Size = new System.Drawing.Size(307, 648);
            this.tlpElementSettings.TabIndex = 1;
            // 
            // flpElementOptions
            // 
            this.flpElementOptions.Controls.Add(this.btnAddMoveToChain);
            this.flpElementOptions.Controls.Add(this.btnElementApplySettings);
            this.flpElementOptions.Controls.Add(this.btnInsert);
            this.flpElementOptions.Controls.Add(this.btnResetMoveSettings);
            this.flpElementOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpElementOptions.Location = new System.Drawing.Point(0, 617);
            this.flpElementOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flpElementOptions.MinimumSize = new System.Drawing.Size(0, 30);
            this.flpElementOptions.Name = "flpElementOptions";
            this.flpElementOptions.Size = new System.Drawing.Size(307, 31);
            this.flpElementOptions.TabIndex = 4;
            // 
            // btnAddMoveToChain
            // 
            this.btnAddMoveToChain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMoveToChain.AutoSize = true;
            this.btnAddMoveToChain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddMoveToChain.Location = new System.Drawing.Point(3, 3);
            this.btnAddMoveToChain.MinimumSize = new System.Drawing.Size(0, 26);
            this.btnAddMoveToChain.Name = "btnAddMoveToChain";
            this.btnAddMoveToChain.Size = new System.Drawing.Size(36, 26);
            this.btnAddMoveToChain.TabIndex = 1;
            this.btnAddMoveToChain.Text = "Add";
            this.ToolTip.SetToolTip(this.btnAddMoveToChain, "Adds a new element to the chain with the current settings.");
            this.btnAddMoveToChain.UseVisualStyleBackColor = true;
            this.btnAddMoveToChain.Click += new System.EventHandler(this.btnAddElementToChain_Click);
            // 
            // btnElementApplySettings
            // 
            this.btnElementApplySettings.AutoSize = true;
            this.btnElementApplySettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnElementApplySettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElementApplySettings.Enabled = false;
            this.btnElementApplySettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnElementApplySettings.Location = new System.Drawing.Point(45, 3);
            this.btnElementApplySettings.MinimumSize = new System.Drawing.Size(0, 26);
            this.btnElementApplySettings.Name = "btnElementApplySettings";
            this.btnElementApplySettings.Size = new System.Drawing.Size(43, 26);
            this.btnElementApplySettings.TabIndex = 2;
            this.btnElementApplySettings.Text = "Apply";
            this.ToolTip.SetToolTip(this.btnElementApplySettings, "Applies the current settings to the selected element.");
            this.btnElementApplySettings.UseVisualStyleBackColor = true;
            this.btnElementApplySettings.Click += new System.EventHandler(this.btnElementApplySettings_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsert.AutoSize = true;
            this.btnInsert.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnInsert.Enabled = false;
            this.btnInsert.Location = new System.Drawing.Point(94, 3);
            this.btnInsert.MinimumSize = new System.Drawing.Size(0, 26);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(43, 26);
            this.btnInsert.TabIndex = 3;
            this.btnInsert.Text = "Insert";
            this.ToolTip.SetToolTip(this.btnInsert, "Inserts a new element into the chain after the selected element");
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnResetMoveSettings
            // 
            this.btnResetMoveSettings.AutoSize = true;
            this.btnResetMoveSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnResetMoveSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnResetMoveSettings.Location = new System.Drawing.Point(143, 3);
            this.btnResetMoveSettings.MinimumSize = new System.Drawing.Size(0, 26);
            this.btnResetMoveSettings.Name = "btnResetMoveSettings";
            this.btnResetMoveSettings.Size = new System.Drawing.Size(45, 26);
            this.btnResetMoveSettings.TabIndex = 4;
            this.btnResetMoveSettings.Text = "Reset";
            this.ToolTip.SetToolTip(this.btnResetMoveSettings, "Resets the currently selected move settings to their default values.");
            this.btnResetMoveSettings.UseVisualStyleBackColor = true;
            this.btnResetMoveSettings.Click += new System.EventHandler(this.btnResetMoveControl_Click);
            // 
            // lblElementTitle
            // 
            this.lblElementTitle.AutoSize = true;
            this.lblElementTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblElementTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblElementTitle.Location = new System.Drawing.Point(3, 0);
            this.lblElementTitle.Name = "lblElementTitle";
            this.lblElementTitle.Size = new System.Drawing.Size(301, 29);
            this.lblElementTitle.TabIndex = 1;
            this.lblElementTitle.Text = "Element";
            this.lblElementTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.Controls.Add(this.lblElementDescriptionTitle);
            this.flpContent.Controls.Add(this.lblElementDescription);
            this.flpContent.Controls.Add(this.lblElementSettingsTitle);
            this.flpContent.Controls.Add(this.lblElementDescriptionHint);
            this.flpContent.Controls.Add(this.tlpContent);
            this.flpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpContent.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpContent.Location = new System.Drawing.Point(0, 59);
            this.flpContent.Margin = new System.Windows.Forms.Padding(0);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(307, 558);
            this.flpContent.TabIndex = 3;
            this.flpContent.WrapContents = false;
            // 
            // lblElementDescriptionTitle
            // 
            this.lblElementDescriptionTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblElementDescriptionTitle.AutoSize = true;
            this.lblElementDescriptionTitle.Location = new System.Drawing.Point(3, 0);
            this.lblElementDescriptionTitle.Name = "lblElementDescriptionTitle";
            this.lblElementDescriptionTitle.Size = new System.Drawing.Size(284, 13);
            this.lblElementDescriptionTitle.TabIndex = 1;
            this.lblElementDescriptionTitle.Text = "Description:";
            // 
            // lblElementDescription
            // 
            this.lblElementDescription.AutoSize = true;
            this.lblElementDescription.Location = new System.Drawing.Point(3, 13);
            this.lblElementDescription.MaximumSize = new System.Drawing.Size(280, 0);
            this.lblElementDescription.Name = "lblElementDescription";
            this.lblElementDescription.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblElementDescription.Size = new System.Drawing.Size(119, 23);
            this.lblElementDescription.TabIndex = 2;
            this.lblElementDescription.Text = "Description Placeholder";
            // 
            // lblElementSettingsTitle
            // 
            this.lblElementSettingsTitle.AutoSize = true;
            this.lblElementSettingsTitle.Location = new System.Drawing.Point(3, 36);
            this.lblElementSettingsTitle.Name = "lblElementSettingsTitle";
            this.lblElementSettingsTitle.Size = new System.Drawing.Size(48, 13);
            this.lblElementSettingsTitle.TabIndex = 3;
            this.lblElementSettingsTitle.Text = "Settings:";
            // 
            // lblElementDescriptionHint
            // 
            this.lblElementDescriptionHint.Location = new System.Drawing.Point(3, 49);
            this.lblElementDescriptionHint.Name = "lblElementDescriptionHint";
            this.lblElementDescriptionHint.Size = new System.Drawing.Size(280, 26);
            this.lblElementDescriptionHint.TabIndex = 4;
            this.lblElementDescriptionHint.Text = "Descriptions to the settings can be found when hovering over the corresponding la" +
    "bels.\r\n";
            // 
            // tlpContent
            // 
            this.tlpContent.AutoSize = true;
            this.tlpContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpContent.ColumnCount = 1;
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContent.Location = new System.Drawing.Point(0, 75);
            this.tlpContent.Margin = new System.Windows.Forms.Padding(0);
            this.tlpContent.MaximumSize = new System.Drawing.Size(295, 0);
            this.tlpContent.MinimumSize = new System.Drawing.Size(290, 100);
            this.tlpContent.Name = "tlpContent";
            this.tlpContent.RowCount = 1;
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpContent.Size = new System.Drawing.Size(290, 100);
            this.tlpContent.TabIndex = 5;
            // 
            // flpElementGeneralSettings
            // 
            this.flpElementGeneralSettings.Controls.Add(this.tlpElementSettingType);
            this.flpElementGeneralSettings.Controls.Add(this.tlpElementSettingName);
            this.flpElementGeneralSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpElementGeneralSettings.Location = new System.Drawing.Point(0, 29);
            this.flpElementGeneralSettings.Margin = new System.Windows.Forms.Padding(0);
            this.flpElementGeneralSettings.Name = "flpElementGeneralSettings";
            this.flpElementGeneralSettings.Size = new System.Drawing.Size(307, 30);
            this.flpElementGeneralSettings.TabIndex = 2;
            // 
            // tlpElementSettingType
            // 
            this.tlpElementSettingType.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpElementSettingType.ColumnCount = 2;
            this.tlpElementSettingType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpElementSettingType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpElementSettingType.Controls.Add(this.lblType, 0, 0);
            this.tlpElementSettingType.Controls.Add(this.cbElementType, 1, 0);
            this.tlpElementSettingType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElementSettingType.Location = new System.Drawing.Point(3, 3);
            this.tlpElementSettingType.MinimumSize = new System.Drawing.Size(0, 30);
            this.tlpElementSettingType.Name = "tlpElementSettingType";
            this.tlpElementSettingType.RowCount = 1;
            this.tlpElementSettingType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettingType.Size = new System.Drawing.Size(135, 30);
            this.tlpElementSettingType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblType.Location = new System.Drawing.Point(3, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 30);
            this.lblType.TabIndex = 1;
            this.lblType.Text = "Type:";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolTip.SetToolTip(this.lblType, resources.GetString("lblType.ToolTip"));
            // 
            // cbElementType
            // 
            this.cbElementType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbElementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElementType.FormattingEnabled = true;
            this.cbElementType.Items.AddRange(new object[] {
            "circle around player"});
            this.cbElementType.Location = new System.Drawing.Point(43, 3);
            this.cbElementType.Name = "cbElementType";
            this.cbElementType.Size = new System.Drawing.Size(90, 21);
            this.cbElementType.TabIndex = 2;
            this.cbElementType.SelectedIndexChanged += new System.EventHandler(this.cbElementType_SelectedIndexChanged);
            // 
            // tlpElementSettingName
            // 
            this.tlpElementSettingName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpElementSettingName.ColumnCount = 2;
            this.tlpElementSettingName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpElementSettingName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpElementSettingName.Controls.Add(this.txtElementName, 0, 0);
            this.tlpElementSettingName.Controls.Add(this.lblMoveName, 0, 0);
            this.tlpElementSettingName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpElementSettingName.Location = new System.Drawing.Point(144, 3);
            this.tlpElementSettingName.MinimumSize = new System.Drawing.Size(0, 30);
            this.tlpElementSettingName.Name = "tlpElementSettingName";
            this.tlpElementSettingName.RowCount = 1;
            this.tlpElementSettingName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpElementSettingName.Size = new System.Drawing.Size(150, 30);
            this.tlpElementSettingName.TabIndex = 2;
            // 
            // txtElementName
            // 
            this.txtElementName.Location = new System.Drawing.Point(47, 3);
            this.txtElementName.Name = "txtElementName";
            this.txtElementName.Size = new System.Drawing.Size(102, 20);
            this.txtElementName.TabIndex = 2;
            // 
            // lblMoveName
            // 
            this.lblMoveName.AutoSize = true;
            this.lblMoveName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMoveName.Location = new System.Drawing.Point(3, 0);
            this.lblMoveName.Name = "lblMoveName";
            this.lblMoveName.Size = new System.Drawing.Size(38, 30);
            this.lblMoveName.TabIndex = 1;
            this.lblMoveName.Text = "Name:";
            this.lblMoveName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStripSettings
            // 
            this.menuStripSettings.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileOptions});
            this.menuStripSettings.Location = new System.Drawing.Point(0, 0);
            this.menuStripSettings.Name = "menuStripSettings";
            this.menuStripSettings.Size = new System.Drawing.Size(45, 20);
            this.menuStripSettings.TabIndex = 8;
            this.menuStripSettings.Text = "menuStrip1";
            // 
            // toolStripFileOptions
            // 
            this.toolStripFileOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.toolStripFileOptions.Name = "toolStripFileOptions";
            this.toolStripFileOptions.Size = new System.Drawing.Size(37, 16);
            this.toolStripFileOptions.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // ToolTip
            // 
            this.ToolTip.AutoPopDelay = 32767;
            this.ToolTip.InitialDelay = 500;
            this.ToolTip.IsBalloon = true;
            this.ToolTip.ReshowDelay = 100;
            // 
            // tlpMenuAndContent
            // 
            this.tlpMenuAndContent.ColumnCount = 1;
            this.tlpMenuAndContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenuAndContent.Controls.Add(this.menuStripSettings, 0, 0);
            this.tlpMenuAndContent.Controls.Add(this.tlpContentAndMargin, 0, 1);
            this.tlpMenuAndContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMenuAndContent.Location = new System.Drawing.Point(0, 0);
            this.tlpMenuAndContent.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMenuAndContent.Name = "tlpMenuAndContent";
            this.tlpMenuAndContent.RowCount = 2;
            this.tlpMenuAndContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMenuAndContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenuAndContent.Size = new System.Drawing.Size(1105, 715);
            this.tlpMenuAndContent.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 715);
            this.Controls.Add(this.tlpMenuAndContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripSettings;
            this.MinimumSize = new System.Drawing.Size(1121, 100);
            this.Name = "Main";
            this.Text = "MovementScriptGenerator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.tlpContentAndMargin.ResumeLayout(false);
            this.tlpElementSettingsAndChainSettings.ResumeLayout(false);
            this.tlpChain.ResumeLayout(false);
            this.tlpChain.PerformLayout();
            this.flpScriptOptions.ResumeLayout(false);
            this.flpScriptOptions.PerformLayout();
            this.flpChainSettings.ResumeLayout(false);
            this.flpChainSettings.PerformLayout();
            this.tlpChainTreeAndElementOptions.ResumeLayout(false);
            this.tlpElementSelectedOptions.ResumeLayout(false);
            this.tlpElementSelectedOptions.PerformLayout();
            this.flpElementSelectedOptions.ResumeLayout(false);
            this.tlpElementSelectedOptionMoveUpAndDown.ResumeLayout(false);
            this.tlpElementSettings.ResumeLayout(false);
            this.tlpElementSettings.PerformLayout();
            this.flpElementOptions.ResumeLayout(false);
            this.flpElementOptions.PerformLayout();
            this.flpContent.ResumeLayout(false);
            this.flpContent.PerformLayout();
            this.flpElementGeneralSettings.ResumeLayout(false);
            this.tlpElementSettingType.ResumeLayout(false);
            this.tlpElementSettingType.PerformLayout();
            this.tlpElementSettingName.ResumeLayout(false);
            this.tlpElementSettingName.PerformLayout();
            this.menuStripSettings.ResumeLayout(false);
            this.menuStripSettings.PerformLayout();
            this.tlpMenuAndContent.ResumeLayout(false);
            this.tlpMenuAndContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContentAndMargin;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cbElementType;
        private System.Windows.Forms.Label lblElementSettingsTitle;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.Label lblChainName;
        private System.Windows.Forms.Button btnGenerateScript;
        private System.Windows.Forms.Label lblElementDescriptionHint;
        private System.Windows.Forms.CheckBox checkSyncToSong;
        private System.Windows.Forms.Label lblElementDescriptionTitle;
        private System.Windows.Forms.Label lblElementDescription;
        private System.Windows.Forms.TableLayoutPanel tlpContent;
        private System.Windows.Forms.TableLayoutPanel tlpElementSettingType;
        private System.Windows.Forms.Label lblAddToScript;
        private System.Windows.Forms.TableLayoutPanel tlpElementSettingsAndChainSettings;
        private System.Windows.Forms.TableLayoutPanel tlpChain;
        private System.Windows.Forms.Label lblChainTitle;
        private System.Windows.Forms.Button btnAddMoveToChain;
        private System.Windows.Forms.TableLayoutPanel tlpElementSettings;
        private System.Windows.Forms.Label lblElementTitle;
        private System.Windows.Forms.FlowLayoutPanel flpChainSettings;
        private System.Windows.Forms.Label lblLoop;
        private System.Windows.Forms.FlowLayoutPanel flpElementGeneralSettings;
        private System.Windows.Forms.TableLayoutPanel tlpElementSettingName;
        private System.Windows.Forms.TextBox txtElementName;
        private System.Windows.Forms.Label lblMoveName;
        private System.Windows.Forms.TreeView tvChain;
        private System.Windows.Forms.FlowLayoutPanel flpElementOptions;
        private System.Windows.Forms.Button btnResetMoveSettings;
        private System.Windows.Forms.TableLayoutPanel tlpChainTreeAndElementOptions;
        private System.Windows.Forms.TableLayoutPanel tlpElementSelectedOptions;
        private System.Windows.Forms.Label lblElementSelectedOptions;
        private System.Windows.Forms.FlowLayoutPanel flpElementSelectedOptions;
        private System.Windows.Forms.Button btnElementMoveUp;
        private System.Windows.Forms.TableLayoutPanel tlpElementSelectedOptionMoveUpAndDown;
        private System.Windows.Forms.Button btnElementMoveDown;
        private System.Windows.Forms.Button btnElementDuplicate;
        private System.Windows.Forms.Button btnElementGetSettings;
        private System.Windows.Forms.Button btnElementApplySettings;
        private System.Windows.Forms.Button btnElementDelete;
        private System.Windows.Forms.Button btnEditScriptPath;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.MenuStrip menuStripSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripFileOptions;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlpMenuAndContent;
        private System.Windows.Forms.FlowLayoutPanel flpScriptOptions;
        private System.Windows.Forms.TextBox txtScriptName;
        private System.Windows.Forms.Label lblScriptName;
        private System.Windows.Forms.Label lblSyncToSong;
        private System.Windows.Forms.CheckBox checkAddToScript;
        private System.Windows.Forms.CheckBox checkLoop;
        private System.Windows.Forms.TextBox txtChainName;
    }
}

