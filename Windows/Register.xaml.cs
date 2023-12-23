
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public void Cleardata()
        {
           txtName.Clear();
           txtType.Clear();
           txtId.Clear();
           txtUser.Clear();
           txtPassword.Clear();
        }
        public bool IsValid()
        {
            if (txtName.Text == string.Empty)
            {
                MessageBox.Show("Name is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtType.Text == string.Empty)
            {
                MessageBox.Show("Type is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtId.Text == string.Empty)
            {
                MessageBox.Show("Id is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private bool IsValidPassword(string password)
        {
            // Define the regular expression pattern
            string pattern = "^[a-zA-Z0-9!@#$%^&*]{6,15}$";

            // Check if the input matches the pattern
            return Regex.IsMatch(password, pattern);
        }
        private void btnRegister_Copy_Click(object sender, RoutedEventArgs e)
        {
            Close();    
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string input = txtPassword.Text;
                                     
            try
            {
                if (IsValid())
                {
                    if (IsValidPassword(input))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Personal VALUES(@Personal_Name,@Personal_Type,@Personal_Id,@Personal_User_Name,@Personal_Password)", con);

                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Personal_Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Personal_Type",txtType.Text);
                        cmd.Parameters.AddWithValue("@Personal_Id", txtId.Text);
                        cmd.Parameters.AddWithValue("@Personal_User_Name", txtUser.Text);
                        cmd.Parameters.AddWithValue("@Personal_Password", txtPassword.Text);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Register succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password. Password must be 6 to 15 characters long and contain only numbers, letters, and the following symbols: !@#$%^&*");
                    }
                }
               
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
               
           

        }



        bool checkDate()
        {
            if((txtName.Text.Trim() == "" )|| 
                (txtType.Text == null) ||
                (txtId.Text == null)||
                (txtUser.Text.Trim()=="" )||
                (txtPassword.Text.Trim() == ""))
            {
                return false;
            }
            else
            { 
                return true; 
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtType.Text = "1";
        }
    }
}
