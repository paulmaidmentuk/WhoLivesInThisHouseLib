using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Item
    {
        private String name;
        private String imageFilenamePrefix;
        private String soundFilenamePrefix;
        private List<Tag> tags;
        private String uiBinding = "";

        public Item(String name, String uiBinding, String imageFilenamePrefix, String soundFilenamePrefix)
        {
            this.name = name;
            this.tags = new List<Tag>();
            this.uiBinding = uiBinding;
            this.imageFilenamePrefix = imageFilenamePrefix;
            this.soundFilenamePrefix = soundFilenamePrefix;
        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public String ImageFileNamePrefix
        {
            get
            {
                return this.imageFilenamePrefix;
            }
        }

        public String SoundFileNamePrefix
        {
            get
            {
                return this.soundFilenamePrefix;

            }
        }

        public String UiBinding
        {
            get
            {
                return uiBinding;
            }
        }

        public void AddTag(Tag tag)
        {
            if (!tags.Contains(tag)) {
                tags.Add(tag);
            }
        }


        public bool HasTag(String tagName)
        {
            Tag t = new Tag(tagName);
            foreach(Tag tag in tags)
            {
                if (t.Equals(tag))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTagIn(List<Tag> tagList)
        {
            foreach(Tag tag in tagList)
            {
                if(HasTag(tag.Name))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Tag> Tags
        {
            get
            {
                return this.tags;
            }
           
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
            {
                return false;
            }
            Item other = (Item) obj;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            String result = "[Item] Name:" + Name;
            foreach(Tag tag in tags)
            {
                result += "\n" + tag;
            }
            return result;
        }
    }
}
