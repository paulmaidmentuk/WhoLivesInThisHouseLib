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
            characters.Add(new Character("Bob Duck", new List<Tag> { new Tag("abc"), new Tag("def") }, new List<Tag> { new Tag("xyz") }, "0000"));
            characters.Add(new Character("Steve Weave", new List<Tag> { new Tag("cde"), new Tag("fga") }, new List<Tag> { new Tag("opq") }, "0000"));
            String serializedCharacters = serializer.Serialize(characters);
            String expected = @"[{""SafeCode"":""0000"",""Name"":""Bob Duck"",""ImagePrefix"":""bob_duck"",""LikeTags"":[{""Name"":""abc""},{""Name"":""def""}],""DislikeTags"":[{""Name"":""xyz""}]},{""SafeCode"":""0000"",""Name"":""Steve Weave"",""ImagePrefix"":""steve_weave"",""LikeTags"":[{""Name"":""cde""},{""Name"":""fga""}],""DislikeTags"":[{""Name"":""opq""}]}]";
            Assert.AreEqual(expected, serializedCharacters);
        }
    }
}
