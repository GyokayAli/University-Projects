using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public class QuestionAnswer
    {
        int answerId;
        string answerName;
        Question questionId;
        bool correct;

        public int AnswerId
        {
            get { return answerId; }
            set { answerId = value; }
        }

        public string AnswerName
        {
            get { return answerName; }
            set { answerName = value; }
        }

        public Question QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        public bool Correct
        {
            get { return correct; }
            set { correct = value; }
        }

        // Takes 2 parameteres
        public QuestionAnswer(int ansId, string ansName)
        {
            answerId = ansId;
            answerName = ansName;
        }

        // Takes 4 parameters
        public QuestionAnswer(int ansId, string ansName, Question qId, bool c)
        {
            answerId = ansId;
            answerName = ansName;
            questionId = qId;
            correct = c;
            
        }
    }
}