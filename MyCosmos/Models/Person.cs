using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MyCosmos.Models
{
    public class Person
    {
        [JsonProperty(PropertyName ="id")]
        public string Id { get; set; }
        
        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string Firstname { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string Lastname { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [JsonProperty(PropertyName = "birthdate")]
        public string Birthdate { get; set; }

        [JsonProperty(PropertyName = "isMarried")]
        public string IsMarried { get; set; }
    }
}