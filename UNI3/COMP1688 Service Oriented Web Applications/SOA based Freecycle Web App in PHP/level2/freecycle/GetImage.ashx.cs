using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace freecycle
{
    /// <summary>
    /// Summary description for GetImage
    /// </summary>
    public class GetImage : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string imgID = context.Request.QueryString["imgID"];
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand("SELECT img FROM ag306.Image WHERE imgID = @imgID", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@imgID", imgID);

            try
            {
                con.Open();
                SqlDataReader myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    context.Response.ContentType = "image/png";
                    context.Response.BinaryWrite((byte[])myReader["img"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                con.Close();                                 // close conn
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        // method to establish connection with the database
        private static SqlConnection getConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }
    }
}