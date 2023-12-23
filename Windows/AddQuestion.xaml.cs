using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;
using Microsoft.Identity.Client;


namespace ExamsSystem.Windows
{
    /// <summary>
    /// Interaction logic for AddQuestion.xaml
    /// </summary>
    public partial class AddQuestion : Window
    {
        public AddQuestion()
        {
            InitializeComponent();
            LoadExams();
        }
        public void LoadGrid()
        {
            if (txt_Exam.Text != "")
            {
               
                string examName = txt_Exam.Text;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tbl_Questions WHERE Exam_Name_Id = @ExamName", con);
                cmd.Parameters.AddWithValue("@ExamName", examName);
                DataTable dt = new DataTable();
                con.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                DataTable dataTable = new DataTable();
                QDataGrid.ItemsSource = dt.DefaultView;
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


        public string c1, c2;
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");
        public void Cleardata()
        {
            txtId.Clear();
            txtQuestion.Clear();
            txtUrl.Clear();
            txtAnswer1.Clear();
            txtAnswer2.Clear();
            txtAnswer3.Clear();
            txtAnswer4.Clear();
            txtGoodAnswer.Clear();
            txtIsRandom.IsChecked = false;
            txtIsRandomQuestion.IsChecked = false;
            txt_Exam.Clear();
        }
        public bool IsValid()
        {
            if (txtQuestion.Text == string.Empty)
            {
                MessageBox.Show("Question is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtAnswer1.Text == string.Empty)
            {
                MessageBox.Show("Answer1 is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtAnswer2.Text == string.Empty)
            {
                MessageBox.Show("Answer2 is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtAnswer3.Text == string.Empty)
            {
                MessageBox.Show("Answer3 is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtAnswer4.Text == string.Empty)
            {
                MessageBox.Show("Answer4 is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtGoodAnswer.Text == string.Empty)
            {
                MessageBox.Show("GoodAnswer is requierd", "failed", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    SqlCommand cmd = new SqlCommand("INSERT INTO Tbl_Questions VALUES(@Question,@Pic_Url,@Answer1,@Answer2,@Answer3,@Answer4,@Answer,@Is_Random,@Is_Random_Question,@Exam_Name_Id)", con);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Question", txtQuestion.Text);
                  //check if there is pic url
                    if(txtUrl.Text=="")
                    {
                        cmd.Parameters.AddWithValue("@Pic_Url","");
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Pic_Url", txtUrl.Text);
                    }
                    cmd.Parameters.AddWithValue("@Answer1", txtAnswer1.Text);
                    cmd.Parameters.AddWithValue("@Answer2", txtAnswer2.Text);
                    cmd.Parameters.AddWithValue("@Answer3", txtAnswer3.Text);
                    cmd.Parameters.AddWithValue("@Answer4", txtAnswer4.Text);
                    cmd.Parameters.AddWithValue("@Answer", txtGoodAnswer.Text);
                    cmd.Parameters.AddWithValue("@Is_Random", c1);
                    cmd.Parameters.AddWithValue("@Is_Random_Question", c2);
                    cmd.Parameters.AddWithValue("@Exam_Name_Id", txt_Exam.Text);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("add question succsessful", "saved", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadGrid();
                    Cleardata();
                }
            }
            catch (SqlException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }
        //exit from questoin form
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       

    
       
        //select data from data grid to the form data
        private void QDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // show data from data grid to form ());
            if (QDataGrid.SelectedItem != null)

            {
                btnAdd.IsEnabled = false;
                DataRowView rowView = (DataRowView)QDataGrid.SelectedItem;
                txtId.Text = Convert.ToInt32(rowView[0]).ToString();
                txtQuestion.Text = Convert.ToString(rowView[1]);
                txtUrl.Text = Convert.ToString(rowView[2]) ?? "";
                txtAnswer1.Text = Convert.ToString(rowView[3]);
                txtAnswer2.Text = Convert.ToString(rowView[4]);
                txtAnswer3.Text = Convert.ToString(rowView[5]);
                txtAnswer4.Text = Convert.ToString(rowView[6]);
                txtGoodAnswer.Text = Convert.ToString(rowView[7]);
                txtIsRandom.IsChecked = Convert.ToBoolean(rowView[8]);
                txtIsRandomQuestion.IsChecked = Convert.ToBoolean(rowView[9]);
            }
           
        }

        //delete question by id number
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tbl_Questions WHERE Question_Id=" + txtId.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("record deleted", "delete",MessageBoxButton.OK,MessageBoxImage.Information);
                con.Close();
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
        //edit question by id number
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Tbl_Questions SET Question='" +txtQuestion.Text + "',Pic_URL= '" + txtUrl.Text + "',Answer1='" + txtAnswer1.Text + "',Answer2='" + txtAnswer2.Text + "',Answer3='" + txtAnswer3.Text + "',Answer4='" + txtAnswer4.Text + "',Answer='" + txtGoodAnswer.Text + "',Is_Random='" + c1  + "',Is_Random_Questions='" + c2 + "' WHERE Question_Id=" + txtId.Text + " ", con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("record has been updated", "UPDATE", MessageBoxButton.OK, MessageBoxImage.Information);
                con.Close();
                LoadGrid();
                Cleardata();
               
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

       

        private void cmb_Exams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = cmb_Exams.SelectedItem as ComboBoxItem;
            if (selectedItem != null)
            {
               int id = (int)selectedItem.Tag;
               txt_Exam.Text = id.ToString();
                
                LoadGrid();
                btnAdd.IsEnabled = true;
               
            }
        }

        private void btnClear_Data_Click(object sender, RoutedEventArgs e)
        {
            Cleardata();
            btnAdd.IsEnabled = true;
        }

        private void txtIsRandom_Checked(object sender, RoutedEventArgs e)
        {
            c1 = "1";
        }

        private void txtIsRandom_Unchecked(object sender, RoutedEventArgs e)
        {
            c1 = "0";
        }

        private void txtIsRandomQuestion_Unchecked(object sender, RoutedEventArgs e)
        {
            c2 = "0";
        }

        private void btn_AddUrl_Click(object sender, RoutedEventArgs e)
        {
            //browse image url
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "SelectImage(*.jpg;*.png;*.gif)| *.jpg; *.png; *.gif";
            bool? result = opf.ShowDialog();
            if (result.HasValue && result.Value)
            {
                txtUrl.Text = opf.FileName;
                MessageBox.Show(opf.FileName);
            }
        }

        private void txtIsRandomQuestion_Checked(object sender, RoutedEventArgs e)
        {
            c2 = "1";
        }
    }
}
