using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mannschaftsverwaltung
{
    public class PersonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Person));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);

            if (jo.ContainsKey("Erfahrung"))
                return jo.ToObject<Trainer>(serializer);

            else if (jo.ContainsKey("Anerkennungen"))
                return jo.ToObject<Physiotherapeut>(serializer);

            else if (jo["SportArt"].Value<string>() == "FusballSpieler")
                return jo.ToObject<FussballSpieler>(serializer);

            else if (jo["SportArt"].Value<string>() == "HandballSpieler")
                return jo.ToObject<HandballSpieler>(serializer);

            else if (jo["SportArt"].Value<string>() == "TennisSpieler")
                return jo.ToObject<TennisSpieler>(serializer);

            return null;
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}