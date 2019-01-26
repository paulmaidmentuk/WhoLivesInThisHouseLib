using NUnit.Framework;
using System;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class TagTest
    {
        [Test()]
        public void it_should_be_considered_equal_to_another_tag_with_identical_attributes()
        {
            Tag tag1 = new Tag("Test Tag");
            Tag tag2 = new Tag("Test Tag");
            Assert.AreEqual(tag1, tag2);
        }

        [Test()]
        public void it_should_be_possible_to_construct_a_tag()
        {
            Tag tag = new Tag("This is a tag");
            Assert.AreEqual("This is a tag", tag.Name);
        }
    }
}
