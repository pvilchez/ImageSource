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
    public partial class FormStartWindow : Form
    {
        private FormTags formTags = new FormTags();
        private FormImages formImages = new FormImages();

        public FormStartWindow()
        {
            InitializeComponent();
        }

        private void buttonTags_Click( object sender, EventArgs e )
        {
            formTags.Show();
        }

        private void buttonImages_Click( object sender, EventArgs e )
        {
            formImages.Show();
        }
    }
}
