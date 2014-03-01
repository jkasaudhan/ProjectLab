<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.Project.Project>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Listing Discussion
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Listing Discussion
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="<%= Url.Action("Discussion","Project",new { id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %>" class="button_ok"><span>New Discussion</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Discussion List for Project
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th scope="col" style="width: 100px">
                            <input type="hidden" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col" style="width: 1269px">
                                Discussion
                            </th>
                            <th scope="col">
                                Actions
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var discuss = new ProjectLab.Areas.Admin.Models.Project.Model();
                    // var discuss = new List<ProjectLab.Areas.Admin.Models.Project.Model>();
                    var disList = discuss.GetAllDiscussion(Int32.Parse(Session["SelectedProjectID"].ToString()));
                    foreach (var item in disList)
                    {
                %>
                <tr>
                    <td style="width: 100px">
                        <input type="hidden" name="Status" value="<%=item.DiscussionID %>" />
                    </td>
                    
                    <td style="width: 700px" >
                   
                        <span style="font-size:medium">
                         <b><%=item.DiscussionTitle%></span></b><br /><br />
                       <div style="text-align:right;">
                                  <span>Posted At:&nbsp;<%=item.CreatedAt %></span><br />
                                   <span><b> </b>PostedBy: &nbsp;<%=item.CreatedBy  %></span><br/>
                                    </div>
                           
                            <a href="<%= Url.Action("ListComment","Project",new {id=Int32.Parse((Session["SelectedDiscussionID"]).ToString())}) %>"<strong>See Previous Comment</strong></a>
                    </td>
                    <td style="width: 80px">
                     <% var mem = new ProjectLab.Areas.Admin.Models.member.Model();%>
               
                   <% if (mem.CheckRole(Int32.Parse(Session["SelectedMemberID"].ToString()))) %>
                   <%{ %>
                        <span></span></a><a class="approve_icon" title="Comment" href="<%= Url.Action("Comment","Project", new { id=Int32.Parse((Session["SelectedDiscussionID"]).ToString()) }) %>">
                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("EditDisscussion","Project", new { id=item.DiscussionID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("DeleteDiscussion","Project", new { id=Int32.Parse((Session["SelectedDiscussionID"]).ToString())})  %>">
                                    <span></span></a>
                                      <%} %>
                                   <% else %> 
                                   <% {%>
                                   <span></span></a><a class="approve_icon" title="Comment" href="<%= Url.Action("Comment","Project", new { id=Int32.Parse((Session["SelectedDiscussionID"]).ToString()) }) %>">
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
