using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    [Serializable]
    public class Character
    {
        private String name;
        private List<Tag> likeTags;
        private List<Tag> dislikeTags;
        private String safeCode;

        public String SafeCode
        {
            get
            {
                return this.safeCode;
            }
            set
            {
                this.safeCode = value;
            }

        }

        public String Name
        {
            get
            {
                return this.name;
            }
        }

        public Character(String name, List<Tag> likeTags, List<Tag> dislikeTags, String safeCode)
        {
            this.name = name;
            this.likeTags = likeTags;
            this.dislikeTags = dislikeTags;
            this.safeCode = safeCode;
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

            if(!SafeCode.Equals(other.SafeCode))
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode()
                + 31 * this.LikeTags.GetHashCode()
                + 31 * this.DislikeTags.GetHashCode()
                + 31 * this.SafeCode.GetHashCode();
        }

        public override string ToString()
        {
            String result = "[Character] Name:" + Name;

            result += "\n Likes: ";
            foreach (Tag tag in LikeTags)
            {
                result += tag;
            }

            result += "\n Dislikes: ";
            foreach (Tag tag in DislikeTags)
            {
                result += tag;
            }

            result += "\nSafecode:" + SafeCode;

            return result;
        }
    }
}
