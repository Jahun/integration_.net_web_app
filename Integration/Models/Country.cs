

using System.ComponentModel.DataAnnotations;
namespace Integration.Models
{
    public class Country
    {
        [Display(Name = "id")]
        public int id { set; get; }
        [Display(Name = "name")]
        public string name { set; get; }

    }
}