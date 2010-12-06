using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ImageSource
{
    class TagOrganizer
    {
        private static TagOrganizer master = new TagOrganizer();
        private TagFactory tagFactory;

        //list of all tag types, loaded at runtime
        private Dictionary< string, TagType > tagTypeList;
        //list of (any image with tags, (tag type, tag object))
        private Dictionary< string, Dictionary< string, Tag > > tagList;

        private TagOrganizer()
        {
            tagFactory = TagFactory.getInstance();

            tagTypeList = tagFactory.readTagTypes();
            tagList = tagFactory.readTags( tagTypeList );
        }

        public static TagOrganizer getInstance()
        {
            return master;
        }

        #region TagTypes

        public ArrayList getTagTypeList()
        {
            return new ArrayList(tagTypeList);
        }

        //remove an existing tagtype from the list, and from the xml file
        //this will remove all existing tags of this type!
        public void removeTagType( string tagType )
        {
            if( tagTypeList.ContainsKey( tagType ))
            {
                    TagType type = tagTypeList[tagType];
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

        //add a new tagtype to the list, and to the xml file
        public void addTagType( string name, int dataType )
        {
            TagType newTagType = new TagType(dataType, name);
            tagTypeList.Add(name, newTagType);
            tagFactory.writeTagType(newTagType);
        }

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

        public ArrayList getTagList( string imageName )
        {
            if (tagList.ContainsKey(imageName))
            {
                return new ArrayList( tagList[imageName] );
            }
            else
            {
                return new ArrayList();
            }
        }

        //remove an existing tag from the list, and from the xml file
        public void removeTag( string imageName, Tag tag )
        {
            tagFactory.removeTag(imageName, tag);
            tagList[imageName].Remove(tag.tagType.name);

            if (tagList[imageName].Count == 0)
            {
                tagList.Remove(imageName);
            }
        }

        //add a new tag to the list, and to the xml file
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

        //change the tag, different value
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

        public void removeAllTags( string imageName )
        {
            foreach( KeyValuePair<string, Tag> tag in tagList[imageName] )
            {
                removeTag(imageName, tag.Value);
            }
        }

        #endregion

        #region Searches

        public ArrayList searchTags( TagType type )
        {
            ArrayList imageList = new ArrayList();
            
            //cycle through all images
            foreach (KeyValuePair<string, Dictionary<string, Tag>> kvp in tagList)
            {
                //if the image has a tag with the correct name, return it.
                if (kvp.Value.ContainsKey(type.name))
                {
                    imageList.Add(kvp.Key);
                }
            }

            return imageList;
        }

        //search for a partial string
        //results will be alpha-ordered
        public ArrayList sortTags( TagType type, string searchPattern )
        {
            ArrayList imageList = searchTags( type );

            foreach (string imageName in imageList)
            {
                if (tagList[imageName][type.name].tagValue.ToString().Contains(searchPattern) != true)
                {
                    imageList.Remove(imageName);
                }
            }

            imageList.Sort();

            return imageList;
        }

        //used to search for a string value
        //recall, (int?) is a nullable int
        //results will be ascending order
        public ArrayList sortTags( TagType type, int? lowerBound, int? upperBound )
        {
            ArrayList imageList = searchTags(type);
            
            if (lowerBound == null)
            {
                lowerBound = int.MinValue;
            }

            if (upperBound == null)
            {
                upperBound = int.MaxValue;
            }

            foreach (string imageName in imageList)
            {
                if (int.Parse(tagList[imageName][type.name].tagValue.ToString()) < lowerBound || int.Parse(tagList[imageName][type.name].tagValue.ToString()) > upperBound)
                {
                    imageList.Remove(imageName);
                }
            }

            imageList.Sort();

            return imageList;
        }

        //used to search for a date
        public ArrayList sortTags( TagType type, DateTime lowerBound, DateTime upperBound )
        {
            ArrayList imageList = searchTags(type);

            foreach (string imageName in imageList)
            {
                if (DateTime.Parse(tagList[imageName][type.name].tagValue.ToString()).CompareTo(lowerBound) < 0
                 || DateTime.Parse(tagList[imageName][type.name].tagValue.ToString()).CompareTo(upperBound) > 0)
                {
                    imageList.Remove(imageName);
                }
            }

            imageList.Sort();

            return imageList;
        }

        #endregion
    }
}
