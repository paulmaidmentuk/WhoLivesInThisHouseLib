using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class CharacterListDeserializer
    {
       public List<Character> Deserialize(String json)
        {
            List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(json);
            return characters;
        }
    }
}
