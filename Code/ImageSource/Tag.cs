using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    /// <summary>
    /// The Tag class hold all information about a particular 
    /// tag which has been applied to an image.
    /// </summary>
    class Tag
    {
        private TagType _tagType;
        private object _tagValue;

        /// <summary>
        /// Create a new Tag object with the specified TagType and value.
        /// </summary>
        /// <param name="type">The TagType of the image.</param>
        /// <param name="val">The value of the tag applied to an image.</param>
        public Tag( TagType type, object val )
        {
            _tagType  = type;
            _tagValue = val;
        }

        /// <summary>
        /// Gets and sets the value of the tag.  The type of tagValue must be the
        /// same as the type specified by tagType.dataType.
        /// </summary>
        public object tagValue
        {
            get
            {
                return _tagValue;
            }
            set
            {
                _tagValue = value;
            }
        }

        /// <summary>
        /// Gets or sets the TagType of the Tag.  When tagType is set, the tagValue
        /// is automatically set to null.
        /// </summary>
        public TagType tagType
        {
            get
            {
                return _tagType;
            }
            set
            {
                _tagType = value;
                _tagValue = null;
            }
        }

        /// <summary>
        /// Returns the tagValue of the Tag.
        /// </summary>
        /// <returns>The tagValue of the Tag</returns>
        public override string ToString()
        {
            return _tagValue.ToString();
        }
    }
}
