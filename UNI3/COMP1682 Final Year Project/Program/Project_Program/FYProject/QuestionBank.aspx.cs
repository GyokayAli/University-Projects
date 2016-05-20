using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYProject
{
    public partial class QuestionBank : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "true")
            {
                Response.Redirect("./Contribute");
            }

            welcomeLbl.Text = "Welcome, " + Session["adminName"] + "!";
        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string diff = diffDropDown.SelectedValue;
            string lang = langDropDown.SelectedValue;
            string question = questionTxtBox.Text;
            string point = pointTxtBox.Text;
            int c1 = 0, c2 = 0, c3 = 0, c4 = 0;

            string answer1 = answerTxtBox1.Text;
            string answer2 = answerTxtBox2.Text;
            string answer3 = answerTxtBox3.Text;
            string answer4 = answerTxtBox4.Text;

            if (answer1 != "" && answer2 != "" && answer3 != "" && answer4 != "" && question != "" && point != "")
            {
                if (CheckBox1.Checked == true || CheckBox2.Checked == true || CheckBox3.Checked == true || CheckBox4.Checked == true)
                {
                    if (CheckBox1.Checked) c1 = 1;
                    if (CheckBox2.Checked) c2 = 1;
                    if (CheckBox3.Checked) c3 = 1;
                    if (CheckBox4.Checked) c4 = 1;

                    try
                    {
                        //get quizID from db
                        int quizID = DBConnectivity.GetQuizID(diff, lang);

                        //creates the question 
                        DBConnectivity.SetQuestion(question, int.Parse(point), quizID);

                        //get current question's ID
                        int questionID = DBConnectivity.GetLastQuestionID();

                        DBConnectivity.SetAnswer(answer1, c1, questionID); //set answer/option 1
                        DBConnectivity.SetAnswer(answer2, c2, questionID); //set answer/option 2
                        DBConnectivity.SetAnswer(answer3, c3, questionID); //set answer/option 3
                        DBConnectivity.SetAnswer(answer4, c4, questionID); //set answer/option 4

                        erroLbl.Text = "Question has been successfully added to the database!";
                    }
                    catch (Exception ex)
                    {
                        erroLbl.Text = "Oops something went wrong!\nPlease try again later.";
                        Console.WriteLine("Error: " + ex);
                    }
                    finally
                    {
                        questionTxtBox.Text = "";
                        pointTxtBox.Text = "";
                        answerTxtBox1.Text = "";
                        answerTxtBox2.Text = "";
                        answerTxtBox3.Text = "";
                        answerTxtBox4.Text = "";
                    }
                }
                else
                {
                    erroLbl.Text = "Please select one correct answer!";
                }
            }
            else
            {
                erroLbl.Text = "Please fill in the empty fields!";
            }
        }
    }
}