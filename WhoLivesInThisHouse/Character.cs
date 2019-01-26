using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class Character
    {
        private List<Tag> likeTags;
        private List<Tag> dislikeTags;

        public Character(List<Tag> likeTags, List<Tag> dislikeTags)
        {
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
    }
}
