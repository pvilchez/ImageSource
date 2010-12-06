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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelIntro = new System.Windows.Forms.Label();
            this.labelTags = new System.Windows.Forms.Label();
            this.labelImages = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonTags
            // 
            this.buttonTags.Location = new System.Drawing.Point(197, 100);
            this.buttonTags.Name = "buttonTags";
            this.buttonTags.Size = new System.Drawing.Size(75, 23);
            this.buttonTags.TabIndex = 0;
            this.buttonTags.Text = "Tags ...";
            this.buttonTags.UseVisualStyleBackColor = true;
            this.buttonTags.Click += new System.EventHandler(this.buttonTags_Click);
            // 
            // buttonImages
            // 
            this.buttonImages.Location = new System.Drawing.Point(197, 156);
            this.buttonImages.Name = "buttonImages";
            this.buttonImages.Size = new System.Drawing.Size(75, 23);
            this.buttonImages.TabIndex = 1;
            this.buttonImages.Text = "Images ...";
            this.buttonImages.UseVisualStyleBackColor = true;
            this.buttonImages.Click += new System.EventHandler(this.buttonImages_Click);
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(15, 18);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(257, 24);
            this.labelWelcome.TabIndex = 2;
            this.labelWelcome.Text = "Welcome to ImageSource!";
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Location = new System.Drawing.Point(16, 51);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(198, 13);
            this.labelIntro.TabIndex = 3;
            this.labelIntro.Text = "To begin, please select an option below.";
            // 
            // labelTags
            // 
            this.labelTags.AutoSize = true;
            this.labelTags.Location = new System.Drawing.Point(16, 91);
            this.labelTags.Name = "labelTags";
            this.labelTags.Size = new System.Drawing.Size(31, 13);
            this.labelTags.TabIndex = 4;
            this.labelTags.Text = "Tags";
            // 
            // labelImages
            // 
            this.labelImages.AutoSize = true;
            this.labelImages.Location = new System.Drawing.Point(16, 147);
            this.labelImages.Name = "labelImages";
            this.labelImages.Size = new System.Drawing.Size(41, 13);
            this.labelImages.TabIndex = 5;
            this.labelImages.Text = "Images";
            // 
            // FormStartWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 206);
            this.Controls.Add(this.labelImages);
            this.Controls.Add(this.labelTags);
            this.Controls.Add(this.labelIntro);
            this.Controls.Add(this.labelWelcome);
            this.Controls.Add(this.buttonImages);
            this.Controls.Add(this.buttonTags);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(292, 233);
            this.MinimumSize = new System.Drawing.Size(292, 233);
            this.Name = "FormStartWindow";
            this.Text = "ImageSource";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTags;
        private System.Windows.Forms.Button buttonImages;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label labelTags;
        private System.Windows.Forms.Label labelImages;
    }
}