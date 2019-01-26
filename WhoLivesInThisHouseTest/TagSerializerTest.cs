using NUnit.Framework;
using System;
using System.Collections.Generic;
using WhoLivesInThisHouse;

namespace WhoLivesInThisHouseTest
{
    [TestFixture()]
    public class TagSerializerTest
    {
        [Test()]
        public void it_should_serialize_a_list_of_tags()
        {
            TagSerializer serializer = new TagSerializer();
            String serializedTags = serializer.Serialize(new Tag("xyz"));
            int x = 1;
            x++;
        }
    }
}
