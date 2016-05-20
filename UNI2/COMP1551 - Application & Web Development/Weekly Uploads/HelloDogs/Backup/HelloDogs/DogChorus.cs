using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloDogs
{
    class DogChorus
    {
        Dog lady;        
        Dog tramp;
        
        public DogChorus() {
            lady = new Dog();        
            tramp = new Dog();
            tramp.SetSound("Ruff!");
        }

        public string GetOutput(){
            return lady.GetSpeech() + " \n " + tramp.GetSpeech();
        }
    }
}
