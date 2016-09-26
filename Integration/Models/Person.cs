
using System.ComponentModel.DataAnnotations;
namespace Integration.Models
{
    public class Person
    {

        [Display(Name = "id")]
        public int id { set; get; }
        [Display(Name = "first_name")]
        public string first_name { set; get; }
        [Display(Name = "last_name")]
        public string last_name { set; get; }

    }
}