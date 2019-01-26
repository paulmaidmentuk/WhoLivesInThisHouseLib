using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class TagFactoryTest
    {
        [Test()]
        public void it_should_create_a_tag_by_name()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            Tag tag = tagFactory.GetTagByName("Test Tag");
            Assert.AreEqual(new Tag("Test Tag"), tag);
        }

        [Test()]
        public void it_should_maintain_a_unique_list_of_created_tags()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            tagFactory.GetTagByName("Test Tag");
            tagFactory.GetTagByName("Test Tag 2");
            tagFactory.GetTagByName("Test Tag");
            List<Tag> tags = tagFactory.GetAllTags();
            Assert.AreEqual(2, tags.Count);
            Assert.AreEqual(new Tag("Test Tag"), tags[0]);
            Assert.AreEqual(new Tag("Test Tag 2"), tags[1]);
        }

        [Test()]
        public void it_should_be_able_to_fetch_random_tags()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            tagFactory.GetTagByName("Tag 1");
            tagFactory.GetTagByName("Tag 2");
            tagFactory.GetTagByName("Tag 3");
            tagFactory.GetTagByName("Tag 4");
            tagFactory.GetTagByName("Tag 5");
            tagFactory.GetTagByName("Tag 6");
            tagFactory.GetTagByName("Tag 7");
            tagFactory.GetTagByName("Tag 8");
            tagFactory.GetTagByName("Tag 9");
            tagFactory.GetTagByName("Tag 10");
            tagFactory.GetTagByName("Tag 11");
            tagFactory.GetTagByName("Tag 12");
            tagFactory.GetTagByName("Tag 13");
            tagFactory.GetTagByName("Tag 14");
            tagFactory.GetTagByName("Tag 15");
            List<Tag> excludedTags = new List<Tag>();
            List<Tag> randomTags = tagFactory.GetRandomTags(5, excludedTags, itemFactory, false);
        }

        [Test()]
        public void it_should_be_able_to_fetch_random_excluding_some()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            tagFactory.GetTagByName("Tag 1");
            tagFactory.GetTagByName("Tag 2");
            tagFactory.GetTagByName("Tag 3");
            tagFactory.GetTagByName("Tag 4");
            tagFactory.GetTagByName("Tag 5");
            List<Tag> excludedTags = new List<Tag>{ new Tag("Tag 1")};
            List<Tag> randomTags = tagFactory.GetRandomTags(5, excludedTags, itemFactory, false);
            Assert.False(randomTags.Contains(new Tag("Tag 1")));
        }
    }
}
