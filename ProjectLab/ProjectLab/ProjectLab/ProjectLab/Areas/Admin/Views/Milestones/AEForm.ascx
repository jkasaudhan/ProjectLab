<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.Milestones.Milestones>" %>
<script src="../../Content/js/jquery-1.10.3.js" type="text/javascript"></script>

 <link rel="stylesheet" type="text/css" href="../../Content/js/jquery-ui.css" />
 <script type="text/javascript">
      $(function () {
          $("#datepicker").datepicker();
      });
 </script>
<fieldset>
    <table class="data_table" width="600" cols="3">
        <tr>
            <td>
                <label class="label_pro">
                    Milestones Title:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.MilestonesTitle, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.MilestonesTitle, "Not Allowed")%>
            </td>
        </tr>
        <tr>
            <td>
                <label class="label_pro">
                    Milestones Description:</label>
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(m => m.MilestonesDescription, new { @class = "dataInput dataBox" })%>
                <%= Html.ValidationMessageFor(m => m.MilestonesDescription, "Not Allowed")%>
            </td>
        </tr>
       <div id="wrappers">
        <tr>
         <td>
                <label class="label_pro">
                    Deadline:</label><br />
            </td>
            <td colspan="2">
              <input type="text" id="example" gldp-id="flatwhite", name="date1"/>

    <div gldp-el="flatwhite" 
                    style="width:250px; height:140px; position:absolute; top:63px; left:328px;"></div>
    </td>
               
  
   
            </tr>
             </div>
               <script type="text/javascript">
                   $(window).load(function () {
                       $('#example').glDatePicker({

                           cssName: 'flatwhite',
                           specialDates: [{
                               date: new Date(),
                               data: { message: $('.txt_box').val() }
                           }],
                           onClick: function (target, cell, date, data) {
                               target.val(date.getFullYear() + ' - ' +
                    date.getMonth() + ' - ' +
                    date.getDate());

                               if (data != null) {
                                   alert(data.message + '\n' + date);
                               }
                           }
                       });
                   });
    </script>
            <tr>
            <td colspan="2">
             <a href="#checkboxes" class="btn" id="show-checkbox">Assign current Status</a>
                <div id="checkboxes">
                 <%  var status = new ProjectLab.Areas.Admin.Models.Milestones.Model();
                        foreach (var statusname in status.GetStatusName())%>
                     <%   { %>
                   
                    <div id="wrapper_check" style="float:left">
                        <input type="radio" name="Status" value="<%=statusname.StatusID %>" checked="checked"/>
                        <label>
                            <%= statusname.Name%>
                        </label>
                        <br />
                    </div>
                    <%
}
                    %> 
                    </div> 
                     <script type="text/javascript">
                         $('#show-checkbox').click(function (e) {
                             $('#checkboxes').toggle({
                                 easing: 'swing'
                             });
                         });
                    </script>
                      
            </td>
            <td colspan="2">
          
           </td>
          </tr>

          
        <tr>
            <td>
                <a class="btn" href="#" onclick="$('#Form').submit();return false;"><span>Submit:</span>
               
                </a>
                       
            </td>
        </tr>
    </table>
</fieldset>
