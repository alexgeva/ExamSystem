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
using Microsoft.Reporting.Map.WebForms.BingMaps;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.CodeDom.Compiler;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using Microsoft.SqlServer.Server;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for ExamStatistics.xaml
    /// </summary>
    public partial class ExamStatistics : Window
    {
        public ExamStatistics()
        {
            InitializeComponent();
            LoadGrid();
            LoadExams();
        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public bool ir = false;
        public int examid;
        public string examname="";
        //private object txt_ExamName;

        public void LoadGrid()
        {
            if (examname == "")
            {
                SqlCommand cmd = new SqlCommand("Select Exam_Id, Exam_Name as Name, Exam_Date as Date From Tbl_Exam", con);
                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                }
                finally
                {
                    con.Close();
                }

                          

                EXDataGrid.ItemsSource = dt.DefaultView;

                // Populate the data table with data...
                         }

            else
            {
                SqlCommand cmd = new SqlCommand("Select Exam_Id, Exam_Name as Name, Exam_Date as Date From Tbl_Exam  WHere Exam_Name = '" + examname + "'", con);


                DataTable dt = new DataTable();
                try
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    dt.Load(sdr);

                }
                finally
                {
                    con.Close();
                }
                DataTable dataTable = new DataTable();
                // Populate the data table with data...
               
                EXDataGrid.ItemsSource = dt.DefaultView;
            }
        }
        public void LoadExams()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam_Name", con);

            //DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            // dt.Load(sdr);

            while (sdr.Read())
            {
                int id = sdr.GetInt32(0);
                string name = sdr.GetString(1);
                cmb_Exams.Items.Add(new ComboBoxItem { Content = name, Tag = id });
            }

            sdr.Close();
            con.Close();
        }
        public void LoadExamsGrid()
        {
           

           // SqlCommand cmd = new SqlCommand("Select StudentExamId,Student_Name,Grade From Tbl_Student_Exams WHere Exam_Id = " + txtExamId.Text + " ", con);
            SqlCommand cmd = new SqlCommand("Select StudentExamId,Student_Name as Student__Name,Grade as Grades From Tbl_Student_Exams WHere Exam_Id = " + examid + " ", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            // Populate the data table with data...
          
            EXDSataGrid.ItemsSource = dt.DefaultView;
           
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EXDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //convert data from data grid
            int id;
            string name;
           
            DateTime date;


            if (EXDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)EXDataGrid.SelectedItem;
                id = Convert.ToInt32(rowView[0]);
                name = Convert.ToString(rowView[1]);
                //DateTime date = DateTime.Parse(rowView[2].ToString());
                date = Convert.ToDateTime(rowView[2]);
              

                // show data from data grid to form ());
               
               
                examid = id;
                //txtExamDate = DateTime.Parse(date);

            }
          
            LoadExamsGrid();
        }

        private void cmb_Exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmb_Exams.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
               // int id = (int)selectedItem.Tag;
               // txtExamName.Text = id.ToString();
                examname = selectedItem.Content.ToString();

                LoadGrid();
                examid = 0;
                LoadExamsGrid();



            }
        }

        private void EXDSataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            examname = "";
            LoadGrid();
        }

        private void EXDSataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "StudentExamId")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
        }
    }
}
