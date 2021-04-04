<%@ Language=VBScript %>
<!-- #include virtual="/Includes/Constants.inc.asp"-->
<%
Application.Lock
If Application("fDebugMode") or Application("fTraceMode") Then LogMessage Application("ApplicationLogFilename"), now & ": DEBUG: Index.asp Session(""ID""): " & Session("ID")
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
	rsLinks.Open "SELECT * FROM MenuEntries where (ButtonLabel like '" & MenuLabel & "' and ParentID=" & ParentID & ") order by ButtonLabel,ParentID,Label", Session("adoConn"), adOpenForwardOnly, adLockOptimistic
	
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
If Not Session("ActiveXControls") Then
    If Session("ButtonColor") = "Surprise Me!" Then
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
        'Response.Write("Today's Color is " & MColor & "!")
    Else	'Not "Surprise Me!"
	    MColor = Session("ButtonColor")
	    BColor = "Dark" & Session("ButtonColor")
    End If	'Session("ButtonColor") = "Surprise Me!"
%>
	<a href="http://www.wayne.sss.sungard.com/" target="_top"><img src="Images/Logos/BLACKSUNGARDLOGO112.JPG" alt="Wayne SunGard Intranet Site" border="0" width="112" height="38"></a><p>
	<a href="/WebTools/WebTools.htm" target="Body"><img src="Images/Buttons/<%=MColor%>WebTools.gif" alt="Web Tools/Links..." border="0" width="112" height="26"></a><br>
	<a href="/WebTools/SoftwareIDX.asp" target="Body"><img src="Images/Buttons/<%=MColor%>SoftwareLinks.gif" alt="Software Development Tools/Links..." border="0" width="112" height="26"></a><br>
	<a href="/Software/Microsoft.asp" target="Body"><img src="Images/Logos/msft.gif" alt="Microsoft" border="0" width="91" height="21"></a><br>
	<a href="Aircraft/" target="_top"><img src="Images/Buttons/<%=MColor%>Aircraft.gif" alt="Ken's Aircraft Image Archive" border="0" width="112" height="26"></a><br>
	<a href="/Games/GameLinks.asp" target="Body"><img src="Images/Buttons/<%=MColor%>GameLinks.gif" alt="Game Links..." border="0" width="112" height="26"></a><br>
	<a href="/Hobby/hobbyidx.asp" target="Body"><img src="Images/Buttons/<%=MColor%>HobbyStuff.gif" alt="Ken's Hobby Stuff..." border="0" width="112" height="26"></a><br>
	<a href="Military/" target="_top"><img src="Images/Buttons/<%=MColor%>MilitaryLinks.gif" alt="Ken's Military Web Site" border="0" width="112" height="26"></a><br>
	<a href="/Music/Tunage.asp" target="Body"><img src="Images/Buttons/<%=MColor%>Music.gif" alt="Tunage" border="0" width="112" height="26"></a><br>
	<a href="NASA/Welcome.htm" target="Body"><img src="Images/Buttons/<%=MColor%>NASAlinks.gif" alt="NASA Index" border="0" width="112" height="26"></a><br>
	<a href="Ships/" target="_top"><img src="Images/Buttons/<%=MColor%>ShipImages.gif" alt="Ken's Ship Image Archive" border="0" width="112" height="26"></a><br>
	<a href="/SciFi/SciFi.asp" target="Body"><img src="Images/Buttons/<%=MColor%>SciFiImages.gif" alt="Ken's SciFi Image Archive" border="0" width="112" height="26"></a><p/>
    <hr style="width:80%"/>
    <div style="font-family:Arial;font-size:small;font-style:italic;font-weight:bold;text-align:left;padding-left:10px">
        <a href="/Books/BooksList.asp" target="Body">Library (Books)</a><br />
        <a href="/Software/SoftwareList.asp" target="Body">Software Library</a><br />
        <div style="padding-left:15px">
            <a href="/Software/Apple2List.asp" target="Body">Apple ][</a><br />
            <a href="/Software/PCList.asp" target="Body">Windows/DOS</a><br />
            <a href="/Software/GamesList.asp" target="Body">Games</a><br />
            <div style="padding-left:20px">
                <a href="/Software/Apple2GamesList.asp" target="Body">Apple ][</a><br />
                <a href="/Software/PCGamesList.asp" target="Body">Windows/DOS</a><br />
                <a href="/Software/XBOXGamesList.asp" target="Body">XBOX</a><br />
                <a href="/Software/PS2GamesList.asp" target="Body">PS2</a><br />
            </div>
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
	<a href="Index/movidx.htm" target="Body"><img src="Images/Buttons/<%=MColor%>Movies.gif" border="0" width="112" height="26"></a><br>
	<img src="Images/Buttons/<%=MColor%>TVlinks.gif" width="112" height="26">
<% 
End If	'Not Session("ActiveXControls")
%>
	<p>
	<!--<img src="Images/Animated/SURPRISE.GIF" alt="This doesn't do anything, I just thought it was cool...!" border="0" width="34" height="37">-->
<%
EndTime = Now()
Response.Write "<!-- Script Complete: " & EndTime & " (" & Second(EndTime-StartTime) & " Seconds elapsed) -->" & CHR(13)
Response.Write "<div style=""position: absolute; top: 850px; left: 25px; z-index=0""><font size=1><b>Loaded in " & Second(EndTime-StartTime) & " Seconds</b></font></div>" & CHR(13)
%>
</center>
</body>
</html>
