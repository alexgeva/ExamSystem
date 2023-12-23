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
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Windows.Controls.Primitives;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for AddExamQuestions.xaml
    /// </summary>
    public partial class AddExamQuestions : Window
    {
        public AddExamQuestions()
        {
            InitializeComponent();
            LoadEXGrid();
            //idexamname = 0;
           // LoadQGrid();
           // LoadEXQGrid();
          //  LoadCount();
        }
        public int idexam, count, idexamname;
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        // SqlConnection con2 = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");

        public bool IsValid()
        {
            if (txtIdExam.Text == string.Empty)
            {
                MessageBox.Show("exam id is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtIdQuestion.Text == string.Empty)
            {
                MessageBox.Show("Question id is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
          


            return true;
        }

        public void LoadEXGrid()
        {
            //SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam", con);
            SqlCommand cmd = new SqlCommand("SELECT e.*, n.Exam_Id AS Exam_Name_Id FROM tbl_exam e INNER JOIN tbl_exam_name n ON e.Exam_Name = n.Exam_Name", con);
          



            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            EXDataGrid.ItemsSource = dt.DefaultView;
        }
        public void LoadQGrid()
        {
           
            SqlCommand cmd = new SqlCommand("Select Question_Id as Id,Question From Tbl_Questions  WHere Exam_Name_Id = " + idexamname + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            QDataGrid.ItemsSource = dt.DefaultView;
        }
        public void LoadEXQGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam_Question_temp WHere Exam_Id = " + idexam + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            EXQDataGrid.ItemsSource = dt.DefaultView;
        }
        public void LoadEXQGridReal()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam_Question WHere Exam_Id = " + idexam + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            EXQDataGridReal.ItemsSource = dt.DefaultView;
        }
        public void LoadCount()
        {
            // Get the number of rows in the EXQDataGrid
            int rowCount = EXQDataGrid.Items.Count;

            // Set the Text property of the txtCount TextBox control
            txtCount.Text = rowCount.ToString();
        }


        public void DeleteDataGridTemp() 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Exam_Question_temp", con);
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("all record deleted", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();

                LoadEXQGrid();
                LoadCount();
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

            private void EXDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            //convert data from data grid
           
          

            if (EXDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)EXDataGrid.SelectedItem;
                idexam = Convert.ToInt32(rowView[0]);
                count = Convert.ToInt32(rowView[8]);
                idexamname = Convert.ToInt32(rowView[10]);
                LoadQGrid();
                LoadEXQGrid();
                LoadEXQGridReal();
                LoadCount();


                // show data from data grid to form ());
                txtIdExam.Text = idexam.ToString();
                txtINumOfQuestion.Text = count.ToString();


            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void QDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //convert data from data grid
            int idquestion;
          
            if (QDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)QDataGrid.SelectedItem;
                idquestion = Convert.ToInt32(rowView[0]);
                // show data from data grid to form ());
                txtIdQuestion.Text = idquestion.ToString();
              
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int noq = int.Parse(txtINumOfQuestion.Text);
            int count = int.Parse(txtCount.Text);

            try
            {
                if (IsValid())
                {
                    if(count < noq)
                    { 
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Exam_Question_temp VALUES(@Exam,@Question)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Exam", txtIdExam.Text);
                    cmd.Parameters.AddWithValue("@Question", txtIdQuestion.Text);
                   
                 


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    // LoadGrid();
                    MessageBox.Show("add question succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Cleardata();
                    LoadEXQGrid();
                    LoadCount();
                      if (txtCount.Text==txtINumOfQuestion.Text)
                        { 
                            btnSave.IsEnabled = true;
                        }

                    }
                    else
                    {
                        MessageBox.Show("you add maximum question ", "stop", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
                con.Close();
            }

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Exam_Question_temp WHERE Question_Id=" + txtIdQuestion.Text + " " + " AND Exam_Id=" + txtIdExam.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("record deleted", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadEXQGrid();
                LoadCount();

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
        //DataGrid exams
        private void EXQDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idquestion, idexam;

            if (EXQDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)EXQDataGrid.SelectedItem;
                idexam = Convert.ToInt32(rowView[0]);

                idquestion = Convert.ToInt32(rowView[1]);
                // show data from data grid to form ());
                txtIdExam.Text = idexam.ToString();
                txtIdQuestion.Text = idquestion.ToString();
  
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
        }

        private void EXDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Exam_Id")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
            // You can add additional logic for other columns if needed
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }

        private void EXQDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Exam_Id")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
        }

        private void EXQDataGridReal_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Exam_Id")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtIdExam.Clear();
            txtIdQuestion.Clear();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            int noq = int.Parse(txtINumOfQuestion.Text);
            int count = int.Parse(txtCount.Text);
            try
            {
              
                    if (count == noq)
                    {
                        //SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Exam_Question(*) SELECT * FROM Tbl_Exam_Question_temp)", con);
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Exam_Question SELECT * FROM Tbl_Exam_Question_temp", con);

                    // string commandText = "INSERT INTO Tbl_Exam_Question (Question_Id, Exam_Id, Question, Option1, Option2, Option3, Option4, Answer) SELECT Question_Id, Exam_Id, Question, Option1, Option2, Option3, Option4, Answer FROM Tbl_Exam_Question_temp";


                    // cmd.CommandType = CommandType.Text;
                    // cmd.Parameters.AddWithValue("@Exam", txtIdExam.Text);
                    //  cmd.Parameters.AddWithValue("@Question", txtIdQuestion.Text);




                    con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        // LoadGrid();
                        MessageBox.Show("add question succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    // Cleardata();
                        DeleteDataGridTemp();
                        LoadEXQGrid();
                        LoadCount();
                        LoadEXQGridReal();



                }
                    else
                    {
                        MessageBox.Show("you need add question ", "check again", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
               
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }

        }
    }
    }

