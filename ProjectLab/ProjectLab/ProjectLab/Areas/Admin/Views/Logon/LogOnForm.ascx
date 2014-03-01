<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.member.Member>" %>

<header class="main-header">
<h1>Welcome ProjectLab Administrator</h1>

</header>

    <div class="form-container">
   <
      <form id="login" name="login-form" class="account-form clear fix" action="" method="post">

        <fieldset>

          <div class="form-item">
            <label for="username" class="visuallyhidden">Username or e-mail *</label>
          <!--  <input type="text" id="username" name="username" class="required" autofocus placeholder="Username or e-mail *"> -->
               <%= Html.TextBoxFor(m =>m.Username, new { @class = "dataInput txt_box" })%>
                <%= Html.ValidationMessageFor(m => m.Username, "Not Allowed")%>
          </div>

          <div class="form-item">
            <label for="password" class="visuallyhidden">Password *</label>
            <!--<input type="password" id="password" name="password" class="required" placeholder="Password *">-->
            <%= Html.PasswordFor(m =>m.Password, new { @class = "dataInput txt_box"})%>
                <%= Html.ValidationMessageFor(m => m.Password, "Not Allowed")%>
          </div>

        </fieldset>

        <button class="btn btn-mega" id="submit">Login</button>
        
        <div class="form-item remember-me">
          <input id="remember-me" type="checkbox" name="remember-me" value="Remember me"/>
          <label for="remember-me" class="text-label">Remember me</label>
        </div>
        
      <div>
      <ul class="login-links">
<li>
<small>
 <a href="<%= Url.Action("Signup","Signup") %>"> <label>SignUp</label>
    </a>

</small>
</li>
</ul>
    </div>
     
    </form>
    </div>