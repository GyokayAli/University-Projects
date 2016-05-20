using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYProject
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

        int point;

        public int Point
        {
            get { return point; }
            set { point = value; }
        }

        // Takes 3 parameters
        public Question(int qId, string qName, int p)
        {
            questionId = qId;
            questionName = qName;
            point = p;
        }

        public Question(int qId)
        {
            questionId = qId;
        }
    }
}