using NUnit.Framework;
using System;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class ItemTest
    {
        [Test()]
        public void it_should_be_possible_to_create_an_item()
        {
            Item item = new Item("Some Name", "");
            Assert.AreEqual("Some Name", item.Name);
        }

        [Test]
        public void items_should_be_considered_equal_if_they_have_the_same_attributes()
        {
            Item item1 = new Item("Some Name", "");
            Item item2 = new Item("Some Name", "");

            Assert.AreEqual(item1, item2);
        }

        [Test]
        public void it_should_support_adding_tags_uniquely_and_fetching_them()
        {
            Item item = new Item("Test Item", "");
            item.AddTag(new Tag("Tag 1 Name"));
            item.AddTag(new Tag("Tag 2 Name"));
            item.AddTag(new Tag("Tag 1 Name"));
            Assert.AreEqual(new Tag("Tag 1 Name"), item.Tags[0]);
            Assert.AreEqual(new Tag("Tag 2 Name"), item.Tags[1]);
            Assert.AreEqual(true, item.HasTag("Tag 1 Name"));
        }
    }
}
