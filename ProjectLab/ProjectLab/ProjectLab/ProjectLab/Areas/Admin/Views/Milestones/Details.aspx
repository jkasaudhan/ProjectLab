<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.Milestones.Model>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Detail Milestones Information
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            <label>
               <b> Milestones Details of Project Name:&nbsp;
                    <% var proj = new ProjectLab.Areas.Admin.Models.Project.Model();
                       var pt = proj.GetOnlyProjectTitle(Int32.Parse(ViewData["ProjectID"].ToString())); %>
                    <% =pt.FirstOrDefault().ProjectTitle%></b>
            </label>
            
        </div>
        <div class="portlet-content nopadding ">
            <%
                var details = new ProjectLab.Areas.Admin.Models.Milestones.Model();
                // var discuss = new List<ProjectLab.Areas.Admin.Models.Project.Project>();
                var disList = details.GetOnlyMilestones(Int32.Parse(ViewData["MilestonesID"].ToString()));
              
                   
                foreach (var item in disList)
                {
                    var stat = new ProjectLab.Areas.Admin.Models.Milestones.Model();
                    var statuslist = stat.StatusNameByStatusId(Int32.Parse(item.Status));
            %>
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <strong>Title:</strong>
                    </td>
                    <td>
                        <div class="portlet-header ui-corner-top project-title">
                            <%=item.MilestonesTitle%>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Description:</strong>
                    </td>
                    <td>
                        <%=item.MilestonesDescription%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <strong>Created AT:</strong>
                    </td>
                    <td>
                        <%=item.CreatedAt%>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                            <strong>Deadline:</strong></label>
                    </td>
                    <td><%=item.Deadline %>
                    </td>
                   
                        
                </tr>
                 <tr>
                    <td>
                        <strong>Status:</strong>
                    </td>
                    <td>
                                                                     
                       <%= statuslist.Name%> 
                    </td>
                </tr>
                 
            </table>
            <%} %>
        </div>
    </div>
</asp:Content>
