using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Script.Serialization;
using Integration.Models;


namespace Integration
{
    public class Account
    {


        private static string base_url = "http://localhost:9673/account.svc/";

        ///Exist function
        public static int exist(string hash_id)
        {
            try
            {
                var wc = new WebClient();
                var json = wc.DownloadString(base_url + "userExist?hash=" + hash_id);
                var js = new JavaScriptSerializer();
                return Convert.ToInt32(js.DeserializeObject(json));
            }
            catch (Exception)
            {

                return 0;
            }

        }

        //Registration function
        public static string register(User user)
        {
            var message = "";

            try
            {
                int suc = 0;
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(User));
                MemoryStream memoryStream = new MemoryStream();
                serializer.WriteObject(memoryStream, user);
                string data = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, (int)memoryStream.Length);
                WebClient webClient = new WebClient();
                webClient.Headers["Content-Type"] = "application/json";
                webClient.Encoding = Encoding.UTF8;
                var json = webClient.UploadString(base_url + "/userRegister", "POST", data);
                var js = new JavaScriptSerializer();
                suc=Convert.ToInt32(js.DeserializeObject(json));
                switch (suc)
                {
                    case 1: message = "true"; break;
                    case 2: message = "<i style='color:red '>With this email already registered another user!!!</i>"; break;
                    default: message = "<i style='color:red '>Error.Try again!!!</i>"; break;
                }

            }
            catch (Exception exception)
            {
                return exception.ToString();
            }


            

            return message;

        }






    }
}