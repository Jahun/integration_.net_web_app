using System;
using System.Data;
using System.Data.SqlClient;
using Api.POCO;

namespace Api.BL
{
    public class Account_BL : IAccountService
    {
        DB dal = new DB();

       
        //user control
        public static bool ifLogin(string hash)
        { 
            return new Account_BL().userExist(hash) == 1;
        }

        //Exist function
        public int userExist(string hash = null)
        {
            int exist = 0;
            string hash_id = Tools.filterString(hash);
            try
            {
                dal.connection.Open();
                string query = "SELECT id FROM users WHERE hash_id='" + hash_id + "'";
                SqlDataReader dr = dal.Command(query).ExecuteReader(CommandBehavior.CloseConnection);
                if (dr.Read())
                {
                    exist = 1;
                }
                dal.connection.Close();
            }
            catch (Exception) { }

            return exist;
        }


        //Registration function
        public int userRegister(User user)
        {
            int ok = 0;
            try
            {

                string name = Tools.filterString(user.name);
                string email = Tools.filterString(user.email);
                string password = Tools.filterString(user.password);
                string hash_id = Tools.filterString(user.hash_id);

                if (userExist(hash_id) == 0)
                {

                    dal.connection.Open();

                    string query = "INSERT INTO users (name,email,password,hash_id) VALUES(@name,@email,@password,@hash_id)";
                    SqlCommand sqlCommand = dal.Command(query);
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    sqlCommand.Parameters.AddWithValue("@hash_id", hash_id);
                    ok = sqlCommand.ExecuteNonQuery();

                    dal.connection.Close();

                }
                else
                {
                    ok = 2;
                }
            }
            catch (Exception) { }
            return ok;
        }
    }
}