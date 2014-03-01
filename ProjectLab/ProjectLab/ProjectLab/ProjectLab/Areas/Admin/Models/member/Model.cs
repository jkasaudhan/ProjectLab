using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using ProjectLab.Helpers;
using System.Web.UI.WebControls;
using System.Web.Security;

//using Telerik.Web.UI;

namespace ProjectLab.Areas.Admin.Models.member
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
        [DisplayName("Title")]
        public string Title { get; set; }


        [Required]
        [DisplayName("RoleID")]
        public int RoleID { get; set; }



        public void Createmember(string fname, string lname, string Email, string username, string password,int roleid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_member(Email,UserName,Password,RoleID) output Inserted.MemberID values(@Email,@Username,@Password,@rid)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@Email", Email);
                sqlConn.Command.Parameters.AddWithValue("@Username", username);
                sqlConn.Command.Parameters.AddWithValue("@Password", password);
                sqlConn.Command.Parameters.AddWithValue("@rid", roleid);
                sqlConn.Connection.Open();
                var id = sqlConn.Command.ExecuteScalar();
                sqlConn.Query = "insert into tbl_memberinfo (MemberID,FirstName,LastName)  values (@id,@fn,@ln)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
                sqlConn.Command.Parameters.AddWithValue("@fn", fname);
                sqlConn.Command.Parameters.AddWithValue("@ln", lname);
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
        ///////////////////////////////////////////////////////////////
        public void createimage(string ti)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_memberImage(Title) output Inserted.ImageID values(@Title)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@Title", ti);
                sqlConn.Connection.Open();
                var id = sqlConn.Command.ExecuteScalar();
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_memberinfo(ImageID) values (@id)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
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

       
        public bool CheckRole(int memid)
        {
            bool userExit = false;
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            int roleID = 0;
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                //  sqlConn.Query = "select m.MemberID,m.RoleID,r.RoleID,r.Name from tbl_memberinfo as m inner join tbl_role as r on m.RoleID=r.RoleID where m.MemberID=@memberid";
                sqlConn.Query = "select MemberID,RoleID from tbl_member where MemberID=@memid ";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@memid", memid);
              
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        //  userExit = true;
                        //ProjectLab.Areas.Admin.Models.member.Member mem = new ProjectLab.Areas.Admin.Models.member.Member();
                        roleID = Int32.Parse(sqlConn.Reader["RoleID"].ToString());

                    }

                }

                if (roleID == 1) //Admin
                {
                    return true;
                }
                else if (roleID == 2) //Project Manager
                {
                    return true;
                }
                else if (roleID == 3) //Member
                {
                    return true;
                }
                else if (roleID == 4) //EndUser
                {
                    return false;
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

            return userExit;
        }



        public Member GetMemberIDFromUsername(string username)
        {
            Member mem = new Member();
            // string encPassword = "";

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select MemberID from tbl_member as tbm where tbm.username=@username";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@username", username);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    if (sqlConn.Reader.Read())
                    {

                        mem.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
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
            return mem;

        }

        public Member GetMemberNameFromMemberId(int mid)
        {
            Member mem = new Member();
            // string encPassword = "";

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select MemberID, FirstName,Lastname from tbl_memberinfo where MemberID=@mid";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@mid", mid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    if (sqlConn.Reader.Read())
                    {

                        mem.FirstName = sqlConn.Reader["FirstName"].ToString();
                        mem.LastName = sqlConn.Reader["LastName"].ToString();
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
            return mem;

        }

        /// /////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        /// 
        //   public class ImageResult : FileStreamResult 
        //         { 
        //             public ImageResult(Image input):this(input,input.Width,input.Height) { } 
        //             public ImageResult(Image input, int width,int height) : 
        //             base(GetMemoryStream(input,width,height,ImageFormat.Png), "image/png") 
        //{ } 

        // static MemoryStream GetMemoryStream(Image input,int width, 
        //                     int height,ImageFormat fmt) 
        // { 
        //    // maintain aspect ratio 
        //    if (input.Width > input.Height) 
        //       height = input.Height * width / input.Width; 
        //    else 
        //       width = input.Width * height / input.Height; 

        //    var bmp = new Bitmap(input, width, height); 
        //    var ms = new MemoryStream();
        //    bmp.Save(ms, ImageFormat.Png); 
        //    ms.Position = 0; 
        //    return ms; 
        //  } 
        //} 
        //     /// 
        //     /// 
        /// 
        /// 
        /// /////////////////
        /// <returns></returns>

        public List<Member> GetAllmembers()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Member mem = new Member();
            var memberList = new List<Member>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = " select m.MemberID,m.Email,m.UserName,mi.FirstName,mi.LastName from tbl_member as m join tbl_memberinfo as mi on m.MemberID = mi.MemberID ";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();
                //var id = Convert.ToInt32(sqlConn.Command.ExecuteScalar());
                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        memberList.Add(new Admin.Models.member.Member
                        {
                            MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString()),
                            Email = sqlConn.Reader["Email"].ToString(),
                            Username = sqlConn.Reader["Username"].ToString(),
                            //   Password=sqlConn.Reader["Password"].ToString(),
                            // string Password = GenerateRandomString(Password).ToString();
                            FirstName = sqlConn.Reader["FirstName"].ToString(),
                            LastName = sqlConn.Reader["LastName"].ToString()
                        });
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

            return memberList;
        }


        /// <summary>
        ///   /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 

        public List<Member> getonlymembers()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Member mem = new Member();
            var onlymemberlist = new List<Member>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = " select MemberID,FirstName,LastName from tbl_memberinfo";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        onlymemberlist.Add(new Admin.Models.member.Member
                        {
                            MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString()),

                            FirstName = sqlConn.Reader["FirstName"].ToString(),
                            LastName = sqlConn.Reader["LastName"].ToString()
                        });
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

            return onlymemberlist;
        }

      


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Member> getNameByroleid()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Member mem = new Member();
            var onlyRoleName = new List<Member>();
          try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = " select RoleID,Name from tbl_role";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        onlyRoleName.Add(new Admin.Models.member.Member
                        {
                            RoleID = Int32.Parse(sqlConn.Reader["RoleID"].ToString()),

                            Name = sqlConn.Reader["Name"].ToString(),
                            //.RoleILastName = sqlConn.Reader["LastName"].ToString()
                        });
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

            return onlyRoleName;
        }
        public void Delete(int ID)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_member where MemberID=@MemberID; delete tbl_memberinfo where MemberID=@MemberID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@MemberID", ID);
                sqlConn.Connection.Open();
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



        public void Edit(int memID, string fname, string lname, string Email, string Username, string password)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "update tbl_member set Email=@Email,Username=@Username where MemberID=@MemberID; update tbl_memberinfo set FirstName=@FirstName,LastName=@LastName where MemberID=@MemberID";
            //  sqlConn.Query = " update tbl_member as  m join tbl_memberinfo as mi on set m.Email=@email,m.UserName=@username,mi.FirstName=@Fnam,mi.LastName=@lname from tbl_member as m.MemberID = mi.MemberID ";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            sqlConn.Command.Parameters.AddWithValue("@Username", Username);
             sqlConn.Command.Parameters.AddWithValue("@Password", password);
            sqlConn.Command.Parameters.AddWithValue("@Email", Email);
            sqlConn.Command.Parameters.AddWithValue("@FirstName", fname);
            sqlConn.Command.Parameters.AddWithValue("@LastName", lname);
            sqlConn.Command.Parameters.AddWithValue("@MemberID", memID);

            try
            {
                sqlConn.Connection.Open();
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

        public Member Details(int ID)
        {
            Member proj = new Member();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                // sqlConn.Query = "select Email,UserName,Password,FirstName,LastName from tbl_member,tbl_memberinfo where tbl_member.MemberID=tbl_memberinfo.MemberID";
                sqlConn.Query = "select m.MemberID,m.Email,m.UserName,m.Password,mi.FirstName,mi.LastName from tbl_member as m join tbl_memberinfo as mi on m.MemberID = mi.MemberID where m.MemberID=@memid and mi.MemberID=@memid";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@memid", ID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                        proj.Email = sqlConn.Reader["Email"].ToString();
                        proj.Username = sqlConn.Reader["UserName"].ToString();
                        proj.Password = sqlConn.Reader["Password"].ToString();

                        proj.FirstName = sqlConn.Reader["FirstName"].ToString();
                        proj.LastName = sqlConn.Reader["LastName"].ToString();
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

            return proj;
        }


        public Member GetData(int ID)
        {
            Member proj = new Member();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                // sqlConn.Query = "select Email,UserName,Password,FirstName,LastName from tbl_member,tbl_memberinfo where tbl_member.MemberID=tbl_memberinfo.MemberID";
                sqlConn.Query = "select m.MemberID,m.Email,m.UserName,m.Password,mi.FirstName,mi.LastName from tbl_member as m join tbl_memberinfo as mi on m.MemberID = mi.MemberID where m.MemberID=@MemberID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@MemberID", ID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                        proj.Email = sqlConn.Reader["Email"].ToString();
                        proj.Username = sqlConn.Reader["UserName"].ToString();
                        proj.Password = sqlConn.Reader["Password"].ToString();
                        proj.FirstName = sqlConn.Reader["FirstName"].ToString();
                        proj.LastName = sqlConn.Reader["LastName"].ToString();
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

            return proj;
        }

        public Member GetMemberByMemberID(int memID)
        {
            Member mem = new Member();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                // sqlConn.Query = "select Email,UserName,Password,FirstName,LastName from tbl_member,tbl_memberinfo where tbl_member.MemberID=tbl_memberinfo.MemberID";
                sqlConn.Query = "select m.MemberID,m.Email,m.UserName,m.Password,mi.FirstName,mi.LastName from tbl_member as m join tbl_memberinfo as mi on m.MemberID = mi.MemberID where m.MemberID=@MemberID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@MemberID", memID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        mem.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                        mem.Email = sqlConn.Reader["Email"].ToString();
                        mem.Username = sqlConn.Reader["UserName"].ToString();
                        mem.Password = sqlConn.Reader["Password"].ToString();
                        mem.FirstName = sqlConn.Reader["FirstName"].ToString();
                        mem.LastName = sqlConn.Reader["LastName"].ToString();
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

            return mem;
        }

       
        public Member GetRoleIDByMemberID(int memid)
        {
            Member mem = new Member();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                
                sqlConn.Query = "select RoleID,MemberID from tbl_member where MemberID=@MemberID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@MemberID", memid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        mem.RoleID = Int32.Parse(sqlConn.Reader["RoleID"].ToString());
                        
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

            return mem;
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
        public string Name { get; set;}
        public string ProjectMembers { get; set; }

    }
}