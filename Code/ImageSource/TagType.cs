using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    /// <summary>
    /// The TagType class is used to represent the name and datatype of any tag which
    /// can be applied to an image.  The name of each TagType in the list of Tag objects
    /// applied to an image must be unique to the image.
    /// </summary>
    class TagType
    {
        private int _dataType;
        private string _name;

        /// <summary>
        /// Create a new TagType with the specified datatype and name.
        /// The dataType can be one of:
        ///  - Constants.DATATYPE_INT
        ///  - Constants.DATATYPE_DATE
        ///  - Constants.DATATYPE_STRING
        /// </summary>
        /// <param name="dataType">The datatype of the TagType to be created.</param>
        /// <param name="name">The name of the TagType to be created.</param>
        public TagType( int dataType, string name )
        {
            _name = name;
            _dataType = dataType;
        }

        /// <summary>
        /// Gets the name of the TagType object.
        /// </summary>
        public string name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets and sets the datatype of the TagType object, as specified in Constants.  If 
        /// an incorrect value is supplied, a default of Constant.DATATYPE_STRING is used.
        /// </summary>
        public int dataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                switch (value)
                {
                    case Constants.DATATYPE_INT :
                        _dataType = Constants.DATATYPE_INT;
                        break;
                    case Constants.DATATYPE_DATE :
                        _dataType = Constants.DATATYPE_DATE;
                        break;
                    case Constants.DATATYPE_STRING :
                    default:
                        _dataType = Constants.DATATYPE_STRING;
                        break;
                }
            }
        }

        /// <summary>
        /// Returns textual representation of the dataType of the TagType object.
        /// </summary>
        /// <returns>The name of the TagType object's datatype</returns>
        public override string ToString()
        {
            switch (dataType)
            {
                case Constants.DATATYPE_DATE:
                    return "Date";
                case Constants.DATATYPE_INT:
                    return "Integer";
                case Constants.DATATYPE_STRING:
                    return "String";
                default :
                    return "String";
            }
        }
    }
}
