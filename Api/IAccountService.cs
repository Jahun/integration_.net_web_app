
using System.ServiceModel;
using System.ServiceModel.Web;
using Api.POCO;

namespace Api
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAccountService" in both code and config file together.
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "userExist?hash={hash}", ResponseFormat = WebMessageFormat.Json)]
        int userExist(string hash = null);

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "userRegister",RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json)]
        int userRegister(User user);
    }
}
