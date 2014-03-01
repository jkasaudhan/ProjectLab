<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.Project.Project>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
Deleting a comments
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentTitle" runat="server">
Deleting a Comment
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Deleting Comments</h2>
    <div class="clear"></div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Deleting current Comment
        </div>
        <table width="100%" cellspacing="0" cellpadding="0" id="box-table-a">
            <thead>
                <tr>
                    <th>
                        Do you want to delete this Comment?
                        <p>
                           <% using (Html.BeginForm("DeleteComment", "Project", FormMethod.Post, new { @id = "Form" })) 
                           { 
                               %>
                                   <a onclick="$('#Form').submit();return false;" class="button_notok"><span>click Delete</span></a>
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
