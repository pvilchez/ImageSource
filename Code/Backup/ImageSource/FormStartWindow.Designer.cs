namespace ImageSource
{
    partial class FormStartWindow
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
            this.buttonImages = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTags
            // 
            this.buttonTags.Location = new System.Drawing.Point(13, 13);
            this.buttonTags.Name = "buttonTags";
            this.buttonTags.Size = new System.Drawing.Size(75, 23);
            this.buttonTags.TabIndex = 0;
            this.buttonTags.Text = "Tags ...";
            this.buttonTags.UseVisualStyleBackColor = true;
            this.buttonTags.Click += new System.EventHandler(this.buttonTags_Click);
            // 
            // buttonImages
            // 
            this.buttonImages.Location = new System.Drawing.Point(13, 43);
            this.buttonImages.Name = "buttonImages";
            this.buttonImages.Size = new System.Drawing.Size(75, 23);
            this.buttonImages.TabIndex = 1;
            this.buttonImages.Text = "Images ...";
            this.buttonImages.UseVisualStyleBackColor = true;
            this.buttonImages.Click += new System.EventHandler(this.buttonImages_Click);
            // 
            // FormStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.buttonImages);
            this.Controls.Add(this.buttonTags);
            this.Name = "FormStartWindow";
            this.Text = "ImageSource";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonTags;
        private System.Windows.Forms.Button buttonImages;
    }
}