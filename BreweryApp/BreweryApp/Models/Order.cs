using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreweryApp.Models
{
    public class Order
    {
        [Key]
        [JsonProperty("id")]
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [JsonProperty("status")]
        [XmlElement("Status")]
        public string Status { get; set; }

        [Column(TypeName = "timestamp with time zone")]
        [JsonProperty("orderDate")]
        [XmlElement("OrderDate")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [JsonProperty("total")]
        [XmlElement("Total")]
        public decimal Total { get; set; }

        [ForeignKey("Client")]
        [JsonProperty("clientId")]
        [XmlElement("ClientId")]
        public int ClientId { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public Client Client { get; set; }

        public List<OrderBeer> OrderBeers { get; set; }
    }
}