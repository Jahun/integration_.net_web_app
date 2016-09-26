using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Api.POCO;

namespace Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPersonsService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getPersons?hash={hash}&country={country}&city={city}&region={region}&order_by={order_by}&order_type={order_type}",
            ResponseFormat = WebMessageFormat.Json)]
        List<Person> getPersons(string hash="",string country = "", string city = "", string region = "", string order_by = "1", string order_type = "0");

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getDetails?hash={hash}&id={id}", ResponseFormat = WebMessageFormat.Json)]
        List<PersonDetails> getDetails(string hash = "", string id = "");

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCountries?hash={hash}", ResponseFormat = WebMessageFormat.Json)]
        List<Country> getCountries(string hash = "");

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getCities?hash={hash}&country={country}", ResponseFormat = WebMessageFormat.Json)]
        List<City> getCities(string hash = "",string country = "");

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "getRegions?hash={hash}&city={city}", ResponseFormat = WebMessageFormat.Json)]
        List<Region> getRegions(string hash = "", string city="");

    }
}
