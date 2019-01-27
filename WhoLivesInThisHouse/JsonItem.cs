using System;
using System.Collections.Generic;

namespace WhoLivesInThisHouse
{
    public class JsonItem
    {
        private String name;
        private List<String> tags;
        private String uiBinding;

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
