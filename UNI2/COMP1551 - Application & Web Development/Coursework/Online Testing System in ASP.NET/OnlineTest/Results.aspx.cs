using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTest
{
    // Shows the results of a student after a test
    public partial class Results : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblCourse.Text = (String)Session["SelectedCourse"]; // displays course name
            lblTest.Text = (String)Session["SelectedTest"];     // displays test name
            lblNo.Text = (String)Session["QuestionNum"];        // displays number of questions

            DateTime dt = Convert.ToDateTime(Session["StartTime"]);
            lblStart.Text = dt.ToString();                      // displays exam start time

            TimeSpan duration = Convert.ToDateTime(Session["StartTime"]) - DateTime.Now;
            lblDuration.Text = duration.ToString();             // displays exam duration

            lblEnd.Text = DateTime.Now.ToString();              // displays current time/ finish time
        }

        // Redirects to Default page
        protected void FinishButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}