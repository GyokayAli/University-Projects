using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FYProject
{
    public class DBConnectivity2
    {
        private static SqlConnection GetConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }

        // method that takes 1 parameter (testId) to get the number of questions in a particular test from the database
        public static int LoadNumberOfQuestions()
        {
            SqlConnection myConnection = GetConnection();
            int questNumber = 0;
            string myQuery = "SELECT COUNT(*) FROM prjQuestion";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();                                     // open conn
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    questNumber += 1;
                }
                return questNumber;
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

       

    }
}