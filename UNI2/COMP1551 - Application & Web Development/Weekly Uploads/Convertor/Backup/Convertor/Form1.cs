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

        private void button1_Click(object sender, EventArgs e)
        {
            Temperature temp = new Temperature(double.Parse(textBox1.Text), radioButton1.Checked);
            richTextBox1.AppendText(temp.getOutputString() + "\n");
            label1.Text = "count: " + Temperature.Count;

        }
    }
}
