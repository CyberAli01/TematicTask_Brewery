using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace BreweryApp.Models
{
    public class Client
    {
        [Key]
        [JsonProperty("id")]
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        [XmlElement("Name")]
        public string Name { get; set; }

        [StringLength(20)]
        [JsonProperty("phone")]
        [XmlElement("Phone")]
        public string Phone { get; set; }

        [JsonProperty("photoPath")]
        [XmlElement("PhotoPath")]
        public string PhotoPath { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public List<Order> Orders { get; set; }
    }
}