using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    public class SourceImage
    {
        private string _name;
        private string _path;

        public SourceImage( string path, string imageName )
        {
            _path = path;
            _name = imageName;
        }

        public string path
        {
            get
            {
                return _path;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }
        }

        public override string ToString()
        {
            return _path;
        }
    }
}
