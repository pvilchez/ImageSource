using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace ImageSource
{
    /// <summary>
    /// Controller for "FormImages" form.
    /// </summary>
    public partial class FormImages : Form
    {
        private SourceImageOrganizer sourceImageOrganizer;
        private TagOrganizer tagOrganizer;

        //form to edit a particular image
        private FormImageEdit formImageEdit;

        private ArrayList imageList;
        private ArrayList tagTypeList;
        private Dictionary<string, TagType> tagTypeDictionary;

        /// <summary>
        /// Constructor.  This gets instances of necessary classes, gets
        /// lists of tag types and images, and add a closing handler.
        /// </summary>
        public FormImages()
        {
            InitializeComponent();

            //Get instances
            sourceImageOrganizer = SourceImageOrganizer.getInstance();
            tagOrganizer = TagOrganizer.getInstance();

            //Add a handler to make sure that the window doesn't get destroyed when it's closed
            this.FormClosing += new FormClosingEventHandler(FormImages_FormClosing);

            //get tag type and image lists
            refreshTagTypeList();
            refreshImageList();
        }

        //Handler for clicking the "Import" button
        private void buttonImport_Click( object sender, EventArgs e )
        {
            //setup the file filter
            importFileDialog.Filter = Constants.FILE_FILTER_IMAGES;

            //launch the dialog, verify the user chose an image
            if (importFileDialog.ShowDialog() == DialogResult.OK)
            {
                //add the image
                //the organizer handles ensuring the image doesn't already exist
                sourceImageOrganizer.addImage(importFileDialog.SafeFileName, importFileDialog.FileName);
            }

            //get the new image list
            refreshImageList();
        }

        //Function to get a new list of images
        private void refreshImageList()
        {
            //get a new list, reset the datagrid
            imageList = sourceImageOrganizer.getImageList();
            dataGridImages.DataSource = imageList;

            //enable / disable buttons based on number of images
            buttonRemoveImage.Enabled = imageList.Count > 0 ? true : false;
            buttonEditImage.Enabled = imageList.Count > 0 ? true : false;
            labelHasImages.Visible = imageList.Count > 0 ? false : true;
        }

        //Function to get a new list of tag types
        private void refreshTagTypeList()
        {
            //get a new tag list
            tagTypeList = tagOrganizer.getTagTypeList();

            //setup the combobox to contain all tag types, with a blank first
            tagTypeDictionary = new Dictionary<string, TagType>();
            tagTypeDictionary.Add("", null);
            foreach(KeyValuePair<string, TagType> kvp in tagTypeList)
            {
                tagTypeDictionary.Add(kvp.Key, kvp.Value);
            }

            comboBoxTagType.DataSource = tagTypeDictionary.Keys.ToList();
        }

        //Handler for clicking the "Edit Image" button
        private void buttonEditImage_Click( object sender, EventArgs e )
        {
            //Show a new FormImageEdit form, using the selected image
            SourceImage image = ( dataGridImages.SelectedCells[1].Value as SourceImage );
            formImageEdit = new FormImageEdit(image);

            formImageEdit.ShowDialog();
        }

        //Handler for clicking the "Remove Image" button
        private void buttonRemoveImage_Click( object sender, EventArgs e )
        {
            ConfirmDialog confirm = new ConfirmDialog( Constants.STRING_YES
                                                     , Constants.STRING_NO
                                                     , Constants.STRING_IMAGE_REMOVE
                                                     , Constants.STRING_CONFIRM_TITLE
                                                     , removeImage
                                                     , noAction
                                                     );

            confirm.ShowDialog();
        }

        /// <summary>
        /// Function called to remove an image.  This is used for the positive
        /// action for confirming to remove of an image from ImageSource.
        /// </summary>
        /// <param name="sender">The object which triggered the event.</param>
        /// <param name="e">The event details.</param>
        public void removeImage( object sender, EventArgs e )
        {
            sourceImageOrganizer.removeImage(dataGridImages.SelectedCells[0].Value.ToString());
            refreshImageList();
        }

        /// <summary>
        /// This function only gets a new image list.  This is used for the
        /// negative action for confirming the removal of an image from ImageSource.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void noAction( object sender, EventArgs e )
        {
            refreshImageList();
        }

        //Handler for changing the selected index of the "Tag Type" dropdown
        //used for searching.
        private void comboBoxTagType_SelectedIndexChanged( object sender, EventArgs e )
        {
            //If a tag is selected
            if(comboBoxTagType.SelectedValue.ToString().Equals("") != true)
            {
                //show and hide controls based on data type of selected tag type
                switch(tagTypeDictionary[comboBoxTagType.SelectedValue.ToString()].dataType)
                {
                    case Constants.DATATYPE_DATE:
                        labelLower.Text = Constants.STRING_LOWERBOUND_DATE;
                        labelUpper.Text = Constants.STRING_UPPERBOUND_DATE;

                        labelLower.Visible   = true;
                        labelUpper.Visible   = true;
                        textBoxLower.Visible = true;
                        textBoxUpper.Visible = true;
                        break;
                    case Constants.DATATYPE_INT:
                        labelLower.Text = Constants.STRING_LOWERBOUND_INT;
                        labelUpper.Text = Constants.STRING_UPPERBOUND_INT;

                        labelLower.Visible   = true;
                        labelUpper.Visible   = true;
                        textBoxLower.Visible = true;
                        textBoxUpper.Visible = true;
                        break;
                    case Constants.DATATYPE_STRING:
                        labelLower.Text = Constants.STRING_BOUND_STRING;

                        labelLower.Visible   = true;
                        labelUpper.Visible   = false;
                        textBoxLower.Visible = true;
                        textBoxUpper.Visible = false;
                        break;
                    default:
                        labelLower.Visible   = false;
                        labelUpper.Visible   = false;
                        textBoxLower.Visible = false;
                        textBoxLower.Visible = false;
                        break;
                }

                //enable the "Search" button
                buttonSortTags.Enabled = true;
            }
            //if no tag is selected, hide all search controls,
            //disable "Search" button
            else
            {
                labelLower.Visible     = false;
                labelUpper.Visible     = false;
                textBoxLower.Visible   = false;
                textBoxUpper.Visible   = false;
                buttonSortTags.Enabled = false;

                refreshImageList();
            }
            textBoxLower.Text = "";
            textBoxUpper.Text = "";
        }

        //Handler for clicking the "Reset" button on search.
        private void buttonReset_Click( object sender, EventArgs e )
        {
            //just change the selected index; handler will take care of the rest
            comboBoxTagType.SelectedIndex = 0;
        }

        //Handler for clicking the "Search" button
        private void buttonSortTags_Click( object sender, EventArgs e )
        {
            //call sort method using the data type of the selected image.
            switch(tagTypeDictionary[comboBoxTagType.SelectedValue.ToString()].dataType)
            {
                case Constants.DATATYPE_DATE:
                    DateTime lowerDate, upperDate;
                    if(textBoxLower.Text.Length > 0)
                    {
                        lowerDate = DateTime.Parse(textBoxLower.Text); 
                    }
                    else
                    {
                        lowerDate = DateTime.MinValue;
                    }
                    if(textBoxUpper.Text.Length > 0)
                    {
                        upperDate = DateTime.Parse(textBoxUpper.Text);
                    }
                    else
                    {
                        upperDate = DateTime.MaxValue;
                    }
                    imageList = tagOrganizer.sortTags(tagTypeDictionary[comboBoxTagType.SelectedValue.ToString()], lowerDate, upperDate);
                    break;
                case Constants.DATATYPE_INT :
                    int lowerInt, upperInt;
                    if(textBoxLower.Text.Length > 0)
                    {
                        lowerInt = int.Parse(textBoxLower.Text);
                    }
                    else
                    {
                        lowerInt = int.MinValue;
                    }
                    if(textBoxUpper.Text.Length > 0)
                    {
                        upperInt = int.Parse(textBoxUpper.Text);
                    }
                    else
                    {
                        upperInt = int.MaxValue;
                    }
                    imageList = tagOrganizer.sortTags(tagTypeDictionary[comboBoxTagType.SelectedValue.ToString()], lowerInt, upperInt);
                    break;
                case Constants.DATATYPE_STRING :
                default:
                    string containsString = textBoxLower.Text;
                    imageList = tagOrganizer.sortTags(tagTypeDictionary[comboBoxTagType.SelectedValue.ToString()], containsString);
                    break;
            }

            dataGridImages.DataSource = imageList;
        }

        //Handler for closing the window
        private void FormImages_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Just hide, don't close
            //This way it only need to be created once
            this.Hide();
            e.Cancel = true;
        }
    }
}
