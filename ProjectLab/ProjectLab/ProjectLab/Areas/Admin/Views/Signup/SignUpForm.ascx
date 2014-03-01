<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectLab.Areas.Admin.Models.member.Member>" %>
<header class="main-header">
<h1>Signup form for Members</h1>
<link rel="stylesheet" type="text/css" href="../../Controllers/Content/960.css" />
</header>
<div class="form-container">
    <form id="login" name="login-form" class="account-form clear fix" action="" method="post">
    <fieldset>
        <div class="form-item">
            <label for="firstname" class="visuallyhidden">
                First Name *</label>
            <%= Html.TextBoxFor(m =>m.FirstName, new { @class = "dataInput txt_box" })%>
            <%= Html.ValidationMessageFor(m => m.FirstName, "Not Allowed")%>
        </div>
        <div class="form-item">
            <label for="lastname" class="visuallyhidden">
                Last Name *</label>
            <%= Html.TextBoxFor(m =>m.LastName, new { @class = "dataInput txt_box" })%>
            <%= Html.ValidationMessageFor(m => m.LastName, "Not Allowed")%>
        </div>
        <div class="form-item">
            <label for="email" class="visuallyhidden">
                Email *</label>
            <%= Html.TextBoxFor(m =>m.Email, new { @class = "dataInput txt_box" })%>
            <%= Html.ValidationMessageFor(m => m.Email, "Not Allowed")%>
        </div>
        <div class="form-item">
            <label for="username" class="visuallyhidden">
                Username *</label>
            <%= Html.TextBoxFor(m =>m.Username, new { @class = "dataInput txt_box" })%>
            <%= Html.ValidationMessageFor(m => m.Username, "Not Allowed")%>
        </div>
        <div class="form-item">
            <label for="password" class="visuallyhidden">
                Password *</label>
            <!--<input type="password" id="password" name="password" class="required" placeholder="Password *">-->
            <%= Html.PasswordFor(m =>m.Password, new { @class = "dataInput txt_box"})%>
            <%= Html.ValidationMessageFor(m => m.Password, "Not Allowed")%>
            </div>
         <div class="form-item">
         <label> Select Type *</label>
         
                <a href="#checkboxes" class="btn" id="show-checkbox"> 
              </a>
                <div id="checkboxes">
                    <%  var role = new ProjectLab.Areas.Admin.Models.member.Model();
                        foreach (var rolename in role.getNameByroleid())%>
                     <%   { %>
                   
                    <div id="wrapper_check">
                        <input type="radio" name="names" value="<%=rolename.RoleID %>" />
                        <label>
                            <%= rolename.Name %>
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
        </div>
                   
    </fieldset>
    <button class="btn btn-mega" id="submit">
        Create Account</button>
    </form>
</div>
