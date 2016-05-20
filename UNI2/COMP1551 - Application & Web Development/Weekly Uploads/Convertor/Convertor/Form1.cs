using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Convertor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Log Today's Temperature button clicked
        private void button1_Click(object sender, EventArgs e)
        {
            Temperature temp = new Temperature(double.Parse(textBox1.Text), radioButton1.Checked); // pass chosen Temp and Unit to class
            richTextBox1.AppendText(temp.getOutputString() + "\n"); //adds data to log list
            label1.Text = "Number of Logs: " + Temperature.Count; //display number of logs
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Other Day's Temperature button clicked
        private void button2_Click(object sender, EventArgs e)
        {
            DateTime myDate = dateTimePicker1.Value.Date; //gets the picked date
            Temperature temp = new Temperature(double.Parse(textBox1.Text), radioButton1.Checked, myDate); // pass chosen Temp, Unit and Date to class
            richTextBox1.AppendText(temp.getOutputString() + "\n"); //adds data to log list
            label1.Text = "Number of Logs: " + Temperature.Count; //display number of logs
        }
        // Clear button clicked
        private void button3_Click(object sender, EventArgs e)
        {
            Temperature.Count = 0; // set Number of Logs to 0
            richTextBox1.Text = ""; // clear the log list
            textBox1.Text = ""; // clear input field
        }

    }
}
