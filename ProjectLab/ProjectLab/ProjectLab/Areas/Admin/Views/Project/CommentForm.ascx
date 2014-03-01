<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.Project.Project>" %>
<style type="text/css">
    .style1
    {
        width: 129px;
    }
    .style2
    {
        width: 129px;
        height: 111px;
    }
    .style3
    {
        height: 111px;
        width: 577px;
    }
    .data_table
    {
        width: 749px;
    }
</style>
<fieldset style="width: 762px">
    <table class="data_table" >
        <tr>
            <td class="style2">
                <label class="label_pro">
                    Comments:</label>
            </td>
            <td colspan="2" class="style3">
                <%= Html.TextAreaFor(m =>m.Comments, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.Comments, "Not Allowed")%>
            </td>
        </tr>
       
        
        <tr>
            <td class="style1">
                <a class="btn" href="" onclick="$('#Form').submit();return false;"><span>Post This 
                Comment!!</span>
                    
                </a>
            </td>
        </tr>
    </table>
</fieldset>


