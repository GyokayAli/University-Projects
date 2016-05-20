using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public class Attempt
    {
        int attemptId;

        public int AttemptId
        {
            get { return attemptId; }
            set { attemptId = value; }
        }

        string attemptStardDate;

        public string AttemptStartDate
        {
            get { return attemptStardDate; }
            set { attemptStardDate = value; }
        }

        string attemptEndDate;

        public string AttemptEndDate
        {
            get { return attemptEndDate; }
            set { attemptEndDate = value; }
        }

        Test testId;

        public Test TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        Student studentId;

        public Student StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        int mark;

        public int Mark
        {
            get { return mark; }
            set { mark = value; }
        }

        // Takes 6 parameters
        public Attempt(int aId, string start, string end, Test tId, Student sId, int m )
        {
            attemptId = aId;
            attemptStardDate = start;
            attemptEndDate = end;
            testId = tId;
            studentId = sId;
            mark = m;
        }
    }
}