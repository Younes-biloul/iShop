using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;

namespace HandyControlProject3.Myclass
{
    public class Connection_Query
    {


        string ConnectionString = "";
        SqlConnection con;

        public void OpenConection()
        {
            string path = System.IO.Path.GetFullPath("DB_SuperMarket.mdf").Replace(@"\bin\Debug\net5.0-windows", "");
            ConnectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString.Replace("filenamemdf", path);
            con = new SqlConnection(ConnectionString);
            con.Open();
        }


        public void CloseConnection()
        {
            con.Close();
        }


        public string ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            string s=Convert.ToString(cmd.ExecuteNonQuery());
            return s;
        }
        public int ExecuteScalar(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            int i=Convert.ToInt32(cmd.ExecuteScalar());
            return i;
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public DataTable ShowDataInGridView(string Query_)
        {
            SqlDataAdapter dr = new SqlDataAdapter(Query_, con);
            DataTable T = new DataTable();
            dr.Fill(T);
            
            return T;
        }
    }
}