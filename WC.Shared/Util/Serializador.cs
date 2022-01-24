using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace WC.Shared.Util
{
    public class Serializador : ISerializer, IDeserializer
    {
        private static Serializador _instancia;
        public static Serializador Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Serializador();

                return _instancia;
            }
        }

        public string ContentType { get; set; }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public string Serialize(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateFormatString = "dd/MM/yyyy"
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
