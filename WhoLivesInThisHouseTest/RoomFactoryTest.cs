using NUnit.Framework;
using System;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class RoomFactoryTest
    {
        [Test()]
        public void it_should_instantiate()
        {
            RandomNumberGenerator randomNumberGenerator = new SystemRandomNumberGenerator();

            TagFactory tagFactory = new TagFactory(randomNumberGenerator);

            ItemFactory itemFactory = new ItemFactory(tagFactory);

            CharacterNameGenerator characterNameGenerator = new CharacterNameGenerator(randomNumberGenerator);

            CharacterFactory characterFactory = new CharacterFactory(
                randomNumberGenerator,
                itemFactory,
                tagFactory,
                characterNameGenerator
            );

            RoomFactory roomFactory = new RoomFactory(
                characterFactory,
                itemFactory,
                randomNumberGenerator
            );
        }
    }
}
