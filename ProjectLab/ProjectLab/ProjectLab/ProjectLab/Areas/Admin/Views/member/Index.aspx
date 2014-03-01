<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.member.Model>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Listing member
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Members Information
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <% var memb = new ProjectLab.Areas.Admin.Models.member.Model();%>
               
                   <% if (memb.CheckRole(Int32.Parse(Session["SelectedMemberID"].ToString()))) %>
                   <%{ %>
    <a href="<%= Url.Action("Create","member") %>" class="button_ok"><span>Add New</span>
    </a><%} %>
    <%else %>
    <%{ %>
    <h2>Member Information</h2>
    <%} %>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
           <h2> Member Listing</h2>
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="34" scope="col">
                            <input type="checkbox" name="allbox" id="allbox" onclick="checkAll()" />
                          <th scope="col">
                               <h3>   First Name</h3>
                            </th>
                            <th scope="col">
                              <h3>  Last Name</h3>
                            </th>
                          
                            <th scope="col">
                              <h3>  Actions</h3>
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var mem = new ProjectLab.Areas.Admin.Models.member.Model();
                    foreach (var item in mem.GetAllmembers())
                    {
                %>
                <tr>
                    <td>
                        <input type="hidden" />
                    </td>
                    <td>
                     <h3><%=item.FirstName %></h3>   
                    </td>
                    <td>
                      <h3><%=item.LastName %></h3>  
                    </td>
                   
                    <td>
                     <% var rol = new ProjectLab.Areas.Admin.Models.member.Model();%>
               
                   <% if (rol.CheckRole(Int32.Parse(Session["SelectedMemberID"].ToString()))) %>
                   <%{ %>
                        <a class="approve_icon" title="Details" href="<%= Url.Action("Details","member",new{ id=item.MemberID}) %>">
                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("Edit","member", new { id=item.MemberID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("Delete","member", new { id=item.MemberID }) %>">
                                    <span></span></a>
                                    <%} %>
                                  <%  else%> 
                                 <%{ %> 
                                 <h3> Active</h3>
                                  <%} %>
                    </td>
                </tr>
                <%
}  
                %>
            </table>
        </div>
    </div>
</asp:Content>
