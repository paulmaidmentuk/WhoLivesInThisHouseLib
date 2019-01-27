using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Room
    {
        private List<Item> items;
        private Character owner;

        public Room(List<Item> items, Character owner)
        {
            this.items = items;
            this.owner = owner;
        }

        public List<Item> Items
        {
            get
            {
                return this.items;
            }
        }

        public Character Owner
        {
            get
            {
                return this.owner;
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
