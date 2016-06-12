using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace CustomerBusinessLayer
{
    public class BusinessLayer
    {
        public IEnumerable<Customer> Customers
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ECommdbConStr"].ConnectionString;

                List<Customer> customers = new List<Customer>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("select * from Customers", con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Customer customer = new Customer();
                        customer.CustomerID = Convert.ToInt32(rdr["CustomersId"]);
                        customer.FirstName = rdr["FirstName"].ToString();
                        customer.LastName = rdr["LastName"].ToString();
                        customer.Address = rdr["Address"].ToString();
                        customer.MobileNo = rdr["MobileNo"].ToString();
                        customer.RegistrationDate = DateTime.Parse(rdr["RegistrationDate"].ToString());
                        customer.Password = rdr["Password"].ToString();
                        //customer.Role= rdr["Role"].ToString();
              
                        customers.Add(customer);
                    }
                }
                return customers;
            }
        }

        public Customer GetCustomer(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ECommdbConStr"].ConnectionString;

            List<Customer> customers = new List<Customer>();
            Customer customer = new Customer();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlcmd = "select * from Customers where CustomersId=" + id;

                SqlCommand cmd = new SqlCommand(sqlcmd, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    customer.CustomerID = Convert.ToInt32(rdr["Id"]);
                    customer.FirstName = rdr["FirstName"].ToString();
                    customer.LastName = rdr["LastName"].ToString();
                    customer.Address = rdr["Address"].ToString();
                    customer.Email = rdr["Email"].ToString();
                    customer.MobileNo = rdr["MobileNo"].ToString();
                    customer.Password = rdr["Password"].ToString();
                    customer.RegistrationDate = DateTime.Parse(rdr["RegistrationDate"].ToString());
                   // customer.Role = rdr["Role"].ToString();
                }
            }
            return customer;

        }
        public bool AddCustomer(Customer customer)
        {
            bool status = false;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ECommdbConStr"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string query = "insert into Customers(CustomersId,FirstName,LastName,Address,Email,MobileNo,RegistrationDate,Password) values(@CustomerId,@FirstName,@LastName,@Address,@Email,@MobileNo,@RegistrationDate,@Password)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", customer.CustomerID));
                    cmd.Parameters.Add(new SqlParameter("@FirstName", customer.FirstName));
                    cmd.Parameters.Add(new SqlParameter("@LastName", customer.LastName));
                    cmd.Parameters.Add(new SqlParameter("@Address", customer.Address));
                    cmd.Parameters.Add(new SqlParameter("@Email", customer.Email));
                    cmd.Parameters.Add(new SqlParameter("@MobileNo", customer.MobileNo));
                    cmd.Parameters.Add(new SqlParameter("@RegistrationDate", customer.RegistrationDate));
                    cmd.Parameters.Add(new SqlParameter("@Password", customer.Password));
                    

                    cmd.ExecuteNonQuery();
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    status = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }
        //public void AddCustomer(Customer cust)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["ECommdbConStr"].ConnectionString;
        //   using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        string sqlcmd = "Insert into Customers (CustomerId,FirstName,LastName,Address,Email,MobileNo,RegistrationDate,Password) Values (" + cust.CustomerID + ",'" + cust.FirstName + "','" + cust.LastName + "','" + cust.Address + "'," + cust.Email + "," + cust.MobileNo + "," + cust.RegistrationDate + "," + cust.Password + ")";
        //        SqlCommand cmd = new SqlCommand(sqlcmd, con);
        //        cmd.CommandType = CommandType.Text;
        //        con.Open();
        //        int value = cmd.ExecuteNonQuery();
        //        con.Close();
        //    }
           
            
        //}


        //public void DeleteEmmployee(Employee emp)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        string sqlcmd = "Delete from Employees where Id="+ emp.ID;
        //        SqlCommand cmd = new SqlCommand(sqlcmd, con);
        //        cmd.CommandType = CommandType.Text;
        //        con.Open();
        //        int value = cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    /*
        //    SharePoint Object Model
        //     */
        //}

        //public void UpdateEmmployee(Employee emp)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        string sqlcmd = "Insert into Employees (Id,Name, Gender, City,deptid) Values (" + emp.ID + ",'" + emp.Name + "','" + emp.Gender + "','" + emp.City + "'," + emp.DeptID + ")";
        //        SqlCommand cmd = new SqlCommand(sqlcmd, con);
        //        cmd.CommandType = CommandType.Text;
        //        con.Open();
        //        int value = cmd.ExecuteNonQuery();
        //        con.Close();
        //    }

        //    /*
        //    SharePoint Object Model
        //     */
        //}
    }
}
