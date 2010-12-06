using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ImageSource
{
    /// <summary>
    /// The SourceImageOrganizer is used to add, remove and modify images
    /// in the ImageSource program.  This class maintains a list of all
    /// SourceImage objects, and calls the SourceImageFactory as necessary
    /// to change the values of the reference file.
    /// This is a singleton class, and must be accessed using the
    /// getInstance() method.
    /// 
    /// This class is used to gain the functionality of the SourceImageFactory class.
    /// </summary>
    class SourceImageOrganizer
    {
        //the singleton
        private static SourceImageOrganizer master = new SourceImageOrganizer();

        private SourceImageFactory sourceImageFactory;

        private Dictionary<string, SourceImage> imageList;

        //Create a new organizer, load images from reference file
        private SourceImageOrganizer()
        {
            sourceImageFactory = SourceImageFactory.getInstance();

            imageList = sourceImageFactory.getImageList();
        }

        /// <summary>
        /// This is used to obtain a list of all image objects loaded into the system.
        /// </summary>
        /// <returns>Returns an ArrayList created from a <![CDATA[KeyValuePair<string name, SourceImage image>]]>
        /// object, where "name" is the file name of the image, and "image" is the SourceImage object.</returns>
        public ArrayList getImageList()
        {
            return new ArrayList(imageList);
        }

        /// <summary>
        /// Creates a SourceImage based on the provided information, and adds it to the
        /// system.  The SourceImageFactory is then called to add the SourceImage
        /// object to the reference file.
        /// 
        /// If the image already exists, the image is not added to the system a second
        /// time.
        /// </summary>
        /// <param name="imageName">The full file name of the image to be added, including file extension.</param>
        /// <param name="path">The full path to the image to be added, including file name and file extension.</param>
        public void addImage( string imageName, string path )
        {
            bool exists = false;

            //check if the image exists
            foreach (KeyValuePair<string, SourceImage> kvp in imageList)
            {
                if (kvp.Key.Equals(imageName) || kvp.Value.path.Equals(path))
                {
                    exists = true;
                }
            }

            //if it doesn't exist
            if (exists != true)
            {
                //add a new image to the reference file
                sourceImageFactory.addImage(path, imageName);

                //add the image to the system
                SourceImage newImage = new SourceImage(path, imageName);
                imageList.Add(imageName, newImage);
            }
        }

        /// <summary>
        /// Removes the specified image from the system, and then calls
        /// SourceImageFactory to remove the image from the reference file.
        /// </summary>
        /// <param name="imageName">The file name, including file extension, to be removed.</param>
        public void removeImage( string imageName )
        {
            if (imageList.ContainsKey(imageName))
            {
                sourceImageFactory.removeImage(imageName);
                imageList.Remove(imageName);
            }
        }

        /// <summary>
        /// Returns the single instance of the SourceImageOrganizer in the running program.
        /// <example>
        /// Example:
        /// <code>
        /// //get the instance
        /// SourceImageOrganizer imageOrganizer = SourceImageOrganizer.getInstance();
        /// 
        /// //the same organizer object can now be used to access the images from
        /// //any class which has retrieved an instance.
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>The current SourceImageOrganizer instance.</returns>
        public static SourceImageOrganizer getInstance()
        {
            return master;
        }

        /// <summary>
        /// A function used to get a list of all SourceImage objects.
        /// 
        /// <seealso cref="SourceImageOrganizer.getImageList()"/>
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, SourceImage> getImageMap()
        {
            return new Dictionary<string, SourceImage>(imageList);
        }
    }
}
