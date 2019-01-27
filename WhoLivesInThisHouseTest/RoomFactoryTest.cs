using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class RoomFactoryTest
    {
        [Test()]
        public void it_should_be_able_to_generate_a_room_of_items()
        {
            for (int k = 0; k < 1000; k++)
            {
                RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();

                TagFactory tagFactory = new TagFactory(randomNumberGenerator);

                ItemFactory itemFactory = new ItemFactory(tagFactory);

                CharacterNameGenerator characterNameGenerator = new CharacterNameGenerator(randomNumberGenerator);
                CharacterSafeCodeGenerator characterSafeCodeGenerator = new CharacterSafeCodeGenerator(randomNumberGenerator);

                for (int i = 1; i < 51; i++)
                {
                    itemFactory.CreateItem("item" + i, "", "", "", new List<String> { "item" + i + "tag1", "common"});
                }

                CharacterFactory characterFactory = new CharacterFactory(
                    randomNumberGenerator,
                    itemFactory,
                    tagFactory,
                    characterNameGenerator,
                    characterSafeCodeGenerator
                );

                List<Character> characters = characterFactory.GenerateCharactersForGame(5);

                RoomFactory roomFactory = new RoomFactory(
                    characterFactory,
                    itemFactory,
                    randomNumberGenerator
                );

                Room room = roomFactory.GenerateRoomForCharacter(characters[1]);
                //Assert.AreEqual(10, room.Items.Count);

                foreach(Tag tag in characters[1].DislikeTags)
                {
                    foreach (Item item in room.Items)
                    {
                        Console.WriteLine(tag.Name);
                        Assert.False(item.Tags.Contains(tag));
                    }
                }

                Console.WriteLine("Characters:");
                foreach (Character c in characters)
                {
                    Console.WriteLine(c + "\n");
                }
                Console.Write("Room:\n" + room);
            }
        }
    }
}
