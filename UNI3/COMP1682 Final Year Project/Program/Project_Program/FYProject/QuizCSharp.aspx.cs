using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYProject
{
    public partial class QuizCSharp : System.Web.UI.Page
    {
        int counter,counter2;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != "true")
            {
                Response.Redirect("./Login");
            }

            // a list that holds all the questions of the chosen test
            List<Question> allQuestions = DBConnectivity.LoadQuestion();

            int questNum = DBConnectivity2.LoadNumberOfQuestions();

            Random r = new Random();
            List<Question> randomQuestions = new List<Question>();

            // randomize questions' order and saves them in new list one by one
            while (randomQuestions.Count < questNum)
            {
                int num = r.Next(allQuestions.Count);
                bool containsQuestion = false;
                foreach (var quest in randomQuestions)
                {
                    if (allQuestions[num] == quest)
                    {
                        containsQuestion = true;
                    }
                }
                if (!containsQuestion)
                {
                    randomQuestions.Add(allQuestions[num]);
                }

            }
            Session["RandomQuestions"] = randomQuestions; // saves the list of randomized questions in Session

            //  Session["SelectedTestId"] = TestDropDown.SelectedValue; // testId saved in Session
            //   Session["SelectedCourse"] = CourseDropDown.SelectedItem.ToString(); // courseName saved in Session
            ///   Session["SelectedTest"] = TestDropDown.SelectedItem.ToString();     // testName saved in Session
            Session["QuestionNum"] = questNum; // number of question in a test saved in Session
            //    Session["StartTime"] = DateTime.Now.ToString(); // exam start time saved in Session

            // increment by 1 every time
            counter2 += 1;
            Session["counter2"] = counter2;

            if (!Page.IsPostBack)
            {
                // used as index
                counter = 0;
                Session["counter"] = counter;

                // creates a new list of questions with randomized order from Session
                List<Question> testQuestions = (List<Question>)Session["RandomQuestions"];

                // creates a new list of answers of a particular question using 1 param - questionId
                List<QuestionAnswer> questionAnswers = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);

                // displays the points the current question worths in a label
                pointLbl.Text = testQuestions[counter].Point.ToString();

                // displays the question in a Lable on the top of the radiobuttonlist
                questionLbl.Text = counter2 + ". " + testQuestions[counter].QuestionName;

                // loads all the answers of particular question from "testAnswer" table using 1 parameter - questinId
                radioBtnList.DataSource = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);
                radioBtnList.DataTextField = "answerName";
                radioBtnList.DataValueField = "answerId";
                radioBtnList.DataBind();

            }
        }

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            counter2 = int.Parse(Session["counter"].ToString());

            // creates a new list of questions with randomized order from Session
            List<Question> testQuestions = (List<Question>)Session["RandomQuestions"];

            // creates a new list of answers of a particular question using 1 param - questionId
            List<QuestionAnswer> questionAnswers = DBConnectivity.LoadQuestionAnswers(testQuestions[counter].QuestionId);

            // DB connection that saves students answer from each test question
            // using 3 params - answer, questionId, studentId
          //  DBConnectivity.SaveStudentAnswer(RadioButtonList1.SelectedItem.ToString(), testQuestions[counter].QuestionId, int.Parse(Session["StudentID"].ToString()));

            // increment by 1 every time
            counter2 += 1;
            Session["counter"] = counter2;

            // if counter is bigger than the number of questions available for that particular test
            // the test is finalized and redirected to Results page
           if (counter2 >= testQuestions.Count)
            {
                Response.Redirect("Members.aspx");
            }
            else
            {
                pointLbl.Text = testQuestions[counter].Point.ToString();
                questionLbl.Text = counter + ". " + testQuestions[counter].QuestionName;
            }


            radioBtnList.ClearSelection(); // clear radio button user selection
            radioBtnList.Items.Clear();    // clear radio buttons' data

            // loads all the answers of particular question from "testAnswer" table using 1 parameter - questinId
            radioBtnList.DataSource = DBConnectivity.LoadQuestionAnswers(testQuestions[counter2].QuestionId);
            radioBtnList.DataTextField = "answerName";
            radioBtnList.DataValueField = "answerId";
            radioBtnList.DataBind();
        }
    }
}