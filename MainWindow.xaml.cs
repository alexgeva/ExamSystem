
using ExamsSystem.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ExamsSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
        }
        //check if login type is student or lecture 
        public bool flag,flagSt,flagLe ;
        public String tempname, type, id, idname,examid,examname;

        public MenuItem TxtStudentMenuItem { get; set; }

        public void MenuEnable()
        {

           //txtStudent.IsEnabled = true;
           txtExams.IsEnabled = true;
        }
        public void Menudisable()
        {
            //txtStudent.IsEnabled = false;
            txtExams.IsEnabled = false;
        }
      
        public void ButtonAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addstudent = new AddStudent();
            addstudent.ShowDialog();
        }
        public void ButtonOQ_Click(object sender, RoutedEventArgs e) 
        {
            AddQuestion addques = new AddQuestion();
            addques.ShowDialog();
        }

        public void ButtonAddExam_Click(object sender, RoutedEventArgs e)
        {
            AddExam addexam = new AddExam();
            addexam.ShowDialog();
        }
        
        public void ButtonAddExamQuestion_Click(object sender, RoutedEventArgs e)
        {
            AddExamQuestions addexam = new AddExamQuestions();
            addexam.ShowDialog();
        }

        private void ButtonExamStatistick_Click(object sender, RoutedEventArgs e)
        {
            ExamStatistics exams = new ExamStatistics();
            exams.ShowDialog();

        }

        private void ButtonStudentStatistick_Click(object sender, RoutedEventArgs e)
        {
            StudentStatistics students = new StudentStatistics();
            students.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            EditStudentLogin editStudentLogin = new EditStudentLogin();
            editStudentLogin.ShowDialog();
        }

        public void ButtonAddStudentExam_Click(object sender, RoutedEventArgs e)
        {
            AddStudentExam addstudentexam = new AddStudentExam();
            addstudentexam.ShowDialog();
        }
        //close the windows
        private void txtExit_Click(object sender, RoutedEventArgs e)
        {
            // Close the entire application
            Application.Current.Shutdown();
        }
        //register
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
           Register register = new Register();
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            lbl3.Visibility = Visibility.Hidden;
            lbl4.Visibility = Visibility.Hidden;
            lbl5.Visibility = Visibility.Hidden;
            register.ShowDialog();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (type == "1")
            {
                MessageBox.Show("1");
            }
            else if (type == "2")
            {
                MessageBox.Show("2");
            }

        }
        //login
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            lbl1.Visibility = Visibility.Hidden;
            lbl2.Visibility = Visibility.Hidden;
            lbl3.Visibility = Visibility.Hidden;
            lbl4.Visibility = Visibility.Hidden;
            lbl5.Visibility = Visibility.Hidden;



            login.ShowDialog();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            MenuEnable();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Menudisable();
        }
      
        
    }
}
