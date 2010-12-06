using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ImageSource
{
    class SourceImageOrganizer
    {
        private static SourceImageOrganizer master = new SourceImageOrganizer();

        private SourceImageFactory sourceImageFactory;

        private Dictionary<string, SourceImage> imageList;

        private SourceImageOrganizer()
        {
            sourceImageFactory = SourceImageFactory.getInstance();

            imageList = sourceImageFactory.getImageList();
        }

        public ArrayList getImageList()
        {
            return new ArrayList(imageList);
        }

        public void addImage( string imageName, string path )
        {
            bool exists = false;

            foreach (KeyValuePair<string, SourceImage> kvp in imageList)
            {
                if (kvp.Key.Equals(imageName) || kvp.Value.path.Equals(path))
                {
                    exists = true;
                }
            }

            if (exists != true)
            {
                sourceImageFactory.addImage(path, imageName);

                SourceImage newImage = new SourceImage(path, imageName);
                imageList.Add(imageName, newImage);
            }
        }

        public void removeImage( string imageName )
        {
            if (imageList.ContainsKey(imageName))
            {
                sourceImageFactory.removeImage(imageName);
                imageList.Remove(imageName);
            }
        }

        public static SourceImageOrganizer getInstance()
        {
            return master;
        }
    }
}
