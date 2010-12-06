namespace ImageSource
{
    partial class FormImages
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
            this.buttonImport = new System.Windows.Forms.Button();
            this.buttonTagView = new System.Windows.Forms.Button();
            this.buttonSortTags = new System.Windows.Forms.Button();
            this.buttonEditImage = new System.Windows.Forms.Button();
            this.buttonRemoveImage = new System.Windows.Forms.Button();
            this.dataGridImages = new System.Windows.Forms.DataGridView();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelHasImages = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridImages ) ).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImport
            // 
            this.buttonImport.Location = new System.Drawing.Point(13, 13);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(124, 23);
            this.buttonImport.TabIndex = 0;
            this.buttonImport.Text = "Import Image ...";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonTagView
            // 
            this.buttonTagView.Location = new System.Drawing.Point(12, 192);
            this.buttonTagView.Name = "buttonTagView";
            this.buttonTagView.Size = new System.Drawing.Size(124, 23);
            this.buttonTagView.TabIndex = 1;
            this.buttonTagView.Text = "View Tags ...";
            this.buttonTagView.UseVisualStyleBackColor = true;
            // 
            // buttonSortTags
            // 
            this.buttonSortTags.Location = new System.Drawing.Point(12, 221);
            this.buttonSortTags.Name = "buttonSortTags";
            this.buttonSortTags.Size = new System.Drawing.Size(124, 23);
            this.buttonSortTags.TabIndex = 2;
            this.buttonSortTags.Text = "Sort Tags ...";
            this.buttonSortTags.UseVisualStyleBackColor = true;
            // 
            // buttonEditImage
            // 
            this.buttonEditImage.Location = new System.Drawing.Point(13, 43);
            this.buttonEditImage.Name = "buttonEditImage";
            this.buttonEditImage.Size = new System.Drawing.Size(124, 23);
            this.buttonEditImage.TabIndex = 3;
            this.buttonEditImage.Text = "Edit Image ...";
            this.buttonEditImage.UseVisualStyleBackColor = true;
            this.buttonEditImage.Click += new System.EventHandler(this.buttonEditImage_Click);
            // 
            // buttonRemoveImage
            // 
            this.buttonRemoveImage.Location = new System.Drawing.Point(13, 73);
            this.buttonRemoveImage.Name = "buttonRemoveImage";
            this.buttonRemoveImage.Size = new System.Drawing.Size(124, 23);
            this.buttonRemoveImage.TabIndex = 4;
            this.buttonRemoveImage.Text = "Remove Image ...";
            this.buttonRemoveImage.UseVisualStyleBackColor = true;
            // 
            // dataGridImages
            // 
            this.dataGridImages.AllowUserToAddRows = false;
            this.dataGridImages.AllowUserToDeleteRows = false;
            this.dataGridImages.AllowUserToResizeRows = false;
            this.dataGridImages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridImages.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridImages.Location = new System.Drawing.Point(144, 13);
            this.dataGridImages.Name = "dataGridImages";
            this.dataGridImages.ReadOnly = true;
            this.dataGridImages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridImages.Size = new System.Drawing.Size(347, 231);
            this.dataGridImages.TabIndex = 5;
            // 
            // importFileDialog
            // 
            this.importFileDialog.FileName = "image.jpg";
            // 
            // labelHasImages
            // 
            this.labelHasImages.AutoSize = true;
            this.labelHasImages.Location = new System.Drawing.Point(248, 116);
            this.labelHasImages.Name = "labelHasImages";
            this.labelHasImages.Size = new System.Drawing.Size(157, 13);
            this.labelHasImages.TabIndex = 6;
            this.labelHasImages.Text = "No images have been imported.";
            this.labelHasImages.Visible = false;
            // 
            // FormImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 256);
            this.Controls.Add(this.labelHasImages);
            this.Controls.Add(this.dataGridImages);
            this.Controls.Add(this.buttonRemoveImage);
            this.Controls.Add(this.buttonEditImage);
            this.Controls.Add(this.buttonSortTags);
            this.Controls.Add(this.buttonTagView);
            this.Controls.Add(this.buttonImport);
            this.Name = "FormImages";
            this.Text = "ImageSource - Images";
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridImages ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonTagView;
        private System.Windows.Forms.Button buttonSortTags;
        private System.Windows.Forms.Button buttonEditImage;
        private System.Windows.Forms.Button buttonRemoveImage;
        private System.Windows.Forms.DataGridView dataGridImages;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.Label labelHasImages;


    }
}