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
    /// Controller for the "FormImageTags" form.
    /// </summary>
    public partial class FormImageTags : Form
    {
        private bool applyMode = false;
        private ArrayList tagList;
        private ArrayList tagTypeList;
        private Dictionary< string, TagType > availableTagTypes;
        private TagOrganizer tagOrganizer;
        private SourceImage sourceImage;

        /// <summary>
        /// Constructor.  This will cause an exception to be thrown, .
        /// since an image must be provided.
        /// </summary>
        public FormImageTags()
        {
            InitializeComponent();

            //This can't run without an image
            throw new Exception("An image must be provided!");
        }

        /// <summary>
        /// Constructor.  The image provided will be used to search
        /// for tags applied to the image.
        /// </summary>
        /// <param name="image">The image the tags apply to.</param>
        public FormImageTags( SourceImage image )
        {
            InitializeComponent();

            //set the source image
            sourceImage = image;

            //get a TagOrganizer instance
            tagOrganizer = TagOrganizer.getInstance();

            //add closing handler
            this.FormClosing += new FormClosingEventHandler(FormImageTags_FormClosing);

            //get new taglist
            refreshTagList();
        }

        //Function used to switch to tag list view
        private void switchToEdit()
        {
            //turn off components
            buttonApplyTags.Visible = false;
            buttonModifyTag.Visible = false;
            buttonRemoveTag.Visible = false;
            labelNoTags.Visible     = false;
            dataGridTags.Visible    = false;

            //turn on components
            labelTagName.Visible  = true;
            labelTagValue.Visible = true;
            labelDataType.Visible = true;
            comboBoxTags.Visible  = true;
            textBoxValue.Visible  = true;
            buttonSave.Visible    = true;
            buttonCancel.Visible  = true;

            if (applyMode)
            {
                comboBoxTags.Visible = true;
                labelTagNameData.Visible = false;
            }
            else
            {
                comboBoxTags.Visible     = false;
                labelTagNameData.Text = dataGridTags.SelectedCells[0].Value.ToString();
                labelDataType.Text = ( dataGridTags.SelectedCells[1].Value as Tag ).tagType.ToString();
                labelTagNameData.Visible = true;              
            }
        }

        //Function used to switch to tag edit / apply view
        private void switchToList()
        {
            //turn off components
            labelTagName.Visible     = false;
            labelTagValue.Visible    = false;
            comboBoxTags.Visible     = false;
            textBoxValue.Visible     = false;
            buttonSave.Visible       = false;
            buttonCancel.Visible     = false;
            labelTagNameData.Visible = false;
            labelDataType.Visible    = false;

            //turn on components
            buttonApplyTags.Visible = true;
            buttonModifyTag.Visible = true;
            buttonRemoveTag.Visible = true;
            dataGridTags.Visible    = true;

            refreshTagList();
        }

        //Function used to retrieve a new tag list
        private void refreshTagList()
        {
            //get tagTypes
            tagTypeList = tagOrganizer.getTagTypeList();

            //get tags
            tagList = tagOrganizer.getTagList( sourceImage.name );
            dataGridTags.DataSource = tagList;

            //show label if no tags, or no tag types.
            labelNoTags.Text = tagTypeList.Count > 0 ? "No tags have been applied to this image." : "No tag types have been created.";
            labelNoTags.Visible = tagList.Count > 0 ? false : true;

            //enable and disable buttons
            buttonApplyTags.Enabled = tagList.Count < tagTypeList.Count ? true : false; ;
            buttonModifyTag.Enabled = tagList.Count > 0 ? true : false;
            buttonRemoveTag.Enabled = tagList.Count > 0 ? true : false;
        }

        //Handler for clicking the "Save" button when in edit / apply view
        private void buttonSave_Click( object sender, EventArgs e )
        {
            //If applying a tag
            if(applyMode)
            {
                tagOrganizer.addTag(sourceImage.name, comboBoxTags.SelectedValue.ToString(), textBoxValue.Text);
            }
            //If editing a tag
            else
            {
                tagOrganizer.changeTag(sourceImage.name, labelTagNameData.Text, textBoxValue.Text);
            }

            //Switch back to the list view
            switchToList();
        }

        //Handler for clicking the "Cancel" button when in edit / apply view
        private void buttonCancel_Click( object sender, EventArgs e )
        {
            //Just switch back to the list
            switchToList();
        }

        //Handler for clicking the "Remove Tag" button
        private void buttonRemoveTag_Click( object sender, EventArgs e )
        {
            //Confirm the removal
            ConfirmDialog confirm = new ConfirmDialog( Constants.STRING_YES
                                                     , Constants.STRING_NO
                                                     , Constants.STRING_TAG_REMOVE
                                                     , Constants.STRING_CONFIRM_TITLE
                                                     , removeTag
                                                     , noAction
                                                     );

            confirm.ShowDialog();
        }

        /// <summary>
        /// This function removes the image tag from ImageSource.  This is 
        /// used as the postive action when confirming an image removal.
        /// </summary>
        /// <param name="sender">The object which triggered the event</param>
        /// <param name="e">The event details</param>
        public void removeTag( object sender, EventArgs e )
        {
            //delete the tag
            if(tagList.Count > 0 && dataGridTags.SelectedCells.Count > 0)
            {
                tagOrganizer.removeTag(sourceImage.name, ( dataGridTags.SelectedCells[1].Value as Tag ));
            }

            //refresh the list of tags
            refreshTagList();
        }

        /// <summary>
        /// This function only refetches the tag list for the image. It
        /// is used as the negative action when confirming an image removal.
        /// </summary>
        /// <param name="sender">The object which triggered the event</param>
        /// <param name="e">The event details</param>
        public void noAction( object sender, EventArgs e)
        {
            //Just get a new tag list
            refreshTagList();
        }

        //Handler for clicking the "Modify Tag" button.
        private void buttonModifyTag_Click( object sender, EventArgs e )
        {
            //Setup the control values
            labelTagNameData.Text = dataGridTags.SelectedCells[0].Value.ToString();
            textBoxValue.Text = dataGridTags.SelectedCells[1].Value.ToString();
            
            //set edit mode
            applyMode = false;

            //switch to edit view
            switchToEdit();
        }

        //Handler for clicking the "Apply Tag" button
        private void buttonApplyTags_Click( object sender, EventArgs e )
        {
            //set apply mode;
            applyMode = true;

            //clear controls
            textBoxValue.Text = "";

            //retrieve a full list of tag types
            availableTagTypes = new Dictionary<string, TagType>();
            foreach(KeyValuePair<string, TagType> kvp in tagTypeList)
            {
                availableTagTypes.Add(kvp.Key, kvp.Value);
            }
            //remove each tag type already applied to the image
            foreach( KeyValuePair<string, Tag> kvp in tagList )
            {
                availableTagTypes.Remove(kvp.Value.tagType.name);
            }

            //reset the dropdown
            comboBoxTags.DataSource = availableTagTypes.Keys.ToList();

            //switch the editing view
            switchToEdit();
        }

        //Handler for changing selection in Tag Type dropdown list
        private void comboBoxTags_SelectedIndexChanged( object sender, EventArgs e )
        {
            //Change the label describing data type based on selection
            labelDataType.Text = availableTagTypes[comboBoxTags.SelectedValue.ToString()].ToString();
        }

        //Handler for closing the form
        private void FormImageTags_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Just hide the form, don't close it
            //this way it only need to be created once
            this.Hide();
            e.Cancel = true;
        }
    }
}
