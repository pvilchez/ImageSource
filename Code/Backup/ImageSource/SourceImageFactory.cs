using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace ImageSource
{
    class SourceImageFactory
    {
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

        public static SourceImageFactory getInstance()
        {
            return master;
        }

        #region Images

        public void addImage( string path, string imageName )
        {
            SourceImage newImage = new SourceImage(path, imageName);
            XmlElement newNode = imageDoc.CreateElement("image");

            newNode.SetAttribute("name", imageName);
            newNode.SetAttribute("path", path);

            imageRoot.AppendChild(newNode);

            imageDoc.Save(Constants.FILE_IMAGES);
        }

        public void removeImage( string imageName )
        {

            tagOrganizer.removeAllTags(imageName);

            foreach (XmlElement node in imageRoot.ChildNodes)
            {
                if (node.GetAttribute("name").Equals(imageName))
                {
                    imageRoot.RemoveChild(node);
                    break;
                }
            }

            imageDoc.Save(Constants.FILE_IMAGES);
        }

        public Dictionary<string, SourceImage> getImageList()
        {
            Dictionary<string, SourceImage> list = new Dictionary<string, SourceImage>();

            SourceImage newImage;

            foreach (XmlElement node in imageRoot.ChildNodes)
            {
                newImage = new SourceImage(node.GetAttribute( "path" ), node.GetAttribute("name"));

                list.Add(newImage.name, newImage);
            }

            return list;
        }

        #endregion
    }
}
