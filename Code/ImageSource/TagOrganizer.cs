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
    class TagOrganizer
    {
        private static TagOrganizer master = new TagOrganizer();
        private TagFactory tagFactory;
        private SourceImageOrganizer imageOrganizer;

        //list of all tag types, loaded at runtime
        private Dictionary< string, TagType > tagTypeList;
        //list of (any image with tags, (tag type, tag object))
        private Dictionary< string, Dictionary< string, Tag > > tagList;

        // Create the TagOrganizer, get read tagtypes and tags
        private TagOrganizer()
        {
            //get instance of TagFactory and SourceImageOrganizer for class
            tagFactory = TagFactory.getInstance();
            imageOrganizer = SourceImageOrganizer.getInstance();

            //get tagtype and tag lists
            tagTypeList = tagFactory.readTagTypes();
            tagList = tagFactory.readTags( tagTypeList );
        }

        /// <summary>
        /// Returns the single instance of the TagOrganizer in the running program.
        /// <example>
        /// Example:
        /// <code>
        /// //get the instance
        /// TagOrganizer tagOrganizer = TagOrganizer.getInstance();
        /// 
        /// //the same organizer object can now be used to access the tags from
        /// //any class which has retrieved an instance.
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>The current TagOrganizer instance.</returns>
        public static TagOrganizer getInstance()
        {
            return master;
        }

        #region TagTypes

        /// <summary>
        /// This is used to obtain a list of all TagType objects loaded into the system.
        /// </summary>
        /// <returns>Returns an ArrayList created from a <![CDATA[KeyValuePair<string name, TagType tagType>]]>
        /// object, where "name" is name of the TagType, and "tagType" is the TagType object.</returns>
        public ArrayList getTagTypeList()
        {
            return new ArrayList(tagTypeList);
        }

        /// <summary>
        /// Removes the specified TagType from the system, and then calls
        /// TagFactory to remove the TagType from the reference file.
        /// 
        /// This will remove all Tags of this TagType from any images which
        /// have them applied.
        /// </summary>
        /// <param name="tagType">The TagType to be removed.</param>
        public void removeTagType( string tagType )
        {
            if( tagTypeList.ContainsKey( tagType ))
            {
                TagType type = tagTypeList[tagType];
                //remove from every image
                foreach( KeyValuePair< string, Dictionary<string, Tag>> kvp in tagList )
                {
                    if( kvp.Value.ContainsKey( type.name ))
                    {
                        //remove the tag from the specified image.
                        //this should be fixed to a more generic search for all images?
                        tagFactory.removeTag( kvp.Key, kvp.Value[ type.name ] );
                        kvp.Value.Remove(type.name);
                    }
                }

                tagTypeList.Remove(type.name);
                tagFactory.removeTagType( type );
            }
        }

        /// <summary>
        /// Adds a new TagType to the system, and calls TagFactory to add it to the
        /// reference file.
        /// </summary>
        /// <param name="name">The name of the TagType to be created.</param>
        /// <param name="dataType">The datatype of the TagType to be created.</param>
        public void addTagType( string name, int dataType )
        {
            TagType newTagType = new TagType(dataType, name);
            tagTypeList.Add(name, newTagType);
            tagFactory.writeTagType(newTagType);
        }

        /// <summary>
        /// Changes the datatype of an existing TagType object, and calls TagFactory
        /// to make the change to the reference file.
        /// 
        /// Any existing tags will remain, however their values will be set to the
        /// default minimum.
        /// </summary>
        /// <param name="name">The name of the TagType to be modified.</param>
        /// <param name="newDataType">The new datatype of the TagType to be modified.</param>
        public void changeTagType(string name, int newDataType)
        {
            object clearValue;

            switch (newDataType)
            {
                case Constants.DATATYPE_DATE :
                    clearValue = DateTime.MinValue;
                    break;
                case Constants.DATATYPE_INT :
                    clearValue = int.MinValue;
                    break;
                case Constants.DATATYPE_STRING :
                    clearValue = "";
                    break;
                default :
                    clearValue = "";
                    break;
            }

            if (tagTypeList.ContainsKey(name))
            {
                tagTypeList[name].dataType = newDataType;
                foreach (KeyValuePair< string, Dictionary< string, Tag>> kvp in tagList)
                {
                    if (kvp.Value.ContainsKey(name))
                    {
                        kvp.Value[name].tagValue = clearValue;
                        tagFactory.writeTag(kvp.Key, kvp.Value[name]);
                    }
                }

                tagFactory.writeTagType(tagTypeList[name]);   
            }
        }

        #endregion

        #region Tags

        /// <summary>
        /// This is used to obtain a list of all Tag objects loaded into the system.
        /// </summary>
        /// <returns>Returns an ArrayList created from a <![CDATA[KeyValuePair<string name, Tag tag>]]>
        /// object, where "name" is name of the tag.TagType object, and "tag" is the Tag object.</returns>
        public ArrayList getTagList( string imageName )
        {
            //return a list of all tags, if any
            if (tagList.ContainsKey(imageName))
            {
                return new ArrayList( tagList[imageName] );
            }
            //return an empty set
            else
            {
                return new ArrayList();
            }
        }

        /// <summary>
        /// Removes the specified TagType from the system, and then calls
        /// TagFactory to remove the TagType from the reference file.
        /// 
        /// This will remove all Tags of this TagType from any images which
        /// have them applied.
        /// </summary>
        /// <param name="imageName">The full name of the image, including file extension,
        /// of the image to remove the Tag from.</param>
        /// <param name="tag">The Tag object to be removed from the system.</param>
        public void removeTag( string imageName, Tag tag )
        {
            tagFactory.removeTag(imageName, tag);
            tagList[imageName].Remove(tag.tagType.name);

            //removes the image from the tags reference file, if no tags exist;
            //this creates a smaller file size
            if (tagList[imageName].Count == 0)
            {
                tagList.Remove(imageName);
            }
        }

        /// <summary>
        /// Adds a new Tag to the system, and calls TagFactory to add it to the
        /// reference file.
        /// </summary>
        /// <param name="imageName">The full name of the image, including file extension,
        /// that the Tag object should be added to.</param>
        /// <param name="newValue">The value of the Tag object to be created.</param>
        /// <param name="tagType">The TagType of the Tag object to be created.</param>
        public void addTag( string imageName, string tagType, object newValue )
        {
            //check that the tag type exists first
            if (tagTypeList.ContainsKey(tagType))
            {
                //create a new tag
                Tag newTag = new Tag(tagTypeList[tagType], newValue);

                //write to the xml file
                tagFactory.writeTag(imageName, newTag);

                //if an image listing exists, add the tag
                if( tagList.ContainsKey( imageName ))
                {
                    tagList[imageName].Add(tagType, newTag);
                }
                //create the image listing, and then add the tag
                else
                {
                    Dictionary< string, Tag > newTaglist = new Dictionary<string, Tag>();
                    newTaglist.Add(tagType, newTag);
                    tagList.Add(imageName, newTaglist);
                }
            }
        }

        /// <summary>
        /// Changes the value of a Tag in the system.
        /// </summary>
        /// <param name="imageName">The name of the image the Tag is applied to.</param>
        /// <param name="tagType">The TagType of the Tag to be modified.</param>
        /// <param name="newValue">The new value of the Tag to be modified.</param>
        public void changeTag(string imageName, string tagType, object newValue)
        {
            if (tagList.ContainsKey(imageName) && tagList[imageName].ContainsKey( tagType ))
            {
                //change the value in the list
                tagList[imageName][tagType].tagValue = newValue;
                //change the value in the xml file
                tagFactory.writeTag(imageName, tagList[imageName][tagType]);
            }
        }

        /// <summary>
        /// Removes all Tag objects from the specified image.
        /// </summary>
        /// <param name="imageName">The full name of the image, including file extension, to be removed.</param>
        public void removeAllTags( string imageName )
        {
            if(tagList.ContainsKey(imageName))
            {
                //remove each tag using the removeTag() method.
                foreach(KeyValuePair<string, Tag> tag in tagList[imageName])
                {
                    removeTag(imageName, tag.Value);
                }
            }
        }

        #endregion

        #region Searches
        //Return a list of all images which have the specified TagType
        private Dictionary<string, SourceImage> searchTags( TagType type )
        {
            Dictionary<string, SourceImage> imageList = imageOrganizer.getImageMap();
            Dictionary<string, SourceImage> imagesWithTags = new Dictionary<string, SourceImage>();

            foreach( KeyValuePair<string, SourceImage> kvp in imageList )
            {
                if( tagList.ContainsKey( kvp.Key ) && tagList[kvp.Key].ContainsKey( type.name ) )
                {
                    imagesWithTags.Add( kvp.Key, kvp.Value );
                }
            }

            return imagesWithTags;
        }

        /// <summary>
        /// Returns a list of all images which have a Tag of TagType.dataType Constants.DATATYPE_STRING,
        /// whose value contains the specified search string.
        /// </summary>
        /// <param name="type">The TagType of the Tag to be searched for.</param>
        /// <param name="searchPattern">The string to be searched for.</param>
        /// <returns>The ArrayList of images in <![CDATA[KeyValuePair<string name, SourceImage image>]]>
        /// format that match the search criteria.</returns>
        public ArrayList sortTags( TagType type, string searchPattern )
        {
            Dictionary<string, SourceImage> imagesWithTags = searchTags( type );
            SortedList< string, SourceImage > sortedList = new SortedList<string, SourceImage>();
            foreach(KeyValuePair<string, SourceImage> kvp in imagesWithTags)
            {
                if(tagList[kvp.Key][type.name].tagValue.ToString().Contains(searchPattern) == true)
                {
                    sortedList.Add(kvp.Key, kvp.Value);
                }
            }

            return new ArrayList( sortedList );
        }

        /// <summary>
        /// Returns a list of all images which have a Tag of TagType.dataType Constants.DATATYPE_INT,
        /// whose value, on the interval [lowerBound, upperBound].
        /// </summary>
        /// <param name="type">The TagType of the Tag to be searched for.</param>
        /// <param name="lowerBound">The lower boundary on the search.</param>
        /// <param name="upperBound">The upper boundary on the search.</param>
        /// <returns>The ArrayList of images in <![CDATA[KeyValuePair<string name, SourceImage image>]]>
        /// format that match the search criteria.</returns>
        public ArrayList sortTags( TagType type, int? lowerBound, int? upperBound )
        {
            Dictionary<string, SourceImage> imagesWithTags = searchTags(type);
            SortedList< string, SourceImage > sortedList = new SortedList<string, SourceImage>();
            
            if (lowerBound == null)
            {
                lowerBound = int.MinValue;
            }

            if (upperBound == null)
            {
                upperBound = int.MaxValue;
            }

            //add each element which is on the interval
            foreach (KeyValuePair<string, SourceImage> kvp in imagesWithTags)
            {
                if (int.Parse(tagList[kvp.Key][type.name].tagValue.ToString()) > lowerBound 
                 && int.Parse(tagList[kvp.Key][type.name].tagValue.ToString()) < upperBound)
                {
                    sortedList.Add(kvp.Key, kvp.Value);
                }
            }

            return new ArrayList( sortedList );
        }

        /// <summary>
        /// Returns a list of all images which have a Tag of TagType.dataType Constants.DATATYPE_DATE,
        /// whose value, on the interval [lowerBound, upperBound].
        /// </summary>
        /// <param name="type">The TagType of the Tag to be searched for.</param>
        /// <param name="lowerBound">The lower boundary on the search.</param>
        /// <param name="upperBound">The upper boundary on the search.</param>
        /// <returns>The ArrayList of images in <![CDATA[KeyValuePair<string name, SourceImage image>]]>
        /// format that match the search criteria.</returns>
        public ArrayList sortTags( TagType type, DateTime lowerBound, DateTime upperBound )
        {
            Dictionary<string, SourceImage> imagesWithTags = searchTags(type);
            SortedList< string, SourceImage > sortedList = new SortedList<string, SourceImage>();

            foreach(KeyValuePair<string, SourceImage> kvp in imagesWithTags)
            {
                if(DateTime.Parse(tagList[kvp.Key][type.name].tagValue.ToString()).CompareTo(lowerBound) > 0
                 && DateTime.Parse(tagList[kvp.Key][type.name].tagValue.ToString()).CompareTo(upperBound) < 0)
                {
                    sortedList.Add(kvp.Key, kvp.Value);
                }
            }

            return new ArrayList( sortedList );
        }

        #endregion
    }
}
