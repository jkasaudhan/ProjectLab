using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ApplicationLayer.LoginApplication;
namespace ProjectLabServices.LoginServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Login" in code, svc and config file together.
    public class Login : ILogin
    {
        LoginApplication applicationLogin = new LoginApplication();
        public string  DoWork()
        {
            return "testing";
        }

        public string CreateCompany(string ownerName,string company,string email,string password) 
        {
            applicationLogin.CreateCompany(ownerName, company, email, password);
            return "test";
        }
    }
}
