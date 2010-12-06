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
    public partial class FormImageEdit : Form
    {
        private SourceImage sourceImage;

        public FormImageEdit()
        {
            InitializeComponent();
        }

        public FormImageEdit( SourceImage image )
        {
            InitializeComponent();

            sourceImage = image;
            labelFileNameData.Text = sourceImage.name;
            this.Text += " ( " + sourceImage.name + " ) ";

            //TODO - KR - Remove when finished
            //also remove the text box, label
            textBoxPath.Text = sourceImage.path;
        }

        private void FormImageEdit_Load( object sender, EventArgs e )
        {

        }

        private void buttonScale_Click( object sender, EventArgs e )
        {
            //TODO - PV - Do the scaling here
            //for now, just use hardcoded values (like, scale by 0.5,0.5)
        }

        private void buttonCrop_Click( object sender, EventArgs e )
        {
            //TODO - PV - Do the cropping here
            //I'm not sure how this one will work...good luck?
        }
    }
}
