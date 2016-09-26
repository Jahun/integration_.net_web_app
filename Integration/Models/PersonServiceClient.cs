using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using Integration.Tools;

namespace Integration.Models
{
    public class PersonServiceClient
    {
        private string base_url = "http://localhost:9673/api.svc/";


        private List<T> downloadInfo<T>(string func_name, string parametrs)
        {
            var hash = new Common().getUserCookie();
            var wc = new WebClient();
            var json = wc.DownloadString(base_url + func_name + "?hash=" + hash + parametrs);
            var js = new JavaScriptSerializer();
            return js.Deserialize<List<T>>(json);
        }






        //Get Persons
        public List<Person> getPersons(string country = null, string city = null, string region = null, string order_by = "1", string order_type = "0")
        {
            try
            {
                var parametrs = "&country=" + country + "&city=" + city + "&region=" + region + "&order_by=" + order_by + "&order_type=" + order_type;
                return downloadInfo<Person>("getPersons", parametrs);
            }
            catch (Exception)
            {

                return null;
            }
        }

        //Get Details
        public List<PersonDetails> getDetails(string id)
        {
            try
            {
                var parametrs = "&id=" + id;
                return downloadInfo<PersonDetails>("getDetails", parametrs);
            }
            catch (Exception)
            {

                return null;
            }
        }

        //Get Counteries
        public List<Country> getCountries()
        {
            try
            {
                return downloadInfo<Country>("getCountries", "");
            }
            catch (Exception)
            {

                return null;
            }
        }

        //Get Cities
        public List<City> getCities(string country)
        {
            try
            {
                var parametrs = "&country=" + country;
                return downloadInfo<City>("getCities", parametrs);
            }
            catch (Exception)
            {

                return null;
            }
        }


        //Get Regions
        public List<Region> getRegions(string city)
        {
            try
            {
                var parametrs = "&city=" + city;
                return downloadInfo<Region>("getRegions", parametrs);
            }
            catch (Exception)
            {

                return null;
            }
        }

    }
}