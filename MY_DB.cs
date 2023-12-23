using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Markup;


namespace ExamsSystem
{
    class MY_DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=owner\acrsapp20001;Initial Catalog=EXAMS;Integrated Security=True");

        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }
        //create functin to open the connection
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed) 
            { 
            con.Open(); 
            }
        }
        //create functin to close the connection
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }


    }

}
