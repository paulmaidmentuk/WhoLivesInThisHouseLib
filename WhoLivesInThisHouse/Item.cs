using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Item
    {
        private String name;
        private List<Tag> tags;

        public Item(String name)
        {
            this.name = name;
            this.tags = new List<Tag>();
        }

        public String GetName()
        {
            return this.name;
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

        public List<Tag> GetTags()
        {
            return this.tags;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Item))
            {
                return false;
            }
            Item other = (Item) obj;
            return GetName().Equals(other.GetName());
        }

        public override int GetHashCode()
        {
            return GetName().GetHashCode();
        }

        public override string ToString()
        {
            String result = "[Item] Name:" + GetName();
            foreach(Tag tag in tags)
            {
                result += "\n" + tag;
            }
            return result;
        }
    }
}
