<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.Project.Project>" %>
<fieldset>
    <table class="data_table" width="600" cols="3">
        <tr>
            <td>
                <label class="label_pro">
                    Discussion Title:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.DiscussionTitle, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.DiscussionTitle, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Discussion Description:</label>
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(m => m.DiscussionDescription, new { @class = "dataInput dataBox" })%>
                <%= Html.ValidationMessageFor(m => m.DiscussionDescription, "Not Allowed")%>
            </td>
        </tr>
       
        
        <tr>
            <td>
                <a class="btn" href="<%= Url.Action("Listed","Project",new{ id=Model.ProjectID}) %>" onclick="$('#Form').submit();return false;"><span>Post This !!</span>
                    
                </a>
            </td>
        </tr>
    </table>
</fieldset>
