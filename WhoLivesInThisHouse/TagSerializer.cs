using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class TagSerializer
    {
       public String Serialize(Tag tag)
        {
            return JsonConvert.SerializeObject(tag);
        }
    }
}
