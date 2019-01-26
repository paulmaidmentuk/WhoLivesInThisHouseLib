using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class TagFactory
    {
        private List<Tag> tags = new List<Tag>();

        public Tag GetTagByName(String name)
        {
            Tag tag = new Tag(name);
            if (!tags.Contains(tag))
            {
                tags.Add(tag);
            }
            return tag;
        }

        public List<Tag> GetAllTags()
        {
            return tags;
        }
    }
}
