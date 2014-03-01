<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<ProjectLab.Areas.Admin.Models.Milestones.Milestones>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
Deleting current Milestones
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
Deleting current milestones
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
 <div class="clear"></div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image1" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
            Deleting a Milestones
        </div>
        <table width="100%" cellspacing="0" cellpadding="0" id="box-table-a">
            <thead>
                <tr>
                    <th>
                        Do you want to delete Selected Milestones?
                        <p>
                           <% using (Html.BeginForm("Delete", "Milestones", FormMethod.Post, new { @id = "Form" })) 
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