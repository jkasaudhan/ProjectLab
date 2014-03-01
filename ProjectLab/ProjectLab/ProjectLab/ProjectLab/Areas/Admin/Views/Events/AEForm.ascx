<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.Events.Events>" %>
<fieldset>
    <table class="data_table" width="600" cols="3">
        <tr>
            <td>
                <label class="label_pro">
                   Event Title:</label>
            </td>
            <td colspan="2">
                <%= Html.TextBoxFor(m =>m.EventTitle, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.EventTitle, "Not Allowed")%>
            </td>
        </tr>

        <tr>
            <td>
                <label class="label_pro">
                  Event Description:</label>
            </td>
            <td colspan="2">
                <%= Html.TextAreaFor(m => m.EventDescription, new { @class = "dataInput dataBox" })%>
                <%= Html.ValidationMessageFor(m => m.EventDescription, "Not Allowed")%>
            </td>
      </tr>
        <div id="wrappers">
         <tr>
        
            <td>
                <label class="label_pro">
                  Calender:</label>
            </td>
            <td colspan="2">
             
         
  <input type="text" id="example" gldp-id="flatwhite", name="date1"/>

    <div gldp-el="flatwhite" style="width:240px; height:150px; position:absolute; top:50px; left:80px;"></div>

               
    <script type="text/javascript">
        $(window).load(function()
        {
            $('#example').glDatePicker({
               
                cssName: 'flatwhite',
                specialDates: [{
               date: new Date (),
               data:{message: "HAppy Birthday"}
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
   
</td>
</tr>
     </div>        
      
        <tr>
       <td>
               <a class="btn" href="#" onclick="$('#Form').submit();return false;"><span>Submit</span>
                <input class="btn" type="submit" value="Submit" />
                </a>
            </td>
        </tr>
    </table>
</fieldset>
