using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace ProjectLab.Areas.Admin.Models.Logon
{
    public class Model
    {

        //public  bool ValidateUser(string username, string password) 
        // {
        //     bool userExit = false;
        //     SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
        //     try
        //     {
        //         sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
        //         sqlConn.Query = "select 1 from tbl_member as tbm where tbm.username=@username and tbm.password=@password";
        //         sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
        //         sqlConn.Command.Parameters.AddWithValue("@username", username);
        //         sqlConn.Command.Parameters.AddWithValue("@password", password);
        //         sqlConn.Connection.Open();

        //         using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
        //         {
        //             while (sqlConn.Reader.Read())
        //             {
        //                 userExit = true;

        //             }
        //         }



        //     }
        //     catch (Exception ex)
        //     {

        //         throw ex;
        //     }
        //     finally
        //     {
        //         if (sqlConn.Reader != null)
        //             sqlConn.Reader.Close();
        //         sqlConn.Connection.Close();
        //         sqlConn.Connection.Dispose();

        //     }
        //     return userExit;
        // }

        public string GetEncryptedPassword(string username)
        {
            ProjectLab.Areas.Admin.Models.member.Member mem = new ProjectLab.Areas.Admin.Models.member.Member();
            string encPassword = "";
            // var encPassword = "";
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select MemberID,Password from tbl_member as tbm where tbm.username=@username";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@username", username);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    if (sqlConn.Reader.Read())
                    {
                        encPassword = sqlConn.Reader["Password"].ToString();
                        // mem.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                    }
                }



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (sqlConn.Reader != null)
                    sqlConn.Reader.Close();
                sqlConn.Connection.Close();
                sqlConn.Connection.Dispose();

            }
            return encPassword;
        }
    }
}
    
    

