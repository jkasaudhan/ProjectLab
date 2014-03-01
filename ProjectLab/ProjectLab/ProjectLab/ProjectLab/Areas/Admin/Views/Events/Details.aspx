<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.Events.Events>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
   Event Detail Information
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
            Event Details
        </div>
        <div class="portlet-content nopadding ">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>Event Title:</strong>
                    </td>
                    <td>
                        <div class="portlet-header ui-corner-top project-title">
                            <%=Model.EventTitle %>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Event Description:</strong>
                    </td>
                    <td>
                        <%=Model.EventDescription%>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <strong>CreatedAt:</strong>
                    </td>
                    <td>
                        <%=Model.CreatedAt%>
                    </td>
                </tr>
                
                     <tr>
                    <td>
                        <strong>Event Date:</strong>
                    </td>
                    <td>
                    <%=Model.EventDate %></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
