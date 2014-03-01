using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace ProjectLab.Areas.Admin.Models.Events
{
    public class Model
    {
        [Required]
        [DisplayName("Event Title")]
        public string EventTitle { get; set; }

        [Required]
        [DisplayName("Event Description")]
        public string EventDescription { get; set; }

        [Required]
        [DisplayName("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DisplayName("EventDate")]
        public string EventDate { get; set; }

        public void CreateEvent(string title, string descript, string dt)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();

            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "insert into tbl_Calender_Event(ProjectID,CompanyID,Title,Description,EventDate,CreatedAt,Status,Members) values(@pid,@cid,@title,@desc,@date,@At,@status,@mem)";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@pid", 4);
                sqlConn.Command.Parameters.AddWithValue("@cid", 2);
                sqlConn.Command.Parameters.AddWithValue("@title", title);
                sqlConn.Command.Parameters.AddWithValue("@desc", descript);
                sqlConn.Command.Parameters.AddWithValue("@date", dt);
                sqlConn.Command.Parameters.AddWithValue("@At", DateTime.Now);
                sqlConn.Command.Parameters.AddWithValue("@Status", "Active");
                sqlConn.Command.Parameters.AddWithValue("@mem", "me");
                sqlConn.Connection.Open();
                sqlConn.Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                sqlConn.Connection.Close();
                sqlConn.Connection.Dispose();
            }
        }


        public List<Events> GetAllEvents()
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            Events eve = new Events();
            var eventList = new List<Events>();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select Calender_Event_ID,Title,Description,CreatedAt,EventDate from tbl_Calender_Event ORDER BY CASE WHEN ISDATE (EventDate)=1 THEN CONVERT(Datetime,EventDate,101) ELSE null END ASC";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        eventList.Add(new Admin.Models.Events.Events
                        {
                            Calender_Event_ID = Int32.Parse(sqlConn.Reader["Calender_Event_ID"].ToString()),
                            EventTitle = sqlConn.Reader["Title"].ToString(),
                            EventDescription = sqlConn.Reader["Description"].ToString(),
                            CreatedAt=DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString()),
                            EventDate = sqlConn.Reader["EventDate"].ToString(),

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

            return eventList;
        }


        public void Delete(int ID)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "delete tbl_Calender_Event where Calender_Event_ID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", ID);
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

        public void Edit(int id, string title, string description,string evdte)
        {
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();

            sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
            sqlConn.Query = "update tbl_Calender_Event set Title =@title, Description=@descrip, EventDate=@evedte where Calender_Event_ID=@id";
            sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
            sqlConn.Command.Parameters.AddWithValue("@title", title);
            sqlConn.Command.Parameters.AddWithValue("@evedte", evdte);
            sqlConn.Command.Parameters.AddWithValue("@descrip", description);
            sqlConn.Command.Parameters.AddWithValue("@id", id);

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
        public Events GetDetails(int id)
        {
            Events eve = new Events();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select Calender_Event_ID,Title,Description,CreatedAt,EventDate from tbl_Calender_Event where Calender_Event_ID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        eve.Calender_Event_ID = Int32.Parse(sqlConn.Reader["Calender_Event_ID"].ToString());
                        eve.EventTitle = sqlConn.Reader["Title"].ToString();
                        eve.EventDescription = sqlConn.Reader["Description"].ToString();
                        eve.CreatedAt=DateTime.Parse(sqlConn.Reader["CreatedAt"].ToString());
                        eve.EventDate = sqlConn.Reader["EventDate"].ToString();
                            
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

            return eve;
        }


        public Events GetData(int id)
        {
            Events eve = new Events();
            SQLManager.SQLManager sqlConn = new SQLManager.SQLManager();
            try
            {
                sqlConn.Connection = new SqlConnection(sqlConn.ConnectionString);
                sqlConn.Query = "select Calender_Event_ID,Title,Description,EventDate from tbl_Calender_Event where Calender_Event_ID=@id";
                sqlConn.Command = new SqlCommand(sqlConn.Query, sqlConn.Connection);
                sqlConn.Command.Parameters.AddWithValue("@id", id);
                sqlConn.Connection.Open();

                using (sqlConn.Reader = sqlConn.Command.ExecuteReader())
                {
                    while (sqlConn.Reader.Read())
                    {
                        eve.Calender_Event_ID = Int32.Parse(sqlConn.Reader["Calender_Event_ID"].ToString());
                        eve.EventTitle = sqlConn.Reader["Title"].ToString();
                        eve.EventDescription = sqlConn.Reader["Description"].ToString();
                        eve.EventDate = sqlConn.Reader["EventDate"].ToString();

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

            return eve;
        }

    }
    public class Events
    {
        public int Calender_Event_ID {get;set;}
        public string EventTitle {get; set;}
        public string EventDescription {get;set;}
        public DateTime CreatedAt { get; set; }
        public string EventDate { get; set; }
    }
}