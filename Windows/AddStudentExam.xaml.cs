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
    /// Interaction logic for AddStudentExam.xaml
    /// </summary>
    public partial class AddStudentExam : Window
    {
     
        public AddStudentExam()
        {
            InitializeComponent();
            Add_Student_data();
            LoadGrid();
        }

        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public static string SetValueForText1 = "";
        public static string SetValueForText2 = "";
        public static string SetValueForText3 = "";
        public static string SetValueForText4 = "";
        public static string SetValueForText5 = "";
        public static string SetValueForText6 = "";
        public static DatePicker? SetValueForText7;
        public static int SetValueForText8 = 0;

        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam", con);
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
        public void Add_Student_data()
        {
                txtPersonalId.Text = UserStatic.PersonalId.ToString();
                txtStudentName.Text = UserStatic.PersonalName;
                txtStudentIdNum.Text = UserStatic.PersonalIdNumber.ToString();

        }


        private void btnStart_Click(object sender, RoutedEventArgs e)

        {
            SetValueForText1 = txtPersonalId.Text;
            SetValueForText2 = txtStudentName.Text;
           // SetValueForText5 = txtStudentIdNum.Text;
            SetValueForText3 = txtExamId.Text;
            SetValueForText4 = txtExamName.Text;
            SetValueForText5 = txtnoq.Text;
            SetValueForText6 = txtScore.Text;
            //SetValueForText7 = txtStartTime.Text
            SetValueForText8 = int.Parse(txtExamTime.Text);


            StudentExams addstudentexam = new StudentExams();
            addstudentexam.ShowDialog();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EXDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //convert data from data grid
            int id, lecture, examtime, score, noofquestion;
            string name, starttime;
            bool random;
            DateTime date;


            if (EXDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)EXDataGrid.SelectedItem;
                id = Convert.ToInt32(rowView[0]);
                name = Convert.ToString(rowView[1]);
                //DateTime date = DateTime.Parse(rowView[2].ToString());
                date = Convert.ToDateTime(rowView[2]);
                lecture = Convert.ToInt32(rowView[3]);
                starttime = Convert.ToString(rowView[4]);
                examtime = Convert.ToInt32(rowView[5]);
                random = Convert.ToBoolean(rowView[6]);
                score = Convert.ToInt32(rowView[7]);
                noofquestion = Convert.ToInt32(rowView[8]);

                // show data from data grid to form ());
                txtExamId.Text = id.ToString();
                txtExamName.Text = name;
                txtStartTime.Text = starttime;
                txtExamTime.Text = examtime.ToString();
                txtScore.Text = score.ToString();
                txtnoq.Text = noofquestion.ToString();

               
            }
            else
            {
                MessageBox.Show("Please select a row.");
            }

      

    }
    }
}
