using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HelloDogs
{
    public partial class Form1 : Form
    {
        DogChorus dogs;
        Dog dog;
        

        public Form1()
        {
            InitializeComponent();
            dogs = new DogChorus();
            dog = new Dog();
            
        }

        // button Display Dog Chorus
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(dogs.GetOutput()); // add dog list into the text box and display
        }

        // button Create Dog
        private void createButton_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog(int.Parse(heightBox.Text),colourBox.Text,breedBox.Text); // takes 3 params
            dog.SetSound(barkBox.Text); // set chosen dog bark
            richTextBox1.AppendText(dog.GetSpeech()); // add all info into the text box and display
        }

    }
}
