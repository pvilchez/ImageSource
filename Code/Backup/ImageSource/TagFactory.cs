using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ImageSource
{
    class TagFactory
    {
        private static  TagFactory master = new TagFactory();
        private XmlDocument tagDoc;
        private XmlDocument tagTypeDoc;
        private XmlNode tagRoot;
        private XmlNode tagTypeRoot;

        private const string FILE_TAG = "c:\\tags\\tags.xml";
        private const string FILE_TAGTYPE = "c:\\tags\\tagTypes.xml";

        private TagFactory()
        {
            tagDoc = new XmlDocument();
            tagDoc.Load(Constants.FILE_TAGS);
            tagRoot = tagDoc.DocumentElement;

            tagTypeDoc = new XmlDocument();
            tagTypeDoc.Load(Constants.FILE_TAGTYPES);
            tagTypeRoot = tagTypeDoc.DocumentElement;
        }

        public static TagFactory getInstance()
        {
            return master;
        }

        #region TagType Operations
        
        //Read in all of the TagTypes,
        //create TagType objects for them, and puts them in a lookup table
        public Dictionary<string, TagType> readTagTypes()
        {
            Dictionary<string, TagType> list = new Dictionary<string, TagType>();
            TagType newType;
            foreach (XmlElement node in tagTypeRoot.ChildNodes)
            {
                newType = new TagType(int.Parse(node.GetAttribute("dataType")), node.GetAttribute("name"));
                list.Add(newType.name, newType);
            }

            return list;
        }

        //Creates a TagType in the XML file
        public void writeTagType( TagType tagType )
        {
            bool found = false;

            //loop through every node, try to find one with the same name
            foreach (XmlElement node in tagTypeRoot.ChildNodes)
            {
                if (node.GetAttribute("name").Equals(tagType.name))
                {
                    //found it, change the dataType
                    node.SetAttribute("dataType", tagType.dataType.ToString());
                    found = true;
                }
            }

            //if we didn't find it before, make one
            if (found != true)
            {
                //make a new node
                XmlElement newType = tagTypeDoc.CreateElement("type");
                newType.SetAttribute("name", tagType.name);
                newType.SetAttribute("dataType", tagType.dataType.ToString());

                //insert as last node in the root tag
                tagTypeDoc.LastChild.AppendChild(newType);
                //tagTypeDoc.LastChild.InsertAfter(newType, tagTypeDoc.LastChild.LastChild);
            }

            //save!
            tagTypeDoc.Save(FILE_TAGTYPE);
        }

        //Remove the specified TagType from the XML file
        //this will orphan any remaining tags of this type!
        public void removeTagType( TagType tagType )
        {
            //loop through each node, remove the correct one if it exists
            foreach (XmlElement node in tagTypeRoot.ChildNodes)
            {
                if (node.GetAttribute("name").Equals(tagType.name))
                {
                    tagTypeRoot.RemoveChild(node);
                }
            }

            //save!
            tagTypeDoc.Save(FILE_TAGTYPE);
        }
        
        #endregion

        #region Tag Operations

        //Reads all Tags from the XML file,
        //creates Tag objects, and puts them in a lookup table
        public Dictionary<string, Dictionary<string, Tag>> readTags( Dictionary<string, TagType> tagTypeList )
        {
            Dictionary<string, Dictionary<string, Tag>> list = new Dictionary<string, Dictionary<string, Tag>>();
            Dictionary<string, Tag> tagList;
            Tag newTag;
            TagType type;
            foreach (XmlElement node in tagRoot.ChildNodes)
            {
                tagList = new Dictionary<string, Tag>();
                foreach (XmlElement tagNode in node.ChildNodes)
                {
                    if (tagTypeList.ContainsKey(tagNode.GetAttribute("type")))
                    {
                        type = tagTypeList[tagNode.GetAttribute("type")];
                        string val = tagNode.GetAttribute("value");

                        switch (type.dataType)
                        {
                            case Constants.DATATYPE_DATE:
                                newTag = new Tag(type, DateTime.Parse(val));
                                break;
                            case Constants.DATATYPE_INT:
                                newTag = new Tag(type, Int16.Parse(val));
                                break;
                            case Constants.DATATYPE_STRING:
                                newTag = new Tag(type, val);
                                break;
                            default:
                                newTag = new Tag(type, val);
                                break;
                        }

                        tagList.Add(newTag.tagType.name, newTag);
                    }
                }
                list.Add(node.GetAttribute("name"), tagList);
            }

            return list;
        }

        //Creates or modifies a Tag in the XML file.  Creates an image listing if necessary
        public void writeTag( string imageName, Tag tag )
        {
            bool found = false;

            foreach (XmlElement node in tagRoot.ChildNodes)
            {
                if (node.GetAttribute("name").Equals(imageName))
                {
                    foreach (XmlElement tagNode in node.ChildNodes)
                    {
                        if (tagNode.GetAttribute("type").Equals(tag.tagType.name))
                        {
                            //found the right type, change the value
                            tagNode.SetAttribute("value", tag.tagValue.ToString());
                            found = true;
                        }
                    }

                    if (found != true)
                    {
                        //create a new tag for the image
                        XmlElement newTag = tagDoc.CreateElement("tag");
                        newTag.SetAttribute("type", tag.tagType.name);
                        newTag.SetAttribute("value", tag.tagValue.ToString());
                        node.AppendChild(newTag);

                        found = true;
                    }
                }
            }

            if (found != true)
            {
                //create a new image, and a tag for it
                XmlElement newImage = tagDoc.CreateElement("image");
                XmlElement newTag = tagDoc.CreateElement("tag");
                newTag.SetAttribute("type", tag.tagType.name);
                newTag.SetAttribute("value", tag.tagValue.ToString());
                newImage.SetAttribute("name", imageName);
                newImage.AppendChild(newTag);
                tagRoot.AppendChild(newImage);
            }

            //save!
            tagDoc.Save(FILE_TAG);
        }

        //Remove the specified Tag from the XML file
        public void removeTag( string imageName, Tag tag )
        {
            //loop through each image, looking for correct one
            foreach (XmlElement node in tagRoot.ChildNodes)
            {
                if (node.GetAttribute("name").Equals(imageName))
                {
                    foreach (XmlElement tagNode in node.ChildNodes)
                    {
                        if (tagNode.GetAttribute("type").Equals(tag.tagType.name))
                        {
                            node.RemoveChild(tagNode);
                            break;
                        }
                    }

                    if (node.ChildNodes.Count == 0)
                    {
                        tagRoot.RemoveChild(node);
                    }
                }
            }

            tagDoc.Save(FILE_TAG);
        }

        #endregion        
    }
}
