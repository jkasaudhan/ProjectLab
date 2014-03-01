<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.Project.Project>" %>
<fieldset>
    <table class="data_table" width="600" cols="3">
        <tr>
            <td>
                <label class="label_pro">
                    Project Title:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.ProjectTitle, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.ProjectTitle, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Project Description:</label>
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(m => m.ProjectDescription, new { @class = "dataInput dataBox" })%>
                <%= Html.ValidationMessageFor(m => m.ProjectDescription, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <a href="#checkboxes" class="btn" id="show-checkbox">Select Project Members</a>
                <div id="checkboxes">
                    <%  var onlymembers = new ProjectLab.Areas.Admin.Models.member.Model();
                        foreach (var member in onlymembers.getonlymembers())
                        {
                    %>
                    <div id="wrapper_check">
                        <input type="checkbox" name="members" value="<%=member.MemberID %>" />
                        <label>
                            <%= member.FirstName +" "+ member.LastName %>
                        </label>
                        <br />
                    </div>
                    <%
}
                    %>
                    <script type="text/javascript">
                        $('#show-checkbox').click(function (e) {
                            $('#checkboxes').toggle({
                                easing: 'swing'
                            });
                        });
                    </script>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Attach Files:</label>
            </td>
            <td colspan="2">
                <% using (Html.BeginForm("FileUpload", "FileUpload",
                    FormMethod.Post, new { enctype = "multipart/form-data" }))
                   {%>
                <input class="btn" name="uploadFile" type="file" />
                <input type="submit" class="btn" value="Upload File" />
                <%} %>
            </td>
        </tr>
        <tr>
            <td>
                <a class="btn" href="#" onclick="$('#Form').submit();return false;"><span>Submit</span>
                    <input class="button" type="submit" value="Submit" />
                </a>
            </td>
        </tr>
    </table>
</fieldset>
