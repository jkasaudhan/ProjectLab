<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.Milestones.Model>>" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Listing Milestones
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Listing Milestones
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="<%= Url.Action("Create","Milestones",new { id=Int32.Parse((Session["SelectedProjectID"]).ToString())} )%>" class="button_ok"><span>Add New Milestones</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
         Milestone List
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="25" scope="col">
                            <input type="checkbox" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col">
                                Milestones Title
                            </th>
                            <th scope="col">
                                Milestones Description
                            </th>
                            <th scope="col">
                                Deadline
                            </th>
                            <th scope="col">
                                Actions
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var mile = new ProjectLab.Areas.Admin.Models.Milestones.Model();
                //    var mile =new <ProjectLab.Areas.Admin.Models.Milestones.Milestones>();
                    foreach (var item in mile.GetAllMilestones(Int32.Parse(Session["SelectedProjectID"].ToString())))
                    {
                %>
                <tr>
                    <td>
                       <input type="hidden" name="Status" value="<%=item.MilestonesID %>" />
                    </td>
                    <td>
                        <%=item.MilestonesTitle%>
                    </td>
                    <td>
                        <%=item.MilestonesDescription %>
                    </td>
                    <td><%=item.Deadline %></td>
                     <td>
                      <% var mem = new ProjectLab.Areas.Admin.Models.member.Model();%>
               
                   <% if (mem.CheckRole(Int32.Parse(Session["SelectedMemberID"].ToString()))) %>
                   <%{ %>
                   
                        <a class="approve_icon" title="Details" href="<%= Url.Action("Details","Milestones",new{ id=item.MilestonesID}) %>">
                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("Edit","Milestones", new { id=item.MilestonesID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("Delete","Milestones", new { id=item.MilestonesID }) %>">
                                    <span></span></a>
                                     <%} %>
                                   <% else %> 
                                   <% {%>
                                    <a class="approve_icon" title="Details" href="<%= Url.Action("Details","Milestones",new{ id=item.MilestonesID}) %>">
                                  <% }%> 
                    </td>
                </tr>
                <%
}  
                %>
               
            </table>
        
         
        </div>
    </div>
</asp:Content>
