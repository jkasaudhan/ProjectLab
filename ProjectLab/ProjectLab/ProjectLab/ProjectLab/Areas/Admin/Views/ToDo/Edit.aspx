<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.ToDo.ToDo>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
Editing Project
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
Editing Project
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="clear"></div>
    <div id="portlets">
         <% using (Html.BeginForm("Edit", "ToDo", FormMethod.Post, new { @id = "Form" }))
           { 
               Html.RenderPartial("AEForm");
            } 
        %>
    </div>


</asp:Content>
