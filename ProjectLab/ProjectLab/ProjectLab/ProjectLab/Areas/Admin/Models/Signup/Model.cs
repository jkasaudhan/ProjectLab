using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using ProjectLab.Helpers;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProjectLab.Areas.Admin.Models.Signup
{
    public class Model
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("RoleID")]
        public string RoleID { get; set; }

        /// <summary>
        /// //////////////////////creating account for the member ///////////////////////

        public void Createaccount( string fname, string lname,string Email, string username, string password, int roleid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_member(Email,UserName,Password,RoleID) output Inserted.MemberID values(@Email,@Username,@Password)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@Email", Email);
                sqlConn.Command.Parameters.AddWithValue("@Username", username);
                sqlConn.Command.Parameters.AddWithValue("@Password", password);
                sqlConn.Command.Parameters.AddWithValue("@RoleId", roleid);
                    
                sqlConn.Connection.Open();
                var id = sqlConn.Command.ExecuteScalar();
                sqlConn.Query = "insert into tbl_memberinfo (MemberID,FirstName,LastName)  values (@id,@fname,@lname)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
                sqlConn.Command.Parameters.AddWithValue("@fname", fname);
                sqlConn.Command.Parameters.AddWithValue("@lname", lname);
                sqlConn.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Connection.Close();
                sqlConn.Connection.Dispose();
            }
        }

    }
    public class Member
    {
        public int MemberID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleID { get; set; }

    }
}