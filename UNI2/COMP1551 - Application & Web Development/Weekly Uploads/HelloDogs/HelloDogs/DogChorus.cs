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
        Dog boss;
        Dog mafia;
        
        public DogChorus() {
            lady = new Dog();        
            tramp = new Dog();
            boss = new Dog();
            mafia = new Dog();
            
            // manual dog bark
            boss.SetSound("Haww!");
            mafia.SetSound("Hrrrr!");

            // manual dog height
            lady.DogHeight = 22;
            tramp.DogHeight = 45;
            boss.DogHeight = 78;
            mafia.DogHeight = 10;

            // manual dog colour
            lady.DogColour = "Brown";
            tramp.DogColour = "Yellow";
            boss.DogColour = "White";
            mafia.DogColour = "Black";

            // manual dog breed
            tramp.Breed = "Bull Terrier";
            boss.Breed = "Bulldog";
            mafia.Breed = "Chihuahua";
        }

        // Display Dog Chorus consisting from 4 dogs
        // Including breed, colour, height, size, bark, legs
        public string GetOutput(){
            return lady.GetSpeech()  + tramp.GetSpeech()  + boss.GetSpeech()
                 + mafia.GetSpeech();
        }
    }
}
