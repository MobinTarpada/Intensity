﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmPaymentReceipt.aspx.cs" Inherits="FitnessCenter.frmPaymentReceipt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="assets/assets/js/jquery-1.11.0.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="button" id="Print" value="Print" />
        <div id="printDiv">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="768px" 
                ShowPrintButton="true"  WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1080px" ShowRefreshButton="False">
                <LocalReport ReportEmbeddedResource="FitnessCenter.rptMemberPayment.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Memberships" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="DataSet1TableAdapters.MembershipsTableAdapter"></asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
<script>
    // Print function (require the reportviewer client ID)
    function printReport(printDiv) {
        var rv1 = $('#' + printDiv);
        var iDoc = rv1.parents('html');

        // Reading the report styles
        var styles = iDoc.find("head style[id$='ReportControl_styles']").html();
        if ((styles == undefined) || (styles == '')) {
            iDoc.find('head script').each(function () {
                var cnt = $(this).html();
                var p1 = cnt.indexOf('ReportStyles":"');
                if (p1 > 0) {
                    p1 += 15;
                    var p2 = cnt.indexOf('"', p1);
                    styles = cnt.substr(p1, p2 - p1);
                }
            });
        }
        if (styles == '') { alert("Cannot generate styles, Displaying without styles.."); }
        styles = '<style type="text/css">' + styles + "</style>";

        // Reading the report html
        var table = rv1.find("div[id$='_oReportDiv']");
        if (table == undefined) {
            alert("Report source not found.");
            return;
        }

        // Generating a copy of the report in a new window
        var docType = '<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/loose.dtd">';
        var docCnt = styles + table.parent().html();
        var docHead = '<head><title>Printing ...</title><style>body{margin:5;padding:0;}</style></head>';
        var winAttr = "location=yes, statusbar=no, directories=no, menubar=no, titlebar=no, toolbar=no, dependent=no, width=720, height=600, resizable=yes, screenX=200, screenY=200, personalbar=no, scrollbars=yes";;
        var newWin = window.open("", "_blank", winAttr);
        writeDoc = newWin.document;
        writeDoc.open();
        writeDoc.write(docType + '<html>' + docHead + '<body onload="window.print();">' + docCnt + '</body></html>');
        writeDoc.close();

        // The print event will fire as soon as the window loads
        newWin.focus();
        // uncomment to autoclose the preview window when printing is confirmed or canceled.
        // newWin.close();
    }; //then simply bind the previous print function to a print button :
        // Linking the print function to the print button
    $('#Print').click(function () {
        printReport('rv1');
    });
</script>
