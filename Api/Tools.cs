using System;
using System.Web;

namespace Api
{
    public class Tools
    {
        //convert to number
        public static int convertTonumber(string str = "")
        {
            int num;
            try
            {
                num = Convert.ToInt32(str);
            }
            catch (Exception)
            {

                num = 0;
            }

            return num;
        }



       


        //filter string
        public static string filterString(string word)
        {

            return HttpContext.Current.Server.HtmlEncode(word.Trim()); ;
        }
    }
}