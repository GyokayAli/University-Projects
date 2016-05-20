using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebAppRestaurantSystem
{
    public class DBConnectivity
    {
        //DB connection method
        private static SqlConnection GetConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }

        //method that helps to register a new user and save their details
        public static void RegisterNewUser(string email, string fName, string lName, string passw, string gender, string dob, string tel, string postcode, string address )
        {
            SqlConnection sqlConn = GetConnection();

            string myQuery = @"INSERT INTO ag306.pdcCustomer (email,fname,lname,passw,gender,dob,tel,postcode,addres) 
                            VALUES (@email,@fname,@lname,@passw,@gender,@dob,@tel,@postcode,@addres);";

            SqlCommand myCommand = new SqlCommand(myQuery, sqlConn);
            //using parameters to prevent SQL Injection
            List<SqlParameter> prm = new List<SqlParameter>()
            {
                new SqlParameter("@email", SqlDbType.VarChar) {Value = email},
                new SqlParameter("@fname", SqlDbType.VarChar) {Value = fName},
                new SqlParameter("@lname", SqlDbType.VarChar) {Value = lName},
                new SqlParameter("@passw", SqlDbType.VarChar) {Value = passw},
                new SqlParameter("@gender", SqlDbType.VarChar) {Value = gender},
                new SqlParameter("@dob", SqlDbType.VarChar) {Value = dob},
                new SqlParameter("@tel", SqlDbType.VarChar) {Value = tel},
                new SqlParameter("@postcode", SqlDbType.VarChar) {Value = postcode},
                new SqlParameter("@addres", SqlDbType.VarChar) {Value = address},
            };
            myCommand.Parameters.AddRange(prm.ToArray());

            try
            {
                sqlConn.Open();           // open conn
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Account creation has failed!",ex);
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
        }

        //method used at Login, checks if user input match with the data in the database
        public static bool LoginUser(string email, string passw)
        {
            SqlConnection sqlConn = GetConnection();
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT email, passw FROM pdcCustomer WHERE email='" + email + "' AND passw='" + passw + "';";

            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr = sqlCmd.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: ",ex);
                return false;
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
        }

        //returns a Data Table by postcode and limit of how many items to be displayed
        public static DataTable LoadRestaurantTableByPostcode(string postcode, int limit)
        {
            string postcodeSubstr;
            if (postcode.Length == 7)
                postcodeSubstr = postcode.Substring(0, 3);
            else if (postcode.Length == 8)
                postcodeSubstr = postcode.Substring(0, 4);
            else
                postcodeSubstr = postcode;

            SqlConnection myConnection = GetConnection();
            string myQuery = @"SELECT TOP "+limit+" r.restID as ID,";
                    myQuery += @"r.restName as Restaurant, 
                                ri.postcode as Postcode, 
                                ri.addres as Address, 
                                ri.foodType as Food,
                                ri.tel as Telephone,
                                ri.email as Email,
                                ri.website as Website,
                                ri.adType as AdType,
                                l.logoURL as LogoURL,
                                l.logoName as Logo,
                                ri.avgPrice as AvgPrice 
                                FROM pdcRestaurant r
                                INNER JOIN pdcRestaurantInfo ri ON ri.restID= r.restID
                                INNER JOIN pdcLogo l on l.restID = r.restID WHERE ri.postcode LIKE '%" + postcodeSubstr + "%';";
            SqlDataAdapter sda = new SqlDataAdapter(myQuery, myConnection);

            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();                                     // open conn
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();                                   // close conn
            }
        }

        //returns Data Table by restaurant ID. A single records is returned
        public static DataTable LoadRestaurantTableByID(int restID)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = @"SELECT r.restID as ID, 
                                r.restName as Restaurant, 
                                ri.postcode as Postcode, 
                                ri.addres as Address, 
                                ri.foodType as Food,
                                ri.tel as Telephone,
                                ri.email as Email,
                                ri.website as Website,
                                ri.adType as AdType,
                                l.logoURL as LogoURL,
                                l.logoName as Logo,
                                ri.avgPrice as AvgPrice 
                                FROM pdcRestaurant r
                                INNER JOIN pdcRestaurantInfo ri ON ri.restID= r.restID
                                INNER JOIN pdcLogo l on l.restID = r.restID WHERE r.restID=" + restID + ";";
            SqlDataAdapter sda = new SqlDataAdapter(myQuery, myConnection);

            DataTable dt = new DataTable();
            try
            {
                myConnection.Open();                                     // open conn
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();                                   // close conn
            }
        }

        //helper method to get customer's postcode
        public static string GetCustomerPostcode(string email)
        {
            SqlConnection sqlConn = GetConnection();
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT postcode FROM pdcCustomer WHERE email='" + email + "';";

            string postcode = "";
            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr = sqlCmd.ExecuteReader();

                while (dr.Read())
                {
                    postcode = dr["postcode"].ToString();
                }
                return postcode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong: ", ex);
                return postcode;
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
        }
    }
}