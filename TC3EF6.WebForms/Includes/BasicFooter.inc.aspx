<asp:Content ID="BasicPageFooter" ContentPlaceHolderID="FooterContent" runat="server">
    <div style="font-family: Arial; color:white; background-color:black">
        <p><i>If you experience any problems with this page, please contact: <a href="mailto:<%= Application["WebMasterEmail"] %>"><b>WebMaster</b></a></i></p>
        <div style="text-align: center;padding: 10px;">
            <table border="0" style="width:100%">
                <tr>
                    <td style="text-align:left;width:50%">
                        &copy; <%: DateTime.Now.Year %> - <%: Application["AppName"] %>
                    </td>
                    <td style="text-align:right;width:50%;"><i>Page Last modified <b><%=GetPageLastModified()%></b></i>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
