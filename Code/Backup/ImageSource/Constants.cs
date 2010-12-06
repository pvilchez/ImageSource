using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    class Constants
    {
        #region Search Constants

        public static readonly DateTime DATE_START_NULL = DateTime.MinValue;
        public static readonly DateTime DATA_END_NULL   = DateTime.MaxValue;

        #endregion

        #region Datatypes

        public const int DATATYPE_INT    = 1;
        public const int DATATYPE_DATE   = 2;
        public const int DATATYPE_STRING = 3;

        #endregion

        #region Strings

        public static readonly string STRING_NO             = "No";
        public static readonly string STRING_YES            = "Yes";
        public static readonly string STRING_TAGTYPE_REMOVE = "Are you sure you wish to remove this\ntag type, and all associated tags?";
        public static readonly string STRING_CONFIRM_TITLE  = "Confirm";
        public static readonly string STRING_CONFIRM_PROMPT = "Are you sure you wish to perform the\nrequested action?";

        #endregion

        #region File Paths

        public static readonly string FILE_TAGS     = "c:\\ImageSource\\tags.xml";
        public static readonly string FILE_TAGTYPES = "c:\\ImageSource\\tagTypes.xml";
        public static readonly string FILE_IMAGES   = "c:\\ImageSource\\images.xml";

        #endregion
    }
}
