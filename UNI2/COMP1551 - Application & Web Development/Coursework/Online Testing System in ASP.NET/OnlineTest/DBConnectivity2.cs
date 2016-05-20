using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace OnlineTest
{
    // Helper Database Connection Class
    public class DBConnectivity2
    {
        // method to establish connection with the database
        private static OleDbConnection GetConnection()
        {
            string connString;
            //  change to your connection string in the following line
            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\Users\Gyoki\Desktop\OnlineTest\TestDB.mdb";
            return new OleDbConnection(connString);
        }

        // method that takes 3 parameters
        // saves the question answers into "testAnswer" table
        public static void AddQuestionAnswer(string answer, int questId, bool correct)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO testAnswer(answer, questionId, correct) VALUES ( '" + answer + "', "+ questId +", "+ correct +")";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        // method that takes 1 parameter (testId) to get the number of questions in a particular test from the database
        public static List<Test> LoadNumberOfQuestions(int tId)
        {
            List<Test> questNumber = new List<Test>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT testQuestionQuantity FROM test WHERE testId = " + tId; // testId = tId
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();                                     // open conn
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // gets the number of questions from "test" table
                    Test t = new Test(int.Parse(myReader["testQuestionQuantity"].ToString()));

                    questNumber.Add(t); // add the data in another list
                }
                return questNumber;
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

    }
}