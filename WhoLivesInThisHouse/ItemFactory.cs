using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class ItemFactory
    {
        private TagFactory tagFactory;
        private List<Item> items;

        public ItemFactory(TagFactory tagFactory)
        {
            this.tagFactory = tagFactory;
            this.items = new List<Item>();
        }

        public Item CreateItem(String name, String uiBinding, String imageFileNamePrefix, String soundFileNamePrefix, List<String> tags)
        {
            Item item = new Item(name, uiBinding, imageFileNamePrefix, soundFileNamePrefix);
            foreach (String tagName in tags)
            {
                Tag tag = tagFactory.GetTagByName(tagName);
                item.AddTag(tag);
            }
            AddItem(item);
            return item;
        }

        private void AddItem(Item item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }

        public List<Item> GetItems()
        {
            return this.items;
        }

        public List<Item> FetchItemsByTagName(String tagName)
        {
            List<Item> result = new List<Item>();
            foreach(Item item in items)
            {
                if (item.HasTag(tagName))
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
