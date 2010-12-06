using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace ImageSource
{
    /// <summary>
    /// Controller for "FormImageEdit" form.
    /// </summary>
    public partial class FormImageEdit : Form
    {
        private SourceImage sourceImage;
        private SourceImageOrganizer sourceImageOrganizer;
        private ImageBox imageBox1;
        private DenseHistogram histogram;

        private FormImageTags formImageTags;
        
        private Point _mouseDownPosition;
        private MouseButtons _mouseDownButton;
        private HScrollBar horizontalScrollBar = new HScrollBar();
        private VScrollBar verticalScrollBar = new VScrollBar();
        private static readonly Cursor _defaultCursor = Cursors.Cross;

        /// <summary>
        /// Constructor.  No image will be displayed.  No further actions will be possible.
        /// </summary>
        public FormImageEdit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor.  The image provided will be automatically displayed when the form is shown.
        /// </summary>
        /// <param name="image">The image to be displayed when the window is shown.</param>
        public FormImageEdit( SourceImage image )
        {
            InitializeComponent();

            //setup the window and variables
            sourceImage = image;
            labelFileNameData.Text = sourceImage.name;
            this.Text += " ( " + sourceImage.name + " ) ";
            sourceImageOrganizer = SourceImageOrganizer.getInstance();

            //setup the ImageBox and the picture it will display
            imageBox1 = new ImageBox();
            imageBox1.Image = new Image<Bgr, byte>(sourceImage.path);
            imageBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            imageBox1.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            imageBox1.MouseDown += new MouseEventHandler(imageBox1_MouseDown);
            imageBox1.MouseUp += new MouseEventHandler(imageBox1_MouseUp);

            //setup the image panel, add the image
            //this is necessary for scroll bars
            panelImagePanel.AutoScroll = true;
            panelImagePanel.Controls.Add(imageBox1);

            showHistogram();
        }

        //Performed when form is loaded.
        private void FormImageEdit_Load( object sender, EventArgs e )
        {
            //Placeholder
        }

        //Handler for clicking the 'Scale' button.
        private void buttonScale_Click( object sender, EventArgs e )
        {
            //read scaling factor from text box
            Double scaleFactor;
            scaleFactor = Double.Parse(textBoxScalingFactor.Text);

            //Scale the image, and set the picturebox
            Image<Bgr,byte> temp = new Image<Bgr, byte>(sourceImage.path).Resize(scaleFactor, INTER.CV_INTER_LINEAR);
            imageBox1.Image = temp;
            imageBox1.Refresh();
        }

        //Handler for the MouseDown event.
        private void imageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //Record the current location of the Mouse, to be used in grayscale
            _mouseDownButton = e.Button;
            _mouseDownPosition = e.Location;
        }

        //Handler for the MouseUp event
        private void imageBox1_MouseUp(object sender, MouseEventArgs e)
        {
            //If the this and the previous MouseDown event was triggered by a left mouse click
            if (_mouseDownButton == MouseButtons.Left && e.Button == MouseButtons.Left)
            {
                //Find the region of interest (x1,y1)->top left, (x2,y2)->bottom right
                int x1 = Math.Min(_mouseDownPosition.X, e.Location.X);
                int x2 = Math.Max(_mouseDownPosition.X, e.Location.X);
                int y1 = Math.Min(_mouseDownPosition.Y, e.Location.Y);
                int y2 = Math.Max(_mouseDownPosition.Y, e.Location.Y);

                if (x1 != x2 || y1 != y2)
                {
                    Rectangle newROI = new Rectangle(x1, y1, x2 - x1, y2 - y1);

                    //Set the region of interest and perform covnersion
                    Image<Bgr, byte> newImage = imageBox1.Image as Image<Bgr, byte>;
                    newImage.ROI = newROI;
                    Image<Bgr, byte> demo = newImage.Convert<Gray, byte>().Convert<Bgr, byte>();

                    //Copy converted section on top of original image.
                    CvInvoke.cvCopy(demo.Ptr, newImage.Ptr, IntPtr.Zero);

                    //Redraw the image, histogram
                    imageBox1.Refresh();
                    showHistogram();
                }
            }
        }
        
        //Handler for clicking the 'Save' button
        private void buttonSaveButton_Click(object sender, EventArgs e)
        {
            // Configure open file dialog box 
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = sourceImage.name;
            dlg.DefaultExt = ".jpg";                   // Default file extension 
            dlg.OverwritePrompt = true;                // Prompt user before overwriting
            dlg.Filter = Constants.FILE_FILTER_IMAGES; // Filter files by extension 

            //If the user clicked "OK"
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string newFile = dlg.FileName;

                Image<Bgr, byte> newImage = imageBox1.Image as Image<Bgr, byte>;

                //Overwrite the original if the same name, else create separate file.
                if (newFile.Equals(sourceImage.path) != true)
                {
                    //Adds the new image to ImageSource
                    sourceImageOrganizer.addImage(newFile.Substring(newFile.LastIndexOf('\\')+1), newFile);
                }
                newImage.Save(dlg.FileName);
            }   
        }

        //Method to recalculate and redisplay the histogram
        private void showHistogram()
        {
            //create the histogram
            histogram = new DenseHistogram(16, new RangeF(0, 255));
            //Clear out an old histogram, if one exists
            //If this is not done, histogram calculated on ROI
            histogramBox1.ClearHistogram();
            histogramBox1.Refresh();

            //Clear the ROI, if one exists
            (imageBox1.Image as Image<Bgr, byte> ).ROI = Rectangle.Empty;
            histogramBox1.GenerateHistograms( imageBox1.Image, 256);
            histogramBox1.Refresh();
        }

        //Handler for the image panel being repainted
        private void panelImagePanel_Paint(object sender, PaintEventArgs e)
        {
            //Placeholder
        }

        //Handler for clicking the 'Tags' button
        private void buttonTags_Click(object sender, EventArgs e)
        {
            //only create the form once.  It will be reused until image editing complete.
            if (formImageTags == null)
            {
                formImageTags = new FormImageTags(sourceImage);
            }

            formImageTags.ShowDialog();
        }

        //Handler for closing the window.
        private void FormImageEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Dispose of this once it is closed; it will be recreatd if the user chooses to
            //edit this image
            formImageTags.Dispose();
        }
    }
}
