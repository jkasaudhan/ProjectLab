<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
	Dashboard
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
	Dashboard
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="clear"></div>
    <div id="textcontent" class="grid_15">
    <script type="text/javascript">
        $(function () {
            $.ajax({
                url: '@Url.Action("Create","Events")',
                type: 'GET',
                dataType: 'json',
                success: function (data) {
                    //Here you will get the data.
                    //Display this in your Modal popup
                },
             //   error: function (data) {
               // }
            });
        });
</script>
        <h2>Project Management Tools</h2>
        <p><b>Project management is the application of knowledge, skills, tools, and techniques to project activities to undertake a process successfully.</br>
        It is a web based project management solution which is used by organization across the globe. It is an excellent way to bring members, managers,</br>
        and clients together in one complete and unified application.
        <br/>
        <br/>
        
        Project management tool is useful for companies for organizing different stages of project using a single application. In real time scenario we know</br>
        every software company works on many projects at a time with huge budgets and human resource required to complete the task. So project management </br> tool
        provides a roadmap that is easily followed and leads to project completion</b></p>
         </br>

            
    </div>
    
    <div class="clear"></div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <span class="ui-icon ui-icon-triangle-1-n"></span>
            <span class="ui-icon ui-icon-triangle-1-n"></span>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Areas/Admin/Content/images/user.gif" Width="16" Height="16" />
           
                     
        </div>
         <thead>
         <div class="clear">
    </div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <asp:Image ID="Image2" ImageUrl="~/Areas/Admin/Content/images/user.gif" runat="server" />
          Upcoming Events
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" cellpadding="0" cellspacing="0" style="width: 499px">
                    <tr>
                        <th width="1px" scope="col">
                            <input type="hidden" name="allbox" id="allbox" onclick="checkAll()" />
                            <th scope="col" style="width: 199px">
                               Event Title
                            </th>
                           
                            <th style="width: 250px">
                               Event Description
                            </th>
                            <th scope="col" style="width: 74px">
                               Event Date
                            </th>
                            
                        </th>
                    </tr>
                </thead>
                <%
                    var eve = new ProjectLab.Areas.Admin.Models.Events.Model();
                    foreach (var item in eve.GetAllEvents())
                    {
                %>
                <tr style="width: 599px">
                    <td>
                        <input type="checkbox" />
                    </td>
                    <td style="width: 199px">
                        <%=item.EventTitle%>
                    </td>
                   
                    <td style="width: 250px">
                        <%=item.EventDescription%>
                    </td>
     
                   <td style="width: 74px">
                     <%=item.EventDate%>      
                    <td>
                    <%} %>
                    </tr>
    </div>

</asp:Content>
