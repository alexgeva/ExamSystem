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
using System.Data.SqlClient;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for EditStudentLogin.xaml
    /// </summary>
    public partial class EditStudentLogin : Window
    {
        public EditStudentLogin()
        {
            InitializeComponent(); 
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Personal WHere Personal_Id = " + UserStatic.PersonalId + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            STDataGrid.ItemsSource = dt.DefaultView;
        }
        //edit Student by Personal_Id 
       
        
        private void STDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //convert data from data grid
            int id, type, idnum;
            //string name, user, password;


            if (STDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)STDataGrid.SelectedItem;
                id = Convert.ToInt32(rowView[0]);
               // name = Convert.ToString(rowView[1]);
               // type = Convert.ToInt32(rowView[2]);
               // idnum = Convert.ToInt32(rowView[3]);
               // user = Convert.ToString(rowView[4]);
               // password = Convert.ToString(rowView[5]);

                // show data from data grid to form ());
               // txtPersonalId.Text = id.ToString();
               // txtStudentName.Text = name;
                txtStudentName.Text = Convert.ToString(rowView[1]);


                // txtStudentType.Text = type.ToString();

                //txtStudentIdNum.Text = idnum.ToString();
                //txtStudentIdNum.Text = Convert.ToInt32(rowView[3]).ToString();
                txtStudentIdNum.Text = rowView[3].ToString();
                
                txtUserName.Text = Convert.ToString(rowView[4]);

                txtPassword.Text = Convert.ToString(rowView[5]);
                //txtUserName.Text = user;

                // txtPassword.Text = password;
            }
           
        }
              
       
        private void STDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Personal_Id")
            {
                // Hide the Personal_ID column
                e.Cancel = true;
            }
            if (e.PropertyName == "personal_Type")
            {
                // Hide the Personal_Type column
                e.Cancel = true;
            }
        }

      

        private void btnEditSave_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Personal SET Personal_Name='" + txtStudentName.Text + "',Personal_Id_number= '" + Convert.ToInt64(txtStudentIdNum.Text) + "',Personal_User_Name='" + txtUserName.Text + "',Personal_Password='" + txtPassword.Text + "' WHERE Personal_Id=" + UserStatic.PersonalId + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been updated", "UPDATE", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();

                LoadGrid();
                txtStudentName.IsEnabled =false;
                txtUserName.IsEnabled = false;
                txtPassword.IsEnabled = false;
                txtStudentIdNum.IsEnabled = false;
            }
            catch (SqlException EX)
            {
                MessageBox.Show("Not updated" + EX.Message);
            }
            finally
            {
                con.Close();
            }

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            txtStudentName.IsEnabled = true;
            txtUserName.IsEnabled=true;
            txtPassword.IsEnabled=true;
            txtStudentIdNum.IsEnabled=true;
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }


}

