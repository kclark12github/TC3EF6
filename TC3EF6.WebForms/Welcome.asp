<%@ Language="JScript"%>
<!-- #include virtual="/Includes/Constants.inc.asp"-->
<script Language="VBScript" runat="Server">
Application.Lock
If Application("fDebugMode") or Application("fTraceMode") Then 
	Set LogFile = Session("FileSystem").OpenTextFile(Application("ApplicationLogFilename"), ForAppending, TRUE)
	LogFile.WriteLine(now & ": DEBUG: Welcome.asp Session(""ID""): " & Session("ID"))
	LogFile.Close
	Set LogFile = Nothing
End If

'Supported the now defunct FPHitCount webbot
'Set LogFile = Session("FileSystem").OpenTextFile(Application("WelcomeCountFilename"), ForWriting, TRUE)
'LogFile.WriteLine("FPCountFile " & String(11 - Len(Application("Visitors")), "0") & Application("Visitors") - 1)
'LogFile.Close

Set LogFile = Session("FileSystem").OpenTextFile(Application("VisitorCountFilename"), ForWriting, TRUE)
LogFile.WriteLine(Application("Visitors"))
LogFile.Close

Set LogFile = Nothing
Application.UnLock
</script>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>

<head>
<link REL="SHORTCUT ICON" HREF="/Images/Icons/X-Files.ico">
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="GENERATOR" content="Microsoft FrontPage 2.0">
<title>Welcome...! We've been expecting you...</title>

</head>
<basefont face="Verdana, Arial, Helvetica">

<body bgcolor="#FFFFFF" text="#000080" vlink="#000080" bgproperties="fixed" topmargin="0" leftmargin="0">
<script language="VBSCRIPT">
<!--
Sub GoToAdmin()
	top.location.href = "<%=Application("AdminPage")%>"
End Sub
    -->
'</script>
<table border="0" width="100%" bgcolor="#000000" !width="615">
	<tr>
		<td height="570">
			<table border="0" width="100%" bgcolor="#000000" !width="615">
				<tr>
					<td width="50%" align="center"> <h1 align="center"><font color="#FFFFFF" face="Arial"><i><%
var FirstName = Session("FirstName")
var Owner = Session("Owner")
var HitCountBot = "webbot i-image=4 bot=HitCounter i-digits=0 preview=&lt;strong&gt;Hit Counter&lt;/strong&gt; u-custom i-resetvalue=0 startspan --" + "><img SRC=\"_vti_bin/fpcount.exe/?Page=Welcome.asp|Image=4\" ALT=\"Hit Counter\"><!--" + "webbot bot=HitCounter endspan i-checksum=7723"
if (FirstName.length > 0)
{
	if (Owner)
	{
%> Welcome Back!<br>
        Boss Dude...<br>
        <%;%> <%
	}
	else
	{
%> Welcome Back!<br>
        <%=FirstName%><br>
        <%;%> <%
	}
}
else 
{
%> Welcome!<br>
        <%;%> <%
}
%> </i></font></h1>
						<p align="center"><font color="#FFFFFF" face="Arial"><strong>You are Visitor<br>
						 <%= String(Application("Visitors")).replace(/(.)(?=(\d{3})+$)/g, '$1,') %> </strong></font> </p>
<%
	if (Owner)
	{
		if (Application("ActiveSessions") == 1)
		{
%>
						<font size="2" color="#FFFFFF" face="Arial"><b><i><%= Session("FirstName")%>, this is the only session connected to your site...</font>
<%
		}
		else
		{
%>
						<font size="2" color="#FFFFFF" face="Arial"><b><i><%= Session("FirstName")%>, there are <%=Application("ActiveSessions")%> sessions connected to your site...</font>
<%
		}
	}
%>
					</td>
					<td align="center" rowspan="2" width="50%" valign="top"> 
<!-- #include virtual="/Includes/DoLakeGIF.inc.asp"-->
<%
DoLakeGIF();
%> 
					</td>
				</tr>
<%
	if (!Owner)
	{
%>
				<tr>
					<td width="50%" valign="top" align="center"> <font size="2" color="#FFFFFF" face="Arial"><b><i>We've been expecting you...</b></i></font> </td>
				</tr>
<%
	}
%>
			</table>
		</td>
	</tr>
</table>

<hr>

<p align="center"> <font face="Arial" size="-1">Thanks for
stopping by... You can find everything you need here to create
great web sites! On the left here you'll find links to all the
areas of my site. So relax, browse around, listen to some tunes,
have a little wine, a little cheese... </font> </p>

<p align="center"> <font face="Arial" size="-1">Feel free to
steal whatever you please... that's how folks learn... To look
behind the scenes, simply <em>right-mouse-click</em> on the page
you'd like to see, and select <strong><u>V</u></strong><strong>iew
Source</strong> from the pop-up menu... that should pull up the
ASCII HTML representing the page in your NotePad... or click on
the lake image above to see how that is done... it's really not
that hard... </font> </p>

<p align="center"> <font face="Arial" size="-1">Have Fun, and
stop back often...!</font> </p>
<%
if (FirstName.length == 0)
{
%>
<p align="left"><font face="Arial" size="-1">P.S. Sign in, and
you can customize this site for your browsing pleasure...</font></p>

<table width="100%">
    <tr>
        <td align="center"> <table background="/Images/Backgrounds/back7.gif" width="100%">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td valign="middle" align="center"> <form action name="Admin" method="POST">
<!--                    <p><input type="button" name="B1" value="Preferences" onclick="GoToAdmin()"></p>-->
                    <p><input type="button" name="B1" value="Preferences" onclick="top.location.href='<%=Application("AdminPage")%>'"></p>
                </form>
                </td>
            </tr>
        </table>
        </td>
    </tr>
</table>
<%
}
%>
<table width="100%" border="0">
	<tr><td width="20">&nbsp;</td></tr>
	<tr>
		<td>
<!-- #include virtual="/Includes/PlayRandomMIDI.inc.asp"--><!--webbot bot="Include" u-include="/Includes/footer.htm" tag="BODY" startspan -->

<hr>

<p><font color="#000000" size="1" face="Arial"><em>If you
experience any problems with this page, please contact:</em></font><font color="#000000" face="Arial"><em><br>
</em></font><font color="#000000" size="1" face="Arial"><em><b>WebMaster:</b></em><em>
</em></font><a href="mailto:<%=Session("WebMasterEmail")%>"><font color="#000000" size="1" face="Arial"><em><b><%=Session("WebMasterName")%></b></em></font></a></p>
<div align="center"><center>

<table border="0" width="100%">
    <tr>
        <td align="right" width="33%"><img src="/Images/Logos/MSnotepad.gif" width="114" height="43"></td>
        <td align="center" width="33%"><font color="#000080" size="1" face="ARIAL, HELVETICA"><b>Best experienced with<br>
        </b></font><a href="http://www.microsoft.com/ie/" target="_blank"><img src="/Images/Logos/ie_static.GIF" alt="Microsoft Internet Explorer" border="0" width="88" height="31" vsapce="7"></a><br>
        <font color="#000080" size="1" face="ARIAL, HELVETICA"><b>Click
        here to start.</b></font> </td>
        <td width="33%"><a href="http://www.microsoft.com/frontpage/" target="_top"><img src="/Images/Logos/fp114a.gif" alt="Microsoft FrontPage" border="0" width="114" height="43"> </a></td>
    </tr>
</table>
</center></div>

<p align="center"><font color="#000080" size="1" face="Arial"><i>--
Page Last modified </i><em><strong>Tuesday, August 24, 2004 01:06 AM</strong></em><i> --</i></font></p>
<!--webbot bot="Include" endspan i-checksum="51161" -->
		</td>
	</tr>
</table>
</body>
</html>
