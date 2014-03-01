<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">
    $(document).ready(function () {
        $('.item').click(function () {
            $('.uls').css('display', 'none');
            $('#' + $(this).attr('id') + '_ul').css('display', 'block');
            $('.main').removeClass('current');
            $(this).find('a').addClass('current');
        });
    });
</script>
<ul id="menu_group_main" class="group">
    <li class="item first" id="m0">
        <a class="main <%= (ViewData["SelectedMenu"] == "m0_main")?"current":"" %>" id="m0_main">
            <span class="outer">
                <span class="inner dashboard">Dashboard</span>
            </span>
        </a>
    </li>
    <li class="item middle" id="m1">
        <a class="main <%= (ViewData["SelectedMenu"] == "m1_main")?"current":"" %>" id="m1_main">
            <span class="outer"><span class="inner users">Projects</span></span>
        </a>
    </li>
    <li class="item middle" id="m2">
        <a class="main <%= (ViewData["SelectedMenu"] == "m2_main")?"current":"" %>" id="m2_main">
            <span class="outer"><span class="inner reports">Reports</span></span>
        </a>
    </li>
    <li class="item middle" id="m3">
        <a class="main <%= (ViewData["SelectedMenu"] == "m3_main")?"current":"" %>" id="m3_main">
            <span class="outer"><span class="inner users">Members</span></span>
        </a>
    </li>
           
    <li class="item middle" id="m5">
         <a class="main <%= (ViewData["SelectedMenu"] == "m5_main")?"current":"" %>" id="m5_main">
            <span class="outer"><span class="inner event_manager">Event Manager</span></span>
         </a>
    </li>        
        
    <li class="item last" id="m7">
        <a class="main<%=(ViewData["SelectedMenu"]=="m7_main")?"current":"" %>" id="m7_main">
            <span class="outer"><span class="inner settings">Contact Us</span></span>
        </a>
    </li>
    
</ul>