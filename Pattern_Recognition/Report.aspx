<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Report.aspx.cs" Inherits="Report" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">

      <script src="//code.jquery.com/jquery-1.10.2.js"></script>

 <div style="width:100%;vertical-align:central">

    <table align="center" style="width:50%;border:1px solid #DFDFDF">
        <tr>
            <td>
                <asp:Label ID="Label1" Text="Select User" runat="server" ></asp:Label>
            </td>
            <td>
                 <asp:DropDownList ID="ddl_items" Width="200px"   runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddl_items_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td>
                 <asp:Label ID="Label2" Text="Select Session" runat="server" ></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" Width="200px"   runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
                <input type="button" onclick="SetValue();" value="Export" id="btnExport"/>
            </td>
        </tr>
    </table>
    <div>
    <table id="tblreport" align="center" style="width:50%;border:1px solid #DFDFDF;border-bottom:none">
        
        <tr align="left">
            <th >
                Question No
            </th>
             <th>
                Question UID
            </th>
            <th>
                Result
            </th>
            <th>
                Time Taken
            </th>
        </tr>
        <tbody id="tblbody" style="border:1px solid #DFDFDF !important" runat="server"></tbody>
    </table>
        <table align="center" style="width:50%;border:1px solid #DFDFDF">
        <tr>
            <td style="width:25%">
                 <asp:Label runat="server" ID="lbltotal"  Text="Total Correct Answer :"></asp:Label>
            </td>
            <td  style="width:25%">
                 <asp:Label runat="server" ID="lbltotalcorrect" class="totalans" Text=""></asp:Label>
            </td>
            <td  style="width:25%">
                <asp:Label runat="server" ID="Label3"  Text="Total TimeTaken :"></asp:Label>
            </td>
            <td  style="width:25%">
                <asp:Label runat="server" ID="lbltimetaken" class="totaltime" Text=""></asp:Label>
            </td>
        </tr>
      
    </table>
    </div>
        </div>
      
         <br />
         <br />
         <br />
    <script type="text/javascript">
      
        function SetValue() {
            $("#tblreport").toCSV();
        }
        jQuery.fn.toCSV = function () {
            var data = $(this).first(); //Only one table
            var csvData = [];
            var tmpArr = [];
            var tmpStr = '';
            data.find("tr").each(function () {
                if ($(this).find("th").length) {
                    $(this).find("th").each(function () {
                        tmpStr = $(this).text().replace(/"/g, '""');
                        tmpArr.push(tmpStr);
                    });
                    //csvData.push(tmpArr);
                } else {
                    tmpArr = [];
                    $(this).find("td").each(function () {
                        if ($(this).text().match(/^-{0,1}\d*\.{0,1}\d+$/)) {
                            tmpArr.push(parseFloat($(this).text()));
                        } else {
                            tmpStr = $(this).text().replace(/"/g, '""');
                            tmpArr.push( tmpStr );
                        }
                    });
                    csvData.push(tmpArr.join(','));
                   
                }
               // csvData.push(tmpArr.join('\n'));
            });
            var output = csvData.join('\n');
            var string = "\nTotal Correct Answer :" + $(".totalans").text(); +"," + "Total TimeTaken :" + $(".totaltime").text(); +"Sec";
            var string1 = "Total TimeTaken :" + $(".totaltime").text(); +"Sec";
            var header = "Question No,  Question UID, Result,  TimeTaken\n";
            output = header + output + string + " , " + string1;
          
            var uri = 'data:application/csv;charset=UTF-8,' + encodeURIComponent(output);
            window.open(uri);
        }


    </script>
    

</asp:Content>
