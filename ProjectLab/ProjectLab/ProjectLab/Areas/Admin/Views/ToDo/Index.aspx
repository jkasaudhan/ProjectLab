<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Helpers.PaginatedList<ProjectLab.Areas.Admin.Models.ToDo.Model>>" %>
  
<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Listing Tasks
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Listing Tasks
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <a href="<%= Url.Action("Create","ToDo",new { id=Int32.Parse((Session["SelectedProjectID"]).ToString())})%>" class="button_ok"><span>Add New Task</span>
    </a>
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
         ToDo List
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                    <tr>
                        <th width="25" scope="col">
                            <input type="checkbox" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col">
                                Task Title
                            </th>
                            <th scope="col">
                                Task Description
                            </th>
                            <th scope="col">
                                Actions
                            </th>
                        </th>
                    </tr>
                </thead>
                <%
                    var tod = new ProjectLab.Areas.Admin.Models.ToDo.Model();
                    foreach (var item in tod.GetAllToDo(Int32.Parse(Session["SelectedProjectID"].ToString())))
                    {
                %>
                <tr>
                    <td>
                       <input type="hidden" name="Status" value="<%=item.ToDoID %>" />
                    </td>
                    <td>
                        <%=item.ToDoTitle%>
                    </td>
                    <td>
                        <%=item.ToDoDescription %>
                    </td>
                    
                    <td>
                        <a class="approve_icon" title="Details" href="<%= Url.Action("Details","ToDo",new{ id=item.ToDoID}) %>">
                            <span></span></a><a class="edit_icon" title="Edit" href="<%= Url.Action("Edit","ToDo", new { id=item.ToDoID }) %>">
                                <span></span></a><a class="delete_icon" title="Delete" href="<%= Url.Action("Delete","ToDo", new { id=item.ToDoID }) %>">
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
