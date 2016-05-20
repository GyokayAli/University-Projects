using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace FormRestaurantSystem
{
    public partial class Food2UManagementForm : Form
    {
        string filePath, fileName;

        public Food2UManagementForm()
        {
            InitializeComponent();
            LoadTable();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
                try
                {
                    if (restNameTxtBox.Text != "" && postcodeTxtBox.Text != "" && addressTxtBox.Text != "" && typeTxtBox.Text != "" && telTxtBox.Text != "" && avgPriceTxtBox.Text != "" && adTypeTxtBox.Text != "")
                    {
                        //get restaurant name and save to db
                        DBConnectivity.AddRestaurants(restNameTxtBox.Text);

                        //get rest of the info of that restaurant and save to db
                        DBConnectivity.AddRestaurantInfo(postcodeTxtBox.Text, addressTxtBox.Text,
                              typeTxtBox.Text, telTxtBox.Text, emailTxtBox.Text, webTxtBox.Text, adTypeTxtBox.Text, decimal.Parse(avgPriceTxtBox.Text), DBConnectivity.GetLastRestID());
                       
                        //add the image to db
                        DBConnectivity.AddLogo(filePath, fileName, DBConnectivity.GetLastRestID());
                        
                        //refresh content of data gridview table
                        LoadTable();

                        MessageBox.Show("Database has been updated succesfully!");
                    }
                    else
                    {
                        MessageBox.Show("Please fill in the blank text fields!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops something went wrong!");
                    Console.WriteLine("Exception in DBHandler", ex);
                }
        }

        //method used to load Restaurant Info data from db
        void LoadTable()
        {
            //populate data grid view table from RestaurantInfo db table
            dataGridView1.DataSource = DBConnectivity.LoadRestaurantTable();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            restNameTxtBox.Text = "";
            addressTxtBox.Text = "";
            postcodeTxtBox.Text = "";
            telTxtBox.Text = "";
            emailTxtBox.Text = "";
            webTxtBox.Text = "";
            typeTxtBox.Text = "";
            avgPriceTxtBox.Text = "";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                    DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                    int restID = int.Parse(Convert.ToString(selectedRow.Cells["ID"].Value));
                    DBConnectivity.DeleteSelectedRow(restID);

                    //refresh content of data gridview table
                    LoadTable();

                    MessageBox.Show("Selected record has been deleted from the database succesfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oops something went wrong!");
                    Console.WriteLine("Exception in DBHandler", ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a row!");
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                int restID = int.Parse(Convert.ToString(selectedRow.Cells["ID"].Value));
                string restName = Convert.ToString(selectedRow.Cells["Restaurant"].Value);
                string address = Convert.ToString(selectedRow.Cells["Address"].Value);
                string postcode = Convert.ToString(selectedRow.Cells["Postcode"].Value);
                string email = Convert.ToString(selectedRow.Cells["Email"].Value);
                string web = Convert.ToString(selectedRow.Cells["Website"].Value);
                string tel = Convert.ToString(selectedRow.Cells["Telephone"].Value);
                string type = Convert.ToString(selectedRow.Cells["Type"].Value);
                string avgPrice = Convert.ToString(selectedRow.Cells["AvgPrice"].Value);

                restNameTxtBox.Text = restName;
                addressTxtBox.Text = address;
                postcodeTxtBox.Text = postcode;
                telTxtBox.Text = tel;
                emailTxtBox.Text = email;
                webTxtBox.Text = web;
                typeTxtBox.Text = type;
                avgPriceTxtBox.Text = avgPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception from table: " + ex);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];

                int restID = int.Parse(Convert.ToString(selectedRow.Cells["ID"].Value));

                //update Restaurant's info
                DBConnectivity.UpdateRestaurantInfo(restID, restNameTxtBox.Text, postcodeTxtBox.Text, addressTxtBox.Text,
                   typeTxtBox.Text, telTxtBox.Text, emailTxtBox.Text, webTxtBox.Text, decimal.Parse(avgPriceTxtBox.Text),adTypeTxtBox.Text);

                //update the Logo image in db
                DBConnectivity.UpdateLogo(filePath, fileName, DBConnectivity.GetLastRestID());

                //refresh content of data gridview table
                LoadTable();

                MessageBox.Show("Record has been successfully updated!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select a row!");
                Console.WriteLine("Exception in: ", ex);
            }
        }

        private void searchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string keyword = searchTxtBox.Text;

            if (keyword != string.Empty)
            {
                dataGridView1.DataSource = DBConnectivity.LoadRestaurantTableByKeyword(keyword);
            }
            else
            {
                LoadTable();
            }
        }

        private void imgBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            

            if (openFileDialog1.FileName != "")
             {
              filePath = openFileDialog1.FileName;
              var fileInfo = new FileInfo(openFileDialog1.FileName);
              fileName = fileInfo.Name;
             }
        }
    }
}
