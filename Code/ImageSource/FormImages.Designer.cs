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
            this.buttonSortTags = new System.Windows.Forms.Button();
            this.buttonEditImage = new System.Windows.Forms.Button();
            this.buttonRemoveImage = new System.Windows.Forms.Button();
            this.dataGridImages = new System.Windows.Forms.DataGridView();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.labelHasImages = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxUpper = new System.Windows.Forms.TextBox();
            this.labelUpper = new System.Windows.Forms.Label();
            this.textBoxLower = new System.Windows.Forms.TextBox();
            this.labelLower = new System.Windows.Forms.Label();
            this.comboBoxTagType = new System.Windows.Forms.ComboBox();
            this.labelTagType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImages)).BeginInit();
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
            // buttonSortTags
            // 
            this.buttonSortTags.Location = new System.Drawing.Point(12, 298);
            this.buttonSortTags.Name = "buttonSortTags";
            this.buttonSortTags.Size = new System.Drawing.Size(124, 23);
            this.buttonSortTags.TabIndex = 2;
            this.buttonSortTags.Text = "Search";
            this.buttonSortTags.UseVisualStyleBackColor = true;
            this.buttonSortTags.Click += new System.EventHandler(this.buttonSortTags_Click);
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
            this.buttonRemoveImage.Click += new System.EventHandler(this.buttonRemoveImage_Click);
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
            this.dataGridImages.Size = new System.Drawing.Size(347, 337);
            this.dataGridImages.TabIndex = 5;
            // 
            // importFileDialog
            // 
            this.importFileDialog.FileName = "image.jpg";
            // 
            // labelHasImages
            // 
            this.labelHasImages.AutoSize = true;
            this.labelHasImages.Location = new System.Drawing.Point(243, 169);
            this.labelHasImages.Name = "labelHasImages";
            this.labelHasImages.Size = new System.Drawing.Size(157, 13);
            this.labelHasImages.TabIndex = 6;
            this.labelHasImages.Text = "No images have been imported.";
            this.labelHasImages.Visible = false;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 327);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(123, 23);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxUpper
            // 
            this.textBoxUpper.Location = new System.Drawing.Point(13, 272);
            this.textBoxUpper.Name = "textBoxUpper";
            this.textBoxUpper.Size = new System.Drawing.Size(122, 20);
            this.textBoxUpper.TabIndex = 8;
            // 
            // labelUpper
            // 
            this.labelUpper.AutoSize = true;
            this.labelUpper.Location = new System.Drawing.Point(12, 256);
            this.labelUpper.Name = "labelUpper";
            this.labelUpper.Size = new System.Drawing.Size(65, 13);
            this.labelUpper.TabIndex = 9;
            this.labelUpper.Text = "Less than ...";
            // 
            // textBoxLower
            // 
            this.textBoxLower.Location = new System.Drawing.Point(12, 230);
            this.textBoxLower.Name = "textBoxLower";
            this.textBoxLower.Size = new System.Drawing.Size(123, 20);
            this.textBoxLower.TabIndex = 10;
            // 
            // labelLower
            // 
            this.labelLower.AutoSize = true;
            this.labelLower.Location = new System.Drawing.Point(12, 214);
            this.labelLower.Name = "labelLower";
            this.labelLower.Size = new System.Drawing.Size(78, 13);
            this.labelLower.TabIndex = 11;
            this.labelLower.Text = "Greater than ...";
            // 
            // comboBoxTagType
            // 
            this.comboBoxTagType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTagType.FormattingEnabled = true;
            this.comboBoxTagType.Location = new System.Drawing.Point(12, 187);
            this.comboBoxTagType.Name = "comboBoxTagType";
            this.comboBoxTagType.Size = new System.Drawing.Size(123, 21);
            this.comboBoxTagType.TabIndex = 12;
            this.comboBoxTagType.SelectedIndexChanged += new System.EventHandler(this.comboBoxTagType_SelectedIndexChanged);
            // 
            // labelTagType
            // 
            this.labelTagType.AutoSize = true;
            this.labelTagType.Location = new System.Drawing.Point(12, 169);
            this.labelTagType.Name = "labelTagType";
            this.labelTagType.Size = new System.Drawing.Size(98, 13);
            this.labelTagType.TabIndex = 13;
            this.labelTagType.Text = "Select Tag Type ...";
            // 
            // FormImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 362);
            this.Controls.Add(this.labelTagType);
            this.Controls.Add(this.comboBoxTagType);
            this.Controls.Add(this.labelLower);
            this.Controls.Add(this.textBoxLower);
            this.Controls.Add(this.labelUpper);
            this.Controls.Add(this.textBoxUpper);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.labelHasImages);
            this.Controls.Add(this.dataGridImages);
            this.Controls.Add(this.buttonRemoveImage);
            this.Controls.Add(this.buttonEditImage);
            this.Controls.Add(this.buttonSortTags);
            this.Controls.Add(this.buttonImport);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(511, 389);
            this.MinimumSize = new System.Drawing.Size(511, 389);
            this.Name = "FormImages";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "ImageSource - Images";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridImages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.Button buttonSortTags;
        private System.Windows.Forms.Button buttonEditImage;
        private System.Windows.Forms.Button buttonRemoveImage;
        private System.Windows.Forms.DataGridView dataGridImages;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.Label labelHasImages;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxUpper;
        private System.Windows.Forms.Label labelUpper;
        private System.Windows.Forms.TextBox textBoxLower;
        private System.Windows.Forms.Label labelLower;
        private System.Windows.Forms.ComboBox comboBoxTagType;
        private System.Windows.Forms.Label labelTagType;


    }
}