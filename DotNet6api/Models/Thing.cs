using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DotNet6api.Models
{
    public class Thing
    {
        public int ThingId { get; set; }
        public string Title { get; set; } = string.Empty;   
        public int ItemId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public Item Item { get; set; }
    }
}
