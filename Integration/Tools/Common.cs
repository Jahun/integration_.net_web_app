using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;



namespace Integration.Tools
{
    public class Common
    {
        public HttpRequest Request = HttpContext.Current.Request;
        public HttpResponse Response = HttpContext.Current.Response;

        private static string hash_key =
            "sLAFFK4CBcxGfM-lvJWvzwyl3d5j5XeQsw-JwwnxF8iXolUqjxcxdDuhZybGQmxGzuvK0zMrrt23i5DuPNgZr8DEOkNAnC3Ohbwla7A7Umw1%%^";
        
        //control login
        public void controlLogin(bool index=false,bool login=false)
        {
            bool ok = false;
            if (Request.Cookies["puser"]!= null)
            {
                string puser_cookie = Request.Cookies["puser"].Value;
                if (puser_cookie != null)
                {
                    if (Account.exist(puser_cookie) != 0)
                    {
                        ok = true;
                    }
                }

            }

            if (ok) { if (index == false) { Response.Redirect("~/"); } }
            else { if (login == false) {Response.Redirect("~/account/login");} }
            
        }

        //set user cookie
        public void setUserCookie(string hash_id,int day=1)
        {
            HttpCookie user_cookie = Response.Cookies["puser"];
            user_cookie.Value = hash_id;
            user_cookie.Expires = DateTime.Now.AddDays(day);
            user_cookie.Path = "/";
            Response.Redirect("~/");
        } 
        
        //get user cookie
        public string getUserCookie()
        {
           return Request.Cookies["puser"].Value;
 
        }


        //md5
        public static string md5(string word)
        {

            StringBuilder crypted = new StringBuilder();
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(word);
            bytes = md5.ComputeHash(bytes);

            foreach (byte byt in bytes)
            {
                crypted.Append(byt.ToString("x2").ToLower());
            }

            return crypted.ToString();
        }

        //create hash id
        public static string createHashId(string email,string password)
        {
            return md5(email + md5(password) + hash_key);
        }

        //filter string
        public static string filterString(string word)
        {

            return HttpContext.Current.Server.HtmlEncode(word.Trim()); 
        }

    }
}