using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    class Tag
    {
        private TagType _tagType;
        private object _tagValue;

        public Tag( TagType type, object val )
        {
            _tagType  = type;
            _tagValue = val;
        }

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

        public TagType tagType
        {
            get
            {
                return _tagType;
            }
            set
            {
                _tagType = value;
            }
        }
    }
}
