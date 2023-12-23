using System;
using Microsoft.Win32;

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
using System.Xml.Linq;
using Microsoft.Identity.Client;
using System.Security.Cryptography;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for AddExam.xaml
    /// </summary>
    public partial class AddExam : Window
    {
        public AddExam()
        {
            InitializeComponent();
            LoadGrid();
            LoadExams();
            LoadLecture();
        }
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public bool ir=false;
        public void LoadGrid()
        {
            SqlCommand cmd = new SqlCommand("Select Exam_Id,Exam_Name AS Exam__Name,Exam_Date AS Exam__Date,Lecture_Id AS Lecture__Id,Exam_Start_Time AS Start__Time,Exam_Time AS Time,Is_Random,Exam_Score AS Score,Exam_No_Of_Question AS No__Questions,Exam_Lock AS Exam__Lock From Tbl_Exam", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            DataTable dataTable = new DataTable();
            EXDataGrid.ItemsSource = dt.DefaultView;
        }
        public void LoadExams()
        {
            SqlCommand cmd = new SqlCommand("Select * From Tbl_Exam_Name", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int id = sdr.GetInt32(0);
                string name = sdr.GetString(1);
                cmb_Exams.Items.Add(new ComboBoxItem { Content = name, Tag = id });
            }

            sdr.Close();
            con.Close();
        }
        public void LoadLecture()
        {
            SqlCommand cmd = new SqlCommand("SELECT * From Tbl_Personal WHERE personal_Type = 2", con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int id = sdr.GetInt32(0);
                string name = sdr.GetString(1);
                cmb_Lecture.Items.Add(new ComboBoxItem { Content = name, Tag = id });
            }
            sdr.Close();
            con.Close();
        }
       
        public void Cleardata() //clear all date from all text
        {
            txtExamName.Clear();
            txtId.Clear();
            txtStartTime.Clear();
            txtExamTime.Clear();
            txtExamScore.Clear();
            txtIsRandom.IsChecked = false;
            txtLectureId.Clear();
            txtExamDate.SelectedDate = null;
            txtExamNum.Clear();
            cmb_Exams.Items.Clear();
            cmb_Lecture.Items.Clear();
            LoadExams();
            LoadLecture();
            btnAdd.IsEnabled =true;
        }
        public bool IsValid() //check that all the text box that requiered are fill
        {
            if (txtExamName.Text == string.Empty)
            {
                MessageBox.Show("Exam Name is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           if (txtExamDate.Text == string.Empty)
            {
                MessageBox.Show("DATE requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtStartTime.Text == string.Empty)
            {
                MessageBox.Show("Start Time is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtExamTime.Text == string.Empty)
            {
                MessageBox.Show("Exam Time is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtExamScore.Text == string.Empty)
            {
                MessageBox.Show("Score is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtLectureId.Text == string.Empty)
            {
                MessageBox.Show("Lecture Id  is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            return true;
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)  //delete the data grid selected row
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Exam WHERE Exam_Id=" + txtId.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("record deleted", "delete", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                Cleardata();
                LoadGrid();
                LoadExams();
                LoadLecture();
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

        private void btnEdit_Click(object sender, RoutedEventArgs e) //edit and change the data that need to change
        {
           
            string query = "UPDATE Tbl_Exam SET Exam_Name=@ExamName, Exam_Date=@ExamDate, Lecture_Id=@LectureId, Exam_Start_Time=@StartTime, Exam_Time=@ExamTime, Is_Random=@IsRandom, Exam_Score=@ExamScore ,Exam_No_Of_Question=@ExamNoOfQuestion WHERE Exam_Id=@ExamId";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@ExamName", txtExamName.Text);
                cmd.Parameters.AddWithValue("@ExamDate", Convert.ToDateTime(txtExamDate.Text));
                cmd.Parameters.AddWithValue("@LectureId", txtLectureId.Text);
                cmd.Parameters.AddWithValue("@StartTime", txtStartTime.Text);
                cmd.Parameters.AddWithValue("@ExamTime", txtExamTime.Text);
                cmd.Parameters.AddWithValue("@IsRandom", txtIsRandom.IsChecked); // Assuming Is_Random is a bit field
                cmd.Parameters.AddWithValue("@ExamScore", txtExamScore.Text);
                cmd.Parameters.AddWithValue("@ExamId", txtId.Text);
                cmd.Parameters.AddWithValue("@ExamNoOfQuestion", txtExamNum.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LoadGrid();
                LoadExams();
                LoadLecture();
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) //add new exam
        {
            try
            {
                if (IsValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Exam (Exam_Name,Exam_date,Lecture_Id,Exam_Start_Time,Exam_Time,Is_Random,Exam_Score,Exam_No_Of_Question)VALUES(@Exam_Name,@Exam_date,@Lecture_Id,@Exam_Start_Time,@Exam_Time,@Is_Random,@Exam_Score,@Exam_No_Of_Question)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Exam_Name", cmb_Exams.Text);
                    DateTime examDate = txtExamDate.SelectedDate ?? DateTime.MinValue; // handle null value for SelectedDate
                    cmd.Parameters.AddWithValue("@Exam_Date", examDate);
                     int Lecture;
                      if (!int.TryParse(txtLectureId.Text, out Lecture))
                      {
                          // Handle invalid age input here
                      }
                      cmd.Parameters.AddWithValue("@Lecture_Id", Lecture);
                    DateTime examStartTime;
                    if (!DateTime.TryParse(txtStartTime.Text, out examStartTime))
                    {
                        // Handle invalid time input here
                    }

                    //DateTime examDate = txtExamDate.SelectedDate ?? DateTime.MinValue; // handle null value for SelectedDate

                    // Add the parameters to the command
                    cmd.Parameters.AddWithValue("@Exam_Start_Time", examStartTime);
                 
                      int Exam_Time;
                      if (!int.TryParse(txtExamTime.Text, out Exam_Time))
                      {
                          // Handle invalid age input here
                      }
               

                      cmd.Parameters.AddWithValue("@Exam_Time", Exam_Time);
                      cmd.Parameters.AddWithValue("@Is_Random", ir);

                      float score;
                      if (!float.TryParse(txtExamScore.Text, out score))

                      {
                          // Handle invalid float input here
                      }
                      cmd.Parameters.AddWithValue("@Exam_Score", score);


                     
                      int qnum;
                      if (!int.TryParse(txtExamNum.Text, out qnum))
                      {
                          // Handle invalid age input here
                      }
                   

                      cmd.Parameters.AddWithValue("@Exam_No_Of_Question", qnum);
                  

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("add exam succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    Cleardata();
                    LoadGrid();
                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
                con.Close();
            }
        }

   

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EXDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // show data from data grid to form ());
           
            if (EXDataGrid.SelectedItem != null)

            {
                DataRowView rowView = (DataRowView)EXDataGrid.SelectedItem;
                txtId.Text = Convert.ToInt32(rowView[0]).ToString();
                txtExamName.Text = (string)rowView[1];
                cmb_Exams.Text = (string)rowView[1];
                txtExamDate.Text = Convert.ToDateTime(rowView[2]).ToString();
                txtLectureId.Text = Convert.ToInt32(rowView[3]).ToString();
                txtStartTime.Text = Convert.ToString(rowView[4]);
                txtExamTime.Text = Convert.ToInt32(rowView[5]).ToString();
                txtIsRandom.IsChecked = Convert.ToBoolean(rowView[6]);
                txtExamScore.Text = Convert.ToInt32(rowView[7]).ToString();
                txtExamNum.Text = Convert.ToInt32(rowView[8]).ToString();

                btnAdd.IsEnabled = false;
            }
        }

        private void txtIsRandom_Checked(object sender, RoutedEventArgs e)
        {
            ir = true;
        }

        private void btnClearData_Click(object sender, RoutedEventArgs e)
        {
            Cleardata();
        }

        private void cmb_Exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmb_Exams.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                int id = (int)selectedItem.Tag;
                txtExamName.Text = id.ToString();

                LoadGrid();
                btnAdd.IsEnabled = true;
            }
        }

        private void cmb_Lecture_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmb_Lecture.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
                int id = (int)selectedItem.Tag;
                txtLectureId.Text = id.ToString();
                LoadGrid();
                btnAdd.IsEnabled = true;
            }
        }

        private void EXDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Exam_Id")
            {
                // Hide the PersonalID column
                e.Cancel = true;
            }
            // change the date type in data grid
            if (e.PropertyType == typeof(System.DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = "dd/MM/yyyy";
        }
    }
}
