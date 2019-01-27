using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class ItemListSerializer
    {
       public String Serialize(List<Item> items)
        {
            return JsonConvert.SerializeObject(items);
        }
    }
}
