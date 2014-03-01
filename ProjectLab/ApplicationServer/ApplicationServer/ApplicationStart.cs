using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApplicationLayer.LoginApplication;
namespace ApplicationServer
{
    class ApplicationStart
    {
        
        static void Main(string[] args)
        {
          LoginApplication login = new LoginApplication();
        var a=  login.CreateCompany("jitendra", "jkcompany", "jk@gmail.com", "12345");


        }
    }
}
