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
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        public AddStudent()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select Personal_Id,Personal_Name as Name,Personal_Type as Type,Personal_Id_number as Id__Number,Personal_User_Name as User__Name,Personal_Password as Password From Tbl_Personal", con);
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
        public void Cleardata()
        {
            txtStudentName.Clear();

            txtPersonalId.Clear();
            txtStudentType.Clear();
            txtStudentIdNum.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
        }

            public bool IsValid()
            {
                if (txtStudentName.Text == string.Empty)
                {
                    MessageBox.Show("Student Name is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (txtStudentType.Text == string.Empty)
                {
                    MessageBox.Show("Student Type is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (txtStudentIdNum.Text == string.Empty)
                {
                    MessageBox.Show("Student Id Num is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (txtUserName.Text == string.Empty)
                {
                    MessageBox.Show("UserName is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Password is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
               


                return true;
            }


            
       


        private void btnAdd_Click(object sender, RoutedEventArgs e)
            {
            try
            {
                if (IsValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Personal VALUES(@Personal_Name,@personal_Type,@Personal_Id_number,@Personal_User_Name,@Personal_Password)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Personal_Name", txtStudentName.Text);
                    cmd.Parameters.AddWithValue("@personal_Type", txtStudentType.Text);
                    cmd.Parameters.AddWithValue("@Personal_Id_number", txtStudentIdNum.Text);
                    cmd.Parameters.AddWithValue("@Personal_User_Name", txtUserName.Text);
                    cmd.Parameters.AddWithValue("@Personal_Password", txtPassword.Text);
                   


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    // LoadGrid();
                    MessageBox.Show("add student succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cleardata();
                    LoadGrid();
                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
        
    }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonalId.Text))
            {
                // Your code when txtPersonalId.Text is not null or empty
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Tbl_Personal SET Personal_Name='" + txtStudentName.Text + "',Personal_Id_number= '" + Convert.ToInt64(txtStudentIdNum.Text) + "',Personal_Type='" + txtStudentType.Text + "',Personal_User_Name='" + txtUserName.Text + "',Personal_Password='" + txtPassword.Text + "' WHERE Personal_Id=" + txtPersonalId.Text + " ", con);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("record has been updated", "UPDATE", MessageBoxButton.OK, MessageBoxImage.Information);
                    con.Close();

                    LoadGrid();
                    Cleardata();
                    //txtStudentName.IsEnabled = false;
                    // txtUserName.IsEnabled = false;
                    // txtPassword.IsEnabled = false;
                    // txtStudentIdNum.IsEnabled = false;
                    //txtStudentType.IsEnabled = false;
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
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPersonalId.Text))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Personal WHERE Personal_Id=" + txtPersonalId.Text + " ", con);
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("record deleted", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
                    con.Close();
                    //Cleardata();
                    LoadGrid();
                    Cleardata();
                }
                catch (SqlException EX)
                {
                    MessageBox.Show("Not deleted" + EX.Message);
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

            private void STDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //convert data from data grid
               // int id, type, idnum;
               // string name, user, password;


                if (STDataGrid.SelectedItem != null)

                {
                    DataRowView rowView = (DataRowView)STDataGrid.SelectedItem;
                  //  id = Convert.ToInt32(rowView[0]);
                  //  name = Convert.ToString(rowView[1]);
                  //  type = Convert.ToInt32(rowView[2]);
                  //  idnum = Convert.ToInt32(rowView[3]);
                  //  user = Convert.ToString(rowView[4]);
                  //  password = Convert.ToString(rowView[5]);

                // show data from data grid to form ());
                // txtPersonalId.Text = id.ToString();
                // txtStudentName.Text = name;
                //txtStudentType.Text = type.ToString();
                //txtStudentIdNum.Text = idnum.ToString();
                // txtUserName.Text = user;
                // txtPassword.Text = password;
                    txtPersonalId.Text = Convert.ToString(rowView[0]);
                    txtStudentName.Text = Convert.ToString(rowView[1]);
                    txtStudentType.Text = Convert.ToString(rowView[2]);
                    txtStudentIdNum.Text = rowView[3].ToString();
                    txtUserName.Text = Convert.ToString(rowView[4]);
                    txtPassword.Text = Convert.ToString(rowView[5]);
                    btnAdd.IsEnabled = false;
                }

            
                
            } 

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Cleardata();
            btnAdd.IsEnabled = true;
        }

        
            private void STDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
            {
                if (e.PropertyName == "Personal_Id")
                {
                    // Hide the Personal_ID column
                    e.Cancel = true;
                }
               
            }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }

       
    }

