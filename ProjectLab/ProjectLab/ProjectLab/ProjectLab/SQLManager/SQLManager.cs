using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace ProjectLab.SQLManager
{
 /// <summary>
 /// ////////////////////////////////////////////
 /// </summary>
    public class SQLManager
    {
        public string ConnectionString { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Query { get; set; }

        public SQLManager() 
        {
            Reader = null;
            Connection = null;
            Command = null;
            ConnectionString =WebConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            Query=string.Empty;
        }
   ///////////////////////////////////////////////
    }
}