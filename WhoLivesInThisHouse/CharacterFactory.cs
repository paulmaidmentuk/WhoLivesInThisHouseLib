using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class CharacterFactory
    {
        private List<Character> characters;
        private RandomNumberGenerator randomNumberGenerator;
        private CharacterNameGenerator characterNameGenerator;
        private CharacterSafeCodeGenerator characterSafeCodeGenerator;
        private TagFactory tagFactory;
        ItemFactory itemFactory;

        public CharacterFactory(
            RandomNumberGenerator randomNumberGenerator,
            ItemFactory itemFactory,
            TagFactory tagFactory,
            CharacterNameGenerator characterNameGenerator,
            CharacterSafeCodeGenerator characterSafeCodeGenerator
        ) {
            characters = new List<Character>();
            this.randomNumberGenerator = randomNumberGenerator;
            this.characterNameGenerator = characterNameGenerator;
            this.itemFactory = itemFactory;
            this.tagFactory = tagFactory;
            this.characterSafeCodeGenerator = characterSafeCodeGenerator;
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

                String characterSafeCode = "";
                do
                {
                    characterSafeCode = characterSafeCodeGenerator.GenerateCode();
                } while (!SafeCodeIsUnique(characterSafeCode));

                List <Tag> likes = tagFactory.GetRandomTags(5, new List<Tag> { }, itemFactory, false);

                List<Tag> dislikes;
                dislikes = tagFactory.GetRandomTags(5, likes, itemFactory, true);



                Character character = new Character(
                    characterName,
                    likes,
                    dislikes,
                    characterSafeCode
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

        public List<Character> GetAllCharactersExcludingOne(Character excluded)
        {
            List<Character> result = new List<Character>();
            foreach (Character character in this.characters)
            {
                if (!character.Equals(excluded))
                {
                    result.Add(character);
                }
            }
            return result;
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

        private bool SafeCodeIsUnique(String safeCode)
        {
            foreach (Character character in characters)
            {
                if (character.SafeCode.Equals(safeCode))
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
                if (character.LikeTags.Equals(likes) || character.DislikeTags.Equals(likes))
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
                if (character.LikeTags.Equals(dislikes) || character.DislikeTags.Equals(dislikes))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
