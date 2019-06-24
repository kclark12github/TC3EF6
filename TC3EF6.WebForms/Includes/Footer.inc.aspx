<asp:Content ID="PageFooter" ContentPlaceHolderID="FooterContent" runat="server">
    <div style="font-family: Arial; color: #000000; background-color: #FFFFFF">
        <p><i>If you experience any problems with this page, please contact: <b>WebMaster:&nbsp;<a href="mailto:<%= Application["WebMasterEmail"] %>"><%= Application["WebMaster"] %></a></b></i>
        </p>
        <div style="text-align: center;">
            <table border="0" style="width:100%">
                <tr>
                    <td style="width:33%"><img src="/Images/Logos/MSnotepad.gif" width="114" height="43"></td>
                    <td style="width:33%;color:#000080;font-size:smaller">
                        <b>Best experienced with</b><br>
                        <a href="http://www.microsoft.com/ie/" target="_blank"><img src="/Images/Logos/ie_static.GIF" alt="Microsoft Internet Explorer" border="0" width="88" height="31"></a><br>
                        <b>Click here to start.</b>
                    </td>
                    <td style="width:33%"><a href="http://www.microsoft.com/frontpage/" target="_top"><img src="/Images/Logos/fp114a.gif" alt="Microsoft FrontPage" border="0" width="114" height="43"></a></td>
                </tr>
            </table>
        </div>
        <p style="text-align: center;padding: 10px;"><i>-- Page Last modified <b><%= PageLastModified.ToString("dddd MMMM d, yyyy @ hh:mm tt")%></b> --</i></p>
    </div>
</asp:Content>
