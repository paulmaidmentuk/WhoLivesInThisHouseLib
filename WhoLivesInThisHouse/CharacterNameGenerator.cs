using System;
namespace WhoLivesInThisHouse
{
    public class CharacterNameGenerator
    {
        private RandomNumberGenerator randomNumberGenerator;
        private String[] fornames = { "attractive", "bald", "beautiful", "clean", "dazzling", "drab", "elegant", "fancy", "fit", "glamorous", "gorgeous", "handsome", "long", "magnificent", "muscular", "quaint", "scruffy", "shapely", "short", "skinny", "stocky", "unsightly" };
        private String[] surnames = { "farmer", "butcher", "baker", "programmer", "artist", "musician", "rockstar", "dragon", "fox", "kitty", "hound", "paul", "rob", "marcus", "denney", "dinah"};

        public CharacterNameGenerator(RandomNumberGenerator randomNumberGenerator)
        {
            this.randomNumberGenerator = randomNumberGenerator;
        }

        public String Generate()
        {
            int forenameIndex = randomNumberGenerator.GetRandomInteger(0, fornames.Length);
            int surnameIndex = randomNumberGenerator.GetRandomInteger(0, surnames.Length);
            String name = UppercaseFirstLetter(fornames[forenameIndex]) + " " + UppercaseFirstLetter(surnames[surnameIndex]);
            Console.WriteLine(name);
            return name;
        }

        private string UppercaseFirstLetter(String text)
        {
            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
