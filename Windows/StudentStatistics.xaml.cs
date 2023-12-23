using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    /// Interaction logic for StudentStatistics.xaml
    /// </summary>
    public partial class StudentStatistics : Window
    {
        public StudentStatistics()
        {
            InitializeComponent();
            LoadGrid();
            SADataGrid.Visibility = Visibility.Collapsed;
            lbl_ewa.Visibility = Visibility.Collapsed;


        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public bool ir = false;
        public int tempid,tempexamid;
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select Personal_Id, Personal_Name as Students__Name, Personal_Id_number as Id__Number From Tbl_Personal WHERE Personal_Type = 1", con);
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
        /* public void LoadStudents()
         {
             SqlCommand cmd = new SqlCommand("Select * From Tbl_Personal", con);

             //DataTable dt = new DataTable();
             con.Open();
             SqlDataReader sdr = cmd.ExecuteReader();
             // dt.Load(sdr);

             while (sdr.Read())
             {
                 int id = sdr.GetInt32(0);
                 string name = sdr.GetString(1);

             }

             sdr.Close();
             con.Close();
         }*/
        public void LoadExamsGrid()
        {
            // int x = int.Parse(txtExamId.Text);

            // Use examIdValue in your SQL query

           // SqlCommand cmd = new SqlCommand("Select StudentExamId,Student_Name,Grade From Tbl_Student_Exams WHere Student_Id = " + txtStudentId.Text + " ", con);
            SqlCommand cmd = new SqlCommand("Select StudentExamId as Exam__Id,Student_Name as Student__Name ,Grade as Grades From Tbl_Student_Exams WHere Student_Id = " + tempid + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            STDDataGrid.ItemsSource = dt.DefaultView;

        }

        public void LoadAnswersGrid()
        {
            // int x = int.Parse(txtExamId.Text);

            // Use examIdValue in your SQL query

            // SqlCommand cmd = new SqlCommand("Select StudentExamId,Student_Name,Grade From Tbl_Student_Exams WHere Student_Id = " + txtStudentId.Text + " ", con);
            SqlCommand cmd = new SqlCommand("Select Question,Answer,GoodAnswer From Tbl_Exam_Student_Answers WHere StudentExamId = " + tempexamid + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            // DataTable dataTable = new DataTable();
            // Populate the data table with data...
            //dataGridView1.DataSource = dataTable;
            //dataGrid.DataSource = dt.DefaultView;
            SADataGrid.ItemsSource = dt.DefaultView;
           
            if (SADataGrid.ItemsSource != null && SADataGrid.Items.Count > 0)
            {
                // The DataGrid has data
                // Your code to access the data goes here
                // Filter the rows where Answer and GoodAnswer are not the same
                var filteredRows = dt.AsEnumerable().Where(row => row.Field<string>("Answer") != row.Field<string>("GoodAnswer")).CopyToDataTable();

                // Assuming SADataGrid is your DataGrid
                SADataGrid.ItemsSource = filteredRows.DefaultView;
            }
            else
            {
                // The DataGrid is empty
                // Handle the case when there is no data
                MessageBox.Show("No Error Found");
                SADataGrid.Visibility = Visibility.Collapsed;
                lbl_ewa.Visibility = Visibility.Collapsed;
            }




           

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
              
        private void STDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //convert data from data grid
            int id,idnumber;
           // string name;

           // DateTime date;


            if (STDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)STDataGrid.SelectedItem;
                id = Convert.ToInt32(rowView[0]);
               // name = Convert.ToString(rowView[1]);
                idnumber = Convert.ToInt32(rowView[2]);


             

                // show data from data grid to form ());

               // txtStudentName.Text = name;
               // txtStudentId.Text = id.ToString();
                tempid = id;
                lbl_ewa.Visibility = Visibility.Collapsed;
                SADataGrid.Visibility = Visibility.Collapsed;



            }
            else
            {
                MessageBox.Show("Please select a row.");
            }
            LoadExamsGrid();
        }

        

      

        private void STDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Personal_Id")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
            // You can add additional logic for other columns if needed
        }

        private void SADataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void STDDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //convert data from data grid
            int id;
           // string name;

       


            if (STDDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)STDDataGrid.SelectedItem;
                id = Convert.ToInt32(rowView[0]);
               // name = Convert.ToString(rowView[1]);

                // show data from data grid to form ());

                //txtStudentName.Text = name;
                // txtStudentId.Text = id.ToString();
                tempexamid = id;
                //MessageBox.Show(tempexamid.ToString());
                SADataGrid.Visibility = Visibility.Visible;
                lbl_ewa.Visibility = Visibility.Visible;
                LoadAnswersGrid();


            }
           // else
          //  {
          //      MessageBox.Show("Please select a row.");
         //   }
            //LoadExamsGrid();
        }
    }
}
