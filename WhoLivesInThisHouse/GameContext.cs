using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class GameContext
    {
        private static GameContext instance;
        private RandomNumberGenerator randomNumberGenerator;
        private TagFactory tagFactory;
        private ItemFactory itemFactory;
        private JsonItemListFactory jsonItemListFactory;
        private CharacterFactory characterFactory;
        private CharacterNameGenerator characterNameGenerator;
        private RoomFactory roomFactory;
        private Room currentRoom;
        private Character roomOwner;
        private GameServer gameServer;

        public static GameContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameContext();
                }
                return instance;
            }
        }

        private GameContext()
        {
            randomNumberGenerator = new SystemRandomNumberGenerator();
            tagFactory = new TagFactory(randomNumberGenerator);
            itemFactory = new ItemFactory(tagFactory);
            jsonItemListFactory = new JsonItemListFactory(itemFactory);
            characterNameGenerator = new CharacterNameGenerator(randomNumberGenerator);
            characterFactory = new CharacterFactory(randomNumberGenerator, itemFactory, tagFactory, characterNameGenerator);
            roomFactory = new RoomFactory(characterFactory, itemFactory, randomNumberGenerator);
            gameServer = new GameServer();
        }

        public void Init(String itemsJson)
        {
            jsonItemListFactory.GetItems(itemsJson);
            gameServer.StartServer();
        }

        public void Stop()
        {
            gameServer.StopServer();
        }

        public void NewGame(int numberOfCharacters)
        {
            List<Character> characters = characterFactory.GenerateCharactersForGame(numberOfCharacters);
            int characterIndex = randomNumberGenerator.GetRandomInteger(0, numberOfCharacters);
            currentRoom = roomFactory.GenerateRoomForCharacter(characters[characterIndex]);
            roomOwner = characters[characterIndex];
        }

        public Room CurrentRoom
        { 
            get
            {
                return this.currentRoom;
            }
        }

        public List<Character> Characters
        {
            get
            {
                return characterFactory.Characters;
            }
        }

        public Character RoomOwner
        {
            get
            {
                return roomOwner;
            }
        }

        public List<Item> AllItems
        {
            get
            {
                return itemFactory.GetItems();
            }
        }

        public List<Tag> AllTags
        {
            get
            {
                return tagFactory.GetAllTags();
            }
        }

    }
}
