<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.member.Member>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Member Details
        </div>
        <div class="portlet-content nopadding ">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>First Name:</strong>
                    </td>
                    <td>
                        <div class="portlet-header ui-corner-top project-title">
                            <%=Model.FirstName %>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Last Name:</strong>
                    </td>
                    <td>
                        <%=Model.LastName%>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <strong>Email:</strong>
                    </td>
                    <td>
                        <%=Model.Email%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Username:</strong>
                    </td>
                    <td>
                        <%=Model.Username%>
                    </td>
                </tr>
           
               
                     <tr>
                    <td>
                        <strong>Password:</strong>
                    </td>
                    <td>
                        <%=Model.Password%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
