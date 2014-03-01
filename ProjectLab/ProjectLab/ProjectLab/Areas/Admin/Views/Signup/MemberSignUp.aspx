<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Login.Master"
    Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Member Signup!!!!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% using (Html.BeginForm("Signup", "Signup", FormMethod.Post, new { @id = "Form" }))
       {
           Html.RenderPartial("SignUpForm");
       } 
    %>
</asp:Content>
