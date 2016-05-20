using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloDogs
{
    class Dog
    {
        private string barkSound;
        private string breed;

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }
        private string dogSpeech;

        public Dog()
        {
            barkSound = "Woof!";
            breed = "cocker spaniel";
        }

        public string GetSpeech()
        {
            dogSpeech = "Hello. I am a " + breed + ". " + barkSound;
            return dogSpeech;
        }
        public void SetSound(String barkSound)
        {
            this.barkSound = barkSound;
        } 

    }
}
