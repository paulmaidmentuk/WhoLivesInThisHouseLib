using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class ItemFactoryTest
    {
        [Test()]
        public void it_should_create_an_item_with_tags()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            Item item = itemFactory.CreateItem("Test Item", "", new List<string>(new String [] { "tag1", "tag2", "tag1"}));
            Assert.AreEqual("Test Item", item.Name);
            Assert.AreEqual(2, item.Tags.Count);
            Assert.AreEqual(new Tag("tag1"), item.Tags[0]);
            Assert.AreEqual(new Tag("tag2"), item.Tags[1]);
            Assert.AreEqual(1, itemFactory.GetItems().Count);
            Assert.AreEqual(item, itemFactory.GetItems()[0]);
        }

        public void it_should_support_fetch_by_tag()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            itemFactory.CreateItem("Test Item", "", new List<string>(new String[] { "tag1", "tag2", "tag1" }));
            itemFactory.CreateItem("Test Item 2", "", new List<string>(new String[] { "tag1", "tag4", "tag5" }));
            List<Item> tag1Items = itemFactory.FetchItemsByTagName("tag1");
            Assert.AreEqual(2, tag1Items.Count);
            Assert.AreEqual("Test Item", tag1Items[0].Name);
            Assert.AreEqual("Test Item 2", tag1Items[1].Name);
            List<Item> tag4Items = itemFactory.FetchItemsByTagName("tag4");
            Assert.AreEqual(1, tag4Items.Count);
            Assert.AreEqual("Test Item 2", tag1Items[0].Name);
        }
    }
}
