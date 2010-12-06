using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ImageSource
{
    /// <summary>
    /// The TagFactory is used to read and write the Tag objectsd directly to the 
    /// file name specified in Constants.FILE_IMAGES .  This is a singleton class,
    /// and must be accessed using the getInstance() static method.
    /// </summary>
    internal class TagFactory
    {
        private static  TagFactory master = new TagFactory();
        private XmlDocument tagDoc;
        private XmlDocument tagTypeDoc;
        private XmlNode tagRoot;
        private XmlNode tagTypeRoot;

        //Create the master object, and open the files
        private TagFactory()
        {
            //open the tag reference file.
            tagDoc = new XmlDocument();
            tagDoc.Load(Constants.FILE_TAGS);
            tagRoot = tagDoc.DocumentElement;

            //open the tagType reference file.
            tagTypeDoc = new XmlDocument();
            tagTypeDoc.Load(Constants.FILE_TAGTYPES);
            tagTypeRoot = tagTypeDoc.DocumentElement;
        }

        /// <summary>
        /// Returns the single instance of the TagFactory in the running program.
        /// <example>
        /// Example:
        /// <code>
        /// //get the instance
        /// TagFactory tagFactory = TagFactory.getInstance();
        /// 
        /// //the same factory object can now be used to access the tag factory from
        /// //any class which has retrieved an instance.
        /// </code>
        /// </example>
        /// </summary>
        /// <returns>The current TagFactory instance.</returns>
        public static TagFactory getInstance()
        {
            return master;
        }

        #region TagType Operations
        
        /// <summary>
        /// Returns a list of all TagType objects in the tag type reference file specified
        /// in Constants.FILE_TAGTYPES.
        /// </summary>
        /// <returns>A TagType list in <![CDATA[Dictionary<string name, TagType tagType>]]> format where
        /// "name" is the name of the TagType object, and tagType is the TagType object.</returns>
        public Dictionary<string, TagType> readTagTypes()
        {
            
            Dictionary<string, TagType> list = new Dictionary<string, TagType>();
            TagType newType;

            //add a new tag type for every TagType object in the tagTypes reference file.
            foreach (XmlElement node in tagTypeRoot.ChildNodes)
            {
                newType = new TagType(int.Parse(node.GetAttribute("dataType")), node.GetAttribute("name"));
                list.Add(newType.name, newType);
            }

            return list;
        }

        /// <summary>
        /// Writes a TagType object to the tagTypes reference file specified in 
        /// Constants.FILE_TAGTYPES.
        /// </summary>
        /// <param name="tagType">The TagType object to be written.</param>
        public void writeTagType( TagType tagType )
        {
            bool found = false;

            //loop through every node, try to find one with the same name
            //we'll just modify it if necessary
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
            tagTypeDoc.Save(Constants.FILE_TAGTYPES);
        }

        //Remove the specified TagType from the XML file
        //this will orphan any remaining tags of this type!
        /// <summary>
        /// Removes the specified TagType from the tagTypes reference file 
        /// specified in Constants.FILE_TAGTYPES.
        /// 
        /// NOTE: This will orphan any Tag object which were not properly removed!
        /// </summary>
        /// <param name="tagType">The TagType to be removed.</param>
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
            tagTypeDoc.Save(Constants.FILE_TAGTYPES);
        }
        
        #endregion

        #region Tag Operations

        /// <summary>
        /// Returns a list of all Tag objects in the tag type reference file specified
        /// in Constants.FILE_TAGS.
        /// </summary>
        /// <returns>A Tag list in <![CDATA[Dictionary<string name, Dictionary<string tagName, Tag tag>>]]> 
        /// format where "name" is the name of the image the tag is applied to, "tagName" is the
        /// name of the tag.tagType object, and "tag" is the Tag object.</returns>
        public Dictionary<string, Dictionary<string, Tag>> readTags( Dictionary<string, TagType> tagTypeList )
        {
            //create a new list of images
            Dictionary<string, Dictionary<string, Tag>> list = new Dictionary<string, Dictionary<string, Tag>>();
            Dictionary<string, Tag> tagList;
            Tag newTag;
            TagType type;

            // SAMPLE tags.xml
            // <root>
            //   <image name="image1.jpg">
            //     <tag name="tagType1" value="A String" />
            //     <tag name="tagType2" value="32" />
            //   </image>
            // </root>
            //

            //for each image
            foreach (XmlElement node in tagRoot.ChildNodes)
            {
                //Create a new list of tags
                tagList = new Dictionary<string, Tag>();

                //for each TagType
                foreach (XmlElement tagNode in node.ChildNodes)
                {
                    //there should only be one tag for each tagType
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
                                newTag = new Tag(type, Int32.Parse(val));
                                break;
                            case Constants.DATATYPE_STRING:
                                newTag = new Tag(type, val);
                                break;
                            default:
                                newTag = new Tag(type, val);
                                break;
                        }
                        //Add the tag to the list of tags for a particular image
                        tagList.Add(newTag.tagType.name, newTag);
                    }
                }
                //Add the image to the list of images
                list.Add(node.GetAttribute("name"), tagList);
            }

            return list;
        }

        /// <summary>
        /// Write the specified Tag object for the specified image to the tags reference file 
        /// specified in Constants.FILE_TAGS. An image element will be added to the reference file,
        /// and the tag written to it.  If an image element already exists, the tag will simply
        /// be added to that list.
        /// </summary>
        /// <param name="imageName">The name of the image to add the Tag object.</param>
        /// <param name="tag">The Tag object to add.</param>
        public void writeTag( string imageName, Tag tag )
        {
            bool found = false;

            //try to find the image element
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
                            break;
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
            tagDoc.Save(Constants.FILE_TAGS);
        }

        /// <summary>
        /// Removes the specified Tag object from the specified image from the tags reference file
        /// specified in Constants.FILE_TAGS.
        /// </summary>
        /// <param name="imageName">The file name of the image to remove the Tag object from.</param>
        /// <param name="tag">The Tag object to be removed.</param>
        public void removeTag( string imageName, Tag tag )
        {
            //loop through each image, looking for correct one
            foreach (XmlElement node in tagRoot.ChildNodes)
            {
                //if it's the correct image
                if (node.GetAttribute("name").Equals(imageName))
                {
                    //for every tag applied to the image
                    foreach (XmlElement tagNode in node.ChildNodes)
                    {
                        //if it's the correct tag
                        if (tagNode.GetAttribute("type").Equals(tag.tagType.name))
                        {
                            //remove it from the list
                            node.RemoveChild(tagNode);
                            break;
                        }
                    }

                    //remove from the reference file
                    if (node.ChildNodes.Count == 0)
                    {
                        tagRoot.RemoveChild(node);
                    }
                }
            }

            //save!
            tagDoc.Save(Constants.FILE_TAGS);
        }

        #endregion        
    }
}
