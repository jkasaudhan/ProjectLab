<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Adding Milestones
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
Adding Milestones
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
 <div class="clear"></div>
    <div id="portlets">
         <% using (Html.BeginForm("Create", "Milestones", FormMethod.Post, new { @id = "Form" }))
           {
               Html.RenderPartial("AEForm");
            } 
        %>
    </div>
</asp:Content>
