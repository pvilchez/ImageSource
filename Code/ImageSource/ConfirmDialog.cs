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
    /// Controller for the "ConfirmDialog" form.
    /// </summary>
    public partial class ConfirmDialog : Form
    {
        /// <summary>
        /// A confirm dialog to be presented to the user.  Default strings are used for all fields.
        /// </summary>
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

        /// <summary>
        /// A confirm dialog to be presented to the user.  Custom strings are used for all fields.
        /// Additionally, custom handlers for the 'Yes' and 'No' answer buttons can be supplied.
        /// </summary>
        /// <param name="yes">The text to appear on the 'Yes' answer button</param>
        /// <param name="no">The text to appear on the 'No' answer button</param>
        /// <param name="prompt">The text to appear as a prompt for the user to confirm</param>
        /// <param name="title">The text to appear as title to the window</param>
        /// <param name="yesHandler">The handler to run when the 'Yes' answer button is pressed.</param>
        /// <param name="noHandler">The handler to run when the 'No' answer button is pressed.</param>
        public ConfirmDialog( string yes, string no, string prompt, string title, EventHandler<EventArgs> yesHandler, EventHandler<EventArgs> noHandler)
        {
            InitializeComponent();

            //Set the custom text fields.
            this.Text = title;
            buttonNo.Text = no;
            buttonYes.Text = yes;
            labelPrompt.Text = prompt;

            buttonYes.Click += new EventHandler(buttonYes_Click);
            buttonNo.Click += new EventHandler(buttonNo_Click);

            //Set the custom button handlers, if they exist.
            if (yesHandler != null)
            {
                buttonYes.Click += new EventHandler(yesHandler);
            }
            if (noHandler != null)
            {
                buttonNo.Click += new EventHandler(noHandler);
            }
        }


        private void ConfirmDialog_Load( object sender, EventArgs e )
        {
            //Placeholder
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
