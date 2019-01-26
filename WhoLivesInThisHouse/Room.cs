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
    }
}
