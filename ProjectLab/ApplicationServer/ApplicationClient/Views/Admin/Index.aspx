<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/MasterLayout.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<script runat="server">


    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<h1>AdminView</h1>
    <asp:Login runat="server">
    </asp:Login>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <legend> &nbsp;<p>
                        admin view</p>
    <p>
                        &nbsp;</p>
                    <p>
                        &nbsp;&nbsp;<asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" 
                            BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" 
                            Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Width="248px">
                            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" 
                                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284775" />
                            <TextBoxStyle Font-Size="0.8em" />
                            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.9em" 
                                ForeColor="White" />
                        </asp:Login>
                    </p>
                    <p>
                        &nbsp;</p>
                </fieldset>
                <p class="submitButton">
                    &nbsp;</p>
    </form>
</asp:Content>
