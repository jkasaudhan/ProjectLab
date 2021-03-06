﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.ToDo.Model>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Detail Work Division Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Detail Work Division Information
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
         <label>  
            ToDo Details of <strong> Project Name:&nbsp; <% var proj = new ProjectLab.Areas.Admin.Models.Project.Model();
                                                   var pt = proj.GetOnlyProjectTitle(Int32.Parse(ViewData["ProjectID"].ToString())); %>
                                                    
                                                   
                                                     <% =pt.FirstOrDefault().ProjectTitle%>
                                                     
             </label> </strong>
        </div>
        <div class="portlet-content nopadding ">
          <%
                    var details = new ProjectLab.Areas.Admin.Models.ToDo.Model();
                     //var details = new List<ProjectLab.Areas.Admin.Models.ToDo.ToDo>();
                    var disList = details.GetOnlyToDo(Int32.Parse(ViewData["ToDoID"].ToString()));
                    foreach (var item in disList)
                    {
                        var stat = new ProjectLab.Areas.Admin.Models.ToDo.Model();
                        var statuslist = stat.StatusNameByStatusId(Int32.Parse((item.Status).ToString()));   
                        
                %>
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 120px; width: 800px;">
                        <strong>ToDo Title:</strong>
                    </td>
                    <td>
                        <div class="portlet-header ui-corner-top project-title"  
                            style="float:left; width: 800px;">
                            <%=item.ToDoTitle%>
                        </div>
                    </td>
                </tr>
                <div  style="float:left;">
                <tr >
                    <td style="width: 120px">
                        <strong>ToDo Description:</strong>
                    </td>
                    <td  style="float:left;width: 800px">
                        <%=item.ToDoDescription%>
                    </td>
                </tr>
                </div>
                <tr>
                    <td style="width: 120px">
                        
                            <strong>CreatedAt:</strong>
                    </td>
                    <td  style="float:left; width: 800px;"><%=item.CreatedAt %></td>
                    </tr>
                     <tr>
                    <td style="width: 120px">
                        <strong>Assigned To:</strong>
                    </td>
                    <td  style="float:left; width: 800px;">
                   <% var mem = new ProjectLab.Areas.Admin.Models.member.Model();%> 
                        <%  var data = mem.GetMemberNameFromMemberId(item.AssignedTo);%>
                        <%=data.FirstName %>&nbsp;<%=data.LastName %>
                    </td>
                
                </tr>
                <tr>
                    <td style="width: 120px">
                       <strong>Current Status:</strong>
                    </td>
                    <td  style="float:left; width: 800px;">
                                                            
                        <% = statuslist.Name %>
                    </td>
                </tr>
                 <tr>
                    <td style="width: 120px">
                        <strong>Deadline:</strong>
                    </td>
                    <td  style="float:left; width: 800px;">
                        <%=item.Deadline%>
                    </td>
                </tr>
                
            </table>
            <%} %>
        </div>
    </div>
</asp:Content>
