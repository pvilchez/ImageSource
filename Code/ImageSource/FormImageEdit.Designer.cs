namespace ImageSource
{
    partial class FormImageEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && ( components != null ))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTags = new System.Windows.Forms.Button();
            this.buttonScale = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelFileNameData = new System.Windows.Forms.Label();
            this.histogramBox1 = new Emgu.CV.UI.HistogramBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxScalingFactor = new System.Windows.Forms.TextBox();
            this.panelImagePanel = new System.Windows.Forms.Panel();
            this.buttonSaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTags
            // 
            this.buttonTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTags.Location = new System.Drawing.Point(836, 361);
            this.buttonTags.Name = "buttonTags";
            this.buttonTags.Size = new System.Drawing.Size(122, 23);
            this.buttonTags.TabIndex = 2;
            this.buttonTags.Text = "Tags ...";
            this.buttonTags.UseVisualStyleBackColor = true;
            this.buttonTags.Click += new System.EventHandler(this.buttonTags_Click);
            // 
            // buttonScale
            // 
            this.buttonScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonScale.Location = new System.Drawing.Point(836, 332);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(70, 23);
            this.buttonScale.TabIndex = 4;
            this.buttonScale.Text = "Scale ...";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(770, 13);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(57, 13);
            this.labelFileName.TabIndex = 5;
            this.labelFileName.Text = "File Name:";
            // 
            // labelFileNameData
            // 
            this.labelFileNameData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFileNameData.AutoSize = true;
            this.labelFileNameData.Location = new System.Drawing.Point(833, 13);
            this.labelFileNameData.Name = "labelFileNameData";
            this.labelFileNameData.Size = new System.Drawing.Size(57, 13);
            this.labelFileNameData.TabIndex = 6;
            this.labelFileNameData.Text = "(unknown)";
            // 
            // histogramBox1
            // 
            this.histogramBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.histogramBox1.AutoSize = true;
            this.histogramBox1.Location = new System.Drawing.Point(773, 59);
            this.histogramBox1.Name = "histogramBox1";
            this.histogramBox1.Size = new System.Drawing.Size(219, 240);
            this.histogramBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(770, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Histogram:";
            // 
            // textBoxScalingFactor
            // 
            this.textBoxScalingFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxScalingFactor.Location = new System.Drawing.Point(912, 334);
            this.textBoxScalingFactor.Name = "textBoxScalingFactor";
            this.textBoxScalingFactor.Size = new System.Drawing.Size(46, 20);
            this.textBoxScalingFactor.TabIndex = 9;
            this.textBoxScalingFactor.Text = "1.0";
            // 
            // panelImagePanel
            // 
            this.panelImagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImagePanel.Location = new System.Drawing.Point(12, 12);
            this.panelImagePanel.Name = "panelImagePanel";
            this.panelImagePanel.Size = new System.Drawing.Size(752, 408);
            this.panelImagePanel.TabIndex = 10;
            this.panelImagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelImagePanel_Paint);
            // 
            // buttonSaveButton
            // 
            this.buttonSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveButton.Location = new System.Drawing.Point(836, 390);
            this.buttonSaveButton.Name = "buttonSaveButton";
            this.buttonSaveButton.Size = new System.Drawing.Size(122, 23);
            this.buttonSaveButton.TabIndex = 11;
            this.buttonSaveButton.Text = "Save...";
            this.buttonSaveButton.UseVisualStyleBackColor = true;
            this.buttonSaveButton.Click += new System.EventHandler(this.buttonSaveButton_Click);
            // 
            // FormImageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1004, 432);
            this.Controls.Add(this.buttonSaveButton);
            this.Controls.Add(this.textBoxScalingFactor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.histogramBox1);
            this.Controls.Add(this.labelFileNameData);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonTags);
            this.Controls.Add(this.panelImagePanel);
            this.Name = "FormImageEdit";
            this.Text = "ImageSource - View / Edit Image";
            this.Load += new System.EventHandler(this.FormImageEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTags;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelFileNameData;
        private Emgu.CV.UI.HistogramBox histogramBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxScalingFactor;
        private System.Windows.Forms.Panel panelImagePanel;
        private System.Windows.Forms.Button buttonSaveButton;
    }
}