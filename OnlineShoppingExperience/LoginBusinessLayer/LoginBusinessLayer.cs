using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace LoginBusinessLayer
{
   public class LoginBusinessLayer1
    {
       public IEnumerable<Login> Logins
       {
           get
           {
               string connectionString = ConfigurationManager.ConnectionStrings["ECommdbConStr"].ConnectionString;

               List<Login> logins = new List<Login>();

               using (SqlConnection con = new SqlConnection(connectionString))
               {
                   SqlCommand cmd = new SqlCommand("select * from Customers", con);
                   cmd.CommandType = CommandType.Text;
                   con.Open();
                   SqlDataReader rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       Login login = new Login();
                       login.EmailId = rdr["Email"].ToString();
                       login.Password = rdr["Password"].ToString();
                       logins.Add(login);
                   }
               }
               return logins;
           }
       }
        private static string conString = string.Empty;

        
        public List<Login> GetAll()
        {
            
            List<Login> logins = new List<Login>();
            try
            {
                conString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\DotNetProject\OnlineShoppingExperience\SunbeamPuneShoppingWeb\App_Data\eCommerseDB.mdf;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "SELECT * FROM Customers";
                    SqlCommand cmd = new SqlCommand(query, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader != null)
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Login login = new Login()
                                {
                                   
                                    EmailId = reader["Email"].ToString(),
                                   Password=reader["Password"].ToString()
                                };
                                logins.Add(login);
                            }
                        }
                    }
                    if (con.State == ConnectionState.Open)
                        con.Close();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return logins;
        }

    }
}

