using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WhoLivesInThisHouse
{
    public class RoomSerializer
    {
       public String Serialize(Room room)
        {
            return JsonConvert.SerializeObject(room);
        }
    }
}
