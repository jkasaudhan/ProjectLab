using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft;
using Commons;
using Newtonsoft.Json;

namespace ApplicationLayer.LoginApplication
{
  public  class LoginApplication
    {
        public LoginApplication() 
        {
           // AppWorkState appWorkState = new AppWorkState();
        }
        public string CreateCompany(string ownerName, string company, string email, string password)
        {
            AppWorkState appWorkState = new AppWorkState();
            appWorkState.Result = "True";
            appWorkState.Data = "data here";
            //string retData = JsonConvert.SerializeObject(appWorkState);
            return "";
        }
    }
}
