using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace freecycle
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            insert();
        }
        /*Source from YouTube tutorial: https://www.youtube.com/watch?v=mKN_RqtiEjM */
        public void insert()
        {
            if (fileUp.PostedFile.FileName != "")
            {
                string imgId = imgID.Text;
                string imgNam = imgName.Text;
                string itemId = itemID.Text;
                byte[] image;
                Stream s = fileUp.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(s);
                image = br.ReadBytes((Int32)s.Length);

                SqlConnection myConnection = getConnection();
                SqlCommand sqlCommand = myConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "INSERT INTO ag306.Image (imgID,imgName,img,itemID) VALUES (@imgId,@imgNam,@image,@itemId);";

                sqlCommand.Parameters.AddWithValue("@imgId", imgId);
                sqlCommand.Parameters.AddWithValue("@imgNam", imgNam);
                sqlCommand.Parameters.AddWithValue("@image", image);
                sqlCommand.Parameters.AddWithValue("@itemId", itemId);

                try
                {
                    myConnection.Open();           // open conn
                    sqlCommand.ExecuteNonQuery();
                    errorLbl.Text = "success";
                }
                catch (Exception ex)
                {
                    errorLbl.Text = "Exception in DBHandler " + ex;
                }
                finally
                {
                    myConnection.Close();        // close conn
                }
            }
        }

        private static SqlConnection getConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }
    }
}