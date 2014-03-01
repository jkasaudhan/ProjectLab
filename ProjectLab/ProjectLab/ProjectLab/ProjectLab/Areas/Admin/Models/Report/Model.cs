using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace ProjectLab.Areas.Admin.Models.Report
{
    public class Model
    {
        

        public DataSet GetEmployeeDetails() 
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            DataSet ds = null;
            try
            {
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "select Email,Username from tbl_member";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            sqlConn.Connection.Open();
            
            SqlDataAdapter adapter;
                    
            ds = new DataSet();
            adapter = new SqlDataAdapter(sqlConn.Command);
                ///////////////////////////
            adapter.Fill(ds);
          //  ds.Tables[0].Merge(dt);
                /////////////////////////
           // adapter.Fill(ds, "Users");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlConn.Connection.Dispose();
                if (sqlConn.Connection.State != ConnectionState.Closed)
                    sqlConn.Connection.Close();
            }
            return ds;
        }

    }
}