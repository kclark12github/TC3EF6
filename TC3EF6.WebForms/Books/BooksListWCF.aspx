<%@ Page Title="Books List Using WCF" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BooksListWCF.aspx.cs" Inherits="TC3EF6.WebForms.Books.BooksListWCF" %>
<asp:Content id="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<%
    //bool DebugMode = false;
    //string DFName = "rsBooks";
    //string SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];";
    string Theme = "brown";
    string TableStyle = ""; // @"style=""width:100%;border-collapse:collapse;border-spacing:0px;font-family:Arial;""";
    string HeaderStyle = $@"style=""background-image:url(/Images/{Theme}side/Navigation/Nav1.jpg);""";
    string DetailStyle = $@"style=""color:{Theme};""";   // $@"background-image:url(/Images/{Theme}/Background/BACK2.jpg);";
%>
    <asp:ScriptManager runat="server">
        <Services>
            <asp:ServiceReference Path="~/Books/BooksService.svc" />
        </Services>
    </asp:ScriptManager>
    <script type="text/javascript">
        function GetData() {
            alert("GetData");
            var pageSize = 10;
            var page = 5;
            BooksService.GetData(pageSize, page, "", onSuccess);
        };
        function onSuccess(json) {
            alert("onSuccess ");
            alert(json.d.Data.Count);

            table = $("#Records");
            header = $("<tr class='table_header'></tr>");
            $.each(Object.keys(json.d.Data[0]), function (iHdr, vHdr) {
                header.append($("<th>" + vHdr + "</th>"));
            });
            table.append(header);

            $.each(json.d.Data, function (iRow, vRow) {
                row = $("<tr></tr>");
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
            });
        };

        GetData();
    </script>
    <table id="BaseTable" border="1" class="data-list" <%=TableStyle%> title="<%=Page.Title%>">
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
