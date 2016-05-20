using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYProject
{
    public class Quiz
    {
        int quizId;
        public int QuizID
        {
            get { return quizId; }
            set { quizId = value; }
        }

        string diff;
        public string Difficulty
        {
            get { return diff; }
            set { diff = value; }
        }

        string lang;
        public string Language
        {
            get { return lang; }
            set { lang = value; }
        }
       
        // Takes 3 parameter
        public Quiz(int id, string language, string difficulty)
        {
            quizId = id;
            lang = language;
            diff = difficulty;
        }

        // Takes 1 parameter
        public Quiz(int id)
        {
            quizId = id;
        }
    }
}