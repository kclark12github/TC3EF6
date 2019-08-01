<%@ Page Title="Books List Using Ajax (jQuery v3.4.1)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksListAjax.aspx.cs" Inherits="TC3EF6.WebForms.Books.BooksListAjax" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%
    //bool DebugMode = false;
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string Theme = "brown";
    string TableStyle = ""; // @"style=""width:100%;border-collapse:collapse;border-spacing:0px;font-family:Arial;""";
    string HeaderStyle = $@"style=""background-image:url(/Images/{Theme}side/Navigation/Nav1.jpg);""";
    string DetailStyle = $@"style=""color:{Theme};""";   // $@"background-image:url(/Images/{Theme}/Background/BACK2.jpg);";
%>
<%--    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
                //alert("$.GET...");
                $.ajax({
                    "url": '<%=Request.ServerVariables["PATH_INFO"]%>/GetData?start=0&pageSize=10',
                    "type": 'GET',
                    "contentType": "application/json",
                    "dataType": "JSON",
                    "data": function (data) { return data },
                    //"dataSrc": function (json) {
                    //    json.draw = json.d.Draw;
                    //    json.recordsTotal = json.d.RecordsTotal;
                    //    json.recordsFiltered = json.d.RecordsFiltered;
                    //    json.data = json.d.Data;
                    //    var return_data = json;
                    //    return return_data.data;
                    //},
                    "success": function (json) {
                        table = $('#Records');
                        //table = $("<table id=" + table_id + "></table>");
                        header = $("<tr class='table_header' style='background-color:silver;'></tr>");
                        $.each(Object.keys(json.d.Data[0]), function (iHdr, vHdr) {
                            header.append($('<th>' + vHdr + '</th>'));
                        })
                        table.append(header);

                        $.each(json.d.Data, function (iRow, vRow) {
                            row = $('<tr></tr>');
                            $.each(vRow, function (iCell, vCell) {
                                var alignment = "left";
                                switch (typeof vCell) {
                                    case "number":
                                        alignment = "right";
                                        break;
                                    case "string":
                                        if (isMSDate(vCell)) {
                                            alignment = "right";
                                            var dt = new Date(parseMSDate(vCell));
                                            vCell = (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
                                            break;
                                        }
                                    default:
                                        break;
                                }
                                //row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                                row.append($('<td style="text-align:' + alignment + ';white-space:nowrap;">' + vCell + '</td>'));
                            })
                            table.append(row);
                        })
                    }
                });
        });
    </script>
    <table id="BaseTable" border="0" class="data-list" <%=TableStyle%> title="<%=Page.Title%>">
        <tr><th class="data-list" <%=HeaderStyle%>><%=Page.Title%></th></tr>
        <tr><td>
        <div class="card-body">
            <table id="Records" 
                class="table table-responsive-xl table-striped table-bordered table-hover compact order-column data-list-detail"
                <%=DetailStyle%>
                border="0" >
            </table>
        </div>
        </td></tr>
    </table>
</asp:Content>
