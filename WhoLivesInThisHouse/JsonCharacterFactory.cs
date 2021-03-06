﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{

    public class JsonCharacterFactory
    {
        private CharacterFactory characterFactory;

        public JsonCharacterFactory()
        {

        }

        public List<Item> GetItems(String json)
        {
            List<Item> result = new List<Item>();
            List<JsonItem> jsonItems = JsonConvert.DeserializeObject<List<JsonItem>>(json);
            foreach(JsonItem jsonItem in jsonItems)
            {
                result.Add(itemFactory.CreateItem(jsonItem.Name, jsonItem.Tags));

            }
            return result;
        }
    }
}
