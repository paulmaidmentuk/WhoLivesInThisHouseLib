using NUnit.Framework;
using System;
using System.Collections.Generic;
using NSubstitute;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class CharacterSafeCodeGeneratorTest
    {
        [Test()]
        public void it_should_generate_correctly_padded_codes()
        {
            RandomNumberGenerator randomNumberGenerator = Substitute.For<RandomNumberGenerator>();
            randomNumberGenerator.GetRandomInteger(0, 9999).Returns(0, 1, 2, 3, 5, 10, 20, 100, 200, 1000, 2000, 9999);
            CharacterSafeCodeGenerator characterSafeCodeGenerator = new CharacterSafeCodeGenerator(randomNumberGenerator);
            Assert.AreEqual("0000", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0001", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0002", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0003", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0005", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0010", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0020", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0100", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("0200", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("1000", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("2000", characterSafeCodeGenerator.GenerateCode());
            Assert.AreEqual("9999", characterSafeCodeGenerator.GenerateCode());
        }
    }
}
