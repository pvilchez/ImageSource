using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    class TagType
    {
        private int _dataType;
        private string _name;

        public TagType( int dataType, string name )
        {
            _name = name;
            _dataType = dataType;
        }

        public string name
        {
            get
            {
                return _name;
            }
        }

        public int dataType
        {
            get
            {
                return _dataType;
            }
            set
            {
                _dataType = value < 1 ? 1 : value > 3 ? 3 : value;
            }
        }

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
