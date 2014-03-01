<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Login.Master" Inherits="System.Web.Mvc.ViewPage" %> 


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	AdminLogon

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
             <% using (Html.BeginForm("Logon", "Logon", FormMethod.Post, new { @id = "Form" }))
           {
              
               Html.RenderPartial("LogOnForm");
            } 
        %>
    

</asp:Content>
