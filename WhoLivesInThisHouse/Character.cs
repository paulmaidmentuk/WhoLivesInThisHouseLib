using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Character
    {
        private String name;
        private List<Tag> likeTags;
        private List<Tag> dislikeTags;

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public Character(String name, List<Tag> likeTags, List<Tag> dislikeTags)
        {
            this.name = name;
            this.likeTags = likeTags;
            this.dislikeTags = dislikeTags;
        }

        public List<Tag> LikeTags
        {
            get
            {
                return this.likeTags;
            }
        }

        public List<Tag> DislikeTags
        {
            get
            {
                return this.dislikeTags;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is Character))
            {
                return false;
            }

            Character other = (Character) obj;

            if (!Name.Equals(other.Name))
            {
                return false;
            }

            if(!LikeTags.Equals(other.LikeTags))
            {
                return false;
            }

            if(!DislikeTags.Equals(other.DislikeTags))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() 
                + 31 * this.LikeTags.GetHashCode() 
                + 31 * this.DislikeTags.GetHashCode();
        }
    }
}
