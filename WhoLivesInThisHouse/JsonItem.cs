using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class JsonItem
    {
        private String name;
        private List<String> tags;
        private String uiBinding;
        private String imageFilenamePrefix;
        private String soundFilenamePrefix;

        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public String UiBinding
        {
            get
            {
                return uiBinding != null ? uiBinding : ""; 
            }
            set 
            {
                this.uiBinding = value;
            }
        }

        public String ImageFilenamePrefix
        {
            get
            {
                return imageFilenamePrefix != null ? imageFilenamePrefix : name.ToLower();
            }
            set
            {
                this.imageFilenamePrefix = value;
            }
        }

        public String SoundFilenamePrefix
        {
            get
            {
                return soundFilenamePrefix != null ? soundFilenamePrefix : name.ToLower();
            }
            set
            {
                this.soundFilenamePrefix = value;
            }
        }

        public List<String> Tags
        {
            get
            {
                return this.tags;
            }
            set
            {
                this.tags = value;
            }
        }

        

    }
}
