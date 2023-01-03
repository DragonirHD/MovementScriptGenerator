
namespace MovementScriptGenerator
{
    partial class RepeatControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpSpiralControl = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.numStartElement = new System.Windows.Forms.NumericUpDown();
            this.lblStartElement = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numEndElement = new System.Windows.Forms.NumericUpDown();
            this.lblEndDistance = new System.Windows.Forms.Label();
            this.flpSpiralControl.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartElement)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndElement)).BeginInit();
            this.SuspendLayout();
            // 
            // flpSpiralControl
            // 
            this.flpSpiralControl.AutoSize = true;
            this.flpSpiralControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpSpiralControl.Controls.Add(this.tableLayoutPanel1);
            this.flpSpiralControl.Controls.Add(this.tableLayoutPanel2);
            this.flpSpiralControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSpiralControl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSpiralControl.Location = new System.Drawing.Point(0, 0);
            this.flpSpiralControl.Margin = new System.Windows.Forms.Padding(0);
            this.flpSpiralControl.MaximumSize = new System.Drawing.Size(290, 0);
            this.flpSpiralControl.Name = "flpSpiralControl";
            this.flpSpiralControl.Size = new System.Drawing.Size(258, 70);
            this.flpSpiralControl.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.numStartElement, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblStartElement, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(0, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(252, 32);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // numStartElement
            // 
            this.numStartElement.Location = new System.Drawing.Point(129, 3);
            this.numStartElement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStartElement.Name = "numStartElement";
            this.numStartElement.Size = new System.Drawing.Size(120, 20);
            this.numStartElement.TabIndex = 1;
            this.numStartElement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStartElement
            // 
            this.lblStartElement.AccessibleDescription = "";
            this.lblStartElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStartElement.AutoSize = true;
            this.lblStartElement.Location = new System.Drawing.Point(3, 0);
            this.lblStartElement.Name = "lblStartElement";
            this.lblStartElement.Size = new System.Drawing.Size(70, 32);
            this.lblStartElement.TabIndex = 2;
            this.lblStartElement.Text = "Start Element";
            this.lblStartElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.numEndElement, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblEndDistance, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 41);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(252, 26);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // numEndElement
            // 
            this.numEndElement.Location = new System.Drawing.Point(129, 3);
            this.numEndElement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEndElement.Name = "numEndElement";
            this.numEndElement.Size = new System.Drawing.Size(120, 20);
            this.numEndElement.TabIndex = 1;
            this.numEndElement.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblEndDistance
            // 
            this.lblEndDistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEndDistance.AutoSize = true;
            this.lblEndDistance.Location = new System.Drawing.Point(3, 0);
            this.lblEndDistance.Name = "lblEndDistance";
            this.lblEndDistance.Size = new System.Drawing.Size(67, 26);
            this.lblEndDistance.TabIndex = 2;
            this.lblEndDistance.Text = "End Element";
            this.lblEndDistance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RepeatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.flpSpiralControl);
            this.Name = "RepeatControl";
            this.Size = new System.Drawing.Size(258, 70);
            this.Load += new System.EventHandler(this.RepeatControl_Load);
            this.flpSpiralControl.ResumeLayout(false);
            this.flpSpiralControl.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStartElement)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEndElement)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpSpiralControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numStartElement;
        private System.Windows.Forms.Label lblStartElement;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numEndElement;
        private System.Windows.Forms.Label lblEndDistance;
    }
}
