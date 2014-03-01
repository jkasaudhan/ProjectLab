using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;


namespace ProjectLab.Areas.Admin.Models.Project
{
    public class Model
    {


        [Required]
        [DisplayName("Project Title")]
        public string ProjectTitle { get; set; }

        [Required]
        [DisplayName("Project Description")]
        public string ProjectDescription { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Discussion Title")]
        public string DiscussionTitle { get; set; }

        [Required]
        [DisplayName(" Discussion Description")]
        public string DiscussionDescription { get; set; }

        [Required]
        [DisplayName("Comments")]
        public string Comment { get; set; }


        [Required]
        [DisplayName("CreatedAt")]
        public DateTime CreatedAt { get; set; }


        [Required]
        [DisplayName("Project Members")]
        public String ProjectMembers { get; set; }



        public void CreateProject(string projecTitle, string projecDescription, string fn, string ln, string members)
        {

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_Projects(CompanyID,ProjectTitle,CreatedBy,CreatedAt,UpdatedAt,Status,ProjectDescription,Members) output Inserted.ProjectID values(@companyID,@ProjectTitle,@CreatedBy,@CreatedAt,@updatedAt,@Status,@ProjectDescription,@ids)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@companyID", 2);
                sqlConn.Command.Parameters.AddWithValue("@ProjectTitle", projecTitle);
                sqlConn.Command.Parameters.AddWithValue("@CreatedBy", 2);
                sqlConn.Command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@Status", "Active");
                sqlConn.Command.Parameters.AddWithValue("@ProjectDescription", projecDescription);
                sqlConn.Command.Parameters.AddWithValue("@ids", members);
                // sqlConn.Command.Parameters.AddWithValue("@ids", files);
                sqlConn.Connection.Open();
                var id = sqlConn.Command.ExecuteScalar();
                sqlConn.Query = "insert into tbl_Project_File(ProjectID) values(@id)";
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
        /// <summary>
        /// /////////////////////////////////////////////////////////create discussion...
        public void CreateDiscussion(int id, string title, string desc,string mid)
        {

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_Discussion(DiscussionTitle,DiscussionDescription,ProjectID,CreatedBy,Status,CreatedAt,UpdatedAt,DiscussionType)output Inserted.DiscussionID values(@title,@desc,@id,@by,@status,@createdat,@updatedat,@disctype)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@title", title);
                sqlConn.Command.Parameters.AddWithValue("@desc", desc);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
                sqlConn.Command.Parameters.AddWithValue("@by", mid);
                sqlConn.Command.Parameters.AddWithValue("@createdat", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@Status", "Active");
                sqlConn.Command.Parameters.AddWithValue("@disctype", "software");
                sqlConn.Command.Parameters.AddWithValue("@updatedat", DateTime.UtcNow);
                sqlConn.Connection.Open();
                var ids = sqlConn.Command.ExecuteScalar();
                sqlConn.Query = "insert into tbl_DiscussionFile(DiscussionID) values(@id)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", ids);
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

        //////////////////////////////////////////////////////////////end here for creating discussion...
        public Project GetmembersByProjectID(int projectID)
        {
            Project proj = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID,Members from tbl_Projects where ProjectID=@projectID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@projectID", projectID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        proj.ProjectMembers = sqlConn.Reader["Members"].ToString();
                        // proj.ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString();

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

        public Project GetUsernameByMemberID(int memID)
        {
            Project proj = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select MemberID,UserName from tbl_member where MemberID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID",memID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                        proj.UserName = sqlConn.Reader["UserName"].ToString();
                        // proj.ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString();

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
        public List<Project> GetAllProjects()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project proj = new Project();
            var projectList = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select p.ProjectID,p.ProjectTitle,p.ProjectDescription,p.Members from tbl_Projects as p";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        projectList.Add(new Admin.Models.Project.Project
                        {
                            ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString()),
                            ProjectTitle = sqlConn.Reader["ProjectTitle"].ToString(),
                            ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString(),
                            ProjectMembers = sqlConn.Reader["Members"].ToString(),

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

            return projectList;
        }


        public void Delete(int ID)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_Projects where ProjectID=@ProjectID;delete tbl_Discussion where ProjectID=@ProjectID;delete tbl_milestones where ProjectID=@ProjectID ;delete tbl_todo where ProjectID=@ProjectID ";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ProjectID", ID);
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

        public void DelDiscussion(int DID)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_discussion where DiscussionID=@ID;delete tbl_Comment where DiscussionID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", DID);
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

        public void DelComment(int cID)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_Comment where CommentID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", cID);
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


        public Project GetDiscussionTitleByDiscussionID(int ID)
        {
            {
                Project proj = new Project();
                SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
                try
                {
                    sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                    sqlConn.Query = "select DiscussionTitle from tbl_discussion where DiscussionID=@disID";
                    sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                    sqlConn.Command.Parameters.AddWithValue("@disID", ID);
                    sqlConn.Connection.Open();

                    using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                    {
                        while (sqlConn.Reader.Read())
                        {

                            // proj.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                            proj.DiscussionTitle = sqlConn.Reader["DiscussionTitle"].ToString();

                          //  proj.CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());

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
        }

        public Project GetCommentIDByDiscussionID(int ID)
        {
            {
                Project proj = new Project();
                SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
                try
                {
                    sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                    sqlConn.Query = "select CommentID from tbl_Comment where DiscussionID=@disID";
                    sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                    sqlConn.Command.Parameters.AddWithValue("@disID", ID);
                    sqlConn.Connection.Open();

                    using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                    {
                        while (sqlConn.Reader.Read())
                        {

                            // proj.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                            proj.CommentID= Int32.Parse(sqlConn.Reader["CommentID"].ToString());

                            //  proj.CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());

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
        }

        public Project GetDiscussData(int ID)
        {
            Project proj = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_discussion where DiscussionID=@disID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@disID", ID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        proj.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                        proj.DiscussionTitle = sqlConn.Reader["DiscussionTitle"].ToString();
                        proj.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();
                        proj.CreatedBy = sqlConn.Reader["CreatedBy"].ToString();
                        proj.CreatedAt=DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());

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

        public Project GetData(int projectID)
        {
            Project proj = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_Projects where ProjectID=@projectID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@projectID", projectID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        proj.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        proj.ProjectTitle = sqlConn.Reader["ProjectTitle"].ToString();
                        proj.ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString();
                        proj.ProjectMembers = sqlConn.Reader["Members"].ToString();
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
        /// <summary>
        /// //////////////////////////
        /// 
        public Project Datadetails(int projectID)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID,ProjectTitle,ProjectDescription,Members,CreatedAt from tbl_Projects where ProjectID=@projectID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@projectID", projectID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        data.ProjectTitle = sqlConn.Reader["ProjectTitle"].ToString();
                        data.ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString();
                        data.ProjectMembers = sqlConn.Reader["Members"].ToString();
                        data.CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());

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
        public List<Project> getProjectmembersfromProjects()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project pro = new Project();
            var onlymemberlist = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = " select * from tbl_Projects";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        onlymemberlist.Add(new Admin.Models.Project.Project
                        {
                            MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString()),
                            ProjectMembers=sqlConn.Reader["Members"].ToString(),
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
        /////////////////////////////////start for the discussion list////////////////
        public List<Project> GetAllDiscussion(int pid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project Discuss = new Project();
            var discussList = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_discussion where ProjectID=@pid";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@pid", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        discussList.Add(new Admin.Models.Project.Project
                        {
                            ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString()),
                           // DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString()),
                            DiscussionTitle = sqlConn.Reader["DiscussionTitle"].ToString(),
                            DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString(),
                            CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
                            CreatedBy=sqlConn.Reader["CreatedBy"].ToString(),
                            
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

            return discussList;
        }
        public Project GetMemberIdByProjectId(int pid)
        {

            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select MemberID from tbl_members where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.MemberID = Int32.Parse(sqlConn.Reader["MemberID"].ToString());
                        //    data.Comments = sqlConn.Reader["Comment"].ToString();
                        //  data.CommentedBy = Int32.Parse(sqlConn.Reader["CommentedBy"].ToString());
                        //  data.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();

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
        public List<Project> GetOnlyDiscussionTitle(int id)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project Discuss = new Project();
            var discussList = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select DiscussionID,DiscussionTitle,CreatedAt from tbl_discussion where DiscussionID=@pid";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@pid", id);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        discussList.Add(new Admin.Models.Project.Project
                        {

                            DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString()),
                            DiscussionTitle = sqlConn.Reader["DiscussionTitle"].ToString(),
                            CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),

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

            return discussList;
        }

        public Project GetProjectByMilestonesID(int mileid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID from tbl_milestones where MilestonesID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", mileid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        //    data.Comments = sqlConn.Reader["Comment"].ToString();
                        //  data.CommentedBy = Int32.Parse(sqlConn.Reader["CommentedBy"].ToString());
                        //  data.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();

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

        public Project GetDiscussionIdByProjectId(int pid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select DiscussionID from tbl_Discussion where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        //data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        //    data.Comments = sqlConn.Reader["Comment"].ToString();
                          data.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                        //  data.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();

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

        public Project GetProjectByToDoID(int todoid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID from tbl_ToDo where ToDoID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", todoid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        //    data.Comments = sqlConn.Reader["Comment"].ToString();
                        //  data.CommentedBy = Int32.Parse(sqlConn.Reader["CommentedBy"].ToString());
                        //  data.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();

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

        public Project GetMembersByProjectID(int pid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select Members from tbl_Projects where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                       // data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        data.ProjectMembers = sqlConn.Reader["Members"].ToString();


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


        public Project GetToDoIdByProjectID(int pid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID,ToDoID from tbl_todo where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        // data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        data.ToDoID = Int32.Parse(sqlConn.Reader["ToDoID"].ToString());


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
        /// <summary>
        /// //////////////////////////////get only comments start here.....
        /// </summary>
        /// <param name="did"></param>
        /// <returns></returns>
        public List<Project> GetOnlyComments(int did)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project comm = new Project();
            var commlist = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select DiscussionID,Comment from tbl_Comment where DiscussionID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", did);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        commlist.Add(new Admin.Models.Project.Project
                        {

                            ProjectID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString()),
                            ProjectTitle = sqlConn.Reader["Comment"].ToString(),
                            CreatedAt=DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
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

            return commlist;
        }

        public List<Project> GetOnlyProjectTitle(int id)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project title = new Project();
            var titleList = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID,ProjectTitle,ProjectDescription,Members from tbl_Projects where ProjectID=@pid";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@pid", id);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        titleList.Add(new Admin.Models.Project.Project
                        {

                            ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString()),
                            ProjectTitle = sqlConn.Reader["ProjectTitle"].ToString(),
                            ProjectDescription = sqlConn.Reader["ProjectDescription"].ToString(),
                            ProjectMembers = sqlConn.Reader["Members"].ToString(),
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

            return titleList;
        }


        public List<Project> GetAllComments(int id)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Project komments = new Project();
            var CommentsList = new List<Project>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_Comment where DiscussionID=@did";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@did", id);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        CommentsList.Add(new Admin.Models.Project.Project
                        {
                           CommentID = Int32.Parse(sqlConn.Reader["CommentID"].ToString()),
                            DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString()),
                            Comments = sqlConn.Reader["Comment"].ToString(),
                            CreatedAt=DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
                            CommentedBy = sqlConn.Reader["CommentedBy"].ToString(),

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

            return CommentsList;
        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="projectID"></param>
        /// <param name="projecTitle"></param>
        /// <param name="projectDescription"></param>

        public void Edit(int projectID, string projecTitle, string projectDescription,string mem)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "update tbl_Projects set ProjectTitle=@projTitle,ProjectDescription=@projDesc,Members=@member where ProjectID=@projectID";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            //cmd.Parameters.AddWithValue("@CMSID", empid);
            sqlConn.Command.Parameters.AddWithValue("@projTitle", projecTitle);
             
            sqlConn.Command.Parameters.AddWithValue("@projDesc", projectDescription);
            sqlConn.Command.Parameters.AddWithValue("@projectID", projectID);
            sqlConn.Command.Parameters.AddWithValue("@member", mem);

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
        public void Details(int projectid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "select ProjectID from tbl_Projects where ProjectID=@projectID";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            //   sqlConn.Command.Parameters.AddWithValue("@projTitle", projecTitle);

            // sqlConn.Command.Parameters.AddWithValue("@projDesc", projectDescription);
            sqlConn.Command.Parameters.AddWithValue("@projectID", projectid);

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

        //////////////////////////////////////////for discussion ////////////////////////////

        public Project Discussion(int pid)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select DiscussionID,DiscussionTitle,DiscussionDescription from tbl_discussion where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                        data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        data.DiscussionTitle = sqlConn.Reader["DiscussionTitle"].ToString();
                        data.DiscussionDescription = sqlConn.Reader["DiscussionDescription"].ToString();

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


        //////////////////////////////////// end discussion///////////////////////////////////

        ///////////////start createcomments///////////////
        public Project GetMemberIDByDiscussionID(int did)
        {
            {
                Project data = new Project();
                SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
                try
                {
                    sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                    sqlConn.Query = "select MemberID,DiscussionID from tbl_discussion where DiscussionID=@ID";
                    sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                    sqlConn.Command.Parameters.AddWithValue("@ID", did);
                    sqlConn.Connection.Open();

                    using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                    {
                        while (sqlConn.Reader.Read())
                        {
                            data.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                            data.Comments = sqlConn.Reader["Comment"].ToString();


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

        }
        public void CreateComments(int id, string comments,string name)
        {

            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_Comment(DiscussionID,Comment,CommentedBy,CreatedAt,Status,Commented_On_Discussion) values(@ids,@comm,@C_by,@createdat,@status,@commdisc)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ids", id);
                sqlConn.Command.Parameters.AddWithValue("@comm", comments);
                sqlConn.Command.Parameters.AddWithValue("@c_by", name);
                sqlConn.Command.Parameters.AddWithValue("@createdat", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@status", "Active");
                sqlConn.Command.Parameters.AddWithValue("@commdisc", "1");
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

        public Project Comments(int did)
        {
            Project data = new Project();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select DiscussionID,CommentedBy,Comment from tbl_Comment where DiscussionID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", did);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.DiscussionID = Int32.Parse(sqlConn.Reader["DiscussionID"].ToString());
                        data.Comments = sqlConn.Reader["Comment"].ToString();
                        data.CommentedBy = sqlConn.Reader["CommentedBy"].ToString();

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

    }

    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       // public string members { get; set; }
        public int DiscussionID { get; set; }
        public string DiscussionTitle { get; set; }
        public string DiscussionDescription { get; set; }
        public string Comments { get; set; }
        public int CommentID { get; set; }
        public string CommentedBy { get; set; }
        public string ProjectMembers { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MemberID { get; set; }
        public int ToDoID { get; set; }
        public string CreatedBy { get; set; }
        public string UserName { get; set; }
    }
}