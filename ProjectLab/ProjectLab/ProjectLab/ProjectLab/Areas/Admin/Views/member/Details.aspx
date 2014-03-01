<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master"
    Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.member.Member>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
    Detail Information
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Member Details
        </div>
        <div class="portlet-content nopadding ">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                      <h3>  <strong>First Name:</strong></h3>
                    </td>
                    <td>
                        <div class="portlet-header ui-corner-top project-title">
                           <h3><%=Model.FirstName %></h3> 
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                       <h3> <strong>Last Name:</strong></h3>
                    </td>
                    <td>
                       <h3><%=Model.LastName%></h3> 
                    </td>
                </tr>
                 <tr>
                    <td>
                       <h3> <strong>Email:</strong></h3>
                    </td>
                    <td>
                     <h3> <%=Model.Email%></h3>  
                    </td>
                </tr>
                <tr>
                    <td>
                       <h3> <strong>Username:</strong>
                    </td></h3>
                    <td>
                       <h3><%=Model.Username%></h3> 
                    </td>
                </tr>
           
               
                     <tr>
                    <td>
                        <h3><strong>Password:</strong></h3>
                    </td>
                    <td>
                       <h3><%=Model.Password%></h3> 
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
