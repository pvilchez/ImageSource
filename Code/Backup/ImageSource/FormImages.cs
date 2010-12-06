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
    public partial class FormImages : Form
    {
        private SourceImageOrganizer sourceImageOrganizer;

        private FormImageEdit formImageEdit;

        private ArrayList imageList;

        public FormImages()
        {
            InitializeComponent();

            sourceImageOrganizer = SourceImageOrganizer.getInstance();

            refreshImageList();
        }

        private void buttonImport_Click( object sender, EventArgs e )
        {
            if (importFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceImageOrganizer.addImage(importFileDialog.SafeFileName, importFileDialog.FileName);
            }

            refreshImageList();
        }

        private void refreshImageList()
        {
            imageList = sourceImageOrganizer.getImageList();
            dataGridImages.DataSource = imageList;

            buttonRemoveImage.Enabled = imageList.Count > 0 ? true : false;
            buttonEditImage.Enabled = imageList.Count > 0 ? true : false;
            labelHasImages.Visible = imageList.Count > 0 ? false : true;
        }

        private void buttonEditImage_Click( object sender, EventArgs e )
        {
            SourceImage image = ( dataGridImages.SelectedCells[1].Value as SourceImage );
            formImageEdit = new FormImageEdit(image);

            formImageEdit.ShowDialog();
        }
    }
}
