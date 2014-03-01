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
        <h2>This is a h2 subheading</h2>
        <p> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla accumsan  mauris a enim aliquet at elementum diam condimentum. Donec et sem eros.  Morbi mollis accumsan pellentesque. Duis ultricies, purus in sodales  luctus, urna dolor ultrices ligula, luctus faucibus ante dolor sit amet  tortor. Fusce non purus eros, id pulvinar ligula. Quisque ullamcorper  placerat libero. Mauris pretium purus eu nibh adipiscing pretium. Nam  libero ipsum, laoreet quis convallis id, viverra id dolor. Praesent  dignissim nisl a mauris ultrices eget ultrices libero adipiscing. Fusce  eget pretium nunc. </p>
        <form>
            <label>Title</label>
            <input type="text" class="smallInput wide" />
            <label>Edit Content</label>
            <textarea cols="30" rows="7" class="smallInput wide" id="wysiwyg"></textarea>
            <label>Select</label>
            <select class="smallInput">
        	    <option>This is one option</option>
        	    <option>This is second option</option>
        	    <option>This is third option</option>            
            </select>
        </form>
    </div>
    <div class="clear"></div>
    <div class="portlet-content nopadding">
           <a class="button"><span>Submit in blue</span></a>
           <a class="button_grey"><span>Submit this form</span></a>
           <a class="button_ok"><span>Update information</span></a>
           <a class="button_notok"><span>Delete this record</span></a>
           <a class="button_grey_round"><span>This is a rounded button</span></a>
    </div>
    
    <div class="clear"></div>
    <div class="portlet-content nopadding">
           <p id="success" class="info"><span class="info_inner">Lorem ipsum dolor sit amet, consectetuer adipiscing elit</span></p>
           <p id="error" class="info"><span class="info_inner">Lorem ipsum dolor sit amet, consectetuer adipiscing elit</span></p>
           <p id="warning" class="info"><span class="info_inner">Lorem ipsum dolor sit amet, consectetuer adipiscing elit</span></p>
           <p id="info" class="info"><span class="info_inner">Lorem ipsum dolor sit amet, consectetuer adipiscing elit</span></p>
    </div>
    
    
    <div class="clear"></div>
    <div class="portlet ui-widget ui-widget-content ui-helper-clearfix ui-corner-all">
        <div class="portlet-header fixed ui-widget-header ui-corner-top">
            <span class="ui-icon ui-icon-triangle-1-n"></span>
            <span class="ui-icon ui-icon-triangle-1-n"></span>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Areas/Admin/Content/images/user.gif" Width="16" Height="16" />
            Last Registered users Table Example
        </div>
        <div class="portlet-content nopadding">
            <table id="box-table-a" width="100%" cellpadding="0" cellspacing="0">
                <thead>
                  <tr>
                    <th width="34" scope="col">
                    <input type="checkbox" onclick="checkAll()" id="allbox" name="allbox"></th>
                    <th width="136" scope="col">Name</th>
                    <th width="102" scope="col">Username</th>
                    <th width="109" scope="col">Date</th>
                    <th width="129" scope="col">Location</th>
                    <th width="171" scope="col">E-mail</th>
                    <th width="123" scope="col">Phone</th>
                    <th width="90" scope="col">Actions</th>
                  </tr>
                </thead>
                <tbody>
                      <tr>
                        <td width="34">
                        <label>
                            <input type="checkbox" id="checkbox" name="checkbox">
                        </label></td>
                        <td>Nimesh L. Shrestha</td>
                        <td>nimesh</td>
                        <td>20.06.2011</td>
                        <td>Nepal, ktm</td>
                        <td>address1@yahoo.com</td>
                        <td>555-55555</td>
                        <td width="90">
                            <a title="Approve" class="approve_icon" href="#"></a>
                            <a title="Reject" class="reject_icon" href="#"></a>
                            <a title="Edit" class="edit_icon" href="#"></a>
                            <a title="Delete" class="delete_icon" href="#"></a>
                        </td>
                      </tr>
                      <tr class="footer">
                        <td colspan="4"><a class="edit_inline" href="#">Edit all</a><a class="delete_inline" href="#">Delete all</a><a class="approve_inline" href="#">Approve all</a><a class="reject_inline" href="#">Reject all</a></td>
                        <td align="right">&nbsp;</td>
                        <td align="right" colspan="3">
				        <!--  PAGINATION START  -->             
                            <div class="pagination">
                            <span class="previous-off">« Previous</span>
                            <span class="active">1</span>
                            <a href="#">2</a>
                            <a href="#">3</a>
                            <a href="#">4</a>
                            <a href="#">5</a>
                            <a href="#">6</a>
                            <a href="#">7</a>
                            <a class="next" href="#">Next »</a>
                            </div>  
                        <!--  PAGINATION END  -->       
                        </td>
                      </tr>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
