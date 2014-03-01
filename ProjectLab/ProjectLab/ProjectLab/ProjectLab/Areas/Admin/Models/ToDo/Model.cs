using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;
using ProjectLab.Areas.Admin.Models.member;

namespace ProjectLab.Areas.Admin.Models.ToDo
{
    public class Model
    {
        [Required]
        [DisplayName("ToDo Title")]
        public string MilestoneName { get; set; }

        [Required]
        [DisplayName("ToDo Description ")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Deadline")]
        public int Deadline { get; set; }

        [Required]
        [DisplayName("Project Members")]
        public String ProjectMembers { get; set; }
        [Required]
        [DisplayName("Status")]
        public String Status { get; set; }

        [Required]
        [DisplayName("AssignedTo")]
        public int AssignedTo { get; set; }




        public void CreateToDo(int ids, string title, string desc, int assign,string stat,DateTime dt)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_ToDo(ProjectID,MemberID,ToDoTitle,ToDoDescription,AssignedTo,Deadline,Status,CreatedAt,UpdatedAt,CompletedBy)  values(@Projid,@memid,@title,@descrip,@assignto,@deadline,@status,@createdat,@updatedat,@comby)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("projid", ids);
                sqlConn.Command.Parameters.AddWithValue("@memid", 2);
                sqlConn.Command.Parameters.AddWithValue("@title", title);
                sqlConn.Command.Parameters.AddWithValue("@descrip", desc);
                sqlConn.Command.Parameters.AddWithValue("@assignto", assign);
                sqlConn.Command.Parameters.AddWithValue("@status", stat);
                sqlConn.Command.Parameters.AddWithValue("@deadline", dt);
                sqlConn.Command.Parameters.AddWithValue("@createdat", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@updatedat", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@comby", DateTime.UtcNow);

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
        public ToDo StatusNameByStatusId(int sid)
        {
            ToDo data = new ToDo();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select StatusID,Name from tbl_status where StatusID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", sid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                      //  data.StatusID = Int32.Parse(sqlConn.Reader["StatusID"].ToString());
                        data.Name = sqlConn.Reader["Name"].ToString();


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

            return data;
        }

       



        public List<ToDo> GetStatusName()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            ToDo mile = new ToDo();
            var toList = new List<ToDo>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select StatusID,Name from tbl_status";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                // sqlConn.Command.Parameters.AddWithValue("@id", sid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        toList.Add(new Admin.Models.ToDo.ToDo
                        {

                            StatusID = Int32.Parse(sqlConn.Reader["StatusID"].ToString()),
                            Name = sqlConn.Reader["Name"].ToString(),
                           
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

            return toList;
        }

       

        public void DeleteSelectedToDo(int tid)
        {

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_todo where ToDoID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", tid);
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
        public ToDo GetData(int tID)
        {
            ToDo to = new ToDo();

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_todo where ToDoID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", tID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        to.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        to.ToDoID = Int32.Parse(sqlConn.Reader["ToDoID"].ToString());
                        to.ToDoTitle = sqlConn.Reader["ToDoTitle"].ToString();
                        to.ToDoDescription = sqlConn.Reader["ToDoDescription"].ToString();
                        to.AssignedTo = Int32.Parse(sqlConn.Reader["AssignedTo"].ToString());
                        to.Status = sqlConn.Reader["Status"].ToString();
                        to.CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());
                        to.Deadline = DateTime.Parse(sqlConn.Reader["Deadline"].ToString());

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

            return to;
        }
        public void Edit(int tid, string title, string Description,int assign, string status,DateTime dt)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "update tbl_todo set ToDoTitle=@title,ToDoDescription=@Desc,AssignedTo=@assign,Deadline=@dead,Status=@status where ToDoID=@todoid";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);

            sqlConn.Command.Parameters.AddWithValue("@todoid", tid);
            sqlConn.Command.Parameters.AddWithValue("@dead", dt);
            sqlConn.Command.Parameters.AddWithValue("@title", title);
            sqlConn.Command.Parameters.AddWithValue("@Desc", Description);
           sqlConn.Command.Parameters.AddWithValue("@assign", assign);
            sqlConn.Command.Parameters.AddWithValue("@status", status);
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

        public List<ToDo> GetAllToDo(int pid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            ToDo todo = new ToDo();
            var todolist = new List<ToDo>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_ToDo where ProjectID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", pid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        todolist.Add(new Admin.Models.ToDo.ToDo
                        {
                            ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString()),
                            ToDoID = Int32.Parse(sqlConn.Reader["ToDoID"].ToString()),
                            ToDoTitle = sqlConn.Reader["ToDoTitle"].ToString(),
                            ToDoDescription = sqlConn.Reader["ToDoDescription"].ToString(),
                            AssignedTo = Int32.Parse(sqlConn.Reader["AssignedTo"].ToString()),
                            Status=sqlConn.Reader["Status"].ToString(),
                            Deadline = DateTime.Parse(sqlConn.Reader["Deadline"].ToString()),
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

            return todolist;
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


        public List<ToDo> GetOnlyToDo(int tid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            ToDo tdo = new ToDo();
            var doList = new List<ToDo>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_ToDo where ToDoID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", tid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        doList.Add(new Admin.Models.ToDo.ToDo
                        {

                            ToDoID = Int32.Parse(sqlConn.Reader["ToDoID"].ToString()),
                            ToDoTitle = sqlConn.Reader["ToDoTitle"].ToString(),
                            ToDoDescription = sqlConn.Reader["ToDoDescription"].ToString(),
                            AssignedTo = Int32.Parse(sqlConn.Reader["AssignedTo"].ToString()),
                            CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
                            Status=sqlConn.Reader["Status"].ToString(),
                            Deadline=DateTime.Parse(sqlConn.Reader["Deadline"].ToString()),
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

            return doList;
        }
    }
    public class ToDo
    {
        public int ToDoID { get; set; }
        public string ToDoTitle { get; set; }
        public string ToDoDescription { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectID { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; }
        public int AssignedTo { get; set; }
        public string ProjectTitle { get; set; }
        public int ProjectDescription { get; set; }
        public int StatusID { get; set; }
        public string Name { get; set; }
        public string ProjectMembers { get; set; }

    }
}