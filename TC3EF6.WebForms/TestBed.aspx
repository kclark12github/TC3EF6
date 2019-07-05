<%@ Page Title="Library - Books" Language="C#" AutoEventWireup="true" CodeBehind="TestBed.aspx.cs" Inherits="TC3EF6.WebForms.TestBed" %>
<%
    //bool DebugMode = false;
    string Theme = "Brownside";
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string TableStyle = "style='width:100%; border-collapse: collapse; border-spacing: 0px;font-family:Arial;'";
    string TableHeaderStyle = $@"style='background-image:url(/Images/{Theme}/Navigation/Nav1.jpg);text-align:left;font-size:xx-large;font-style:italic;color:white;height:56px;white-space:nowrap;padding-left:10px;'";
    string TableDetailStyle = "style='max-width:none;overflow-x:visible,scroll;background-color:white;color:brown;'";   // $@"background-image:url(/Images/{Theme}/Background/BACK2.jpg);";
%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="search" href="/Stylesheets/<%=Theme%>/Style2.css"/>
    <link href="/Content/bootstrap.css" rel="stylesheet"/>
    <link href="/Content/site.css" rel="stylesheet"/>
<%
    var UseNewJQ = 1;
    if (UseNewJQ==1)
    {
%>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<%--    <script type="text/javascript">
        $(window).load(function () {
            alert("$.GET...");
            $.get('<%=Request.ServerVariables["PATH_INFO"]%>/GetData', function (json, status) {
                    table = $('#Records');
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
                                    if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                        alignment = "right";
                                        vCell = parseMSDate(vCell);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            row.append($('<td style="text-align:'+ alignment + ';">' + vCell + ' (' + typeof(vCell) + ')</td>'));
                        })
                        table.append(row);
                    })
                });
        });
    </script>--%>
<%
    } else {
%>
    <script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<%--    <script type="text/javascript">
        $(window).load(function () {
            alert("$.AJAX...");
            $.ajax({
                "url": '<%=Request.ServerVariables["PATH_INFO"]%>/GetData',
                "type": 'GET',
                "contentType": "application/json",
                "type": "GET",
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
                                    if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                        alignment = "right";
                                        vCell = parseMSDate(vCell);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                        })
                        table.append(row);
                    })
                }
            });
        });
    </script>--%>
<%
    }
%>
<script type="text/javascript">
    $(document).ready(function () {
        var UseNewJQ = <%=UseNewJQ%>;
        //alert("Load");
        if (UseNewJQ == 1) {
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
                                    if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
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
<%--            $.get("<%=Request.ServerVariables["PATH_INFO"]%>/GetData", function (json, status) {
                table = $("#Records");
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
                                if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                    alignment = "right";
                                    vCell = parseMSDate(vCell);
                                    break;
                                }
                            default:
                                break;
                        }
                        row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                    })
                    table.append(row);
                })
            });--%>
        } else {
            //alert("$.AJAX...");
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
                                    if (vCell.length > 6 && vCell.substr(0, 6) == "/Date(") {
                                        alignment = "right";
                                        vCell = parseMSDate(vCell);
                                        break;
                                    }
                                default:
                                    break;
                            }
                            row.append($('<td style="text-align:' + alignment + ';">' + vCell + ' (' + typeof (vCell) + ')</td>'));
                        })
                        table.append(row);
                    })
                }
            });
        }
        function isMSDate(s) {
            var dregex = /\/Date\((\d*)\)\//;
            return dregex.test(s);
        };
        function parseMSDate(s) {
            var dregex = /\/Date\((\d*)\)\//;
            //alert(dregex.test(s) ? new Date(parseInt(dregex.exec(s)[1])) : s);
            return dregex.test(s) ? new Date(parseInt(dregex.exec(s)[1])) : s;
        };
    });
</script>


</head>
<body>
<table id="BaseTable" border="0" <%=TableStyle%> title="<%=Page.Title%>">
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
    <hr />
<%--    <form id="form1" runat="server">
        <div>
            <asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="TC3EF6.Data.TCContext" EntityTypeName="" OrderBy="AlphaSort, DateCreated" TableName="Books" Where="DatePurchased &gt; @DatePurchased">
                <WhereParameters>
                    <asp:Parameter DefaultValue="#06/01/2019#" Name="DatePurchased" Type="DateTime" />
                </WhereParameters>
            </asp:LinqDataSource>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="LinqDataSource1" ForeColor="#333333" GridLines="None" AllowPaging="True" AllowSorting="True" AutoGenerateSelectButton="True" EnableSortingAndPagingCallbacks="True" PageSize="25">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="AlphaSort" HeaderText="AlphaSort" SortExpression="AlphaSort" />
                    <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                    <asp:BoundField DataField="MediaFormat" HeaderText="MediaFormat" SortExpression="MediaFormat" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
                    <asp:BoundField DataField="Misc" HeaderText="Misc" SortExpression="Misc" />
                    <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Subject" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:CheckBoxField DataField="Cataloged" HeaderText="Cataloged" SortExpression="Cataloged" />
                    <asp:BoundField DataField="DateInventoried" HeaderText="DateInventoried" SortExpression="DateInventoried" />

                    <asp:BoundField DataField="DatePurchased" HeaderText="DatePurchased" SortExpression="DatePurchased" />
                    <asp:BoundField DataField="DateVerified" HeaderText="DateVerified" SortExpression="DateVerified" />
                    <asp:BoundField DataField="LocationID" HeaderText="LocationID" SortExpression="LocationID" />
                    <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" />
                    <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                    <asp:BoundField DataField="Value" HeaderText="Value" SortExpression="Value" />
                    <asp:CheckBoxField DataField="WishList" HeaderText="WishList" SortExpression="WishList" />
                    <asp:BoundField DataField="OID" HeaderText="OID" SortExpression="OID" />
<asp:BoundField DataField="DateCreated" HeaderText="DateCreated" SortExpression="DateCreated"></asp:BoundField>
<asp:BoundField DataField="DateModified" HeaderText="DateModified" SortExpression="DateModified"></asp:BoundField>
<asp:BoundField DataField="ID" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                    <asp:CheckBoxField DataField="HasErrors" HeaderText="HasErrors" ReadOnly="True" SortExpression="HasErrors" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>--%>
</body>
</html>
