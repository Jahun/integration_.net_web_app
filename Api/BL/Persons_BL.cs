using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Api.POCO;

namespace Api.BL
{
    public class Persons_BL : IService
    {
        DB dal = new DB();


        //Get persons
        public List<Person> getPersons(string hash, string country, string city, string region, string order_by, string order_type)
        {


            List<Person> person_list = new List<Person>();
            try
            {

                if (Account_BL.ifLogin(hash))
                {
                    string where = "";
                    int country_id = Tools.convertTonumber(country);
                    int city_id = Tools.convertTonumber(city);
                    int region_id = Tools.convertTonumber(region);
                    int orderby = Tools.convertTonumber(order_by);
                    int ordertype = Tools.convertTonumber(order_type);
                    string sort_by = "";
                    string sort_type = "";
                    if (ordertype == 1) { sort_type = " DESC"; } else { sort_type = " ASC"; }

                    switch (orderby)
                    {
                        case 2: sort_by = "first_name"; break;
                        case 3: sort_by = "last_name"; break;
                        default: sort_by = "id"; break;
                    }


                    if (country_id != 0) { where = " WHERE id in(SELECT person_id FROM persons_places WHERE country_id=" + country_id; }
                    if (city_id != 0) { where += " AND city_id=" + city_id; }
                    if (region_id != 0) { where += " AND region_id=" + region_id; }
                    if (country_id != 0 || city_id != 0 || region_id != 0) { where += ")"; }



                    dal.connection.Open();
                    string query = "SELECT id,first_name,last_name FROM persons" + where + " ORDER BY " + sort_by + sort_type;
                    SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Person person = new Person();
                        person.id = (int)dr["id"];
                        person.first_name = dr["first_name"].ToString();
                        person.last_name = dr["last_name"].ToString();
                        person_list.Add(person);
                    }
                    dal.connection.Close();
                }
            }
            catch (Exception) { }

            return person_list;
        }

        //Get Person Details
        public List<PersonDetails> getDetails(string hash, string id)
        {
            List<PersonDetails> person_details = new List<PersonDetails>();

            try
            { 
                if (Account_BL.ifLogin(hash))
                {
                    int personID = Tools.convertTonumber(id);
                    dal.connection.Open();
                    string query = "SELECT * FROM persons WHERE id=" + personID;
                    SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        PersonDetails person = new PersonDetails();
                        person.id = (int)dr["id"];
                        person.first_name = dr["first_name"].ToString();
                        person.last_name = dr["last_name"].ToString();
                        person.phone = (int)dr["phone"];
                        person.email = dr["email"].ToString();
                        person.birthday = Convert.ToDateTime(dr["birthday"]).ToString("yyyy-MM-dd");
                        person.address = dr["address"].ToString();
                        person_details.Add(person);
                    }
                    dal.connection.Close();
                }
            }
            catch (Exception)
            { }
            return person_details;
        }


        //Get Counteries
        public List<Country> getCountries(string hash)
        {

            List<Country> countries = new List<Country>();
            try
            {
                if (Account_BL.ifLogin(hash))
                {
                    dal.connection.Open();
                    string query = "SELECT * FROM countries";
                    SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Country country = new Country();
                        country.id = (int)dr["id"];
                        country.name = dr["name"].ToString();
                        countries.Add(country);
                    }
                    dal.connection.Close();
                }
            }
            catch (Exception) { }
            return countries;
        }


        //Get Cities
        public List<City> getCities(string hash, string country)
        {
            List<City> cities = new List<City>();
            try
            {
                if (Account_BL.ifLogin(hash))
                {
                    int country_id = Tools.convertTonumber(country);
                    string where = "";
                    if (country_id != 0)
                    {
                        where = " WHERE country_id=" + country_id;
                    }


                    dal.connection.Open();
                    string query = "SELECT * FROM cities" + where;
                    SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        City city = new City();
                        city.id = (int)dr["id"];
                        city.name = dr["name"].ToString();
                        city.country_id = (int)dr["country_id"];
                        cities.Add(city);
                    }
                    dal.connection.Close();
                }
            }
            catch (Exception)
            { }
            return cities;
        }

        //Get Regions
        public List<Region> getRegions(string hash, string city)
        {
            List<Region> regions = new List<Region>();
            try
            {
                if (Account_BL.ifLogin(hash))
                {
                    int city_id = Tools.convertTonumber(city);
                    string where = "";
                    if (city_id != 0)
                    {
                        where = " WHERE city_id=" + city_id;
                    }


                    dal.connection.Open();
                    string query = "SELECT * FROM regions" + where;
                    SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                    while (dr.Read())
                    {
                        Region region = new Region();
                        region.id = (int)dr["id"];
                        region.name = dr["name"].ToString();
                        region.city_id = (int)dr["city_id"];
                        regions.Add(region);
                    }
                    dal.connection.Close();
                }
            }
            catch (Exception)
            { }
            return regions;
        }

    }
}