using System;
namespace WhoLivesInThisHouse
{
    public class Tag
    {
        private String name;
        public Tag(String name)
        {
            this.name = name;
        }

        public String GetName()
        {
            return this.name;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Tag))
            {
                return false;
            }
            Tag other = (Tag) obj;
            return GetName().Equals(other.GetName());
        }

        public override int GetHashCode()
        {
            return GetName().GetHashCode();
        }
    }
}
