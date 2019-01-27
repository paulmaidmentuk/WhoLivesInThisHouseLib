using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class JsonItemListFactoryTest
    {
        [Test()]
        public void it_should_be_able_to_deserialize_a_collection_of_items()
        {
            String json = @"[{
              'name': 'Test1',
              'tags': [
                'tag1',
                'tag2'
              ]
            },
            {
              'name': 'Test2',
              'tags': [
                'tag3',
                'tag4'
              ]
            }]";

            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            JsonItemListFactory jsonItemListFactory = new JsonItemListFactory(itemFactory);
            List<Item> itemList = jsonItemListFactory.GetItems(json);
            Assert.AreEqual(2, itemList.Count);
            Assert.AreEqual("Test1", itemList[0].Name);
            Assert.AreEqual("tag1", itemList[0].Tags[0].Name);
            Assert.AreEqual("tag2", itemList[0].Tags[1].Name);
            Assert.AreEqual("Test2", itemList[1].Name);
            Assert.AreEqual("tag3", itemList[1].Tags[0].Name);
            Assert.AreEqual("tag4", itemList[1].Tags[1].Name);
        }
    }
}
