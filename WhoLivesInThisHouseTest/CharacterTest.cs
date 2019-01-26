using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class CharacterTest
    {
        [Test()]
        public void it_should_be_constructed_with_likes_and_dislikes_as_tags()
        {
            List<Tag> likeTags = new List<Tag> { new Tag("tag1"), new Tag("tag2")};
            List<Tag> dislikeTags = new List<Tag> { new Tag("tag3"), new Tag("tag4")};
            Character character = new Character(
                "Bob",
                likeTags,
                dislikeTags
            );
            Assert.AreEqual("Bob", character.Name);
            Assert.AreEqual(2, character.LikeTags.Count);
            Assert.AreEqual("tag1", character.LikeTags[0].Name);
            Assert.AreEqual("tag2", character.LikeTags[1].Name);
            Assert.AreEqual(2, character.DislikeTags.Count);
            Assert.AreEqual("tag3", character.DislikeTags[0].Name);
            Assert.AreEqual("tag4", character.DislikeTags[1].Name);
            Console.WriteLine("Character:" + character);
        }

        [Test()]
        public void it_should_be_considered_equal_to_another_character_if_the_attributes_are_identical()
        {
            List<Tag> likeTags = new List<Tag> { new Tag("tag1"), new Tag("tag2") };
            List<Tag> dislikeTags = new List<Tag> { new Tag("tag3"), new Tag("tag4") };

            Character character1 = new Character(
                "Bob",
                likeTags,
                dislikeTags
            );

            Console.WriteLine("Character 1:" + character1);

            Character character2 = new Character(
                "Bob",
                likeTags,
                dislikeTags
            );

            Console.WriteLine("Character 2:" + character2);

            Assert.AreEqual(character1, character2);

            List<Tag> moreTags = new List<Tag> { new Tag("tag4"), new Tag("tag5") };
            Character character3 = new Character(
                "Bob",
                moreTags,
                dislikeTags
            );

            Console.WriteLine("Character 3:" + character3);

            Assert.AreNotEqual(character2, character3);

            Character character4 = new Character(
                "Bob",
                likeTags,
                moreTags
            );

            Console.WriteLine("Character 4:" + character4);

            Assert.AreNotEqual(character2, character4);
        }
    }
}
