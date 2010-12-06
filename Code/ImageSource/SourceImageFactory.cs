using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace ImageSource
{
    /// <summary>
    /// The SourceImageFactory is used to read and write the SourceImage objects
    /// directly to the file name specified in Constants.FILE_IMAGES .  This is a
    /// singleton class, and must be accessed using the getInstance() static method.
    /// </summary>
    internal class SourceImageFactory
    {
        //the master instance, returned using getInstance()
        private static SourceImageFactory master = new SourceImageFactory();

        private XmlDocument imageDoc;
        private XmlNode imageRoot;

        private TagOrganizer tagOrganizer;

        private SourceImageFactory()
        {
            imageDoc = new XmlDocument();
            imageDoc.Load(Constants.FILE_IMAGES);
            imageRoot = imageDoc.DocumentElement;

            tagOrganizer = TagOrganizer.getInstance();
        }

        /// <summary>
        /// Returns the single instance of the SourceImageFactory in the running program.
        /// <example>
        /// Example:
        /// <code>
        /// //get the instance
        /// SourceImageFactory imageFactory = SourceImageFactory.getInstance();
        /// 
        /// //the same factory object can now be used to access the file from
        /// //any class which has retrieved an instance.
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>The current SourceImageFactory instance.</returns>
        public static SourceImageFactory getInstance()
        {
            return master;
        }

        #region Images

        /// <summary>
        /// Adds the specified SourceImage object to the XML file specified in Constants.FILE_IMAGES.
        /// </summary>
        /// <param name="path">The path of the full path of the file, inclduing file name and file extension.</param>
        /// <param name="imageName">The name of the file, including file extension.</param>
        public void addImage( string path, string imageName )
        {
            //Create a new node
            SourceImage newImage = new SourceImage(path, imageName);
            XmlElement newNode = imageDoc.CreateElement("image");

            //set attributes
            newNode.SetAttribute("name", imageName);
            newNode.SetAttribute("path", path);

            //add to the end of the document
            imageRoot.AppendChild(newNode);

            //save!
            imageDoc.Save(Constants.FILE_IMAGES);
        }

        /// <summary>
        /// Removes the specified SourceImage object from the XML file specified in Constants.FILE_IMAGES.
        /// All for the image are also removed, using the TagOrganizer.
        /// </summary>
        /// <param name="imageName">The name of the file to be removed, including file extension.</param>
        public void removeImage( string imageName )
        {
            //remove all tags for the image from the TagOrganizer
            tagOrganizer.removeAllTags(imageName);

            //loop until correct image is found
            foreach (XmlElement node in imageRoot.ChildNodes)
            {
                //remove the correct image
                if (node.GetAttribute("name").Equals(imageName))
                {
                    imageRoot.RemoveChild(node);
                    break;
                }
            }

            //save!
            imageDoc.Save(Constants.FILE_IMAGES);
        }

        /// <summary>
        /// Returns a list of all images in the ImageSource project.
        /// </summary>
        /// <returns>An image list in <![CDATA[Dictionary<string imageName,SourceImage image>]]> format, where
        /// 'imageName' is the full file name, and 'image' is the SourceImage object. </returns>
        public Dictionary<string, SourceImage> getImageList()
        {
            Dictionary<string, SourceImage> list = new Dictionary<string, SourceImage>();

            SourceImage newImage;

            //add each element to the Dictionary
            foreach (XmlElement node in imageRoot.ChildNodes)
            {
                //create a new SourceImage object
                newImage = new SourceImage(node.GetAttribute( "path" ), node.GetAttribute("name"));

                list.Add(newImage.name, newImage);
            }

            return list;
        }

        #endregion
    }
}
