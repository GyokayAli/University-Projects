using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace freecycle
{
    /// <summary>
    /// Summary description for freecycleDotNet
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class freecycleDotNet : System.Web.Services.WebService
    {
        // method to establish connection with the database
        private static SqlConnection getConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }


        [WebMethod]
        public XmlDocument lookupSingleItemByID(string itemID)
        {
            SqlConnection sqlConn = getConnection();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            string ID = itemID.Replace("'", "''");
            sqlCmd.CommandText = "SELECT * FROM ag306.Item WHERE itemID ='" + ID + "';";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);


            XmlDocument xmlDom = new XmlDocument();
            xmlDom.AppendChild(xmlDom.CreateElement("", "items", ""));
            XmlElement xmlRoot = xmlDom.DocumentElement;

            XmlElement xmlItem, xmlTitle, xmlDescr, xmlDate, xmlMember, xmlImage, xmlImgName,
                xmlMemName, xmlMemPostcode, xmlMemTel, xmlMemEmail;
            XmlText xmlTxt;
            XmlAttribute xmlItemID, xmlMemID, xmlImgID;
            string title, descr, itID, post_date, memID;

            DataTable dtMember, dtImage;

            foreach (DataRow r in dt.Rows)
            {
                title = r["title"].ToString();
                descr = r["description"].ToString();
                itID = r["itemID"].ToString();
                post_date = r["post_date"].ToString();
                memID = r["memID"].ToString();

                xmlItem = xmlDom.CreateElement("item");
                xmlItemID = xmlDom.CreateAttribute("itemID");
                xmlItemID.Value = itID;
                xmlItem.Attributes.Append(xmlItemID);

                xmlTitle = xmlDom.CreateElement("title");
                xmlTxt = xmlDom.CreateTextNode(title);
                xmlTitle.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlTitle);

                xmlDescr = xmlDom.CreateElement("descr");
                xmlTxt = xmlDom.CreateTextNode(descr);
                xmlDescr.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDescr);

                xmlDate = xmlDom.CreateElement("post_date");
                xmlTxt = xmlDom.CreateTextNode(post_date);
                xmlDate.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDate);

                //get image details into XML
                dtImage = getImageDetails(itID);
                if (dtImage != null)
                {
                    string imgID, imgName, image;
                    foreach (DataRow row in dtImage.Rows)
                    {
                        imgID = row["imgID"].ToString();
                        imgName = row["imgName"].ToString();
                        //image = row["img"].ToString();

                        xmlImage = xmlDom.CreateElement("image");
                        xmlImgID = xmlDom.CreateAttribute("imgID");
                        xmlImgID.Value = imgID;
                        xmlImage.Attributes.Append(xmlImgID);
                        xmlTxt = xmlDom.CreateTextNode(imgName);
                        xmlImage.AppendChild(xmlTxt);
                        xmlItem.AppendChild(xmlImage);
                    }
                }

                xmlMember = xmlDom.CreateElement("member");
                xmlMemID = xmlDom.CreateAttribute("memID");
                xmlMemID.Value = memID;
                xmlMember.Attributes.Append(xmlMemID);
                xmlItem.AppendChild(xmlMember);

                //get member details into XML
                dtMember = getMemberDetails(memID);
                if (dtMember != null)
                {
                    string memName, memPostcode, memTel, memEmail;

                    foreach (DataRow row in dtMember.Rows)
                    {
                        memName = row["name"].ToString();
                        memPostcode = row["postcode"].ToString();
                        memTel = row["tel"].ToString();
                        memEmail = row["email"].ToString();

                        xmlMemName = xmlDom.CreateElement("full_name");
                        xmlTxt = xmlDom.CreateTextNode(memName);
                        xmlMemName.AppendChild(xmlTxt);
                        xmlMember.AppendChild(xmlMemName);

                        xmlMemPostcode = xmlDom.CreateElement("postcode");
                        xmlTxt = xmlDom.CreateTextNode(memPostcode);
                        xmlMemPostcode.AppendChild(xmlTxt);
                        xmlMember.AppendChild(xmlMemPostcode);

                        if (memTel != string.Empty)
                        {
                            xmlMemTel = xmlDom.CreateElement("contact_number");
                            xmlTxt = xmlDom.CreateTextNode(memTel);
                            xmlMemTel.AppendChild(xmlTxt);
                            xmlMember.AppendChild(xmlMemTel);
                        }

                        if (memEmail != string.Empty)
                        {
                            xmlMemEmail = xmlDom.CreateElement("email");
                            xmlTxt = xmlDom.CreateTextNode(memEmail);
                            xmlMemEmail.AppendChild(xmlTxt);
                            xmlMember.AppendChild(xmlMemEmail);
                        }
                    }
                }

                xmlRoot.AppendChild(xmlItem);
            }
            return xmlDom;
        }


        [WebMethod]
        public XmlDocument lookupListOfItemsByKeyWord(string keyword)
        {
            SqlConnection sqlConn = getConnection();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            string search = keyword.Replace("'", "''");
            sqlCmd.CommandText = @"SELECT itemID, title, description, post_date, memID  
                                   FROM ag306.Item WHERE CONCAT (title,description) LIKE '%" + search + "%' ";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            XmlDocument xmlDom = new XmlDocument();
            xmlDom.AppendChild(xmlDom.CreateElement("", "items", ""));
            XmlElement xmlRoot = xmlDom.DocumentElement;

            XmlElement xmlItem, xmlTitle, xmlDescr, xmlDate, xmlImage,
                 xmlMemPostcode;
            XmlText xmlTxt;
            XmlAttribute xmlItemID, xmlImgID;
            string title, descr, itID, post_date, memID;

            DataTable dtMember, dtImage;

            foreach (DataRow r in dt.Rows)
            {
                title = r["title"].ToString();
                descr = r["description"].ToString();
                itID = r["itemID"].ToString();
                post_date = r["post_date"].ToString();
                memID = r["memID"].ToString();

                xmlItem = xmlDom.CreateElement("item");
                xmlItemID = xmlDom.CreateAttribute("itemID");
                xmlItemID.Value = itID;
                xmlItem.Attributes.Append(xmlItemID);

                xmlTitle = xmlDom.CreateElement("title");
                xmlTxt = xmlDom.CreateTextNode(title);
                xmlTitle.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlTitle);

                xmlDescr = xmlDom.CreateElement("descr");
                xmlTxt = xmlDom.CreateTextNode(descr);
                xmlDescr.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDescr);

                xmlDate = xmlDom.CreateElement("post_date");
                xmlTxt = xmlDom.CreateTextNode(post_date);
                xmlDate.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDate);

                //get member postcode details into XML
                dtMember = getMemberDetails(memID);
                if (dtMember != null)
                {
                    string memPostcode;

                    foreach (DataRow row in dtMember.Rows)
                    {
                        memPostcode = row["postcode"].ToString();

                        xmlMemPostcode = xmlDom.CreateElement("postcode");
                        xmlTxt = xmlDom.CreateTextNode(memPostcode);
                        xmlMemPostcode.AppendChild(xmlTxt);
                        xmlItem.AppendChild(xmlMemPostcode);
                    }
                }

                //get image details into XML
                dtImage = getImageDetails(itID);
                if (dtImage != null)
                {
                    string imgID, imgName, image;
                    foreach (DataRow row in dtImage.Rows)
                    {
                        imgID = row["imgID"].ToString();
                        imgName = row["imgName"].ToString();
                        //image = row["img"].ToString();

                        xmlImage = xmlDom.CreateElement("image");
                        xmlImgID = xmlDom.CreateAttribute("imgID");
                        xmlImgID.Value = imgID;
                        xmlImage.Attributes.Append(xmlImgID);
                        xmlTxt = xmlDom.CreateTextNode(imgName);
                        xmlImage.AppendChild(xmlTxt);
                        xmlItem.AppendChild(xmlImage);
                    }
                }
                xmlRoot.AppendChild(xmlItem);
            }
            return xmlDom;
        }

        [WebMethod]
        public XmlDocument lookupListOfItemsBy3Param(string keyword, int pSize, int pNum)
        {
            // Handle args
            if (pSize == null) pSize = 1; else pSize = pSize / 2;
            if (pNum == null) pNum = 1;
            int iSize = 1;
            //int.TryParse(pSize, out iSize);
            //int iNum = 1;
            //int.TryParse(pNum, out iNum);
            int start = pSize * (pNum - 1);
            int finish = start + iSize;

            SqlConnection sqlConn = getConnection();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            string word = keyword.Replace("'", "''");
            sqlCmd.CommandText = @"SELECT itemID, title, description, post_date, memID  
                                   FROM ag306.Item WHERE CONCAT (title,description) LIKE '%" + word + "%' ORDER BY itemID OFFSET " + start + " ROWS FETCH NEXT " + pSize + " ROWS ONLY";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            XmlDocument xmlDom = new XmlDocument();
            xmlDom.AppendChild(xmlDom.CreateElement("", "items", ""));
            XmlElement xmlRoot = xmlDom.DocumentElement;

            XmlElement xmlItem, xmlTitle, xmlDescr, xmlDate, xmlImage,
                 xmlMemPostcode;
            XmlText xmlTxt;
            XmlAttribute xmlItemID, xmlImgID;
            string title, descr, itID, post_date, memID;

            DataTable dtMember, dtImage;

            foreach (DataRow r in dt.Rows)
            {
                title = r["title"].ToString();
                descr = r["description"].ToString();
                itID = r["itemID"].ToString();
                post_date = r["post_date"].ToString();
                memID = r["memID"].ToString();

                xmlItem = xmlDom.CreateElement("item");
                xmlItemID = xmlDom.CreateAttribute("itemID");
                xmlItemID.Value = itID;
                xmlItem.Attributes.Append(xmlItemID);

                xmlTitle = xmlDom.CreateElement("title");
                xmlTxt = xmlDom.CreateTextNode(title);
                xmlTitle.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlTitle);

                xmlDescr = xmlDom.CreateElement("descr");
                xmlTxt = xmlDom.CreateTextNode(descr);
                xmlDescr.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDescr);

                xmlDate = xmlDom.CreateElement("post_date");
                xmlTxt = xmlDom.CreateTextNode(post_date);
                xmlDate.AppendChild(xmlTxt);
                xmlItem.AppendChild(xmlDate);

                //get member postcode details into XML
                dtMember = getMemberDetails(memID);
                if (dtMember != null)
                {
                    string memPostcode;

                    foreach (DataRow row in dtMember.Rows)
                    {
                        memPostcode = row["postcode"].ToString();

                        xmlMemPostcode = xmlDom.CreateElement("postcode");
                        xmlTxt = xmlDom.CreateTextNode(memPostcode);
                        xmlMemPostcode.AppendChild(xmlTxt);
                        xmlItem.AppendChild(xmlMemPostcode);
                    }
                }

                //get image details into XML
                dtImage = getImageDetails(itID);
                if (dtImage != null)
                {
                    string imgID, imgName, image;
                    foreach (DataRow row in dtImage.Rows)
                    {
                        imgID = row["imgID"].ToString();
                        imgName = row["imgName"].ToString();
                        //image = row["img"].ToString();

                        xmlImage = xmlDom.CreateElement("image");
                        xmlImgID = xmlDom.CreateAttribute("imgID");
                        xmlImgID.Value = imgID;
                        xmlImage.Attributes.Append(xmlImgID);
                        xmlTxt = xmlDom.CreateTextNode(imgName);
                        xmlImage.AppendChild(xmlTxt);
                        xmlItem.AppendChild(xmlImage);
                    }
                }
                xmlRoot.AppendChild(xmlItem);
            }
            return xmlDom;
        }

        

        private static DataTable getImageDetails(string itemID)
        {
            SqlConnection sqlConn = getConnection();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            //string search = memberID.Replace("'", "''");
            sqlCmd.CommandText = "SELECT TOP 1 imgID, imgName FROM ag306.Image WHERE itemID ='" + itemID + "';";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        //method to return a single member's details
        private static DataTable getMemberDetails(string memberID)
        {
            SqlConnection sqlConn = getConnection();

            SqlCommand sqlCmd = sqlConn.CreateCommand();
            sqlCmd.CommandType = CommandType.Text;
            //string search = memberID.Replace("'", "''");
            sqlCmd.CommandText = "SELECT name, postcode, tel, email FROM ag306.Member WHERE memID ='" + memberID + "';";

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
