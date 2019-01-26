using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    /*
        No two characters must like or dislike the same things after generation
    */

    public class CharacterFactory
    {
        private List<Character> characters;
        private RandomNumberGenerator randomNumberGenerator;
        private CharacterNameGenerator characterNameGenerator;
        private TagFactory tagFactory;
        ItemFactory itemFactory;

        public CharacterFactory(
            RandomNumberGenerator randomNumberGenerator,
            ItemFactory itemFactory,
            TagFactory tagFactory,
            CharacterNameGenerator characterNameGenerator
        ) {
            characters = new List<Character>();
            this.randomNumberGenerator = randomNumberGenerator;
            this.characterNameGenerator = characterNameGenerator;
            this.itemFactory = itemFactory;
            this.tagFactory = tagFactory;
        }

        public List<Character> GenerateCharactersForGame(int maxCharacters)
        {
            characters.Clear();

            do
            {
                String characterName = "";
                do
                {
                    characterName = characterNameGenerator.Generate();
                } while (!CharacterNameIsUnique(characterName));

                List<Tag> likes = tagFactory.GetRandomTags(5, new List<Tag> { });
                List<Tag> dislikes = tagFactory.GetRandomTags(5, likes);

                Character character = new Character(
                    characterName,
                    likes,
                    dislikes
                );

                if (LikesAreUnique(likes) && DislikesAreUnique(dislikes))
                {
                    if (!characters.Contains(character))
                    {
                        characters.Add(character);
                    }
                }
            } while (characters.Count < maxCharacters);

            return characters;
        }

        public List<Character> Characters
        {
            get
            {
                return this.characters;
            }
        }

        private bool CharacterNameIsUnique(String characterName)
        {
            foreach (Character character in characters)
            {
                if (character.Name.Equals(characterName))
                {
                    return false;
                }
            }
            return true;
        }

        private bool LikesAreUnique(List<Tag> likes)
        {
            foreach (Character character in characters)
            {
                if (character.LikeTags.Equals(likes))
                {
                    return false;
                }
            }
            return true;
        }

        private bool DislikesAreUnique(List<Tag> dislikes)
        {
            foreach (Character character in characters)
            {
                if (character.DislikeTags.Equals(dislikes))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
