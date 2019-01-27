using System.Net;
using System;
using System.Collections.Generic;
using System.IO;

namespace WhoLivesInThisHouse
{
    public class CharacterListApiCaller
    {
        private String serverBaseUrl;
        private CharacterListDeserializer deserializer;

        public CharacterListApiCaller(String serverBaseUrl)
        {
            this.serverBaseUrl = serverBaseUrl;
            this.deserializer = new CharacterListDeserializer();
        }

        public List<Character> GetCharacters()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverBaseUrl + "/api/characters");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            return deserializer.Deserialize(jsonResponse);
        }
    }
}
