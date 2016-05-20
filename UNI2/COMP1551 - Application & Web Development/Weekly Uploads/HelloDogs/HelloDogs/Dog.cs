using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloDogs
{
    class Dog
    {
        // declaring variables
        private string barkSound;
        private string breed;
        private string dogSpeech;
        int dogHeight, lastSize;
        string dogColour;
        static int noOfLegs = 4;

        // constructor that holds 3 params
        public Dog(int DogHeight, string DogColour, string breed)
        {
            this.dogHeight = DogHeight;
            this.dogColour = DogColour;
            this.breed = breed;
        }

        // get/set height of a dog
        public int DogHeight
        {
            get { return dogHeight; }
            set { dogHeight = value; }
        }
        
        // get/set colour of a dog
        public string DogColour
        {
            get { return dogColour; }
            set { dogColour = value; }
        }

        // STATIC!
        // all dogs have 4 legs
        public static int NoOfLegs
        {
            get { return Dog.noOfLegs; }
            set { Dog.noOfLegs = value; }
        }

        // get/set breed of a dog
        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        
        // manual set up
        public Dog()
        {
            barkSound = "Huff"; // set bark
            breed = "cocker spaniel"; // set breed
        }

        /* Bool to check whether a dog is BIG or SMALL
         * Returns BIG if false
         * Returns SMALL if true*/
        private bool isBig(int size)
        {      
            bool result;
            if (size < 50)
            {
                result = false;
            }
            else
            {
                result = true;
            }
            lastSize = size; // keeps copy of last size
            return result;
        }

        /* Getter method that checks if a dog is big or small
         as well as displaying the Speech of Dog in the text box */
        public string GetSpeech()
        {
            {
                string big_or_small;
                if (isBig(this.lastSize = dogHeight) == true)
                {
                    big_or_small = "I am a big dog with height "; // BIG dog
                }
                else
                {
                    big_or_small = "I am a small dog with height "; // SMALL dog
                }

                dogSpeech = "Hello. I am a " + breed + ". " + barkSound + "!! " + big_or_small
                        + lastSize.ToString() + " cm." + " I have a lovely " + dogColour + " colour. "
                        + barkSound + "!! And have " + Dog.NoOfLegs + " legs!\n";

                return dogSpeech;
            }
        }
        // Setter method for dog barking
        public void SetSound(String barkSound)
        {
            this.barkSound = barkSound;
        }
    
    }
}
