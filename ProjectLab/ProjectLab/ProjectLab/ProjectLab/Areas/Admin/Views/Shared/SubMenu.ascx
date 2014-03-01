<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<ul id="m0_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m0_ul")?"block":"none" %>">
      <li><a id="m0_t1" class="<%= (ViewData["SelectedTab"] == "m0_t1")?"current":"" %>" href="<%=Url.Action("Index","Index")%>"><span>Dashboard</span></a></li>
        
</ul>

<ul id="m1_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m1_ul")?"block":"none" %>">
      
      <li>
        <a id="m1_t1" class="<%= (ViewData["SelectedTab"] == "m1_t1")?"current":"" %>" href="<%= Url.Action("Create","Project") %>"><span>New Project</span></a>
      </li>
            <li>
        <a id="m1_t2" class="<%= (ViewData["SelectedTab"] == "m1_t2")?"current":"" %>" href="<%= Url.Action("Index","Project") %>"><span>Active Projects</span></a>
      </li>
      
             
</ul>
<ul id="m2_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m2_ul")?"block":"none" %>">
      
      <li>
        <a id="m2_t1" class="<%= (ViewData["SelectedTab"] == "m2_t1")?"current":"" %>" href="<%= Url.Action("Index","Report") %>"><span>Reports</span></a>
      </li>
      <li>
        <a id="m2_t2" class="<%= (ViewData["SelectedTab"] == "m2_t2")?"current":"" %>" href="<%= Url.Action("Index","Document") %>"><span>Documents</span></a>
      </li>       
</ul>
<ul id="m3_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m3_ul")?"block":"none" %>">
      <li>
        <a id="m3_t1" class="<%= (ViewData["SelectedTab"] == "m3_t1")?"current":"" %>" href="<%= Url.Action("Create","member") %>"><span>Add Member</span></a>
      </li>
      <li>
        <a id="m3_t2" class="<%= (ViewData["SelectedTab"] == "m3_t2")?"current":"" %>" href="<%= Url.Action("Index","member") %>"><span>Member Information</span></a>
      </li> 
    
      </li>   
      
</ul>
<ul id="m4_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m4_ul")?"block":"none" %>">
      
      <li>
        <a id="m4_t1" class="<%= (ViewData["SelectedTab"] == "m4_t1")?"current":"" %>" href="<%= Url.Action("Index","Slider") %>"><span>Slider</span></a>
      </li>
           
             
</ul>
<ul id="m5_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m5_ul")?"block":"none" %>">
      <li>
        <a id="m5_t1" class="<%= (ViewData["SelectedTab"] == "m5_t1")?"current":"" %>" href="<%= Url.Action("Create","Events") %>"><span>Add New Events</span></a>
      </li>
      <li>
        <a id="m5_t2" class="<%= (ViewData["SelectedTab"] == "m5_t2")?"current":"" %>" href="<%= Url.Action("Index","Events") %>"><span>Seminar & Events Information</span></a>
      </li>        
</ul>
<ul id="m7_ul" class="uls" style="display: <%= (ViewData["SelectedSubMenu"] == "m7_ul")?"block":"none" %>">
    <li>
        <a id="m7_t1" class="<%= (ViewData["SelectedTab"] == "m7_t1")?"current":"" %>" href="http://www.acem.edu.np/"><span>Contact ACEM College</span></a>
      </li>         
</ul>
