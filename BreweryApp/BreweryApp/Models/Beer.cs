using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace BreweryApp.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonProperty("id")]
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [JsonProperty("name")]
        [XmlElement("Name")]
        public string Name { get; set; }

        [StringLength(50)]
        [JsonProperty("type")]
        [XmlElement("Type")]
        public string Type { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        [JsonProperty("abv")]
        [XmlElement("Abv")]
        public decimal ABV { get; set; }

        [JsonProperty("imagePath")]
        [XmlElement("ImagePath")]
        public string ImagePath { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public ICollection<OrderBeer> OrderBeers { get; set; }
    }
}