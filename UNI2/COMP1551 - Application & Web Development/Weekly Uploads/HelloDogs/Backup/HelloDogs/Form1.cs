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

        public Form1()
        {
            InitializeComponent();
            dogs = new DogChorus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText(dogs.GetOutput());
        }

    }
}
