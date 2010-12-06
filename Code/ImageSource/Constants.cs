using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    /// <summary>
    /// Constant values to be used throughout the ImageSource project.
    /// </summary>
    class Constants
    {
        #region Search Constants

        /// <summary>
        /// The minimum value of DateTime allowed.
        /// </summary>
        public static readonly DateTime DATE_START_NULL = DateTime.MinValue;
        /// <summary>
        /// The maximum value of DateTime allowed.
        /// </summary>
        public static readonly DateTime DATA_END_NULL   = DateTime.MaxValue;

        #endregion

        #region Datatypes

        /// <summary>
        /// Constant representing the 'Integer' datatype for tag types.
        /// </summary>
        public const int DATATYPE_INT    = 1;
        /// <summary>
        /// Constant representing the 'Date' datatype for tag types.
        /// </summary>
        public const int DATATYPE_DATE   = 2;
        /// <summary>
        /// Constant representing the 'String' datatype for tag types.
        /// </summary>
        public const int DATATYPE_STRING = 3;

        #endregion

        #region Strings

        /// <summary>
        /// Constant string used for 'No'
        /// </summary>
        public static readonly string STRING_NO              = "No";
        /// <summary>
        /// Constant string used for 'Yes'
        /// </summary>
        public static readonly string STRING_YES             = "Yes";
        /// <summary>
        /// Constant string used for prompting removal of tag types.
        /// </summary>
        public static readonly string STRING_TAGTYPE_REMOVE  = "Are you sure you wish to remove this\ntag type, and all associated tags?";
        /// <summary>
        /// Constant string used for prompting removal of tags.
        /// </summary>
        public static readonly string STRING_TAG_REMOVE      = "Are you sure you wish to remove the \nselected tag from this image?";
        /// <summary>
        /// Constant string used for prompting removal of images.
        /// </summary>
        public static readonly string STRING_IMAGE_REMOVE    = "Are you sure you wish to remove the \nselected image, and all associated\ntags?";
        /// <summary>
        /// Constant string used for 'Confirm'
        /// </summary>
        public static readonly string STRING_CONFIRM_TITLE   = "Confirm";
        /// <summary>
        /// Constant string used for prompting generic action.
        /// </summary>
        public static readonly string STRING_CONFIRM_PROMPT  = "Are you sure you wish to perform the\nrequested action?";
        /// <summary>
        /// Constant string used for lower search bound of 'Integer' datatype.
        /// </summary>
        public static readonly string STRING_LOWERBOUND_INT  = "Greater than ...";
        /// <summary>
        /// Constant string used for upper search bound of 'Integer' datatype.
        /// </summary>
        public static readonly string STRING_UPPERBOUND_INT  = "Less than ...";
        /// <summary>
        /// Constant string used for lower search bound of 'Date' datatype.
        /// </summary>
        public static readonly string STRING_LOWERBOUND_DATE = "Start Date ...";
        /// <summary>
        /// Constant string used for upper search bound of 'Date' datatype.
        /// </summary>
        public static readonly string STRING_UPPERBOUND_DATE = "End Date ...";
        /// <summary>
        /// Constant string used for search string of 'String' datatype.
        /// </summary>
        public static readonly string STRING_BOUND_STRING    = "Containing ...";


        #endregion

        #region File Paths

        /// <summary>
        /// Constant URI for tag reference file.
        /// </summary>
        //public static readonly string FILE_TAGS     = "h:\\ImageSource\\tags.xml";
        public static readonly string FILE_TAGS = Properties.Settings.Default.FILE_TAGS;
        /// <summary>
        /// Constant URI for tag type reference file.
        /// </summary>
        //public static readonly string FILE_TAGTYPES = "h:\\ImageSource\\tagTypes.xml";
        public static readonly string FILE_TAGTYPES = Properties.Settings.Default.FILE_TAGTYPES;
        /// <summary>
        /// Constant URI for image reference file.
        /// </summary>
        //public static readonly string FILE_IMAGES   = "h:\\ImageSource\\images.xml";
        public static readonly string FILE_IMAGES = Properties.Settings.Default.FILE_IMAGES;

        #endregion

        #region CONFIGURATION

        /// <summary>
        /// Constant file type filter for supported image types.
        /// </summary>
        public static readonly string FILE_FILTER_IMAGES = "Image Files (*.jpg, *.tiff, *.gif, *.bmp, *.png)|*.jpg;*.tiff;*.gif;*.bmp;*.png";

        #endregion
    }
}
