<%@ Page Title="Books List Using jQuery v1.7.2 Ajax" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksListAjax-1.7.2.aspx.cs" Inherits="TC3EF6.WebForms.Books.BooksListAjax_1__7__2" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%
    //bool DebugMode = false;
    string Theme = "Brownside";
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string TableStyle = "style='width:100%; border-collapse: collapse; border-spacing: 0px;font-family:Arial;background-color:black;'";
    string TableHeaderStyle = $@"style='background-image:url(/Images/{Theme}/Navigation/Nav1.jpg);text-align:left;font-size:xx-large;font-style:italic;color:white;height:56px;white-space:nowrap;padding-left:10px;'";
    string TableDetailStyle = "style='max-width:none;overflow-x:visible,scroll;background-color:white;color:brown;'";   // $@"background-image:url(/Images/{Theme}/Background/BACK2.jpg);";
%>
<%--    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                "url": '<%=Request.ServerVariables["PATH_INFO"]%>/GetData',
                "type": 'GET',
                "contentType": "application/json",
                "dataType": "JSON",
                "data": function (data) { return data },
                "dataSrc": function (json) {
                    json.draw = json.d.Draw;
                    json.recordsTotal = json.d.RecordsTotal;
                    json.recordsFiltered = json.d.RecordsFiltered;
                    json.data = json.d.Data;
                    var return_data = json;
                    return return_data.data;
                },
                "success": function (json) {
                    table = $('#Records');
                    //table = $("<table id=" + table_id + "></table>");
                    header = $("<tr class='table_header'></tr>");
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
                                        vCell = parseMSDate(vCell);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            row.append($('<td style="text-align:' + alignment + ';white-space:nowrap;">' + vCell + '</td>'));
                        })
                        table.append(row);
                    })
                }
            });
            function isMSDate(s) {
                var pattern = /Date\(([^)]+)\)/;
                return pattern.test(s);
            };
            function parseMSDate(s) {
                if (s === null) return "Null";
                var pattern = /Date\(([^)]+)\)/;
                var results = pattern.exec(s);
                var dt = new Date(parseFloat(results[1]));
                return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
            };
        });
    </script>
    <table id="BaseTable" border="1" <%=TableStyle%> title="<%=Page.Title%>">
        <tr><th <%=TableHeaderStyle%>><%=Page.Title%></th></tr>
        <tr><td>
        <div class="card-body">
            <table id="Records" 
                class="table table-responsive-xl table-striped table-bordered table-hover compact order-column"
                <%=TableDetailStyle%>
                border="0" >
            </table>
        </div>
        </td></tr>
    </table>
</asp:Content>
