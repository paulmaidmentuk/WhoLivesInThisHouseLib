using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Room
    {
        private List<Item> items;

        public Room(List<Item> items)
        {
            this.items = items;
        }

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public override string ToString()
        {
            String result = "[Room]:";
            result += "\n Items:\n";
            foreach (Item item in items)
            {
                result += item + "\n";
            }

            return result;
        }
    }
}
