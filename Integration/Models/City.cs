

using System.ComponentModel.DataAnnotations;
namespace Integration.Models
{
    public class City
    {
        [Display(Name = "id")]
        public int id { set; get; }
        [Display(Name = "name")]
        public string name { set; get; }
        [Display(Name = "country_id")]
        public int country_id { set; get; }
    }
}