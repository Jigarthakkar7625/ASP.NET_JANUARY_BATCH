using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MyFIrstAspnetTablesd.DAL
{
    public class EmployeeDAL
    {
        private readonly string conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString; //Dariyo

        // connected archit >> EF
        // disconnected

        public DataTable GetData()
        {
            //SqlConnection con = new SqlConnection(conn);

            using (SqlConnection con = new SqlConnection(conn))
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from Customers; Select * from Employees;", conn);

                DataTable dataTable = new DataTable(); // Balti >> Always one table
                da.Fill(dataTable);

                //DataSet ds = new DataSet(); // Balti >> Multiple table return thase
                //da.Fill(ds);

                return dataTable;
            }


        }


        public DataTable GetDataUsingSP()
        {
            //SqlConnection con = new SqlConnection(conn);

            using (SqlConnection con = new SqlConnection(conn))
            {
                //SqlCommand cmd = new SqlCommand("sp_MyFirstSPGet", con)

                using (SqlCommand cmd = new SqlCommand("sp_MyFirstSPGet", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", "NAMAE");
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable(); // Balti >> Always one table
                    da.Fill(dataTable);

                    //DataSet ds = new DataSet(); // Balti >> Multiple table return thase
                    //da.Fill(ds);
                    return dataTable;

                }

            }


        }


        public void SaveData()
        {
            //SqlConnection con = new SqlConnection(conn);

            using (SqlConnection con = new SqlConnection(conn))
            {
                string insert = "Insert into Customers VALUES(@id, @name, @city,@newcolumn)";
                SqlCommand sqlCommand = new SqlCommand(insert, con);
                sqlCommand.Parameters.AddWithValue("@id", 7);
                sqlCommand.Parameters.AddWithValue("@name", "NAMAE");
                sqlCommand.Parameters.AddWithValue("@city", "CCIITTY");
                sqlCommand.Parameters.AddWithValue("@newcolumn", "jkdfsgsd");
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }


        }
    }

}