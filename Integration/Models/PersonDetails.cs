using System.ComponentModel.DataAnnotations;
namespace Integration.Models
{
    public class PersonDetails
    {
        [Display(Name = "id")]
        public int id { set; get; }
        [Display(Name = "first_name")]
        public string first_name { set; get; }
        [Display(Name = "last_name")]
        public string last_name { set; get; }
        [Display(Name = "phone")]
        public int phone { set; get; }
        [Display(Name = "email")]
        public string email { set; get; }
        [Display(Name = "birthday")]
        public string birthday { set; get; }
        [Display(Name = "address")]
        public string address { set; get; }
    }
}

