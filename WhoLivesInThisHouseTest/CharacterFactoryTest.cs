using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;
using NSubstitute;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class CharacterFactoryTest
    {
        [Test()]
        public void it_should_set_up_dislikes_and_likes_for_characters()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();
            TagFactory tagFactory = new TagFactory(randomNumberGenerator);
            ItemFactory itemFactory = new ItemFactory(tagFactory);
            CharacterNameGenerator characterNameGenerator = new CharacterNameGenerator(randomNumberGenerator);
            CharacterSafeCodeGenerator characterSafeCodeGenerator = new CharacterSafeCodeGenerator(randomNumberGenerator);

            for (int i = 1; i < 51; i++)
            {
                itemFactory.CreateItem("item" + i, "", new List<String> { "item"+i+"tag1", "commonTag1", "commonTag2"});
            }

            CharacterFactory characterFactory = new CharacterFactory(randomNumberGenerator, itemFactory, tagFactory, characterNameGenerator, characterSafeCodeGenerator);
            List<Character> characters = characterFactory.GenerateCharactersForGame(5);
            Assert.AreEqual(5, characters.Count);
            Assert.AreEqual(5, characters[0].LikeTags.Count);

            Console.WriteLine("Characters:\n");
            foreach(Character character in characters)
            {
                Console.WriteLine(character);
            }
        }
    }
}
