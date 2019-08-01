<%@ Page Title="Manage Account" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="TC3EF6.WebForms.Account.Manage" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successMessage" Visible="false" ViewStateMode="Disabled">
            <p class="text-success"><%: SuccessMessage %></p>
        </asp:PlaceHolder>
    </div>

    <div class="row">
        <div class="col-md-12" style="padding-bottom:50px;">
            <div class="form-horizontal">
                <h4>Change your account settings</h4>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Identification:</dt>
                    <dd>
                        <asp:Label runat="server" AssociatedControlID="txtEmail" CssClass="col-md-2 control-label">Email</asp:Label>
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" TextMode="Email" ReadOnly="true" />

                        <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-2 control-label">First Name</asp:Label>
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" />

                        <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-2 control-label">Last Name</asp:Label>
                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" TextMode="SingleLine" ReadOnly="true" />

                        <asp:Label runat="server" AssociatedControlID="txtPhone" CssClass="col-md-2 control-label">Phone</asp:Label>
                        <asp:TextBox runat="server" ID="txtPhone" CssClass="form-control" TextMode="Phone" ReadOnly="true" />
                    </dd>
                </dl>
                <hr />
                <dl class="dl-horizontal">
                    <dt>Password:</dt>
                    <dd>
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Change]" Visible="false" ID="hlChangePassword" runat="server" />
                        <asp:HyperLink NavigateUrl="/Account/ManagePassword" Text="[Create]" Visible="false" ID="hlCreatePassword" runat="server" />
                    </dd>
                    <dt>External/Social Media Logins:</dt>
                    <dd><%: LoginsCount %>
                        <asp:HyperLink NavigateUrl="/Account/ManageLogins" Text="[Manage]" runat="server" />
                    </dd>
                </dl>
                <hr />
                <h4 style="color:gray">MIDI Files (<asp:HyperLink Style="color:gray;" NavigateUrl="http://midkar.com/MidiStudio/Crescendo/index.html" Text="no longer supported" ID="hlCrescendo" runat="server" Target="_blank" ToolTip="Crescendo Version 5" />)</h4>
                <script type="text/javascript">
                    //TODO: Abandoning this effort as I cannot consistently determine Checked and Enabled values of asp:CheckBox controls via jQuery
                    //window.onload = function () {alert('Window loaded');};
                    //$(document).ready(function () {alert('DOM loaded');});
<%--                    $(document).ready(function () {
                        $("#MainContent_chkMusic").change(function () {
                            //If Playing Music is not desired AutoStart and Detached have no meaning...
                            var chkMusic = $('#MainContent_chkMusic');
                            var chkAutoStart = $('#MainContent_chkAutoStart');
                            var chkDetached = $('#MainContent_chkDetached');
                            alert('chkMusic.change: ' + chkMusic.checked);
                            if (chkMusic.checked == false)
                            {
                                alert('chkMusic.click: Unchecking...');
                                chkAutoStart.checked = false; 
                                chkDetached.checked = false; 
                            }
                            alert('chkMusic.click: Enable/Disabling...');
                            chkAutoStart.disabled = !chkMusic.checked;
                            chkDetached.disabled = !chkMusic.checked;
                        });
                    });
--%>
                </script>
                <div style="padding-left:25px;color:gray;">
                    <asp:CheckBox runat="server" ID="chkMusic" Text="Play MIDI Files" Enabled="false" ToolTip="Use Crescendo to play various MIDI audio throughout the app" /><br />
                    <div style="padding-left:25px">
                        <asp:CheckBox runat="server" ID="chkAutoStart" Text="AutoStart" Enabled="false" ToolTip="Automatically start Crescendo when pages load" /><br />
                        <asp:CheckBox runat="server" ID="chkDetached" Text="Detached" Enabled="false" ToolTip="Crescendo MIDI player should run detached (as opposed to embedded in the page)" /><br />
                    </div>
                </div>
                <hr />
<%--<% if (Owner) { %>--%>
                <h4>Administration</h4>
                <div style="padding-left:25px">
                    <asp:HyperLink NavigateUrl="~/Admin/VisitorList.asp" Text="Visitors..." ID="hlVisitors" runat="server" ToolTip="Manage Visitor Data" />
                </div>
                <hr />
<%--<%    }%>--%>
                <h4>Welcome Page Image</h4>
                <div style="width:100%;text-align:center;">
                    <asp:CheckBox runat="server" ID="chkDoLakeGIF" Text="Lake Applet" ToolTip="Apply Lake animation to welcome image selected below (under construction)" />
                </div>
	            <div style="justify-content:center;width:100%">
                    <asp:RadioButtonList ID="rblImages" runat="server" RepeatDirection="Horizontal" RepeatColumns="4" RepeatLayout="Table">
                    </asp:RadioButtonList>
                </div>
            </div>
        </div>
        <div class="form-group mx-auto">
            <asp:Button runat="server" OnClick="SaveChanges_Click" Text="Save Changes" CssClass="btn btn-default btn-light" />
        </div>
    </div>

</asp:Content>
