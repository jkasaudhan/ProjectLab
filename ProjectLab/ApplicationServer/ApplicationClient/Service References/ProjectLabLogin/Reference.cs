﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApplicationClient.ProjectLabLogin {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProjectLabLogin.ILogin")]
    public interface ILogin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/DoWork", ReplyAction="http://tempuri.org/ILogin/DoWorkResponse")]
        string DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ILogin/CreateCompany", ReplyAction="http://tempuri.org/ILogin/CreateCompanyResponse")]
        string CreateCompany();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ILoginChannel : ApplicationClient.ProjectLabLogin.ILogin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class LoginClient : System.ServiceModel.ClientBase<ApplicationClient.ProjectLabLogin.ILogin>, ApplicationClient.ProjectLabLogin.ILogin {
        
        public LoginClient() {
        }
        
        public LoginClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public LoginClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public LoginClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string DoWork() {
            return base.Channel.DoWork();
        }
        
        public string CreateCompany() {
            return base.Channel.CreateCompany();
        }
    }
}