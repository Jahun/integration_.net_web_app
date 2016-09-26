
using System.ComponentModel.DataAnnotations;
namespace Integration.Models
{
    public class Region
    {
        [Display(Name = "id")]
        public int id { set; get; }
        [Display(Name = "name")]
        public string name { set; get; }
        [Display(Name = "city_id")]
        public int city_id { set; get; }
    }
}