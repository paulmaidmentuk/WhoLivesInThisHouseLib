using System;
namespace WhoLivesInThisHouse
{
    public class SystemRandomNumberGenerator : RandomNumberGenerator
    {
        private Random random;
        private int seed;

        public SystemRandomNumberGenerator()
        {
            random = new Random();
        }

        public SystemRandomNumberGenerator(int seed)
        {
            this.seed = seed;
            random = new Random(seed);
        }

        public int Seed
        {
            get
            {
                return seed;
            }
        }

        public int GetRandomInteger(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
