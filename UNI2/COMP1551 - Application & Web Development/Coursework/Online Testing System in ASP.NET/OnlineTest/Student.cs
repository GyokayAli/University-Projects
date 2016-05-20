using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public partial class Student
    {
        int studentId;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        string studentEmail;

        public string StudentEmail
        {
            get { return studentEmail; }
            set { studentEmail = value; }
        }

        string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        // Takes 5 parameters
        public Student(int sId, string fName, string sEmail, string userName, string pass)
        {
            studentId = sId;
            fullName = fName;
            studentEmail = sEmail;
            username = userName;
            password = pass;
            
        }

        // Takes 2 parameters
        public Student(int sId, string fName)
        {
            studentId = sId;
            fullName = fName;
        }

        // Takes null parameter
        public Student()
        {

        }
    }
}