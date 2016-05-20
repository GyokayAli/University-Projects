using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        // Redirects to Create Test page
        protected void CreateTestButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateTest.aspx");
        }

        protected void CheckTestButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CheckTestResults.aspx");
        }

        protected void FeedbackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("SendFeedback.aspx");
        }
      
    }
}