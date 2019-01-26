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

        public String Name
        {
            get
            {
                return this.name;
            }

        }

        public override bool Equals(object obj)
        {
            if (!(obj is Tag))
            {
                return false;
            }
            Tag other = (Tag) obj;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            String result = "[Tag] Name:" + Name +" ";
            return result;
        }
    }
}
