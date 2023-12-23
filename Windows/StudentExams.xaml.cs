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
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;
using System.IO;
using System.Security.AccessControl;
using System.Diagnostics;
using Application = System.Windows.Application;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using System.Windows.Interop;
using System.Threading;

namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for StudentExams.xaml
    /// </summary>
    public partial class StudentExams : Window
        
    {
        //private int currentQuestionIndex = 0;// Keep track of the current column index
        private int currentColumnIndex = 0; // Keep track of the current column index
        private string answer, answer2;
        private DataView questionsView; // DataView object to create a view of the Tbl_Questions table
        private (int q, string answer, string goodAnswer, string answerNo , string question)[] dataArray;
        public int flag,flag2;
        private DateTime examStartTime;
        private Timer timer;


        public StudentExams()
        {
      
        InitializeComponent();
            SData();
            dataArray = new (int q, string answer, string goodAnswer, string answerNo ,string question)[20];

            //loadGrid();

            // Create a DataView object to create a view of the Tbl_Questions table
            questionsView = new DataView(GetQuestionsDataTable());
          

        }

      

        public void SData()
        {
           // if (AddStudentExam.SetValueForText1 != null)
           // {
                txtPersonalId.Text = AddStudentExam.SetValueForText1;
                txtStudentName.Text = AddStudentExam.SetValueForText2;
                txtExamName.Text = AddStudentExam.SetValueForText4;
                txtExamId.Text = AddStudentExam.SetValueForText3;
                txtNoq.Text = AddStudentExam.SetValueForText5;
                txtQnum.Text = AddStudentExam.SetValueForText5;
            // }
            // else
            //  {
            // handle the null case here
            // }
        }

     

        public void SetAddTempDate()
        {
            // Add  questions and answers here
            if
               (txtQuestionId.Text != null)
            {

            }



        }
        public void GetAddTempDate()
        {
               

        }
        public void Add_Student_data()
        {
            string[] lines = System.IO.File.ReadAllLines(@"E:\CSHARP\sql\ExamsSystem\user.txt");


            foreach (string line in lines)
            {
              
                string stid = line.Substring(0,1); // extract "id"
                string stname = line.Substring(1, 8); // extract "id"
                string idnum = line.Substring(9, 9); // extract "id"
                txtPersonalId.Text = stid;
                txtStudentName.Text = stname;
                txtQnum.Text = idnum;



            }
        }


        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        //private object mainWindow1;

       


        private DataTable GetQuestionsDataTable()
        {
            // Query the Tbl_Questions table and load the data into a DataTable object
            //string connectionString = @"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Questions", connection);
            DataTable dataTable = new DataTable();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            dataTable.Load(reader);
            connection.Close();
            return dataTable;
        }

        private void ShowCurrentColumn()
        {
           

            // Check if questionsView.Table is null
            if (questionsView.Table != null)
            {
                // Show the data of the current column in the TextBox
                if (currentColumnIndex >= 0 && currentColumnIndex < questionsView.Table.Rows.Count)
                {
                   // string columnName = questionsView.Table.Columns[currentColumnIndex].ColumnName;
                   // string columnData = questionsView[0][columnName].ToString();
                    //txtQuestion.Text = columnData;
                    
                    int i = currentColumnIndex;
                    txtQuestionId.Text = questionsView[i]["Question_Id"].ToString();
                    txtUrl.Text = questionsView[i]["Pic_Url"].ToString();
                    txtQuestion.Text = questionsView[i]["Question"].ToString();
                    txtAnswer1.Text = questionsView[i]["Answer1"].ToString();
                    txtAnswer2.Text = questionsView[i]["Answer2"].ToString();
                    txtAnswer3.Text = questionsView[i]["Answer3"].ToString();
                    txtAnswer4.Text = questionsView[i]["Answer4"].ToString();
                    txtGoodAnswer.Text = questionsView[i]["Answer"].ToString();

                    if (txtUrl.Text == "")
                    {
                        string imageUrl = "file:///" + @"E:\CSHARP\sql\ExamsSystem\Images\c2.jpg";
                  
                        Uri imageUri = new Uri(imageUrl);
                        ImgUrl.Source = new BitmapImage(imageUri);

                    }
                    else
                    {
                        //string imageUrl = "file:///" + @"E:\CSHARP\sql\ExamsSystem\Images\q1.gif";
                        string imageUrl = "file:///" + txtUrl.Text +"";
                        Uri imageUri = new Uri(imageUrl);
                        ImgUrl.Source = new BitmapImage(imageUri);

                    }

                    ClearData();


                }
            }

        }
        private void AddTempData()

        {
            int index = int.Parse(txtQuestionId.Text);
            int qValue = index;
            string answerValue = txtAnswer.Text;
            string goodAnswerValue = txtGoodAnswer.Text;
            string answerNoValue = answer;
            string question = txtQuestion.Text;

            // Set the values at the specified index in the array
            dataArray[index] = (q: qValue, answer: answerValue, goodAnswer: goodAnswerValue, answerNo: answerNoValue , question: question);

            //MessageBox.Show($"Data set at index {index}.");
        }
        private void GetTempData()

        {
            //int qValue = int.Parse(txtQuestionId.Text)-1;
            int qValue = currentColumnIndex;

            // Find the element in the array where q matches the index
            var data = dataArray.FirstOrDefault(d => d.q == qValue);

         
                answer = data.answerNo;
                switch (answer)
                {
                    case "1":
                        A1.IsChecked = true;
                        break;
                    case "2":
                        A2.IsChecked = true;
                        break;
                    case "3":
                        A3.IsChecked = true;
                        break;
                    case "4":
                        A4.IsChecked = true;
                        break;
                    default:
                        // Handle the case when none of the specified cases match
                        // You can either assign a default value to x or provide error handling
                        break;
            
               // MessageBox.Show($"Data found for q = {qValue}: \n" +
                 //   $"answer: {data.answer} \n" +
                   // $"good answer: {data.goodAnswer} \n" +
                   // $"answer no: {data.answerNo}");
            }
        }

        //  private void AddData(int[]questionid ,int newquestionid ,int[]answerid,int newanswer)
        //   {

            //       questionid[newquestionid] = newquestionid;
            //      answerid[newquestionid] = newanswer;
            //   }
        public class QuizQuestion
        {
            public int Id { get; set; }
            public string SelectedChoice { get; set; }
        }
        List<QuizQuestion> quizQuestions = new List<QuizQuestion>
        {
        new QuizQuestion
    {
        Id = 1,
       
        SelectedChoice = "1"
    },
    // Add more questions in a similar manner
};

        public  class SaveAnswer
        {
           

        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            // Move to the previous column and show its data
            
            if (currentColumnIndex > 0)
                {
                AddTempData();
                currentColumnIndex--;
                ClearData();
                txtAnswer.Clear();

                GetTempData();
                ShowCurrentColumn();
            }
          
          


           // if (currentColumnIndex < 0)
           // {
           //      currentColumnIndex = 0;
           //  }
           
           
           

        }
       
        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            //ClearData();
            if (flag == 1)
            {
                AddTempData();
                flag2 = 1;
            }
            else
            {
                if (MessageBox.Show("You Dont Choose An Answer Do you want to continue?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MessageBox.Show("OK", "information", MessageBoxButton.OK);
                    flag2 = 1;

                    // Close the window  
                }
            else
                {
                     MessageBox.Show("Try Again", "information", MessageBoxButton.OK);
                    flag2 = 0;
                }
            }


            if (flag2 == 1) 
            { 
                     int noq,qid;
                    // checke the id number to get only the question

                     int.TryParse(txtNoq.Text, out noq);
                     int.TryParse(txtQuestionId.Text, out qid);


                    if (qid < noq)
                     {
                        currentColumnIndex++;
                        ClearData();
                        GetTempData();
                        ShowCurrentColumn();
                        txtAnswer.Clear();//temp
                        txtStudentIdLeft.Text = (noq - qid).ToString();
                     }
                    else
                    {
                        MessageBox.Show("This Is The Last Question", "Attention",MessageBoxButton.OK);
                        txtStudentIdLeft.Text = (noq - qid).ToString();
                    }

            }


            // Move to the next column and show its data

            // }


            /*
             Application.Current.Properties["variable1"] = txtQuestionId.Text;
             Application.Current.Properties["variable2"] = answer;
             Application.Current.Properties["variable3"] = currentColumnIndex.ToString();
             var variable1 = Application.Current.Properties["variable1"] as string;
             var variable2 = Application.Current.Properties["variable2"] as string;
             var variable3 = Application.Current.Properties["variable3"] as string;
             MessageBox.Show(variable1);
             MessageBox.Show(variable2);
             MessageBox.Show(variable3);
             /*
              using System;
 using System.Linq;

 namespace WpfApp
 {
     public partial class MainWindow
     {
         private (int q, string answer, string goodAnswer, string answerNo)[] dataArray;

         public MainWindow()
         {
             InitializeComponent();

             // Initialize the array with four elements
             dataArray = new (int q, string answer, string goodAnswer, string answerNo)[4];
         }

         private void SetDataButton_Click(object sender, RoutedEventArgs e)
         {
             int index = int.Parse(IndexTextBox.Text);
             int qValue = index;
             string answerValue = AnswerTextBox.Text;
             string goodAnswerValue = GoodAnswerTextBox.Text;
             string answerNoValue = AnswerNoTextBox.Text;

             // Set the values at the specified index in the array
             dataArray[index] = (q: qValue, answer: answerValue, goodAnswer: goodAnswerValue, answerNo: answerNoValue);

             MessageBox.Show($"Data set at index {index}.");
         }

         private void GetDataButton_Click(object sender, RoutedEventArgs e)
         {
             int qValue = int.Parse(QTextBox.Text);

             // Find the element in the array where q matches the index
             var data = dataArray.FirstOrDefault(d => d.q == qValue);

             if (data != default)
             {
                 MessageBox.Show($"Data found for q = {qValue}: \n" +
                     $"answer: {data.answer} \n" +
                     $"good answer: {data.goodAnswer} \n" +
                     $"answer no: {data.answerNo}");
             }
             else
             {
                 MessageBox.Show($"No data found for q = {qValue}.");
             }
         }
     }
 }

              // Retrieve data
 if (Application.Current.Properties.Contains("variable1") && Application.Current.Properties.Contains("variable2"))
 {
     var variable1 = Application.Current.Properties["variable1"] as string;
     var variable2 = Application.Current.Properties["variable2"] as int;
     // Do something with variable1 and variable2
 }*/

        }


        private void A1_Checked(object sender, RoutedEventArgs e)
        {
           
            A2.IsChecked = false;
            A3.IsChecked = false;
            A4.IsChecked = false;
            txtAnswer.Text = txtAnswer1.Text;
            answer = "1";
            flag = 1;
        }

        private void A2_Checked(object sender, RoutedEventArgs e)
        {
            A1.IsChecked = false;
           
            A3.IsChecked = false;
            A4.IsChecked = false;

            txtAnswer.Text = txtAnswer2.Text;
            answer = "2";
            flag = 1;
        }

       
        public void ClearData()
        {
            A1.IsChecked = false;
            A2.IsChecked = false;
            A3.IsChecked = false;
            A4.IsChecked = false;
            flag = 0;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            txtAnswer.Clear();
            //txtAnswer1.Clear();
            //txtAnswer2.Clear();
           // txtAnswer3.Clear();
          //  txtAnswer4.Clear();


        }

        private void A3_Checked(object sender, RoutedEventArgs e)
        {
            A1.IsChecked = false;
            A2.IsChecked = false;
          
            A4.IsChecked = false;
            txtAnswer.Text = txtAnswer3.Text;
            answer = "3";
            flag = 1;
        }

        private void A4_Checked(object sender, RoutedEventArgs e)
        {
            A1.IsChecked = false;
            A2.IsChecked = false;
            A3.IsChecked = false;
          
            txtAnswer.Text = txtAnswer4.Text;
            answer = "4";
            flag = 1;
        }

     

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

      

       

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ShowCurrentColumn();
            txtStudentIdLeft.Text = txtQnum.Text;
            flag = 0;
            // Add_Timer();


        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            add_exam();
      /* for (int i = 1; i <= int.Parse(txtNoq.Text); i++)
                {
                // Your code here
                MessageBox.Show(dataArray[i].q.ToString());
                MessageBox.Show(dataArray[i].answer.ToString());
                MessageBox.Show(dataArray[i].goodAnswer.ToString());
                if(dataArray[i].answer== dataArray[i].goodAnswer)
                {
                    MessageBox.Show("ok");
                }
                else 
                {
                    MessageBox.Show("false");
                }


            }*/
        }

        public void add_exam()
        {
            int score=0;
            string seid = "";
            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True"))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Student_Exams(StudentExamId ,Student_Id, Student_Name, Exam_Id) VALUES (@StudentExamId,@StudentId,@StudentName,@ExamId)", con))
                    {
                        seid = (txtPersonalId.Text + txtExamId.Text);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@StudentExamId", int.Parse(seid));
                        cmd.Parameters.AddWithValue("@StudentId", int.Parse(txtPersonalId.Text));
                        cmd.Parameters.AddWithValue("@StudentName", txtStudentName.Text);
                        cmd.Parameters.AddWithValue("@ExamId", int.Parse(txtExamId.Text));
                        
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("add question succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    
                
                        for (int i = 1; i <= int.Parse(txtNoq.Text); i++)
                        {
                            // Your code here
                            // MessageBox.Show(dataArray[i].q.ToString());
                            // MessageBox.Show(dataArray[i].answer.ToString());
                            //  MessageBox.Show(dataArray[i].goodAnswer.ToString());
                            if (dataArray[i].answer == dataArray[i].goodAnswer)
                            {
                                score = 10;
                            }
                            else
                            {
                                score = 0;
                            }
                            using (SqlCommand cmd2 = new SqlCommand("INSERT INTO Tbl_Exam_Student_Answers(StudentExamId,QuestionId, Question,Answer,GoodAnswer,Answer_point) VALUES (@StudentExamId,@QuestionId,@Question,@Answer,@GoodAnswer,@Answer_point)", con))
                        {
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Parameters.AddWithValue("@StudentExamId", int.Parse(seid));
                            cmd2.Parameters.AddWithValue("@QuestionId", i);
                            cmd2.Parameters.AddWithValue("@Question", dataArray[i].question.ToString());
                            cmd2.Parameters.AddWithValue("@Answer", dataArray[i].answer.ToString());
                            cmd2.Parameters.AddWithValue("@GoodAnswer", dataArray[i].goodAnswer.ToString());
                            cmd2.Parameters.AddWithValue("@Answer_point", score);


                            cmd2.ExecuteNonQuery();
                            //MessageBox.Show("add question succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        public void Add_Timer()
        {
          // DispatcherTimer timer = new DispatcherTimer();
        //   timer.Interval = TimeSpan.FromSeconds(1);

           // timer.Tick += timer_Tick;
           // timer.Start();


        }
       
        void timer_Tick(object sender, EventArgs e)

        {

            lblTime.Content = DateTime.Now.ToLongTimeString();
           
        }


       
    }
}
