using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace FormRestaurantSystem
{
    public partial class TextBoxComponent : TextBox
    {
        private ToolTip tt;

        public TextBoxComponent()
        {
            InitializeComponent();
        }

        public TextBoxComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            try
            {
                if(decimal.Parse(this.Text) > 50)
                {
                    this.ForeColor = Color.Red; //set color font color to red if value > 50
                    this.Font = new Font(this.Font, FontStyle.Bold); //set font to Bold
                    showTooltip(decimal.Parse(this.Text)); //notice message to user
                }
                else if (decimal.Parse(this.Text) == 0)
                {
                    this.ForeColor = Color.Red; //set font color to red if value == 0
                    this.Font = new Font(this.Font, FontStyle.Bold); //set font to Bold
                    showTooltip(decimal.Parse(this.Text)); //notice message to user
                }
                else
                {
                    this.ForeColor = Color.Green; //set font color to green if value > 0 and value < 50
                    this.Font = new Font(this.Font, FontStyle.Regular); //set font to normal
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in TextBoxComponent Component ", ex);
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            try
            {

                //checks if input is only digits and floating point
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                //allows the user to enter only one decimal point
                if (e.KeyChar == '.' && this.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in TextBoxComponent Component: ",ex);
            }
        }

        private void showTooltip(decimal value)
        {
            tt = new ToolTip();
            tt.InitialDelay = 0;
            tt.IsBalloon = true;
            tt.Show(string.Empty, this);

            if (value > 49.9M)
            {
                tt.Show("Notice: Value is higher than usual!", this, 0);
            }
            if (value == 0M)
            {
                tt.Show("Notice: Value cannot be zero!", this, 0);
            }
        }
    }
}
