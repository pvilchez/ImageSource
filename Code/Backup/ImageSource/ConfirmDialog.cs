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
    public partial class ConfirmDialog : Form
    {
        public ConfirmDialog()
        {
            InitializeComponent();

            this.Text = Constants.STRING_CONFIRM_TITLE;
            buttonNo.Text = Constants.STRING_NO;
            buttonYes.Text = Constants.STRING_YES;
            labelPrompt.Text = Constants.STRING_CONFIRM_PROMPT;

            buttonYes.Click += new EventHandler(buttonYes_Click);
            buttonNo.Click += new EventHandler(buttonNo_Click);
        }

        public ConfirmDialog( string yes, string no, string prompt, string title, EventHandler<EventArgs> yesHandler, EventHandler<EventArgs> noHandler)
        {
            InitializeComponent();

            this.Text = title;
            buttonNo.Text = no;
            buttonYes.Text = yes;
            labelPrompt.Text = prompt;

            buttonYes.Click += new EventHandler(yesHandler);
            buttonYes.Click += new EventHandler(buttonYes_Click);
            buttonNo.Click += new EventHandler(noHandler);
            buttonNo.Click += new EventHandler(buttonNo_Click);
        }


        private void ConfirmDialog_Load( object sender, EventArgs e )
        {

        }

        private void buttonYes_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void buttonNo_Click( object sender, EventArgs e )
        {
            this.Close();
        }
    }
}
