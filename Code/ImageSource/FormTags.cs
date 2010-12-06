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
    /// <summary>
    /// Controller for "FormTags" form.
    /// </summary>
    public partial class FormTags : Form
    {
        private TagOrganizer tagOrganizer;
        private ArrayList tagTypeList;

        //controls which controls displayed when editing/creating
        private bool createMode = true;

        private ArrayList dataTypes = new ArrayList(50);

        /// <summary>
        /// Constructor.  Sets up the TagOrganizer, sets up comboboxes, and adds closing handler.
        /// </summary>
        public FormTags()
        {
            InitializeComponent();

            //Add datatypes for the "DataType" dropdown
            dataTypes.Add("Integer");
            dataTypes.Add("Date");
            dataTypes.Add("String");
            comboBoxDataType.DataSource = dataTypes;

            //get an instance of the tagOrganizer for this class
            tagOrganizer = TagOrganizer.getInstance();

            //Add a handler to make sure that the window doesn't get destroyed when it's closed
            this.FormClosing += new FormClosingEventHandler(FormTags_FormClosing);

            //Get the tag types
            refreshTagTypeList();
        }

        //Handler for when the form is loaded.
        private void FormTags_Load( object sender, EventArgs e )
        {
            //Placeholder
        }

        //Handler for when the form is closed.
        private void FormTags_FormClosing( object sender, FormClosingEventArgs e)
        {
            //Hide the form instead of actually closing it. 
            //This way, it only needs to be created once.
            this.Hide();
            e.Cancel = true;
        }

        //Handler for clicking the "Remove Tag Type" button
        private void buttonRemoveTagType_Click( object sender, EventArgs e )
        {
            //Confirm the choice
            ConfirmDialog dialog = new ConfirmDialog( Constants.STRING_YES
                                                    , Constants.STRING_NO
                                                    , Constants.STRING_TAGTYPE_REMOVE
                                                    , Constants.STRING_CONFIRM_TITLE
                                                    , removeTagType
                                                    , noAction
                                                    );
            dialog.ShowDialog();
        }

        //Handler for user confirming to remove the tag type.
        private void removeTagType( object sender, EventArgs e )
        {
            //Only remove if something is selected
            if (tagTypeList.Count > 0 && dataGridTagTypeList.SelectedCells.Count != 0)
            {
                tagOrganizer.removeTagType(dataGridTagTypeList.SelectedCells[0].Value.ToString());
            }

            //Get the new tagtype list
            refreshTagTypeList();
        }

        //Function to retrieve a new list of tag types.
        private void refreshTagTypeList()
        {
            //get a new tag type list for the TagOrganizer
            //reset the datasource for the datagrid
            tagTypeList = tagOrganizer.getTagTypeList();
            dataGridTagTypeList.DataSource = tagTypeList;

            //enable and disable buttons based on number of tags
            buttonRemoveTagType.Enabled = tagTypeList.Count > 0 ? true : false;
            buttonModifyTagType.Enabled = tagTypeList.Count > 0 ? true : false;
            labelHasTagTypes.Visible = tagTypeList.Count > 0 ? false : true;
        }

        //Handler for user cancelling the removal of tag type
        private void noAction( object sender, EventArgs e )
        {
            //Just get a new image list
            refreshTagTypeList();
        }

        //Handler for clicking the "Create Tag Type" button
        private void buttonCreateTagType_Click( object sender, EventArgs e )
        {
            //set create mode
            createMode = true;
            switchToEdit();

            //clear controls
            textBoxName.Text = "";
            comboBoxDataType.SelectedIndex = 0;
        }

        //Handler for clicking the "Modify Tag Type" button
        private void buttonModifyTagType_Click( object sender, EventArgs e )
        {
            //unset create mode
            createMode = false;

            //set controls to correct values
            textBoxName.Text = dataGridTagTypeList.SelectedCells[0].Value.ToString();
            comboBoxDataType.SelectedIndex = (dataGridTagTypeList.SelectedCells[1].Value as TagType).dataType - 1;

            switchToEdit();
        }

        //Function used to switch the form to editing or creating mode
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

        //Function used to switch the form to the tag type list mode
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

        //Handler for clicking the "Save" button when creating / editing tag types
        private void buttonSave_Click( object sender, EventArgs e )
        {
            //what to do if creating a tag
            if (createMode)
            {
                bool inUse = false;

                //search to see if the name is already being used
                if( tagTypeList.Count > 0 ) foreach (KeyValuePair<string, TagType > type in tagTypeList)
                {
                    if (type.Value.name.Equals(textBoxName.Text) == true)
                    {
                        inUse = true;
                        break;
                    }
                }

                //if it's not being used, add
                //return to list
                if( !inUse )
                {
                    tagOrganizer.addTagType(textBoxName.Text, comboBoxDataType.SelectedIndex + 1);
                    labelInUse.Visible = false;
                    switchToList();
                }
                //if it is being used, show a warning. 
                //Don't return to list
                else
                {
                    labelInUse.Visible = true;
                }
            }
            //what to do if editing a tag
            else
            {
                tagOrganizer.changeTagType(textBoxName.Text, comboBoxDataType.SelectedIndex + 1);
                switchToList();
            }
        }

        //Handler for clicking the "Cancel" button when creating / editing tag types
        private void buttonCancel_Click( object sender, EventArgs e )
        {
            //switch back to image list
            labelInUse.Visible = false;
            switchToList();
        }
    }
}
