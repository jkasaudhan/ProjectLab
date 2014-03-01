<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.member.Member>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
Deleting a member
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
Deleting a member
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
 <div class="clear"></div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Deleting...
        </div>
        <table width="100%" cellspacing="0" cellpadding="0" id="box-table-a">
            <thead>
                <tr>
                    <th>
                        Are you sure???
                        <p>
                           <% using (Html.BeginForm("Delete", "member", FormMethod.Post, new { @id = "Form" })) 
                           { 
                               %>
                                   <a onclick="$('#Form').submit();return false;" class="button_notok"><span>Click to Delete</span></a>
                                <% 
                           } 
                            %>
                        </p>
                    </th>
                </tr>
            </thead>
        </table>
    </div>

</asp:Content>