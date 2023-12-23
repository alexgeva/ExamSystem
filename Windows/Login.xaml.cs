using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using ExamsSystem.Windows;
using System.IO;
using System.Text.RegularExpressions;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        //private object msgbox;

        public Login()
        {
            InitializeComponent();
            MainWindow mainWindow = Application.Current.MainWindow as MainWindow; // Get a reference to the MainWindow instance
            mainWindow.txtStudent.IsEnabled = false; // clear the txtStudent MenuItem
            mainWindow.txtExams.IsEnabled = false; // clear the txtStudent MenuItem
            txtName.Focus(); // put the Focus to add user name
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("Please Fill All Data");
            }
            else
            {
             
                MY_DB db = new MY_DB();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable dt = new DataTable();
                // get a connection object
         
                SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Personal where Personal_User_Name =@usn  and Personal_Password=@pass", db.GetConnection);
                command.Parameters.Add("@usn", SqlDbType.VarChar).Value = txtName.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = txtPassword.Password;
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                // MainWindow mainWindow2 = new MainWindow();
                // mainWindow2.flag =false;
                if (dt.Rows.Count > 0)
                {
                   // mainWindow2.tempname = dt.Rows[0]["Personal_Name"].ToString();
                   // mainWindow2.type = dt.Rows[0]["Personal_Type"].ToString();
                   // mainWindow2.id = dt.Rows[0]["Personal_Id"].ToString();
                   //  mainWindow2.idname = dt.Rows[0]["Personal_Id_Number"].ToString();
                   // string newLine = mainWindow2.id + mainWindow2.tempname + mainWindow2.idname;
                
                   UserStatic.PersonalId = (int)dt.Rows[0]["Personal_Id"];
                   UserStatic.PersonalName = dt.Rows[0]["Personal_Name"].ToString();
                   UserStatic.PersonalType = (int)dt.Rows[0]["Personal_Type"];
                   UserStatic.PersonalIdNumber = (long)dt.Rows[0]["Personal_Id_Number"];
                   if  (UserStatic.PersonalType==1)
                      {
                         UserStatic.isAdmin = false;
                      }
                   else
                      {
                         UserStatic.isAdmin =true;
                      }

            
                   //MessageBox.Show("LOGIN Success Welcome Back" + " -- " + mainWindow2.tempname);
                   MessageBox.Show("LOGIN Success Welcome Back" + " -- " + UserStatic.PersonalName);

                   //if (mainWindow2.type == "1")
                   if (UserStatic.PersonalType == 1)
                      {
                        MainWindow mainWindow = Application.Current.MainWindow as MainWindow; // Get a reference to the MainWindow instance
                        if (mainWindow != null)
                           {
                              mainWindow.txtStudent.IsEnabled = true; // Enable the txtStudent MenuItem
                           }
                        }
                        //else if (mainWindow2.type == "2")
                   else if (UserStatic.PersonalType == 2)
                      {
                        MainWindow mainWindow = Application.Current.MainWindow as MainWindow; // Get a reference to the MainWindow instance
                        if (mainWindow != null)
                           {
                              mainWindow.txtExams.IsEnabled = true; // Enable the txtStudent MenuItem
                           }
                        }

                        Close();
                }
                else
                {
                   MessageBox.Show("LOGIN Fail Try Again");
                }
  
            }
        }
        //clear the data 
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtPassword.Clear();

        }
        //close windows login
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
