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
            TagFactory tagFactory = new TagFactory();
            Tag tag = tagFactory.GetTagByName("Test Tag");
            Assert.AreEqual(new Tag("Test Tag"), tag);
        }

        [Test()]
        public void it_should_maintain_a_unique_list_of_created_tags()
        {
            TagFactory tagFactory = new TagFactory();
            tagFactory.GetTagByName("Test Tag");
            tagFactory.GetTagByName("Test Tag 2");
            tagFactory.GetTagByName("Test Tag");
            List<Tag> tags = tagFactory.GetAllTags();
            Assert.AreEqual(2, tags.Count);
            Assert.AreEqual(new Tag("Test Tag"), tags[0]);
            Assert.AreEqual(new Tag("Test Tag 2"), tags[1]);
        }
    }
}
