namespace ImageSource
{
    partial class FormTags
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
            this.buttonCreateTagType = new System.Windows.Forms.Button();
            this.buttonModifyTagType = new System.Windows.Forms.Button();
            this.buttonRemoveTagType = new System.Windows.Forms.Button();
            this.dataGridTagTypeList = new System.Windows.Forms.DataGridView();
            this.labelHasTagTypes = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDataType = new System.Windows.Forms.Label();
            this.comboBoxDataType = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelInUse = new System.Windows.Forms.Label();
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridTagTypeList ) ).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateTagType
            // 
            this.buttonCreateTagType.Location = new System.Drawing.Point(13, 13);
            this.buttonCreateTagType.Name = "buttonCreateTagType";
            this.buttonCreateTagType.Size = new System.Drawing.Size(124, 23);
            this.buttonCreateTagType.TabIndex = 0;
            this.buttonCreateTagType.Text = "Create Tag Type ...";
            this.buttonCreateTagType.UseVisualStyleBackColor = true;
            this.buttonCreateTagType.Click += new System.EventHandler(this.buttonCreateTagType_Click);
            // 
            // buttonModifyTagType
            // 
            this.buttonModifyTagType.Enabled = false;
            this.buttonModifyTagType.Location = new System.Drawing.Point(13, 43);
            this.buttonModifyTagType.Name = "buttonModifyTagType";
            this.buttonModifyTagType.Size = new System.Drawing.Size(124, 23);
            this.buttonModifyTagType.TabIndex = 1;
            this.buttonModifyTagType.Text = "Modify Tag Type ...";
            this.buttonModifyTagType.UseVisualStyleBackColor = true;
            this.buttonModifyTagType.Click += new System.EventHandler(this.buttonModifyTagType_Click);
            // 
            // buttonRemoveTagType
            // 
            this.buttonRemoveTagType.Enabled = false;
            this.buttonRemoveTagType.Location = new System.Drawing.Point(13, 73);
            this.buttonRemoveTagType.Name = "buttonRemoveTagType";
            this.buttonRemoveTagType.Size = new System.Drawing.Size(124, 23);
            this.buttonRemoveTagType.TabIndex = 2;
            this.buttonRemoveTagType.Text = "Remove Tag Type ...";
            this.buttonRemoveTagType.UseVisualStyleBackColor = true;
            this.buttonRemoveTagType.Click += new System.EventHandler(this.buttonRemoveTagType_Click);
            // 
            // dataGridTagTypeList
            // 
            this.dataGridTagTypeList.AllowUserToAddRows = false;
            this.dataGridTagTypeList.AllowUserToDeleteRows = false;
            this.dataGridTagTypeList.AllowUserToResizeColumns = false;
            this.dataGridTagTypeList.AllowUserToResizeRows = false;
            this.dataGridTagTypeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTagTypeList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridTagTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTagTypeList.Location = new System.Drawing.Point(144, 13);
            this.dataGridTagTypeList.MultiSelect = false;
            this.dataGridTagTypeList.Name = "dataGridTagTypeList";
            this.dataGridTagTypeList.ReadOnly = true;
            this.dataGridTagTypeList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridTagTypeList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTagTypeList.Size = new System.Drawing.Size(347, 231);
            this.dataGridTagTypeList.TabIndex = 3;
            // 
            // labelHasTagTypes
            // 
            this.labelHasTagTypes.AutoSize = true;
            this.labelHasTagTypes.Location = new System.Drawing.Point(243, 109);
            this.labelHasTagTypes.Name = "labelHasTagTypes";
            this.labelHasTagTypes.Size = new System.Drawing.Size(163, 13);
            this.labelHasTagTypes.TabIndex = 4;
            this.labelHasTagTypes.Text = "No tag types have been created.";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(214, 89);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 5;
            this.labelName.Text = "Name";
            this.labelName.Visible = false;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(255, 86);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(121, 20);
            this.textBoxName.TabIndex = 6;
            this.textBoxName.Visible = false;
            // 
            // labelDataType
            // 
            this.labelDataType.AutoSize = true;
            this.labelDataType.Location = new System.Drawing.Point(199, 128);
            this.labelDataType.Name = "labelDataType";
            this.labelDataType.Size = new System.Drawing.Size(50, 13);
            this.labelDataType.TabIndex = 7;
            this.labelDataType.Text = "Datatype";
            this.labelDataType.Visible = false;
            // 
            // comboBoxDataType
            // 
            this.comboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataType.FormattingEnabled = true;
            this.comboBoxDataType.Location = new System.Drawing.Point(255, 125);
            this.comboBoxDataType.Name = "comboBoxDataType";
            this.comboBoxDataType.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataType.TabIndex = 8;
            this.comboBoxDataType.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(415, 220);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(334, 220);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelInUse
            // 
            this.labelInUse.AutoSize = true;
            this.labelInUse.ForeColor = System.Drawing.Color.Red;
            this.labelInUse.Location = new System.Drawing.Point(383, 89);
            this.labelInUse.Name = "labelInUse";
            this.labelInUse.Size = new System.Drawing.Size(106, 13);
            this.labelInUse.TabIndex = 11;
            this.labelInUse.Text = "Name already in use!";
            this.labelInUse.Visible = false;
            // 
            // FormTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 256);
            this.Controls.Add(this.labelInUse);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.comboBoxDataType);
            this.Controls.Add(this.labelDataType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelHasTagTypes);
            this.Controls.Add(this.dataGridTagTypeList);
            this.Controls.Add(this.buttonRemoveTagType);
            this.Controls.Add(this.buttonModifyTagType);
            this.Controls.Add(this.buttonCreateTagType);
            this.Name = "FormTags";
            this.Text = "ImageSource - Tag Types";
            this.Load += new System.EventHandler(this.FormTags_Load);
            ( (System.ComponentModel.ISupportInitialize)( this.dataGridTagTypeList ) ).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateTagType;
        private System.Windows.Forms.Button buttonModifyTagType;
        private System.Windows.Forms.Button buttonRemoveTagType;
        private System.Windows.Forms.DataGridView dataGridTagTypeList;
        private System.Windows.Forms.Label labelHasTagTypes;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelDataType;
        private System.Windows.Forms.ComboBox comboBoxDataType;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelInUse;
    }
}