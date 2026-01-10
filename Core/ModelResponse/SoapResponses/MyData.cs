using System.Runtime.Serialization;

namespace Core.ModelResponse.SoapResponses
{
    [DataContract]
    public class MyData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
