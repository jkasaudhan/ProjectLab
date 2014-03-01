<%@ Page Title="" Language="C#" MasterPageFile="~/Areas/Admin/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
        <LocalReport ReportPath="Areas\Admin\Views\Report\Report1.rdlc">
        </LocalReport>
    </rsweb:ReportViewer>
    <%
        
        System.Data.DataSet DsTest = new System.Data.DataSet("dtTest");
        System.Data.DataTable dtTest = new System.Data.DataTable("dtTest");

        dtTest.Columns.Add("EmpName", System.Type.GetType("System.String"));
        dtTest.Columns.Add("EmpId", System.Type.GetType("System.Int32"));
        dtTest.Columns.Add("EmpSal", System.Type.GetType("System.Double"));


        System.Data.DataRow dr;
        for (int iIndex = 0; iIndex < 99; iIndex++)
        {
            dr = dtTest.NewRow();
            dr["EmpId"] = "100" + iIndex.ToString();
            dr["EmpName"] = "Kapil Dev-  " + iIndex.ToString();
            dr["EmpSal"] = (iIndex * 32678).ToString();
            dtTest.Rows.Add(dr);
        }
        DsTest.Tables.Add(dtTest);


        ReportViewer1.Visible = true;
        ReportDataSource datasource = new ReportDataSource("DataSet1", DsTest.Tables[0]);
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(datasource);
        ReportViewer1.LocalReport.Refresh();  
        
         %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PageTitle" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
