<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Adding Discussion
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
Adding Discussion
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="clear"></div>
    <div id="portlets">
         <% using (Html.BeginForm("Discussion", "Project", FormMethod.Post, new { @id = "Form" }))
           {
               Html.RenderPartial("DiscussionForm");
            } 
        %>
    </div>
</asp:Content>
