using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class TagFactory
    {
        private RandomNumberGenerator randomNumberGenerator;
        private List<Tag> tags = new List<Tag>();

        public TagFactory(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

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

        /// <summary>
        /// Get a unique and random list of tags up to the specified limit
        /// </summary>
        /// <returns>The random tags.</returns>
        /// <param name="maxTags">Max tags to retrieve.</param>
        public List<Tag> GetRandomTags(int maxTags, List<Tag> excludeTags)
        {
            List<Tag> result = new List<Tag>();
            if (maxTags > 0 && tags.Count > 0)
            {
                do
                {
                    int tagIndex = randomNumberGenerator.GetRandomInteger(0, tags.Count);
                    Tag tag = tags[tagIndex];
                    if (!result.Contains(tag) && !excludeTags.Contains(tag))
                    {
                        result.Add(tag);
                    }
                } while ((result.Count < maxTags) && (result.Count < (tags.Count - excludeTags.Count)));
            }
            return result;
        }
    }
}
