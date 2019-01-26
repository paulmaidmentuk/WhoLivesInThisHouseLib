using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class RoomFactory
    {
        List<Item> items;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;
        private RandomNumberGenerator randomNumberGenerator;

        public RoomFactory(
            CharacterFactory characterFactory,
            ItemFactory itemFactory,
            RandomNumberGenerator randomNumberGenerator
        ) {
            this.characterFactory = characterFactory;
            items = new List<Item>();
            this.itemFactory = itemFactory;
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public Room GenerateRoomForCharacter(Character character)
        {
            PopulateRoomWithLikedItemsFromCharacter(character);
            PopulateRoomWithFillerItems(character);
            return new Room(items);
        }

        private void PopulateRoomWithLikedItemsFromCharacter(Character character)
        {
            foreach (Tag likeTag in character.LikeTags)
            {
                List<Item> tagItems = itemFactory.FetchItemsByTagName(likeTag.GetName());
                if (tagItems.Count == 0)
                {
                    throw new Exception("There must be items for the tag " + likeTag.GetName() + " please check config");
                }
                int randomItemIndex = randomNumberGenerator.GetRandomInteger(0, tagItems.Count);
                Item selectedTagItem;
                do
                {
                    selectedTagItem = tagItems[randomItemIndex];
                } while (items.Contains(selectedTagItem));
                items.Add(selectedTagItem);
            }
        }

        private void PopulateRoomWithFillerItems(Character character)
        {
            List<Character> characters = characterFactory.GetAllCharactersExcludingOne(character);
            List<Tag> tagsDislikedByOtherCharacters = new List<Tag>();
            foreach(Character c in characters)
            {
                foreach(Tag tag in c.DislikeTags)
                {
                    tagsDislikedByOtherCharacters.Add(tag);
                }
            }
            foreach(Tag tag in character.DislikeTags)
            {
                tagsDislikedByOtherCharacters.Remove(tag);
            }
            foreach (Tag tag in character.LikeTags)
            {
                tagsDislikedByOtherCharacters.Remove(tag);
            }

            foreach (Tag fillerTag in tagsDislikedByOtherCharacters)
            {
                List<Item> tagItems = itemFactory.FetchItemsByTagName(fillerTag.GetName());
                if (tagItems.Count == 0)
                {
                    throw new Exception("There must be items for the tag " + fillerTag.GetName() + " please check config");
                }
                int randomItemIndex = randomNumberGenerator.GetRandomInteger(0, tagItems.Count);
                Item selectedTagItem;
                do
                {
                    selectedTagItem = tagItems[randomItemIndex];
                } while (items.Contains(selectedTagItem));
                items.Add(selectedTagItem);
                if (items.Count > 10)
                {
                    //Stop after so many items
                    break;
                }
            }
        }
    }
}
