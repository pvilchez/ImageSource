namespace ImageSource
{
    partial class FormImageTags
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
            this.buttonApplyTags = new System.Windows.Forms.Button();
            this.buttonModifyTag = new System.Windows.Forms.Button();
            this.buttonRemoveTag = new System.Windows.Forms.Button();
            this.dataGridTags = new System.Windows.Forms.DataGridView();
            this.comboBoxTags = new System.Windows.Forms.ComboBox();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelTagName = new System.Windows.Forms.Label();
            this.labelTagValue = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelNoTags = new System.Windows.Forms.Label();
            this.labelTagNameData = new System.Windows.Forms.Label();
            this.labelDataType = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridTags ) ).BeginInit();
            this.SuspendLayout();
            // 
            // buttonApplyTags
            // 
            this.buttonApplyTags.Location = new System.Drawing.Point(13, 13);
            this.buttonApplyTags.Name = "buttonApplyTags";
            this.buttonApplyTags.Size = new System.Drawing.Size(124, 23);
            this.buttonApplyTags.TabIndex = 0;
            this.buttonApplyTags.Text = "Apply Tags ...";
            this.buttonApplyTags.UseVisualStyleBackColor = true;
            this.buttonApplyTags.Click += new System.EventHandler(this.buttonApplyTags_Click);
            // 
            // buttonModifyTag
            // 
            this.buttonModifyTag.Location = new System.Drawing.Point(13, 43);
            this.buttonModifyTag.Name = "buttonModifyTag";
            this.buttonModifyTag.Size = new System.Drawing.Size(124, 23);
            this.buttonModifyTag.TabIndex = 1;
            this.buttonModifyTag.Text = "Modify Tag Value ...";
            this.buttonModifyTag.UseVisualStyleBackColor = true;
            this.buttonModifyTag.Click += new System.EventHandler(this.buttonModifyTag_Click);
            // 
            // buttonRemoveTag
            // 
            this.buttonRemoveTag.Location = new System.Drawing.Point(13, 73);
            this.buttonRemoveTag.Name = "buttonRemoveTag";
            this.buttonRemoveTag.Size = new System.Drawing.Size(124, 23);
            this.buttonRemoveTag.TabIndex = 2;
            this.buttonRemoveTag.Text = "Remove Tag ...";
            this.buttonRemoveTag.UseVisualStyleBackColor = true;
            this.buttonRemoveTag.Click += new System.EventHandler(this.buttonRemoveTag_Click);
            // 
            // dataGridTags
            // 
            this.dataGridTags.AllowUserToAddRows = false;
            this.dataGridTags.AllowUserToDeleteRows = false;
            this.dataGridTags.AllowUserToResizeColumns = false;
            this.dataGridTags.AllowUserToResizeRows = false;
            this.dataGridTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTags.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTags.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTags.Location = new System.Drawing.Point(144, 13);
            this.dataGridTags.MultiSelect = false;
            this.dataGridTags.Name = "dataGridTags";
            this.dataGridTags.ReadOnly = true;
            this.dataGridTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTags.Size = new System.Drawing.Size(347, 231);
            this.dataGridTags.TabIndex = 3;
            // 
            // comboBoxTags
            // 
            this.comboBoxTags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTags.FormattingEnabled = true;
            this.comboBoxTags.Location = new System.Drawing.Point(219, 74);
            this.comboBoxTags.Name = "comboBoxTags";
            this.comboBoxTags.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTags.TabIndex = 4;
            this.comboBoxTags.Visible = false;
            this.comboBoxTags.SelectedIndexChanged += new System.EventHandler(this.comboBoxTags_SelectedIndexChanged);
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(219, 102);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(121, 20);
            this.textBoxValue.TabIndex = 5;
            this.textBoxValue.Visible = false;
            // 
            // labelTagName
            // 
            this.labelTagName.AutoSize = true;
            this.labelTagName.Location = new System.Drawing.Point(156, 77);
            this.labelTagName.Name = "labelTagName";
            this.labelTagName.Size = new System.Drawing.Size(57, 13);
            this.labelTagName.TabIndex = 6;
            this.labelTagName.Text = "Tag Name";
            this.labelTagName.Visible = false;
            // 
            // labelTagValue
            // 
            this.labelTagValue.AutoSize = true;
            this.labelTagValue.Location = new System.Drawing.Point(179, 105);
            this.labelTagValue.Name = "labelTagValue";
            this.labelTagValue.Size = new System.Drawing.Size(34, 13);
            this.labelTagValue.TabIndex = 7;
            this.labelTagValue.Text = "Value";
            this.labelTagValue.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(416, 221);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(335, 221);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelNoTags
            // 
            this.labelNoTags.AutoSize = true;
            this.labelNoTags.ForeColor = System.Drawing.Color.Red;
            this.labelNoTags.Location = new System.Drawing.Point(246, 117);
            this.labelNoTags.Name = "labelNoTags";
            this.labelNoTags.Size = new System.Drawing.Size(156, 13);
            this.labelNoTags.TabIndex = 10;
            this.labelNoTags.Text = "This image has no tags applied.";
            // 
            // labelTagNameData
            // 
            this.labelTagNameData.AutoSize = true;
            this.labelTagNameData.Location = new System.Drawing.Point(219, 77);
            this.labelTagNameData.Name = "labelTagNameData";
            this.labelTagNameData.Size = new System.Drawing.Size(0, 13);
            this.labelTagNameData.TabIndex = 11;
            // 
            // labelDataType
            // 
            this.labelDataType.AutoSize = true;
            this.labelDataType.Location = new System.Drawing.Point(346, 105);
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(0, 13);
            this.labelDataType.TabIndex = 12;
            // 
            // FormImageTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 256);
            this.Controls.Add(this.labelDataType);
            this.Controls.Add(this.labelTagNameData);
            this.Controls.Add(this.labelNoTags);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelTagValue);
            this.Controls.Add(this.labelTagName);
            this.Controls.Add(this.textBoxValue);
            this.Controls.Add(this.comboBoxTags);
            this.Controls.Add(this.dataGridTags);
            this.Controls.Add(this.buttonRemoveTag);
            this.Controls.Add(this.buttonModifyTag);
            this.Controls.Add(this.buttonApplyTags);
            this.Name = "FormImageTags";
            this.Text = "ImageSource - View Image Tags";
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridTags ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonApplyTags;
        private System.Windows.Forms.Button buttonModifyTag;
        private System.Windows.Forms.Button buttonRemoveTag;
        private System.Windows.Forms.DataGridView dataGridTags;
        private System.Windows.Forms.ComboBox comboBoxTags;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelTagName;
        private System.Windows.Forms.Label labelTagValue;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelNoTags;
        private System.Windows.Forms.Label labelTagNameData;
        private System.Windows.Forms.Label labelDataType;
    }
}