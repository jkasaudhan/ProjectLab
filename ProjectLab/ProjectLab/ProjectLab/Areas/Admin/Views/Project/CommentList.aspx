﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.Project.Model>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    CommentList
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
    Listing Comments
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <a href="<%= Url.Action("Comment","Project",new { id=Int32.Parse(ViewData["DiscussionID"].ToString())}) %>" class="button_ok"><span>Add Comment</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            <% var discuss = new ProjectLab.Areas.Admin.Models.Project.Model();
                    // var discuss = new List<ProjectLab.Areas.Admin.Models.Project.Model>();
                    var title = discuss.GetDiscussionTitleByDiscussionID(Int32.Parse(Session["SelectedDiscussionID"].ToString()));%>
              
             <span><b>Discussion Title:</b>&nbsp; <%=title.DiscussionTitle %></span>
                  
                
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th scope="col" style="width: 100px">
                            
                            <th scope="col" style="width: 1269px">
                                Comments
                            </th>
                           
                        </th>
                    </tr>
                </thead>
                <%
                    var comment = new ProjectLab.Areas.Admin.Models.Project.Model();
                     //var comment = new List<ProjectLab.Areas.Admin.Models.Project.Model>();
                    var commList = comment.GetAllComments(Int32.Parse(ViewData["DiscussionID"].ToString()));
                    foreach (var item in commList)
                    {
                %>
                <tr>
                    <td style="width: 100px">
                        <input type="hidden" name="Status" value="<%=item.DiscussionID %>" />
                    </td>
                    <td style="width: 800px">
                    <span><u><%=item.CommentedBy %></u>&nbsp;Says:</span><br /><br />
                        <span>
                            <%=item.Comments%></span><br />
                     <div style="text-align:right;">  <span>
                            <%=item.CreatedAt %></span>
                            </div>
                    </td>
                  
                </tr>
                <%
}  
                %>
            </table>
        </div>
    </div>
</asp:Content>
