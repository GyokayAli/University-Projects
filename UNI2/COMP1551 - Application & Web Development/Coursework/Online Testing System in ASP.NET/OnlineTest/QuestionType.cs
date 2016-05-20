using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public class QuestionType
    {
        int questionTypeId;

        public int QuestionTypeId
        {
            get { return questionTypeId; }
            set { questionTypeId = value; }
        }
        string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        // Takes 2 parameters
        public QuestionType(int id, string ty)
        {
            questionTypeId = id;
            type = ty;
        }
    }
}