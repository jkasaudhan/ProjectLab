<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.Project.Project>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
     
                 <label>Project Detail Information</label>
                
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
           
            <strong>
                <label>
                     <a title="Create Discussion" href="<%= Url.Action("Discussion","Project",new{ id=Model.ProjectID}) %>"class="button_ok">
    
                                <span>New Discussion</span>
                              </a>
                        
                            <a title="Discussion List" href="<%= Url.Action("DiscussionList","Project",new{ id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %>"class="button_ok">
    
                                <span>Active Discussion</span>
                                
                            </a>
                        
                        
                        <a title="Create Milestones" href="<%= Url.Action("Create","Milestones",new{ id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %>" class="button_ok">
    
                                <span>New Milestones</span>
                            
                        </a>
                    
                    
                        <a title="Show Active Milestones List" href="<%= Url.Action("Index","Milestones",new{ id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %>" class="button_ok">
                            <span>
                                Active Milestones
                            </span>
                        </a>
                    
                     
                        <a title="Click to Create ToDo " href="<%= Url.Action("Create","ToDo",new{ id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %>" class="button_ok">
                            <span>
                               New Tasks
                            <span>
                        </a>
                         <a title="Click To Show ToDos " href="<%= Url.Action("Index","ToDo",new{ id=Int32.Parse((Session["SelectedProjectID"]).ToString())}) %> "class="button_ok">
                            <span>
                                Active Tasks
                            </span>
                        </a></label></strong>
                        <tr></tr>
        </div>
        <div class="portlet-content nopadding ">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 100px">
                        <strong>Project Title:</strong>
                    </td>
                    <td style="width: 589px">
                        <div class="portlet-header ui-corner-top project-title" 
                            style="width: 278px; height: 32px;">
                            <%=Model.ProjectTitle %>
                        </div>
                    </td>
                </tr>
               <tr>
                    <td style="width: 100px">
                         <strong>Project Description:</strong>
                    </td>
                    <td style="width: 589px";" float:left; clear: left">
                        <%=Model.ProjectDescription%>
                    </td>
                </tr>
               
               
                <tr>
                    <td>
                        <label>
                            <strong>Created At:</strong></label>
                    </td>
                    <td>
                    <%=Model.CreatedAt %>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
