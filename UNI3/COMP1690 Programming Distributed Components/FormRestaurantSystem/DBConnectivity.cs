using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace FormRestaurantSystem
{
    class DBConnectivity
    {
        public static SqlConnection GetConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }

        //method that helps to submit a restaurant's name 
        public static void AddRestaurants(string restaurantName)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO ag306.pdcRestaurant (restName) VALUES (@restName)";
            
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
            //using parameters to prevent SQL Injection
            myCommand.Parameters.AddWithValue("restName", restaurantName); 

            try
            {
                myConnection.Open();           // open conn
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();        // close conn
            }
        }

        //method that helps to submit a restaurant's info 
        public static void AddRestaurantInfo(string postcode, string address, string type, string tel, string email, string website, string adType,decimal avgPrice, int restID)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO ag306.pdcRestaurantInfo(postcode,addres,foodType,tel,email,website,adType,avgPrice,restID) VALUES (@postcode,@address,@type,@tel,@email,@website,@adType,@avgPrice,@restID)";

            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
            //using parameters to prevent SQL Injection
            List<SqlParameter> prm = new List<SqlParameter>()
            {
                new SqlParameter("@postcode", SqlDbType.VarChar) {Value = postcode},
                new SqlParameter("@address", SqlDbType.VarChar) {Value = address},
                new SqlParameter("@type", SqlDbType.VarChar) {Value = type},
                new SqlParameter("@tel", SqlDbType.VarChar) {Value = tel},
                new SqlParameter("@email", SqlDbType.VarChar) {Value = email},
                new SqlParameter("@website", SqlDbType.VarChar) {Value = website},
                new SqlParameter("@avgPrice", SqlDbType.Decimal) {Value = avgPrice},
                new SqlParameter("@adType", SqlDbType.VarChar) {Value = adType},
                new SqlParameter("@restID", SqlDbType.Int) {Value = restID},
            };
            myCommand.Parameters.AddRange(prm.ToArray());

            try
            {
                myConnection.Open();           // open conn
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();        // close conn
            }
        }

        //method used to get the last restaurant's ID 
        public static int GetLastRestID()
        {

            int questionID = 0;
            SqlConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM pdcRestaurant WHERE restID = ALL (SELECT MAX(restID) FROM pdcRestaurant);";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();                                     // open conn
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    questionID = int.Parse(myReader["restID"].ToString());
                }
                return questionID;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return 0;
            }
            finally
            {
                myConnection.Close();                                   // close conn
            }
        }

        //method that creates and returns a DataTable containing data from 2 tables pdcRestaurant and pdcRestaurantInfo
        public static DataTable LoadRestaurantTable()
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = @"SELECT r.restID as ID, 
                                r.restName as Restaurant, 
                                ri.postcode as Postcode, 
                                ri.addres as Address, 
                                ri.foodType as Type,
                                ri.tel as Telephone,
                                ri.email as Email,
                                ri.website as Website,
                                ri.adType as AdType,
                                l.logoURL as LogoURL,
                                l.logoName as LogoName,
                                ri.avgPrice as AvgPrice 
                                FROM pdcRestaurant r 
                                INNER JOIN pdcRestaurantInfo ri ON ri.restID= r.restID
                                INNER JOIN pdcLogo l on l.restID = r.restID";
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

        //method that helps to delete a selected row from the db
        public static void DeleteSelectedRow(int row)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "DELETE FROM ag306.pdcRestaurantInfo WHERE restID = @id;";
            string myQuery2 = "DELETE FROM ag306.pdcRestaurant WHERE restID = @id;";
            string myQuery3 = "DELETE FROM ag306.pdcLogo WHERE restID = @id;";

            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
            myCommand.Parameters.AddWithValue("id", row);

            SqlCommand myCommand2 = new SqlCommand(myQuery2, myConnection);
            myCommand2.Parameters.AddWithValue("id", row);

            SqlCommand myCommand3 = new SqlCommand(myQuery3, myConnection);
            myCommand3.Parameters.AddWithValue("id", row);

            try
            {
                myConnection.Open();           // open conn
                myCommand.ExecuteNonQuery();
                myCommand3.ExecuteNonQuery();
                myCommand2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();        // close conn
            }
        }

        //method that helps to update a selected restaurant's info
        public static void UpdateRestaurantInfo(int restID, string restName, string postcode, string address, string type, string tel, string email, string website, decimal avgPrice, string adType)
        {
            SqlConnection sqlConn = GetConnection();

            //update Restaurant table
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE ag306.pdcRestaurant SET restName = '"+restName+"' WHERE restID = "+restID+";";

            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr = sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                sqlConn.Close();        // close conn
            }

            //update RestaurantInfo table
            SqlCommand sqlCmd2 = sqlConn.CreateCommand();
            sqlCmd2.CommandType = CommandType.Text;
            sqlCmd2.CommandText = "UPDATE ag306.pdcRestaurantInfo SET postcode = '" + postcode + "', addres = '" + address + "',foodType = '" + type + "',tel = '" + tel + "',email = '" + email + "',website = '" + website + "',avgPrice = '" + avgPrice + "', adType = '"+adType+"' WHERE restID = " + restID + ";";

            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr2 = sqlCmd2.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
           
        }

        //method that makes a search for a restaurant using a keyword (Restaurant name, Postcode, Food type)
        public static DataTable LoadRestaurantTableByKeyword(string keyword)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = @"SELECT r.restID as ID, 
                                r.restName as Restaurant, 
                                ri.postcode as Postcode, 
                                ri.addres as Address, 
                                ri.foodType as Type,
                                ri.tel as Telephone,
                                ri.email as Email,
                                ri.website as Website,
                                ri.adType as AdType,
                                l.logoURL as LogoURL,
                                l.logoName as LogoName,
                                ri.avgPrice as AvgPrice
                                FROM pdcRestaurant r 
                                INNER JOIN pdcRestaurantInfo ri ON ri.restID= r.restID 
                                INNER JOIN pdcLogo l on l.restID = r.restID 
                                WHERE r.restName LIKE '%" + keyword + "%' OR ri.postcode LIKE '%" + keyword + "%' OR ri.foodType LIKE '%"+keyword+"%'";
                                
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

        //method that helps to submit a restaurant's logo 
        public static void AddLogo(string filePath, string fileName, int restID)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO ag306.pdcLogo (logoURL,logoName,restID) VALUES (@logoURL, @logoName, @restID)";

            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);
            //using parameters to prevent SQL Injection
            myCommand.Parameters.AddWithValue("logoURL", filePath);
            myCommand.Parameters.AddWithValue("logoName", fileName);
            myCommand.Parameters.AddWithValue("restID", restID);

            try
            {
                myConnection.Open();           // open conn
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();        // close conn
            }
        }

        //method that helps to update the Logo image
        public static void UpdateLogo(string imgURL, string imgName, int restID)
        {
            SqlConnection sqlConn = GetConnection();

            //update Restaurant table
            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE ag306.pdcLogo SET logoURL = '" + imgURL + "', logoName = '"+ imgName +"' WHERE restID = " + restID + ";";

            try
            {
                sqlConn.Open();           // open conn
                SqlDataReader dr = sqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                sqlConn.Close();        // close conn
            }
        }
    }
}
