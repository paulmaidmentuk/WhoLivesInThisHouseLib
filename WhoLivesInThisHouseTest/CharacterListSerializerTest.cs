using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class CharacterListSerializerTest
    {
        [Test()]
        public void it_should_serialize_a_list_of_characters()
        {
            CharacterListSerializer serializer = new CharacterListSerializer();
            List<Character> characters = new List<Character>();
            characters.Add(new Character("Bob", new List<Tag> { new Tag("abc"), new Tag("def") }, new List<Tag> { new Tag("xyz") }));
            characters.Add(new Character("Steve", new List<Tag> { new Tag("cde"), new Tag("fga") }, new List<Tag> { new Tag("opq") }));
            String serializedCharacters = serializer.Serialize(characters);
            String expected = @"[{""Name"":""Bob"",""LikeTags"":[{""Name"":""abc""},{""Name"":""def""}],""DislikeTags"":[{""Name"":""xyz""}]},{""Name"":""Steve"",""LikeTags"":[{""Name"":""cde""},{""Name"":""fga""}],""DislikeTags"":[{""Name"":""opq""}]}]";
            Assert.AreEqual(expected, serializedCharacters);
        }
    }
}
