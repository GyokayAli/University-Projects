using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FYProject
{
    public class DBConnectivity
    {
        public Question Question
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Quiz Quiz
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public QuestionAnswer QuestionAnswer
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Login Login
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Register Register
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Suggestion Suggestion
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Progress Progress
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public QuestionBank QuestionBank
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Settings Settings
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public QuizCSharp QuizCSharp
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public GameCSharp GameCSharp
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    
        public static SqlConnection GetConnection()
        {
            string conString = @"server=SQL-SERVER;integrated security=SSPI;database=ag306";
            return new SqlConnection(conString);
        }

        // method to load all answers of particular question from "testAnswer" table - using 1 parameter the questionId
        // keeps them in a generic list of type QuestionAnswer
        public static List<QuestionAnswer> LoadQuestionAnswers(int qId)
        {
            List<QuestionAnswer> answers = new List<QuestionAnswer>();
            SqlConnection myConnection = GetConnection();

            string myQuery = "SELECT answerID, answer FROM prjAnswer WHERE questionID = " + qId; // questionId = qId
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            List<Question> questions = LoadQuestion();

            try
            {
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 2 parameters - answerId, answer
                    QuestionAnswer ans = new QuestionAnswer(int.Parse(myReader["answerID"].ToString()), myReader["answer"].ToString());
                    //   questionId, bool.Parse(myReader["correct"].ToString()));

                    answers.Add(ans); // add the data in another list
                }
                return answers;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        // method that loads all questions from the "testQuestion" table
        // keeps them in a generlic list of type Question
        public static List<Question> LoadQuestion()
        {
            List<Question> quest = new List<Question>();
            SqlConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM prjQuestion";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 8 parameters - questionId, question, testId, picture, points, instructions, courseId, questionTypeId
                    Question q = new Question(int.Parse(myReader["questionID"].ToString()), myReader["question"].ToString(),
                        int.Parse(myReader["point"].ToString()));

                    quest.Add(q); // add the data in another list
                }
                return quest;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return null;
            }
            finally
            {
                myConnection.Close();
            }
        }

        // helper method to find the questionId from the Question class
        private static Question FindQuestionId(List<Question> question, int id)
        {
            foreach (var quest in question)
            {
                if (quest.QuestionId == id)
                {
                    return quest;
                }
            }
            return null;
        }

        //method that helps to submit a Suggestion made by a member
        public static void SubmitSuggestion(string suggest, string user)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO ag306.prjSuggestion(description, username) VALUES ('" + suggest + "', '" + user + "')";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

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

        // method that saves created Test details into "test" table using 3 param - name, questQuantity, courseId
        public static void SetQuestion(string question, int point, int quizID)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO prjQuestion (question, point, quizID) VALUES ( '" + question + "'," + point + ", " + quizID + " )";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static void SetAnswer(string answer, int correct, int questionID)
        {
            SqlConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO prjAnswer (answer, correct, questionID) VALUES ( '" + answer + "'," + correct + ", " + questionID + " )";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static int GetLastQuestionID()
        {

            int questionID = 0;
            SqlConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM prjQuestion WHERE questionID = ALL (SELECT MAX(questionID) FROM prjQuestion);";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();                                     // open conn
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    questionID = int.Parse(myReader["questionID"].ToString());
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

        //get quiz ID from Quiz Table with 2 param
        public static int GetQuizID(string difficulty, string language)
        {
            int quizID = 0;
            SqlConnection myConnection = GetConnection();
            string myQuery = "SELECT * FROM prjQuiz WHERE difficulty='" + difficulty + "' AND language='" + language + "';";
            SqlCommand myCommand = new SqlCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();                                     // open conn
                SqlDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    quizID = int.Parse(myReader["quizID"].ToString());
                }
                return quizID;
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