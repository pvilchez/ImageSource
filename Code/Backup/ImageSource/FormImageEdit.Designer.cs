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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonTags = new System.Windows.Forms.Button();
            this.buttonCrop = new System.Windows.Forms.Button();
            this.buttonScale = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelFileNameData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(350, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Path:";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(388, 191);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(254, 20);
            this.textBoxPath.TabIndex = 1;
            // 
            // buttonTags
            // 
            this.buttonTags.Location = new System.Drawing.Point(770, 397);
            this.buttonTags.Name = "buttonTags";
            this.buttonTags.Size = new System.Drawing.Size(122, 23);
            this.buttonTags.TabIndex = 2;
            this.buttonTags.Text = "Tags ...";
            this.buttonTags.UseVisualStyleBackColor = true;
            // 
            // buttonCrop
            // 
            this.buttonCrop.Location = new System.Drawing.Point(770, 368);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(122, 23);
            this.buttonCrop.TabIndex = 3;
            this.buttonCrop.Text = "Crop ...";
            this.buttonCrop.UseVisualStyleBackColor = true;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // buttonScale
            // 
            this.buttonScale.Location = new System.Drawing.Point(770, 339);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(122, 23);
            this.buttonScale.TabIndex = 4;
            this.buttonScale.Text = "Scale ...";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(770, 13);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(57, 13);
            this.labelFileName.TabIndex = 5;
            this.labelFileName.Text = "File Name:";
            // 
            // labelFileNameData
            // 
            this.labelFileNameData.AutoSize = true;
            this.labelFileNameData.Location = new System.Drawing.Point(791, 35);
            this.labelFileNameData.Name = "labelFileNameData";
            this.labelFileNameData.Size = new System.Drawing.Size(57, 13);
            this.labelFileNameData.TabIndex = 6;
            this.labelFileNameData.Text = "(unknown)";
            // 
            // FormImageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 432);
            this.Controls.Add(this.labelFileNameData);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonCrop);
            this.Controls.Add(this.buttonTags);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Name = "FormImageEdit";
            this.Text = "ImageSource - View / Edit Image";
            this.Load += new System.EventHandler(this.FormImageEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonTags;
        private System.Windows.Forms.Button buttonCrop;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelFileNameData;
    }
}