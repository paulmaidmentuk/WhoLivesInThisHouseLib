using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class TagListSerializer
    {
       public String Serialize(List<Tag> tags)
        {
            return JsonConvert.SerializeObject(tags);
        }
    }
}
