using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageSource
{
    /// <summary>
    /// The SourceImage class is used to hold the image objects.
    /// Using the EMGU framework, images can be loaded using only
    /// a file path, contained within the SourceImage class.
    /// </summary>
    public class SourceImage
    {
        private string _name;
        private string _path;

        /// <summary>
        /// Create a new SourceImage object, using the supplied path and 
        /// file name.
        /// </summary>
        /// <param name="path">The complete file path, including file and file extension</param>
        /// <param name="imageName">The name of the image, including file extension.</param>
        public SourceImage( string path, string imageName )
        {
            _path = path;
            _name = imageName;
        }

        /// <summary>
        /// Returns the full path required to access the image.
        /// </summary>
        public string path
        {
            get
            {
                return _path;
            }
        }

        /// <summary>
        /// Returns the name of the image.
        /// </summary>
        public string name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Returns the full path of the file.
        /// </summary>
        /// <returns>The full file path.</returns>
        public override string ToString()
        {
            return _path;
        }

    }
}
