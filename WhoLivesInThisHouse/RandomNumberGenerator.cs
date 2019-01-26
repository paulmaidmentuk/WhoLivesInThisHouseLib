using System;
namespace WhoLivesInThisHouse
{
    public interface RandomNumberGenerator
    {
        int Seed
        {
            get;
        }

        int GetRandomInteger(int min, int max);
    }
}
