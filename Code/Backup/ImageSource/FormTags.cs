using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ImageSource
{
    public partial class FormTags : Form
    {
        private TagOrganizer tagOrganizer;
        private ArrayList tagTypeList;
        private bool createMode = true;

        private ArrayList dataTypes = new ArrayList(50);

        public FormTags()
        {
            InitializeComponent();

            dataTypes.Add("Integer");
            dataTypes.Add("Date");
            dataTypes.Add("String");

            comboBoxDataType.DataSource = dataTypes;

            tagOrganizer = TagOrganizer.getInstance();
            refreshTagTypeList();

            //Add a handler to make sure that the window doesn't get destroyed when it's closed
            this.FormClosing += new FormClosingEventHandler(FormTags_FormClosing);
        }

        private void FormTags_Load( object sender, EventArgs e )
        {
        }

        private void FormTags_FormClosing( object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void buttonRemoveTagType_Click( object sender, EventArgs e )
        {
            ConfirmDialog dialog = new ConfirmDialog( Constants.STRING_YES
                                                    , Constants.STRING_NO
                                                    , Constants.STRING_TAGTYPE_REMOVE
                                                    , Constants.STRING_CONFIRM_TITLE
                                                    , removeTagType
                                                    , noAction
                                                    );
            dialog.ShowDialog();
        }

        private void removeTagType( object sender, EventArgs e )
        {
            if (tagTypeList.Count > 0 && dataGridTagTypeList.SelectedCells.Count != 0)
            {
                tagOrganizer.removeTagType(dataGridTagTypeList.SelectedCells[0].Value.ToString());
            }

            refreshTagTypeList();
        }

        private void refreshTagTypeList()
        {
            tagTypeList = tagOrganizer.getTagTypeList();
            dataGridTagTypeList.DataSource = tagTypeList;

            buttonRemoveTagType.Enabled = tagTypeList.Count > 0 ? true : false;
            buttonModifyTagType.Enabled = tagTypeList.Count > 0 ? true : false;
            labelHasTagTypes.Visible = tagTypeList.Count > 0 ? false : true;
        }

        private void noAction( object sender, EventArgs e )
        {
            refreshTagTypeList();
        }

        private void buttonCreateTagType_Click( object sender, EventArgs e )
        {
            createMode = true;
            switchToEdit();

            textBoxName.Text = "";
            comboBoxDataType.SelectedIndex = 0;
        }

        private void buttonModifyTagType_Click( object sender, EventArgs e )
        {
            createMode = false;
            switchToEdit();

            textBoxName.Text = dataGridTagTypeList.SelectedCells[0].Value.ToString();
            comboBoxDataType.SelectedIndex = (dataGridTagTypeList.SelectedCells[1].Value as TagType).dataType - 1;
        }

        private void switchToEdit()
        {
            //turning off components
            buttonCreateTagType.Visible = false;
            buttonModifyTagType.Visible = false;
            buttonRemoveTagType.Visible = false;

            dataGridTagTypeList.Visible = false;

            labelHasTagTypes.Visible = false;

            //turning on components
            buttonSave.Visible = true;
            buttonCancel.Visible = true;

            labelName.Visible = true;
            labelDataType.Visible = true;

            textBoxName.Visible = true;
            comboBoxDataType.Visible = true;

            if (createMode)
            {
                textBoxName.Enabled = true;
            }
            else
            {
                textBoxName.Enabled = false;
            }
        }

        private void switchToList()
        {
            //turning off components
            buttonCreateTagType.Visible = true;
            buttonModifyTagType.Visible = true;
            buttonRemoveTagType.Visible = true;

            dataGridTagTypeList.Visible = true;

            //turning on components
            buttonSave.Visible = false;
            buttonCancel.Visible = false;

            labelName.Visible = false;
            labelDataType.Visible = false;

            textBoxName.Visible = false;
            comboBoxDataType.Visible = false;

            refreshTagTypeList();
        }

        private void buttonSave_Click( object sender, EventArgs e )
        {
            if (createMode)
            {
                bool inUse = false;


                if( tagTypeList.Count > 0 ) foreach (KeyValuePair<string, TagType > type in tagTypeList)
                {
                    if (type.Value.name.Equals(textBoxName.Text) == true)
                    {
                        inUse = true;
                        break;
                    }
                }

                if( !inUse )
                {
                    tagOrganizer.addTagType(textBoxName.Text, comboBoxDataType.SelectedIndex + 1);
                    labelInUse.Visible = false;
                }
                else
                {
                    labelInUse.Visible = true;
                }
            }
            else
            {
                tagOrganizer.changeTagType(textBoxName.Text, comboBoxDataType.SelectedIndex + 1);

                
            }

            switchToList();
        }

        private void buttonCancel_Click( object sender, EventArgs e )
        {
            labelInUse.Visible = false;
            switchToList();
        }
    }
}
