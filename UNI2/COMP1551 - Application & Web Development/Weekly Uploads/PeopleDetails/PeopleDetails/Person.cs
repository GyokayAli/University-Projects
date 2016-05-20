using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// author ag306

namespace PeopleDetails
{
    public class Person
    {
        // declare class variables
        private int age;
        private string fName, sName, gender, mobile, DoB;

        // class constructor that creates and pass 6 parameters
        // Age, First name, Surname, Gender, Mobile number, Date of Birth
        public Person(int age, string fName, string sName, string gen, string mob, string dob)
        {
            this.age = age;
            this.fName = fName;
            this.sName = sName;
            this.gender = gen;
            this.mobile = mob;
            this.DoB = dob;
        }

        // Method that returns all the info entered by the user as a string
        public string PresentPerson()
        {

            return fName + " " + sName + " - " + age + " years old " + gender + "." +
                " Born on " + DoB + ". Mobile: " + mobile;
        }
    }
}