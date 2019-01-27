using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class CharacterListDeserializerTest
    {
        [Test()]
        public void it_should_deserialize_a_list_of_characters()
        {
            String json = @"[{""SafeCode"":""0000"",""Name"":""Bob"",""LikeTags"":[{""Name"":""abc""},{""Name"":""def""}],""DislikeTags"":[{""Name"":""xyz""}]},{""SafeCode"":""0000"",""Name"":""Steve"",""LikeTags"":[{""Name"":""cde""},{""Name"":""fga""}],""DislikeTags"":[{""Name"":""opq""}]}]";
            CharacterListDeserializer deserializer = new CharacterListDeserializer();
            List<Character> characters = deserializer.Deserialize(json);
            Assert.AreEqual(2, characters.Count);
            Assert.AreEqual("Bob", characters[0].Name);
            Assert.AreEqual("0000", characters[0].SafeCode);
            Assert.AreEqual("abc", characters[0].LikeTags[0].Name);
            Assert.AreEqual("def", characters[0].LikeTags[1].Name);
            Assert.AreEqual("xyz", characters[0].DislikeTags[0].Name);
            Assert.AreEqual("Steve", characters[1].Name);
            Assert.AreEqual("0000", characters[1].SafeCode);
            Assert.AreEqual("cde", characters[1].LikeTags[0].Name);
            Assert.AreEqual("fga", characters[1].LikeTags[1].Name);
            Assert.AreEqual("opq", characters[1].DislikeTags[0].Name);
        }
    }
}
