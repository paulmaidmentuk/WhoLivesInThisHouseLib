using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class CharacterListSerializer
    {
       public String Serialize(List<Character> characters)
        {
            return JsonConvert.SerializeObject(characters);
        }
    }
}
