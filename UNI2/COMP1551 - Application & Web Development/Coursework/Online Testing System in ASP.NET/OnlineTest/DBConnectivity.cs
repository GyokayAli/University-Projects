using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace OnlineTest
{
    // MAIN DATABASE CONNECTION CLASS
    public class DBConnectivity
    {
        // method to establish connection with the database
        private static OleDbConnection GetConnection()
        {
            string connString;
            //  change to your connection string in the following line
            connString = @"Provider=Microsoft.JET.OLEDB.4.0;Data Source=C:\Users\Gyoki\Desktop\OnlineTest\TestDB.mdb";
            return new OleDbConnection(connString);
        }

        // method to load all courses from the "course" table
        // keeps them in generic list of type Course
        public static List<Course> LoadCourses()
        {
            List<Course> courses = new List<Course>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM course";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 2 parameters - courseID and courseName
                    Course c = new Course(int.Parse(myReader["courseID"].ToString()), myReader["courseName"].ToString());
                    courses.Add(c); // add the data in another list
                }
                return courses;
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

        // method to load all the student details from the "student" table
        // keeps them in generic list of type Student
        public static List<Student> LoadStudents()
        {
            List<Student> students = new List<Student>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM student";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 2 parameters - studentId, fullName
                    Student s = new Student(int.Parse(myReader["studentId"].ToString()), myReader["fullName"].ToString());
                    students.Add(s); // add the data in another list
                }
                return students;
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

        // method to load all answers of particular question from "testAnswer" table - using 1 parameter the questionId
        // keeps them in a generic list of type QuestionAnswer
        public static List<QuestionAnswer> LoadQuestionAnswers(int qId)
        {
            List<QuestionAnswer> answers = new List<QuestionAnswer>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT answerId, answer FROM testAnswer WHERE questionId = " + qId; // questionId = qId
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            List<Question> questions = LoadQuestion();

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                   // passes 2 parameters - answerId, answer
                    QuestionAnswer ans = new QuestionAnswer(int.Parse(myReader["answerId"].ToString()), myReader["answer"].ToString());
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
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM testQuestion";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            List<Test> tests = LoadTest();
            List<Course> courses = LoadCourses();
            List<QuestionType> types = LoadQuestionType();

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Test testId = FindTestId(tests, int.Parse(myReader["testId"].ToString())); // used to find the testId
                    Course courseId = FindCourseId(courses, int.Parse(myReader["courseId"].ToString())); // used to find the courseId
                    QuestionType questionTypeId = FindQuestionTypeId(types, int.Parse(myReader["questionTypeId"].ToString())); // used to find the questionTypeId

                    // passes 8 parameters - questionId, question, testId, picture, points, instructions, courseId, questionTypeId
                    Question q = new Question(int.Parse(myReader["questionId"].ToString()), myReader["question"].ToString(),
                        testId, myReader["picture"].ToString(),
                        int.Parse(myReader["points"].ToString()), myReader["instructions"].ToString(),
                        courseId, questionTypeId);
                        
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
 
        // method that load all the questions of a particular test from "testQuestion" table using 1 parameter - testId
        // keeps them in a generic list of type Question
        public static List<Question> LoadQuestionsByTest(int tId)
        {
            List<Question> questions = new List<Question>();
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT questionId, question, testId, points, instructions, picture, courseId, questionTypeId FROM testQuestion WHERE testId = " + tId; // testId = tId
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            List<Test> tests = LoadTest(); // gets all tests
            List<Course> courses = LoadCourses(); // gets all courses
            List<QuestionType> types = LoadQuestionType(); // gets all question types

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Test testId = FindTestId(tests, int.Parse(myReader["testId"].ToString())); // gets the testId
                    Course courseId = FindCourseId(courses, int.Parse(myReader["courseId"].ToString())); // gets the courseId
                    QuestionType questionTypeId = FindQuestionTypeId(types, int.Parse(myReader["questionTypeId"].ToString())); // gets the questionTypeId

                    // passes 8 parameters - questionId, question, testid, picture, points, instructions, courseId, questionTypeId
                    Question q = new Question(int.Parse(myReader["questionId"].ToString()), myReader["question"].ToString(),
                        testId, myReader["picture"].ToString(),
                        int.Parse(myReader["points"].ToString()), myReader["instructions"].ToString(),
                        courseId, questionTypeId);

                    questions.Add(q); // add the data in another list
                }
                return questions;
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

        // method that loads all the attemps by a student using 1 parameter - studentId
        // keeps them in a generic list of type Attempt
        public static List<Attempt> LoadAttemptByStudent(int sId)
        {
            List<Attempt> attempts = new List<Attempt>();
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT attemptId, attemptStartDate, attemptEndDate, testId, studentId, mark FROM testAttempt WHERE studentId = " + sId; // studentId = sId
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            List<Test> tests = LoadTest(); // gets all tests
            List<Student> students = LoadStudents(); // gets all students' info

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Test testId = FindTestId(tests, int.Parse(myReader["testId"].ToString())); //gets the testId
                    Student studentId = FindStudentId(students, int.Parse(myReader["studentId"].ToString())); // gets the studentId

                    // passes 6 parameter - attemptId, attemptStartDate, attemptEndDate, testId, studentId, mark
                    Attempt a = new Attempt(int.Parse(myReader["attemptId"].ToString()), myReader["attemptStartDate"].ToString(),
                        myReader["attemptEndDate"].ToString(), testId,
                        studentId, int.Parse(myReader["mark"].ToString()));

                    attempts.Add(a); // add the data in another list
                }
                return attempts;
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

        // helper method to find the testId from the Test class
        private static Test FindTestId(List<Test> tests, int id)
        {
            foreach (var test in tests)
            {
                if (test.TestId == id)
                {
                    return test;
                }
            }
            return null;
        }

        // helper method to find the studentId from the Student class
        private static Student FindStudentId(List<Student> students, int id)
        {
            foreach (var stud in students)
            {
                if (stud.StudentId == id)
                {
                    return stud;
                }
            }
            return null;
        }

        // helper method to find the courseId from the Course class
        private static Course FindCourseId(List<Course> courses, int id)
        {
            foreach (var course in courses)
            {
                if (course.CourseId == id)
                {
                    return course;
                }
            }
            return null;
        }

        // helper method to find the questionTypeId from the QuestionType class
        private static QuestionType FindQuestionTypeId(List<QuestionType> questType, int id)
        {
            foreach (var qType in questType)
            {
                if (qType.QuestionTypeId == id)
                {
                    return qType;
                }
            }
            return null;
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

        // method that loads all the question types from the "testQuestionType" table
        // keeps them in a generic list of type QuestionType
        public static List<QuestionType> LoadQuestionType()
        {
            List<QuestionType> qType = new List<QuestionType>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM questionType";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 2 param - questionTypeId, type
                    QuestionType qt = new QuestionType(int.Parse(myReader["questionTypeId"].ToString()), myReader["type"].ToString());
                    qType.Add(qt); // add the data in another list
                }
                return qType;
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

        // method that loads all the available tests from the "test" table
        // keeps them in a generic list of type Test
        public static List<Test> LoadTest()
        {
            List<Test> test = new List<Test>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM test";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    // passes 2 param - testId, testName
                    Test t = new Test(int.Parse(myReader["testId"].ToString()), myReader["testName"].ToString());

                    test.Add(t); // add the data in another list
                }
                return test;
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

        // method that saves created Test details into "test" table using 3 param - name, questQuantity, courseId
        public static void CreateTest(string name,int questQuantity, int courseId)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO test(testName, testQuestionQuantity, courseId) VALUES ( '" + name + "'," + questQuantity + ", " + courseId + " )";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        // method that saves the answers of student into "studentAnswer" table using 3 param - answer, testQuestionId, studentId
        public static void SaveStudentAnswer(string answer, int testQuestId, int studId)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO studentAnswer(answer, testQuestionId, studentId) VALUES ( '" + answer + "' , " + testQuestId + ", " + studId + " )";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        // method that saves each attempt of a student into "testAttempt" table using 5 param - start time, end time, testId, studentId, mark
        public static void SaveTestAttempt(string start, string end, int testId, int studId, int mark)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO testAttempt(attemptStartDate, attemptEndDate, testId, studentId, mark) VALUES ( '" + start + "','"+end+"', " + testId + ", " + studId + ",  " + mark + " )";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        // method that saves the questions added by the staff into the "testQuestion" table
        // using 8 params - questionId, question, testId, points, instructtions, picture, courseId, questionTypeId
        public static void AddQuestion(int questId, string question, int testId, int points, string instruction, string picture, int courseId, int questionTypeId )
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO testQuestion(questionId, question, testId, points, instructions, picture, courseId, questionTypeId) VALUES ( "+ questId +", '" + question + "', " + testId + ",  " + points + ", '" + instruction + "', '"+ picture +"', " + courseId + ", " + questionTypeId + ")";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        // method that saves the student details from the Login page into the "student" table
        // using 5 params - studentId, fullName, userEmail, username, password
        public static void SaveStudentDetails(int id, string name, string email, string username, string pass)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO student(studentId, fullName, userEmail, username, pass) VALUES ( "+ id +", '" + name + "', '"+email+"', '"+username+"', '"+pass+"')"; 
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

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

        
    }
}