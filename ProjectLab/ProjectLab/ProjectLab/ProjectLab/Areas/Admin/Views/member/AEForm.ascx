<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.member.Member>" %>
<fieldset>
    <table class="data_table" width="600" cols="3">
       <%-- <tr>
            <td>
                <label class="label_pro">
                    Profile Picture:</label>
            </td>
            <td colspan="2">
                <label for="file">
                    Upload Image:</label>
                <input type="file" class="btn" name="file" id="file" />
                <input type="submit" class="btn" value="Upload Image" />
            </td>
        </tr>--%>
        <tr>
            <td>
                <label class="label_pro">
                    First Name:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.FirstName, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.FirstName, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Last Name:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.LastName, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.LastName, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Email:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.Email, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.Email, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Username:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.Username, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.Username, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Password:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.Password, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.Password, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <a class="button" href="#" onclick="$('#Form').submit();return false;"><span>Add/Edit</span>
                </a>
            </td>
        </tr>
    </table>
</fieldset>
