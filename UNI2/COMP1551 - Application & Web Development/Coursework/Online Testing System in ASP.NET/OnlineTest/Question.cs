using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public class Question
    {
        int questionId;

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        string questionName;

        public string QuestionName
        {
            get { return questionName; }
            set { questionName = value; }
        }

        Test testId;

        public Test TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        string picture;

        public string  Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }

        string instruction;

        public string Instruction
        {
            get { return instruction; }
            set { instruction = value; }
        }

        Course courseId;

        public Course CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        QuestionType questionTypeId;

        public QuestionType QuestionTypeId
        {
            get { return questionTypeId; }
            set { questionTypeId = value; }
        }

        // Takes 8 parameters
        public Question(int qId,string qName,Test tId,string pic, int p,string ins,Course cId,QuestionType qtId)
        {
            questionId = qId;
            questionName = qName;
            testId = tId;
            picture = pic;
            point = p;
            instruction = ins;
            courseId = cId;
            questionTypeId = qtId; 
        }
    }
}