using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;

namespace ProjectLab.Areas.Admin.Models.Milestones
{
    public class Model
    {
        [Required]
        [DisplayName("Milestone Title")]
        public string MilestoneName { get; set; }

        [Required]
        [DisplayName("Milestone Description ")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("CreatedAt")]
        public int CreatedAt { get; set; }
       
        [Required]
        [DisplayName("Deadline")]
        public int Deadline { get; set; }

        [Required]
        [DisplayName("Project Members")]
        public int members { get; set; }
        [Required]
        [DisplayName("Status")]
        public String Status { get; set; }

        [Required]
        [DisplayName("UpdatedAt")]
        public DateTime UpdatedAt { get; set; }




        public void Createmilestones(int ids,string title, string desc,string status,DateTime dte)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_milestones(ProjectID,CreatedBy,ReviewedBy,Status,Deadline,MilestonesTitle,MilestonesDescription,UpdatedAt,CreatedAt)  values(@Projid,@createdby,@reviewby,@status,@deadline,@title,@descrip,@updatedat,@createdat)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("projid", ids);
                sqlConn.Command.Parameters.AddWithValue("@createdby",2 );
                 sqlConn.Command.Parameters.AddWithValue("@reviewby",2);
                sqlConn.Command.Parameters.AddWithValue("@status", status);
                sqlConn.Command.Parameters.AddWithValue("@deadline", dte);
                 sqlConn.Command.Parameters.AddWithValue("@title", title);
                 sqlConn.Command.Parameters.AddWithValue("@descrip", desc);
                 sqlConn.Command.Parameters.AddWithValue("@updatedat", DateTime.Now);
                 sqlConn.Command.Parameters.AddWithValue("@createdat", DateTime.Now);
                // sqlConn.Command.Parameters.AddWithValue("@memss",mem);

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

        public Milestones Datamilestones(int pid)
        {
            Milestones data = new Milestones();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select ProjectID, MilestonesID,MilestonesTitle,MilestonesDescription from tbl_milestones where ProjectID=@ID";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@ID", pid);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        data.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        data.MilestonesID = Int32.Parse(sqlConn.Reader["MilestonesID"].ToString());
                        data.MilestonesTitle = sqlConn.Reader["MilestonesTitle"].ToString();
                        data.MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString();
                        data.Deadline = DateTime.Parse(sqlConn.Reader["Deadline"].ToString());

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

        public Milestones StatusNameByStatusId(int sid)
        {
            Milestones data = new Milestones();
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
                        data.StatusID = Int32.Parse(sqlConn.Reader["StatusID"].ToString());
                        data.Name = sqlConn.Reader["Name"].ToString();
                       // data.MilestonesTitle = sqlConn.Reader["MilestonesTitle"].ToString();
                       // data.MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString();

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
       
        public List<Milestones> GetAllMilestones(int mid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Milestones mile = new Milestones();
            var mileList = new List<Milestones>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_milestones where ProjectID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", mid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        mileList.Add(new Admin.Models.Milestones.Milestones
                        {
                            ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString()),
                            MilestonesID = Int32.Parse(sqlConn.Reader["MilestonesID"].ToString()),
                            MilestonesTitle = sqlConn.Reader["MilestonesTitle"].ToString(),
                            MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString(),
                            Status=sqlConn.Reader["Status"].ToString(),                            
                           Deadline = DateTime.Parse(sqlConn.Reader["Deadline"].ToString()),
                            UpdatedAt = DateTime.Parse(sqlConn.Reader["UpdatedAt"].ToString()),
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

            return mileList;
        }

        
        

        public List<Milestones> GetOnlyMilestones(int pid)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Milestones mile = new Milestones();
            var mileList = new List<Milestones>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_milestones where MilestonesID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", pid);

                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        mileList.Add(new Admin.Models.Milestones.Milestones
                        {
                           
                            MilestonesID = Int32.Parse(sqlConn.Reader["MilestonesID"].ToString()),
                            MilestonesTitle = sqlConn.Reader["MilestonesTitle"].ToString(),
                            MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString(),
                            Status=sqlConn.Reader["Status"].ToString(),
                            Deadline = DateTime.Parse(sqlConn.Reader["Deadline"].ToString()),
                             CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
                            UpdatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
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

            return mileList;
        }



        public List<Milestones> GetStatusName()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Milestones mile = new Milestones();
            var mileList = new List<Milestones>();
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
                        mileList.Add(new Admin.Models.Milestones.Milestones
                        {

                            StatusID = Int32.Parse(sqlConn.Reader["StatusID"].ToString()),
                            Name = sqlConn.Reader["Name"].ToString(),
                         //   MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString(),

                         //   CreatedAt = DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
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

            return mileList;
        }

       

        public Milestones GetData(int mID)
        {
            Milestones mile = new Milestones();
            
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select * from tbl_milestones where MilestonesID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", mID);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        mile.ProjectID = Int32.Parse(sqlConn.Reader["ProjectID"].ToString());
                        mile.MilestonesID = Int32.Parse(sqlConn.Reader["MilestonesID"].ToString());
                        mile.MilestonesTitle = sqlConn.Reader["MilestonesTitle"].ToString();
                        mile.MilestonesDescription = sqlConn.Reader["MilestonesDescription"].ToString();
                        mile.Deadline=DateTime.Parse(sqlConn.Reader["Deadline"].ToString());
                        mile.Status = sqlConn.Reader["Status"].ToString();
                        mile.UpdatedAt = DateTime.Parse(sqlConn.Reader["UpdatedAt"].ToString());

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

            return mile;
        }


       

         public void DeleteSelectedMilestones(int mid)
        {
            
                SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
                try
                {
                    sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                    sqlConn.Query = "delete tbl_milestones where MilestonesID=@mileid";
                    sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                    sqlConn.Command.Parameters.AddWithValue("@mileid",mid);
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
        public void Edit(int mileid, string title, string Description, string status,DateTime dt)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "update tbl_milestones set MilestonesTitle=@title,MilestonesDescription=@Desc, Deadline=@datetime, Status=@status where MilestonesID=@mileid";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            
            sqlConn.Command.Parameters.AddWithValue("@mileid", mileid);
            sqlConn.Command.Parameters.AddWithValue("@updatedat",DateTime.Now);

            sqlConn.Command.Parameters.AddWithValue("@title", title);
            sqlConn.Command.Parameters.AddWithValue("@Desc", Description);
            sqlConn.Command.Parameters.AddWithValue("@datetime", dt);
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
       
    }
    public class Milestones
    {
        public int MilestonesID { get; set; }
        public string MilestonesTitle { get; set; }
        public string MilestonesDescription { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ProjectID { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; }
        public string ProjectTitle { get; set; }
        public int ProjectDescription { get; set; }
        public int StatusID { get; set; }
        public string Name { get; set;}
        public DateTime UpdatedAt { get; set; }
      
    }
}