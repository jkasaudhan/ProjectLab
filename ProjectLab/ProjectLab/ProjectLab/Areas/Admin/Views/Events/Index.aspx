<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" 
Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.Events.Model>>" %>



<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
Listing Events
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
Listing Events
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <a href="<%= Url.Action("Create","Events") %>" class="button_ok"><span>Add New</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
          Events Listing
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="25" scope="col">
                            <input type="checkbox" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col">
                               Event Title
                            </th>
                           
                            <th scope="col">
                               Event Description
                            </th>
                           
                            <th scope="col">
                                Actions
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var eve = new ProjectLab.Areas.Admin.Models.Events.Model();
                    foreach (var item in eve.GetAllEvents())
                    {
                %>
                <tr>
                    <td>
                        <input type="checkbox" />
                    </td>
                    <td>
                        <%=item.EventTitle%>
                    </td>
                   
                    <td>
                        <%=item.EventDescription %>
                    </td>
     
                   
                    <td>
                        <a class="approve_icon" title="Details" href="<%= Url.Action("Details","Events",new{ id=item.Calender_Event_ID}) %>">
                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("Edit","Events", new { id=item.Calender_Event_ID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("Delete","Events", new { id=item.Calender_Event_ID }) %>">
                                    <span></span></a>
                    </td>
                </tr>
                <%
                    }  
                %>
            </table>
        </div>
    </div>

</asp:Content>