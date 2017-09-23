using Newtonsoft.Json;

namespace AlphaCompanyWebApi.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
        public Link Self { get; set; }
    }
}
