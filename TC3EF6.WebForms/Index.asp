<%@ Language=VBScript %>
<!-- #include virtual="/Includes/Constants.inc.asp"-->
<%
Application.Lock
If Application("fDebugMode") or Application("fTraceMode") Then 
	Set LogFile = Session("FileSystem").OpenTextFile(Application("ApplicationLogFilename"), ForAppending, TRUE)
	LogFile.WriteLine(now & ": DEBUG: Index.asp Session(""ID""): " & Session("ID"))
	LogFile.Close
	Set LogFile = Nothing
End If
Application.UnLock
%>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="GENERATOR" content="Microsoft FrontPage 4.0">
<title>Ken's Site Index</title>

<STYLE TYPE="text/css">
<!--
DIV.Label 
{
	position:		relative;
	cursor: 		hand;
	top:			-24px;
	left:			10px;
	width:			112px;
	height:			26px;
	z-index:		1;
	font-family:	arial;
	font-size: 		09pt;
	font-weight:	bold;
	font-style:		italic;
	color:			white;
	text-align:		left;
	filter:progid:DXImageTransform.Microsoft.dropshadow(OffX=2, OffY=2, Color='black', Positive='true');
	}
IMG.iconNav
{
	//position: relative;
	//top: 2;
	align:			center;
	cursor:			hand;
}
-->
</STYLE>
<base target="_self">
</head>

<body bgcolor="#000000" text="#FFFFFF" link="#FFFFFF" vlink="#FFFFFF" bgproperties="fixed">
<basefont face="Verdana, Arial, Helvetica">
<center>
<%
StartTime = Now()
Response.Write "<!-- Script Started: " & StartTime & "-->"
'Server.ScriptTimeout = 600

Set cmdTemp = Server.CreateObject("ADODB.Command")

Sub PopulateMenuFromDisk(MenuLabel, ParentID)
	'Go to the folder indicated by the Menu Label and drill down through 
	'all the subfolders, processing shortcuts as we go...
End Sub
Sub PopulateMenu(MenuLabel, ParentID)
	dim rsLinks
	Set rsLinks = Server.CreateObject("ADODB.Recordset")
	rsLinks.Open "SELECT * FROM MenuEntries where (ButtonLabel like '" & MenuLabel & "' and ParentID=" & ParentID & ") order by ButtonLabel,ParentID,Label", Session("KFC"), adOpenForwardOnly, adLockOptimistic
	
	Do While Not rsLinks.EOF
		Response.Write "	Ad """ & rsLinks("ID") & """, """ & rsLinks("Label") & """, """ & rsLinks("URL") & """, """ & rsLinks("ParentID") & """" & Chr(13)
		If fDebugMode Then Response.Write "<!-- rsLinks(""HasMembers"") = " & rsLinks("HasMembers") & "-->" & Chr(13)
		If rsLinks("HasMembers") Then PopulateMenu MenuLabel, rsLinks("ID")
		rsLinks.MoveNext
	Loop 
	rsLinks.Close
	Set rsLinks = Nothing
End Sub
%>
<SCRIPT LANGUAGE="VBScript">
Sub GoToAdmin()
	parent.frames("Body").location.href = "<%=Application("AdminPage")%>"
	'top.location.href = "<%=Application("AdminPage")%>"
End Sub
Sub ExitSession()
	parent.frames("Body").location.href = "<%=Application("AdminPage")%>"
End Sub
</SCRIPT>

<%
If Session("ActiveXControls") Then
	If Session("MajorVersion") > 3 Then
%>
<!--
<OBJECT classid="CLSID:F5131C24-E56D-11CF-B78A-444553540000" codeBase="http://activex.microsoft.com/controls/iptdweb/ikcntrls.cab#version=1,0,0,9" 
	height=0 id=Menu style="LEFT: 0px; TOP: 0px" width=0 align="Center">
    <param name="_Version" value="65536">
    <param name="_ExtentX" value="21">
    <param name="_ExtentY" value="21">
    <param name="_StockProps" value="0">
    <embed TYPE="application/x-oleobject" NAME="Menu" 
    	classid="CLSID:F5131C24-E56D-11CF-B78A-444553540000" 
    	WIDTH="112" HEIGHT="26" 
    	PARAM__Version="65536" 
    	PARAM__ExtentX="2646" 
    	PARAM__ExtentY="1323" 
    	PARAM__StockProps="0">
</OBJECT>
-->
<OBJECT classid="CLSID:F5131C24-E56D-11CF-B78A-444553540000" codeBase="http://activex.microsoft.com/controls/iptdweb/ikcntrls.cab#version=1,0,0,9" 
	height=0 id=Menu style="LEFT: 0px; TOP: 0px" width=0 align="Center">
    <param name="_Version" value="65536">
    <param name="_ExtentX" value="21">
    <param name="_ExtentY" value="21">
    <param name="_StockProps" value="0">
    <embed TYPE="application/x-oleobject" NAME="Menu" 
    	classid="CLSID:F5131C24-E56D-11CF-B78A-444553540000" 
    	WIDTH="0" HEIGHT="0" 
    	PARAM__Version="65536" 
    	PARAM__ExtentX="2646" 
    	PARAM__ExtentY="1323" 
    	PARAM__StockProps="0">
</OBJECT>

<div style="position: absolute; top: 000px; left: 10px; width: 112px; height: 38px; z-index=0">
	<IMG ID=iSunGard CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=38 BORDER=0 ALT="SunGard/Wayne Intranet Site">
</div>
<div style="position: absolute; top: 042px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iWeb CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Web Links...">
	<DIV ID=lWeb CLASS="Label">Web Links...</div>
</div>
<div style="position: absolute; top: 068px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iSoftware CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Software...">
	<DIV ID=lSoftware CLASS="Label">Software...</div>
</div>
<div style="position: absolute; top: 094px; left: 21px; width: 91px; height: 21px; z-index=0">
	<IMG ID=iMicrosoft CLASS="iconNav" SRC="" WIDTH=91 HEIGHT=21 BORDER=0 ALT="Microsoft Links..."><br>
</div>
<div style="position: absolute; top: 115px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iAircraft CLASS="iconNav" SRC="images/Buttons/xDarkBlueBar.gif" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Aircraft...">
	<DIV ID=lAircraft CLASS="Label">Aircraft...</div>
</div>
<div style="position: absolute; top: 141px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iBooks CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Books...">
	<DIV ID=lBooks CLASS="Label">Books...</div>
</div>
<div style="position: absolute; top: 167px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iGames CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Games...">
	<DIV ID=lGames CLASS="Label">Games...</div>
</div>
<div style="position: absolute; top: 193px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iHobby CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Hobby...">
	<DIV ID=lHobby CLASS="Label">Hobby...</div>
</div>
<div style="position: absolute; top: 219px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iMilitary CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Military...">
	<DIV ID=lMilitary CLASS="Label">Military...</div>
</div>
<div style="position: absolute; top: 245px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iMovies CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Movies...">
	<DIV ID=lMovies CLASS="Label">Movies...</div>
</div>
<div style="position: absolute; top: 271px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iMusic CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Music...">
	<DIV ID=lMusic CLASS="Label">Music...</div>
</div>
<div style="position: absolute; top: 297px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iNASA CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="NASA...">
	<DIV ID=lNASA CLASS="Label">NASA...</div>
</div>
<div style="position: absolute; top: 323px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iSciFi CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="SciFi...">
	<DIV ID=lSciFi CLASS="Label">SciFi...</div>
</div>
<div style="position: absolute; top: 349px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iShips CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="Ships...">
	<DIV ID=lShips CLASS="Label">Ships...</div>
</div>
<div style="position: absolute; top: 375px; left: 10px; width: 112px; height: 26px; z-index=0">
	<IMG ID=iTV CLASS="iconNav" SRC="" WIDTH=112 HEIGHT=26 BORDER=0 ALT="TV...">
	<DIV ID=lTV CLASS="Label">TV...</div>
</div>
<div style="position: absolute; top: 425px; left: 10px; width: 112px; height: 26px; z-index=0">
	<form action="" name="Admin" method="POST">
		<p><input type="button" name="B1" value="Options..." onClick="parent.frames['Body'].location.href='<%=Application("AdminPage")%>'"></p>
	</form>
</div>
<%		If Session("Owner") Then	
			ConnectionString = Replace(Application("KFC.ConnectionString"), """", "'")
%>
	<!-- Application Object Connection String: <%= ConnectionString %> -->
	<!-- Session ADO Connection Object Connection String: <%= Session("KFC").ConnectionString %> -->
	<div style="position: absolute; top: 460px; left: 10px; width: 112px; height: 26px; z-index=0">
		<OBJECT 
			ID=uRefresh 
			CLASS="WebUIdx.uRefresh" CLASSID="CLSID:1C3CB9AD-ED8E-4287-B7F9-3F2731D24056" CODEBASE="\Downloads\Controls\WebUidx\WebUIdx.CAB#version=1,1,0,3"
			VIEWASTEXT>
			<PARAM NAME="_ExtentX" VALUE="2265">
			<PARAM NAME="_ExtentY" VALUE="677">
			<PARAM NAME="ConnectionString" VALUE="<%= ConnectionString %>">
			<PARAM NAME="UserID" VALUE="<%= Application("KFC.RuntimeUserName")%>">
			<PARAM NAME="Password" VALUE="<%= Application("KFC.RuntimePassword")%>">
			<PARAM NAME="TraceFile" VALUE="<%= Server.MapPath("/") & "\Logs\WebUIdx.log"%>">
			<PARAM NAME="WebRoot" VALUE="<%= Server.MapPath("/")%>">
		</OBJECT>
	</div>
<%		End If	'Session("Owner")	%>
<!--
<div style="position: absolute; top: 495px; left: 41px; width: 50px; height: 64px; z-index=0">
	<IMG ID=iSOF2K CLASS="iconNav" SRC="" WIDTH=50 HEIGHT=64 BORDER=0 ALT="Willow Grove Sounds of Freedom 2000...">
</div>
<div style="position: absolute; top: 535px; left: 41px; width: 50px; height: 64px; z-index=0">
	<IMG ID=iClarkHome CLASS="iconNav" SRC="" WIDTH=50 HEIGHT=64 BORDER=0 ALT="Clark Family WebSite...">
</div>
-->
<div style="position: absolute; top: 500px; left: 12px; width: 50px; height: 64px; z-index=0">
	<IMG ID=iSOF2K CLASS="iconNav" SRC="" WIDTH=50 HEIGHT=64 BORDER=0 ALT="Willow Grove Sounds of Freedom 2000...">
</div>
<div style="position: absolute; top: 500px; left: 65px; width: 60px; height: 58px; z-index=0">
	<IMG ID=iNFAS2K CLASS="iconNav" SRC="" WIDTH=60 HEIGHT=58 BORDER=0 ALT="NAS Oceana Neptune Festival 2000 Air Show...">
</div>
<div style="position: absolute; top: 565px; left: 40px; width: 50px; height: 64px; z-index=0">
	<IMG ID=iClarkHome CLASS="iconNav" SRC="" WIDTH=50 HEIGHT=64 BORDER=0 ALT="Clark Family WebSite...">
</div>
<div style="position: absolute; top: 700px; left: 36px; width: 60px; height: 59px; z-index=0">
	<IMG ID=iHome CLASS="iconNav" SRC="" WIDTH=60 HEIGHT=59 BORDER=0 ALT="Back to Ken's WebSite...">
</div>
<p>
<%
	Else		'Not Session("MajorVersion") > 3
%>
<center>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=38 id=iSunGard style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="804"><PARAM NAME="MyHeight" VALUE="38"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="456"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="38" PARAM_ExtentY="529" PARAM_BackColor="Black"></OBJECT>
	<p>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iWeb style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iWeb" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iSoftware style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iSoftware" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=21 id=iMicrosoft style="LEFT: 0px; TOP: 0px" width=91 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="1926"><PARAM NAME="_ExtentY" VALUE="445"><PARAM NAME="MyHeight" VALUE="21"><PARAM NAME="MyWidth" VALUE="91"><PARAM NAME="Height" VALUE="252"><PARAM NAME="Width" VALUE="1092"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iMicrosoft" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="91" HEIGHT="21" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iAircraft style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iAircraft" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iBooks style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iBooks" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iGames style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iGames" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iHobby style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iHobby" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iMilitary style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iMilitary" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iMusic style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iMusic" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iNASA style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iNASA" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iShips style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iShips" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iSciFi style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iSciFi" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT>
	<p>
	<form action="" name="Admin" method="POST">
		<p><input type="button" name="B1" value="Options..." onClick="parent.frames['Body'].location.href = '<%=Application("AdminPage")%>'"></p>
	</form>
	<p>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=59 id=iHome style="LEFT: 0px; TOP: 0px" width=60 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="1270"><PARAM NAME="_ExtentY" VALUE="1249"><PARAM NAME="MyHeight" VALUE="59"><PARAM NAME="MyWidth" VALUE="60"><PARAM NAME="Height" VALUE="708"><PARAM NAME="Width" VALUE="720"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iHome" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="60" HEIGHT="59" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT>
	<p>
	<font size="1" face="Arial"><em><strong>Coming Soon...</strong></em></font>
	<p>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iMovies style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iMovies" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT><br>
	<OBJECT classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" height=26 id=iTV style="LEFT: 0px; TOP: 0px" width=112 border = 0 VIEWASTEXT><PARAM NAME="_ExtentX" VALUE="2371"><PARAM NAME="_ExtentY" VALUE="550"><PARAM NAME="MyHeight" VALUE="26"><PARAM NAME="MyWidth" VALUE="112"><PARAM NAME="Height" VALUE="312"><PARAM NAME="Width" VALUE="1344"><PARAM NAME="BackColor" VALUE="Black"><PARAM NAME="Picture" VALUE=""><PARAM NAME="LoadPictureToCache" VALUE=""><PARAM NAME="ScreenX" VALUE="-576"><PARAM NAME="ScreenY" VALUE="-432"><EMBED TYPE="application/x-oleobject" NAME="iTV" classid="clsid:5E3E59C4-7847-11D0-9081-0080C76A0985" WIDTH="112" HEIGHT="26" PARAM__ExtentY="529" PARAM_BackColor="Black"></OBJECT>
</center>
<%
	End If		'Session("MajorVersion")
%>
<SCRIPT LANGUAGE="VBScript">
dim BColor, MColor, Buttons, Logos
Sub GetTodaysColors()
<%
	If Session("ButtonColor") = "Surprise Me!" Then
%>
	dim Colors(10), Method

	Method = 0
	LowerBound = 1
	UpperBound = 2
	Randomize
	Method = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)

	Randomize
	Select Case Method
		Case 1				' Allow Random Dark Buttons Brightening w/same Color when Selected...
			Colors(1) = "Blue"
			Colors(2) = "Red"
			Colors(3) = "Green"
			Colors(4) = "Purple"
			Colors(5) = "Gold"
			UpperBound = 5

			x = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)
			if x < UpperBound then
				x = 1
			end if
	
			MColor = Colors(x)
			BColor = "Dark" & MColor
		Case Else			' Force Gold Buttons Changing Color when Selected...
			Colors(1) = "Blue"
			Colors(2) = "Red"
			Colors(3) = "Green"
			Colors(4) = "Purple"
			Colors(5) = "DarkBlue"
			Colors(6) = "DarkRed"
			Colors(7) = "DarkGreen"
			Colors(8) = "DarkPurple"
			Colors(9) = "DarkGold"
			UpperBound = 9

			x = Int((UpperBound - LowerBound + 1) * Rnd + LowerBound)
			if x < UpperBound then
				x = 1
			end if
	
			MColor = Colors(x)
			BColor = "Gold"
	End Select
<%
	Else	'Not "Surprise Me!"
%>
	MColor = "<%=Session("ButtonColor")%>"
	BColor = "Dark<%=Session("ButtonColor")%>"
<%
	End If	'Session("ButtonColor") = "Surprise Me!"
%>
End Sub
'=============================================================================
Sub Ad (cde,lbl,menuitem,par)
	Menu.AddItem cde,lbl,menuitem,par
End Sub
'=============================================================================
Sub Window_onBeforeUnload()
	Menu.RemoveAllItems()
End Sub
'=============================================================================
<%
	If Session("MajorVersion") > 3 Then
%>
Sub Window_onLoad()
	GetTodaysColors

	' Figure out where we are...
	Path = location.href
	Buttons = "images/Buttons/"
	Logos = "images/Logos/"

	iSunGard.src = Logos & "gBLACKSUNGARDLOGO112.JPG"
	iMicrosoft.src = Logos & "gmsft.gif"
	iSOF2K.src = Buttons & "gsof2k.gif"
	iNFAS2K.src = Buttons & "gnfas2k.jpg"
	iClarkHome.src = Buttons & "gcleary.gif"
	iHome.src = Buttons & "ghome.gif"

	iWeb.src = Buttons & BColor & "Bar.gif"
	iSoftware.src = Buttons & BColor & "Bar.gif"
	iAircraft.src = Buttons & BColor & "Bar.gif"
	iBooks.src = Buttons & BColor & "Bar.gif"
	iGames.src = Buttons & BColor & "Bar.gif"
	iHobby.src = Buttons & BColor & "Bar.gif"
	iMilitary.src = Buttons & BColor & "Bar.gif"
	iMusic.src = Buttons & BColor & "Bar.gif"
	iNASA.src = Buttons & BColor & "Bar.gif"
	iShips.src = Buttons & BColor & "Bar.gif"
	iSciFi.src = Buttons & BColor & "Bar.gif"
	iMovies.src = Buttons & BColor & "Bar.gif"
	iTV.src = Buttons & BColor & "Bar.gif"

End Sub
'=============================================================================
Sub Document_onMouseOver()
	dim srcElement

	set srcElement = window.event.srcElement
	select case srcElement.id
		case "", "uRefresh"
			Exit Sub
		case "iSunGard"
			srcElement.src = Logos & "BLACKSUNGARDLOGO112.JPG"
		case "iMicrosoft"
			srcElement.src = Logos & "msft.gif"
		case "iSOF2K"
			srcElement.src = Buttons & "sof2k.gif"
		case "iNFAS2K"
			srcElement.src = Buttons & "nfas2k.jpg"
		case "iClarkHome"
			srcElement.src = Buttons & "cleary.gif"
		case "iHome"
			srcElement.src = Buttons & "home.gif"
		case "lWeb"
			iWeb.src = Buttons & MColor & "Bar.gif"
		case "lSoftware"
			iSoftware.src = Buttons & MColor & "Bar.gif"
		case "lAircraft"
			iAircraft.src = Buttons & MColor & "Bar.gif"
		case "lBooks"
			iBooks.src = Buttons & MColor & "Bar.gif"
		case "lGames"
			iGames.src = Buttons & MColor & "Bar.gif"
		case "lHobby"
			iHobby.src = Buttons & MColor & "Bar.gif"
		case "lMilitary"
			iMilitary.src = Buttons & MColor & "Bar.gif"
		case "lMusic"
			iMusic.src = Buttons & MColor & "Bar.gif"
		case "lNASA"
			iNASA.src = Buttons & MColor & "Bar.gif"
		case "lShips"
			iShips.src = Buttons & MColor & "Bar.gif"
		case "lSciFi"
			iSciFi.src = Buttons & MColor & "Bar.gif"
		case "lMovies"
			iMovies.src = Buttons & MColor & "Bar.gif"
		case "lTV"
			iTV.src = Buttons & MColor & "Bar.gif"
		case else
			srcElement.src = Buttons & MColor & "Bar.gif"
	end select
	Exit Sub
end Sub
'=============================================================================
Sub Document_onMouseOut()
	dim srcElement

	set srcElement = window.event.srcElement
	select case srcElement.id
		case "", "uRefresh"
			Exit Sub
		case "iSunGard"
			srcElement.src = Logos & "gBLACKSUNGARDLOGO112.JPG"
		case "iMicrosoft"
			srcElement.src = Logos & "gmsft.gif"
		case "iClarkHome"
			srcElement.src = Buttons & "gcleary.gif"
		case "iSOF2K"
			srcElement.src = Buttons & "gsof2k.gif"
		case "iNFAS2K"
			srcElement.src = Buttons & "gnfas2k.jpg"
		case "iHome"
			srcElement.src = Buttons & "ghome.gif"
		case "lWeb"
			iWeb.src = Buttons & BColor & "Bar.gif"
		case "lSoftware"
			iSoftware.src = Buttons & BColor & "Bar.gif"
		case "lAircraft"
			iAircraft.src = Buttons & BColor & "Bar.gif"
		case "lBooks"
			iBooks.src = Buttons & BColor & "Bar.gif"
		case "lGames"
			iGames.src = Buttons & BColor & "Bar.gif"
		case "lHobby"
			iHobby.src = Buttons & BColor & "Bar.gif"
		case "lMilitary"
			iMilitary.src = Buttons & BColor & "Bar.gif"
		case "lMusic"
			iMusic.src = Buttons & BColor & "Bar.gif"
		case "lNASA"
			iNASA.src = Buttons & BColor & "Bar.gif"
		case "lShips"
			iShips.src = Buttons & BColor & "Bar.gif"
		case "lSciFi"
			iSciFi.src = Buttons & BColor & "Bar.gif"
		case "lMovies"
			iMovies.src = Buttons & BColor & "Bar.gif"
		case "lTV"
			iTV.src = Buttons & BColor & "Bar.gif"
		case else
			srcElement.src = Buttons & BColor & "Bar.gif"
	end select
	Exit Sub
end Sub
'=============================================================================
Sub Document_onClick()
	dim srcElement
	set srcElement = window.event.srcElement

	select case window.event.srcElement.id
		case "iSunGard", "lSunGard"
			iSunGard_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iWeb", "lWeb"
			iWeb_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iSoftware", "lSoftware"
			iSoftware_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iMicrosoft", "lMicrosoft"
			iMicrosoft_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iAircraft", "lAircraft"
			iAircraft_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iBooks", "lBooks"
			iBooks_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iGames", "lGames"
			iGames_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iHobby", "lHobby"
			iHobby_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iMilitary", "lMilitary"
			iMilitary_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iMovies", "lMovies"
			iMovies_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iMusic", "lMusic"
			iMusic_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iNASA", "lNASA"
			iNASA_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iSciFi", "lSciFi"
			iSciFi_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iShips", "lShips"
			iShips_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iTV", "lTV"
			iTV_Menu Window.Event.ClientX, Window.Event.ClientY
		case "iClarkHome", "lClarkHome"
			top.location.href = "http://home.att.net/~clarkfd/"
		case "iSOF2K", "lSOF2K"
			parent.frames("Body").location.href = "http://home.earthlink.net/~kclark12/WGSOF2000.html"
		case "iNFAS2K", "lNFAS2K"
			parent.frames("Body").location.href = "http://home.earthlink.net/~kclark12/NFAS2000.html"
		case "iHome", "lHome"
			top.location.href = "http://" & location.host & "/"
	end select
end Sub
'=============================================================================
<%
	Else	'Not Session("MajorVersion") > 3
%>
Sub Ld(obj, pic)
	set lobj = obj
	lobj.LoadPictureToCache = pic
End Sub
'=============================================================================
Sub Show(obj, pic)
	set lobj = obj
	lobj.Picture = pic
End Sub
'=============================================================================
Sub Window_onLoad()
	GetTodaysColors

	Ld iSunGard, "http://" & location.host & "/Images/Logos/BLACKSUNGARDLOGO112.JPG"
	Ld iSunGard, "http://" & location.host & "/Images/Logos/gBLACKSUNGARDLOGO112.JPG"
	Show iSunGard, "http://" & location.host & "/Images/Logos/gBLACKSUNGARDLOGO112.JPG"

	Ld iWeb, "http://" & location.host & "/Images/Buttons/" & BColor & "WebTools.gif"
	Ld iWeb, "http://" & location.host & "/Images/Buttons/" & MColor & "WebTools.gif"
	Show iWeb, "http://" & location.host & "/Images/Buttons/" & BColor & "WebTools.gif"

	Ld iSoftware, "http://" & location.host & "/Images/Buttons/" & BColor & "SoftwareLinks.gif"
	Ld iSoftware, "http://" & location.host & "/Images/Buttons/" & MColor & "SoftwareLinks.gif"
	Show iSoftware, "http://" & location.host & "/Images/Buttons/" & BColor & "SoftwareLinks.gif"

	Ld iMicrosoft, "http://" & location.host & "/Images/Logos/msft.gif"
	Ld iMicrosoft, "http://" & location.host & "/Images/Logos/gmsft.gif"
	Show iMicrosoft, "http://" & location.host & "/Images/Logos/gmsft.gif"

	Ld iAircraft, "http://" & location.host & "/Images/Buttons/" & BColor & "Aircraft.gif"
	Ld iAircraft, "http://" & location.host & "/Images/Buttons/" & MColor & "Aircraft.gif"
	Show iAircraft, "http://" & location.host & "/Images/Buttons/" & BColor & "Aircraft.gif"

	Ld iBooks, "http://" & location.host & "/Images/Buttons/" & BColor & "Books.gif"
	Ld iBooks, "http://" & location.host & "/Images/Buttons/" & MColor & "Books.gif"
	Show iBooks, "http://" & location.host & "/Images/Buttons/" & BColor & "Books.gif"

	Ld iGames, "http://" & location.host & "/Images/Buttons/" & BColor & "GameLinks.gif"
	Ld iGames, "http://" & location.host & "/Images/Buttons/" & MColor & "GameLinks.gif"
	Show iGames, "http://" & location.host & "/Images/Buttons/" & BColor & "GameLinks.gif"
	
	Ld iHobby, "http://" & location.host & "/Images/Buttons/" & BColor & "HobbyStuff.gif"
	Ld iHobby, "http://" & location.host & "/Images/Buttons/" & MColor & "HobbyStuff.gif"
	Show iHobby, "http://" & location.host & "/Images/Buttons/" & BColor & "HobbyStuff.gif"
	
	Ld iMilitary, "http://" & location.host & "/Images/Buttons/" & BColor & "MilitaryLinks.gif"
	Ld iMilitary, "http://" & location.host & "/Images/Buttons/" & MColor & "MilitaryLinks.gif"
	Show iMilitary, "http://" & location.host & "/Images/Buttons/" & BColor & "MilitaryLinks.gif"
	
	Ld iMusic, "http://" & location.host & "/Images/Buttons/" & BColor & "Music.gif"
	Ld iMusic, "http://" & location.host & "/Images/Buttons/" & MColor & "Music.gif"
	Show iMusic, "http://" & location.host & "/Images/Buttons/" & BColor & "Music.gif"

	Ld iNASA, "http://" & location.host & "/Images/Buttons/" & BColor & "NASAlinks.gif"
	Ld iNASA, "http://" & location.host & "/Images/Buttons/" & MColor & "NASAlinks.gif"
	Show iNASA, "http://" & location.host & "/Images/Buttons/" & BColor & "NASAlinks.gif"

	Ld iShips, "http://" & location.host & "/Images/Buttons/" & BColor & "ShipImages.gif"
	Ld iShips, "http://" & location.host & "/Images/Buttons/" & MColor & "ShipImages.gif"
	Show iShips, "http://" & location.host & "/Images/Buttons/" & BColor & "ShipImages.gif"

	Ld iSciFi, "http://" & location.host & "/Images/Buttons/" & BColor & "SciFiImages.gif"
	Ld iSciFi, "http://" & location.host & "/Images/Buttons/" & MColor & "SciFiImages.gif"
	Show iSciFi, "http://" & location.host & "/Images/Buttons/" & BColor & "SciFiImages.gif"

	Ld iHome, "http://" & location.host & "/Images/Buttons/home.gif"
	Ld iHome, "http://" & location.host & "/Images/Buttons/ghome.gif"
	Show iHome, "http://" & location.host & "/Images/Buttons/ghome.gif"

	Ld iMovies, "http://" & location.host & "/Images/Buttons/" & BColor & "Movies.gif"
	Ld iMovies, "http://" & location.host & "/Images/Buttons/" & MColor & "Movies.gif"
	Show iMovies, "http://" & location.host & "/Images/Buttons/" & BColor & "Movies.gif"

	Ld iTV, "http://" & location.host & "/Images/Buttons/" & BColor & "TVlinks.gif"
	Ld iTV, "http://" & location.host & "/Images/Buttons/" & MColor & "TVlinks.gif"
	Show iTV, "http://" & location.host & "/Images/Buttons/" & BColor & "TVlinks.gif"
End Sub
'=============================================================================
Sub iSunGard_MouseEnter()
	Show iSunGard, "http://" & location.host & "/Images/Logos/BLACKSUNGARDLOGO112.JPG"
End Sub
Sub iSunGard_MouseExit()
	Show iSunGard, "http://" & location.host & "/Images/Logos/gBLACKSUNGARDLOGO112.JPG"
End Sub
Sub iSunGard_Click()
	iSunGard_Menu iSunGard.ScreenX + 112, iSunGard.ScreenY
End Sub
'=============================================================================
Sub iWeb_MouseEnter()
	Show iWeb, "http://" & location.host & "/Images/Buttons/" & MColor & "WebTools.gif"
End Sub
Sub iWeb_MouseExit()
	Show iWeb, "http://" & location.host & "/Images/Buttons/" & BColor & "WebTools.gif"
End Sub
Sub iWeb_Click()
	iWeb_Menu iWeb.ScreenX + 112, iWeb.ScreenY
End Sub
'=============================================================================
Sub iSoftware_MouseEnter()
	Show iSoftware, "http://" & location.host & "/Images/Buttons/" & MColor & "SoftwareLinks.gif"
End Sub
Sub iSoftware_MouseExit()
	Show iSoftware, "http://" & location.host & "/Images/Buttons/" & BColor & "SoftwareLinks.gif"
End Sub
Sub iSoftware_Click()
	iSoftware_Menu iSoftware.ScreenX + 112, iSoftware.ScreenY
End Sub
'=============================================================================
Sub iMicrosoft_MouseEnter()
	Show iMicrosoft, "http://" & location.host & "/Images/Logos/msft.gif"
End Sub
Sub iMicrosoft_MouseExit()
	Show iMicrosoft, "http://" & location.host & "/Images/Logos/gmsft.gif"
End Sub
Sub iMicrosoft_Click()
	iMicrosoft_Menu iMicrosoft.ScreenX + 91, iMicrosoft.ScreenY
End Sub
'=============================================================================
Sub iAircraft_MouseEnter()
	Show iAircraft, "http://" & location.host & "/Images/Buttons/" & MColor & "Aircraft.gif"
End Sub
Sub iAircraft_MouseExit()
	Show iAircraft, "http://" & location.host & "/Images/Buttons/" & BColor & "Aircraft.gif"
End Sub
Sub iAircraft_Click()
	iAircraft_Menu iAircraft.ScreenX + 112, iAircraft.ScreenY
End Sub
'=============================================================================
Sub iBooks_MouseEnter()
	Show iBooks, "http://" & location.host & "/Images/Buttons/" & MColor & "Books.gif"
End Sub
Sub iBooks_MouseExit()
	Show iBooks, "http://" & location.host & "/Images/Buttons/" & BColor & "Books.gif"
End Sub
Sub iBooks_Click()
	iBooks_Menu iBooks.ScreenX + 112, iBooks.ScreenY
End Sub
'=============================================================================
Sub iGames_MouseEnter()
	Show iGames, "http://" & location.host & "/Images/Buttons/" & MColor & "GameLinks.gif"
End Sub
Sub iGames_MouseExit()
	Show iGames, "http://" & location.host & "/Images/Buttons/" & BColor & "GameLinks.gif"
End Sub
Sub iGames_Click()
	iGames_Menu iGames.ScreenX + 112, iGames.ScreenY
End Sub
'=============================================================================
Sub iHobby_MouseEnter()
	Show iHobby, "http://" & location.host & "/Images/Buttons/" & MColor & "HobbyStuff.gif"
End Sub
Sub iHobby_MouseExit()
	Show iHobby, "http://" & location.host & "/Images/Buttons/" & BColor & "HobbyStuff.gif"
End Sub
Sub iHobby_Click()
	iHobby_Menu iHobby.ScreenX + 112, iHobby.ScreenY
End Sub
'=============================================================================
Sub iMilitary_MouseEnter()
	Show iMilitary, "http://" & location.host & "/Images/Buttons/" & MColor & "MilitaryLinks.gif"
End Sub
Sub iMilitary_MouseExit()
	Show iMilitary, "http://" & location.host & "/Images/Buttons/" & BColor & "MilitaryLinks.gif"
End Sub
Sub iMilitary_Click()
	top.location.href = "/Military/"
End Sub
'=============================================================================
Sub iMusic_MouseEnter()
	Show iMusic, "http://" & location.host & "/Images/Buttons/" & MColor & "Music.gif"
End Sub
Sub iMusic_MouseExit()
	Show iMusic, "http://" & location.host & "/Images/Buttons/" & BColor & "Music.gif"
End Sub
Sub iMusic_Click()
	parent.frames("Body").location.href = "/Tunage.asp"
End Sub
'=============================================================================
Sub iNASA_MouseEnter()
	Show iNASA, "http://" & location.host & "/Images/Buttons/" & MColor & "NASAlinks.gif"
End Sub
Sub iNASA_MouseExit()
	Show iNASA, "http://" & location.host & "/Images/Buttons/" & BColor & "NASAlinks.gif"
End Sub
Sub iNASA_Click()
	parent.frames("Body").location.href = "/NASA/Welcome.htm"
End Sub
'=============================================================================
Sub iShips_MouseEnter()
	Show iShips, "http://" & location.host & "/Images/Buttons/" & MColor & "ShipImages.gif"
End Sub
Sub iShips_MouseExit()
	Show iShips, "http://" & location.host & "/Images/Buttons/" & BColor & "ShipImages.gif"
End Sub
Sub iShips_Click()
	iShips_Menu iShips.ScreenX + 112, iShips.ScreenY
End Sub
'=============================================================================
Sub iSciFi_MouseEnter()
	Show iSciFi, "http://" & location.host & "/Images/Buttons/" & MColor & "SciFiImages.gif"
End Sub
Sub iSciFi_MouseExit()
	Show iSciFi, "http://" & location.host & "/Images/Buttons/" & BColor & "SciFiImages.gif"
End Sub
Sub iSciFi_Click()
	top.location.href = "/SciFi/"
End Sub
'=============================================================================
Sub iHome_MouseEnter()
	Show iHome, "http://" & location.host & "/Images/Buttons/home.gif"
End Sub
Sub iHome_MouseExit()
	Show iHome, "http://" & location.host & "/Images/Buttons/ghome.gif"
End Sub
Sub iHome_Click()
	top.location.href = "http://" & location.host & "/"
End Sub
'=============================================================================
Sub iMovies_MouseEnter()
	Show iMovies, "http://" & location.host & "/Images/Buttons/" & MColor & "Movies.gif"
End Sub
Sub iMovies_MouseExit()
	Show iMovies, "http://" & location.host & "/Images/Buttons/" & BColor & "Movies.gif"
End Sub
Sub iMovies_Click()
	parent.frames("Body").location.href = "/Index/movidx.htm"
End Sub
'=============================================================================
Sub iTV_MouseEnter()
	Show iTV, "http://" & location.host & "/Images/Buttons/" & MColor & "TVlinks.gif"
End Sub
Sub iTV_MouseExit()
	Show iTV, "http://" & location.host & "/Images/Buttons/" & BColor & "TVlinks.gif"
End Sub
Sub iTV_Click()
	parent.frames("Body").location.href = "/Index/tvidx.htm"
End Sub
'=============================================================================
<%
	End If	'Session("MajorVersion") > 3
%>
Sub Menu_OnClick(id)
	'On Error Resume Next
	
	URL = Menu.GetItemValue(id)
	'Alert("URL: " & URL & " (lcase(Left(URL,7)) = """ & lcase(Left(URL,7)) & """)")

	If lcase(Left(URL,7)) = "http://" or lcase(Left(URL,8)) = "https://" Then
		'08/28/00: Open in &New Window isn't working, so until that's worked-out...
		Window.Open URL, "_top", "toolbar=yes, menubar=yes, location=yes, directories=no, scrollbars=yes, status=yes, resizable=yes"
		'top.location.href = URL
	Else
		Select Case URL
			Case "/SciFi/SAAB/", "/BooksOnLine/", "/Aircraft/", "/Ships/", "/SciFi/", "/Military/"
				top.location.href = URL
			Case Else
				parent.frames("Body").location.href = URL
		End Select
	End If
End Sub
'=============================================================================
<!-- #include virtual="/Index/SunGard.inc.asp"-->
<!-- #include virtual="/Index/Web.inc.asp"-->
<!-- #include virtual="/Index/Software.inc.asp"-->
<!-- #include virtual="/Index/Microsoft.inc.asp"-->
<!-- #include virtual="/Index/Aircraft.inc.asp"-->
<!-- #include virtual="/Index/Books.inc.asp"-->
<!-- #include virtual="/Index/Games.inc.asp"-->
<!-- #include virtual="/Index/Hobby.inc.asp"-->
<!-- #include virtual="/Index/Military.inc.asp"-->
<!-- #include virtual="/Index/Music.inc.asp"-->
<!-- #include virtual="/Index/NASA.inc.asp"-->
<!-- #include virtual="/Index/Ships.inc.asp"-->
<!-- #include virtual="/Index/SciFi.inc.asp"-->
<!-- #include virtual="/Index/Home.inc.asp"-->
<!-- #include virtual="/Index/Movies.inc.asp"-->
<!-- #include virtual="/Index/TV.inc.asp"-->
'=============================================================================
</script>
<%
Else	'Not Session("ActiveXControls")
%>
	<a href="http://www.wayne.sss.sungard.com/" target="_top"><img src="Images/Logos/BLACKSUNGARDLOGO112.JPG" alt="Wayne SunGard Intranet Site" border="0" width="112" height="38"></a><p>
	<a href="/WebTools/WebTools.htm" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>WebTools.gif" alt="Web Tools/Links..." border="0" width="112" height="26"></a><br>
	<a href="/WebTools/SoftwareIDX.asp" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>SoftwareLinks.gif" alt="Software Development Tools/Links..." border="0" width="112" height="26"></a><br>
	<a href="/Software/Microsoft.asp" target="Body"><img src="Images/Logos/msft.gif" alt="Microsoft" border="0" width="91" height="21"></a><br>
	<a href="Aircraft/" target="_top"><img src="Images/Buttons/<%=Session("ButtonColor")%>Aircraft.gif" alt="Ken's Aircraft Image Archive" border="0" width="112" height="26"></a><br>
	<a href="/Games/GameLinks.asp" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>GameLinks.gif" alt="Game Links..." border="0" width="112" height="26"></a><br>
	<a href="/Hobby/hobbyidx.asp" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>HobbyStuff.gif" alt="Ken's Hobby Stuff..." border="0" width="112" height="26"></a><br>
	<a href="Military/" target="_top"><img src="Images/Buttons/<%=Session("ButtonColor")%>MilitaryLinks.gif" alt="Ken's Military Web Site" border="0" width="112" height="26"></a><br>
	<a href="/Music/Tunage.asp" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>Music.gif" alt="Tunage" border="0" width="112" height="26"></a><br>
	<a href="NASA/Welcome.htm" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>NASAlinks.gif" alt="NASA Index" border="0" width="112" height="26"></a><br>
	<a href="Ships/" target="_top"><img src="Images/Buttons/<%=Session("ButtonColor")%>ShipImages.gif" alt="Ken's Ship Image Archive" border="0" width="112" height="26"></a><br>
	<a href="/SciFi/SciFi.asp" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>SciFiImages.gif" alt="Ken's SciFi Image Archive" border="0" width="112" height="26"></a><p/>
    <hr style="width:80%"/>
    <div style="font-family:Arial;font-size:small;font-style:italic;font-weight:bold;text-align:left;padding-left:10px">
        <a href="/Books/BooksList.asp" target="Body">Library (Books)</a><br />
        <a href="/Software/SoftwareList.asp" target="Body">Software Library</a><br />
        <div style="padding-left:15px">
            <a href="/Software/Apple2List.asp" target="Body">Software - Apple ][</a><br />
            <a href="/Software/PCList.asp" target="Body">Software - PC</a><br />
            <a href="/Software/Apple2GamesList.asp" target="Body">Games - Apple ][</a><br />
            <a href="/Software/PCGamesList.asp" target="Body">Games - PC</a><br />
        </div>
        <p>Hobby...</p>
        <a href="/Hobby/KitsList.asp" target="Body">Kits</a><br />
        <div style="padding-left:15px">
            <a href="/Hobby/AircraftModelsList.asp" target="Body">Aircraft</a><br />
            <a href="/Hobby/ArmorModelsList.asp" target="Body">Armor</a><br />
            <a href="/Hobby/NavalModelsList.asp" target="Body">Naval</a><br />
            <a href="/Hobby/SciFiModelsList.asp" target="Body">SciFi</a><br />
        </div>
        <a href="/Hobby/DecalsList.asp" target="Body">Decals</a><br />
        <a href="/Hobby/DetailSetsList.asp" target="Body">Detail Sets</a><br />
    </div>
   <hr style="width:80%"/>
	<p/>
	<form action="" name="Admin" method="POST">
		<p><input type="button" name="B1" value="Options..." onClick="parent.frames['Body'].location.href = '<%=Application("AdminPage")%>'"></p>
	</form>
	<p>
	<a href="Default.asp" target="_top"><img src="Images/Buttons/home.gif" alt="Back to Ken's Home Page..." border="0" width="60" height="59"></a><p>
	<p style="font-family:Arial;font-size:small;font-style:italic;font-weight:bold;text-align:center;">Coming Soon...</p>
	<a href="Index/movidx.htm" target="Body"><img src="Images/Buttons/<%=Session("ButtonColor")%>Movies.gif" border="0" width="112" height="26"></a><br>
	<img src="Images/Buttons/<%=Session("ButtonColor")%>TVlinks.gif" width="112" height="26">
<% 
End If	'Session("ActiveXControls")
%>
	<p>
	<!--<img src="Images/Animated/SURPRISE.GIF" alt="This doesn't do anything, I just thought it was cool...!" border="0" width="34" height="37">-->
<%
EndTime = Now()
Response.Write "<!-- Script Complete: " & EndTime & " (" & Second(EndTime-StartTime) & " Seconds elapsed) -->" & CHR(13)
Response.Write "<div style=""position: absolute; top: 650px; left: 38px; z-index=0""><font size=1><b>Loaded in<br>" & Second(EndTime-StartTime) & " Seconds</b></font></div>" & CHR(13)
%>
</center>
</body>
</html>
