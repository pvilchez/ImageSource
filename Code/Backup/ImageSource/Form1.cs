using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageSource
{
    public partial class Form1 : Form
    {
        private  Dictionary< string, TagType > tagListFull;
        public Form1()
        {
            InitializeComponent();
            System.Console.WriteLine(DateTime.MinValue.ToString());
            System.Console.WriteLine(DateTime.MaxValue.ToString());
        }

        private void button1_Click( object sender, EventArgs e )
        {
            TagFactory factory = TagFactory.getInstance();

            factory.writeTagType(new TagType(Int16.Parse(textBox2.Text), textBox1.Text));
        }

        private void button2_Click( object sender, EventArgs e )
        {
            TagFactory factory = TagFactory.getInstance();

            factory.removeTagType(new TagType(Int16.Parse(textBox2.Text), textBox1.Text));
        }

        private void button3_Click( object sender, EventArgs e )
        {
            TagFactory factory = TagFactory.getInstance();

            tagListFull = factory.readTagTypes();

            fileXML.Text = "";
            foreach( KeyValuePair< string, TagType>  kvp in tagListFull )
            {
                fileXML.Text += kvp.Key + ":" + kvp.Value.dataType.ToString() + "\n";
            }

            button4.Enabled = true;
        }

        private void button4_Click( object sender, EventArgs e )
        {
            TagFactory factory = TagFactory.getInstance();

            Dictionary< string, Dictionary<string, Tag>> list = factory.readTags(tagListFull);

            fileXML.Text = "";
            foreach (KeyValuePair< string, Dictionary<string, Tag>>  kvp in list)
            {
                fileXML.Text += kvp.Key + "[";
                foreach (KeyValuePair< string, Tag >  kv in kvp.Value)
                {
                    fileXML.Text += "(" + kv.Value.tagType.name + "," + kv.Value.tagValue.ToString() + ")";
                }
            }
        }

        private void button5_Click( object sender, EventArgs e )
        {
            Tag newTag = new Tag(tagListFull[textBox4.Text], textBox5.Text);
            TagFactory factory = TagFactory.getInstance();

            factory.writeTag(textBox3.Text, newTag);
        }

        private void button6_Click( object sender, EventArgs e )
        {
            Tag oldTag = new Tag(tagListFull[textBox4.Text], textBox5.Text);
            TagFactory factory = TagFactory.getInstance();

            factory.removeTag(textBox3.Text, oldTag);
        }
    }
}
