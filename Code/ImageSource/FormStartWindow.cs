using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageSource
{
    /// <summary>
    /// Controller for "FromStartWindow" form.  This serves as the entry
    /// form for the ImageSource program.
    /// </summary>
    public partial class FormStartWindow : Form
    {
        //These persist for the life of the program
        private FormTags formTags = new FormTags();
        private FormImages formImages = new FormImages();

        /// <summary>
        /// Constructor.  Set the intro text for the user.
        /// </summary>
        public FormStartWindow()
        {
            InitializeComponent();

            //set intro text
            labelIntro.Text  = "To begin, please select one of the \noptions below.";
            labelImages.Text = "Click here to manage pictures.\nFrom here, you can import, edit,\nsearch and remove images.";
            labelTags.Text   = "Click here to manage tags.    \nFrom here, you can create, modify,\n and remove tag types.";
        }

        //Handler for clicking the "Tags" button
        private void buttonTags_Click( object sender, EventArgs e )
        {
            //Show the "FormTags" form
            formTags.Show();
        }

        //Handler for clicking the "Images" button
        private void buttonImages_Click( object sender, EventArgs e )
        {
            //Show the "FormImages" form
            formImages.Show();
        }
    }
}
