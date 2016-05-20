using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public class Course
    {
        int courseId;

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        string courseName;

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        // Takes to 2 parameters
        public Course(int id, string course)
        {
            courseId = id;
            courseName = course;
        }
    }
}