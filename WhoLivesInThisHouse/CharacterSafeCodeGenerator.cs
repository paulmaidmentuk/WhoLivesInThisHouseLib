using System;
namespace WhoLivesInThisHouse
{
    public class CharacterSafeCodeGenerator
    {
        private RandomNumberGenerator randomNumberGenerator;
        public CharacterSafeCodeGenerator(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public String GenerateCode()
        {
            int code = randomNumberGenerator.GetRandomInteger(0, 9999);
            return code.ToString().PadLeft(4, '0');
        }

    }
}
