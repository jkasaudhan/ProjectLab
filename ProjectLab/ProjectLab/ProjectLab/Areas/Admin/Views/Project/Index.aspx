<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.Project.Model>>" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Listing Projects
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Listing Projects
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="<%= Url.Action("Create","Project") %>" class="button_ok"><span>Add New</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Project Listing
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="25" scope="col">
                            <input type="checkbox" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col" style="width: 150px">
                                Project Title
                            </th>
                            <th scope="col" style="width: 686px">
                                Project Description
                            </th>
                            <th scope="col">
                                Actions
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var proj = new ProjectLab.Areas.Admin.Models.Project.Model();
                    foreach (var item in proj.GetAllProjects())
                    {
                %>
                <tr>
                    <td>
                       <input type="checkbox" name="Status" value="<%=item.ProjectID %>" />
                    </td>
                    <td style="width: 150px">
                        <%=item.ProjectTitle%>
                    </td>
                    <td style="width: 686px">
                        <%=item.ProjectDescription %>
                    </td>
                    <td>
                 <%--   <% var mem = new ProjectLab.Areas.Admin.Models.member.Model();%>--%>
               
                  <%-- <% if (mem.CheckRole(Int32.Parse(Session["SelectedMemberID"].ToString()))) %>
                   <%{ %>--%>
                        <a class="approve_icon" title="Details" href="<%= Url.Action("Details","Project",new{ id=item.ProjectID}) %>">

                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("Edit","Project", new { id=item.ProjectID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("Delete","Project", new { id=item.ProjectID }) %>">
                                    <span></span></a>
                                <%--    <%} %>
                                 <%else %>
                                 <%{ %>  --%>
                                  <a class="approve_icon" title="Details" href="<%= Url.Action("Details","Project",new{ id=item.ProjectID}) %>">
                                <%-- <%}%>--%>  
                    </td>
                </tr>
                <%
}  
                %>
               
            </table>
        
     
        </div>
    </div>
</asp:Content>
