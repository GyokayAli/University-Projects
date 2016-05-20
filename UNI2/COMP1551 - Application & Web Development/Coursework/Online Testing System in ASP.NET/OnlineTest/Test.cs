using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineTest
{
    public partial class Test
    {
        int testId;

        public int TestId
        {
            get { return testId; }
            set { testId = value; }
        }

        string testName;

        public string TestName
        {
            get { return testName; }
            set { testName = value; }
        }
      
        int testQuestionQuantity;

        public int TestQuestionQuantity
        {
            get { return testQuestionQuantity; }
            set { testQuestionQuantity = value; }
        }

        // Takes 2 parameters
        public Test(int id, string name)
        {
            testId = id;
            testName = name;
        }

        // Takes 1 parameter
        public Test(int quant)
        {
            testQuestionQuantity = quant;         
        }

        Course courseId;

        // Takes 4 parameters
        public Test(int id, string name, Course cId, int tQuestQuant)
        {
            testId = id;
            testName = name;
            courseId = cId;
            testQuestionQuantity = tQuestQuant;
        }

        // Takes null parameter
        public Test()
        {

        }
        
    }
}