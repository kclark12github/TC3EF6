<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestBed.aspx.cs" Inherits="TC3EF6.WebForms.TestBed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>
