<%@ Language=JScript %>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<meta name="GENERATOR" content="Microsoft FrontPage 2.0">
<title>Ship Image Archive</title>
</head>

<body background="Images/Water.gif" bgcolor="#FFFFFF" text="#FFFFFF" link="#FFFFFF" vlink="#FFFFFF" bgproperties="fixed">

<h1><font color="#FFFFFF" face="Arial"><img src="Images/USflag.gif" width="100" height="55"> Ship Image
Archive</font></h1>

<hr>

<table border="0">
    <tr>
        <td><h2><font color="#FFFFFF" face="Arial">U.S. Navy
        Ships</font></h2>
        <ul>
            <li><a href="Carriers/Carriers.asp" target="Body"><font color="#FFFFFF" face="Arial"><em><strong>Aircraft
                Carriers...</strong></em></font></a></li>
            <li><a href="Battleships/Battleships.asp" target="Body"><font color="#FFFFFF" face="Arial"><em><strong>Battleships...</strong></em></font></a></li>
            <li><a href="Crusiers/Crusiers.asp" target="Body"><font color="#FFFFFF" face="Arial"><em><strong>Crusiers...</strong></em></font></a></li>
            <li><a href="Destroyers/Destroyers.asp" target="Body"><font color="#FFFFFF" face="Arial"><em><strong>Destroyers...</strong></em></font></a></li>
            <li><a href="Submarines/Submarines.asp" target="Body"><font color="#FFFFFF" face="Arial"><em><strong>Submarines...</strong></em></font></a></li>
        </ul>
        </td>
        <td><a href="Images/comehome.jpg" target="_top"><img src="Images/thcomehome.jpg" border="0" width="200" height="141"></a></td>
    </tr>
</table>

<hr>

<table border="0">
    <tr>
        <td valign="top"><h2><font face="Arial">Naval Aviation...</font></h2>
        <dl>
            <dd><font size="2" face="Arial"><em>(from the </em></font><a href="../Aircraft/" target="_top"><font size="2" face="Arial"><em><strong>Aircraft Image Archive</strong></em></font></a><font size="2" face="Arial"><em>)</em></font></dd>
        </dl>
        </td>
        <td><a href="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/CVW-2%20AIRWING%20FLYOVER.jpg" target="_top"><img src="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/thCVW-2%20AIRWING%20FLYOVER.jpg" border="0" width="150" height="112"></a></td>
    </tr>
    <tr>
        <td><ul>
            <li><a href="../Aircraft/Attack%20Aircraft/A-4%20Skyhawk/A-4%20Skyhawk.htm" target="Body"><font size="2" face="Arial"><em><strong>A-4
                Skyhawk</strong></em></font></a></li>
            <li><a href="../Aircraft/Attack%20Aircraft/A-6%20Intruder/A-6%20Intruder.htm" target="Body"><font size="2" face="Arial"><em><strong>A-6
                Intruder</strong></em></font></a></li>
            <li><a href="../Aircraft/Attack%20Aircraft/AV-8B%20Harrier/AV-8B%20Harrier.htm" target="Body"><font size="2" face="Arial"><em><strong>AV-8B
                Harrier</strong></em></font></a></li>
            <li><a href="../Aircraft/Blue%20Angels/BlueAngels.asp" target="Body"><font size="2" face="Arial"><em><strong>Blue
                Angels</strong></em></font></a></li>
            <li><a href="../Aircraft/Cargo%20Aircraft/CH-53%20Sea%20Stallion/CH-53%20Sea%20Stallion.htm" target="Body"><font size="2" face="Arial"><em><strong>CH-53
                Sea Stallion/Dragon</strong></em></font></a></li>
            <li><a href="../Aircraft/Electronic%20Warfare%20Aircraft/EA-6B%20Prowler/EA-6B%20Prowler.htm" target="Body"><font size="2" face="Arial"><em><strong>EA-6B
                Prowler</strong></em></font></a></li>
            <li><a href="../Aircraft/Electronic%20Warfare%20Aircraft/E-2C%20Hawkeye/E-2C%20Hawkeye.htm" target="Body"><font size="2" face="Arial"><em><strong>E-2C
                Hawkeye</strong></em></font></a></li>
            <li><a href="../Aircraft/Fighter%20Aircraft/F-4%20Phantom%20II/F-4%20Phantom%20II.htm" target="Body"><font size="2" face="Arial"><em><strong>F-4
                Phantom II</strong></em></font></a></li>
            <li><a href="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/F-14%20Tomcat.htm" target="Body"><font size="2" face="Arial"><em><strong>F-14
                Tomcat</strong></em></font></a></li>
            <li><a href="../Aircraft/Fighter%20Aircraft/FA-18%20Hornet/FA-18%20Hornet.htm" target="Body"><font size="2" face="Arial"><em><strong>F/A-18
                Hornet</strong></em></font></a></li>
            <li><a href="../Aircraft/ASW-Patrol%20Aircraft/P-3%20Orion/P-3%20Orion.htm" target="Body"><font size="2" face="Arial"><em><strong>P-3C
                Orion</strong></em></font></a></li>
            <li><a href="../Aircraft/ASW-Patrol%20Aircraft/S-3%20Viking/S-3%20Viking.htm" target="Body"><font size="2" face="Arial"><em><strong>S-3A
                Viking</strong></em></font></a></li>
        </ul>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

<hr>

<h2><font face="Arial">Links...</font></h2>

<ul>
    <li><a href="USN%20Index.asp" target="Body"><font face="Arial"><em><strong>U.S. Navy Links</strong></em></font></a></li>
</ul>
<% 
if (Session("Music"))
{
	SongURL = "../Sounds/MIDI/Doom/bmlvl1.mid"
	Delay = "" 
	if (!Session("AutoStart"))
	{
		AutoStart = "false"
	}
	else
	{
		AutoStart = "true"
	}
	if (!Session("Detached"))
	{
		Detached = "false"
	}
	else
	{
		Detached = "true"
	}
%>
<!-- #include virtual="/Includes/PlayMIDI.inc.asp"-->
<%
}
%>
<!--webbot bot="Include" u-include="hfooter.htm" tag="BODY" startspan -->

<hr>
<div align="center"><center>

<table border="0">
    <tr>
        <td valign="top" nowrap><a href="../" target="_top"><font color="#FFFFFF" face="Arial"><img src="Images/home.gif" alt="Home to the Main Page" border="0" width="60" height="59"></font></a><font color="#FFFFFF" size="1" face="Arial"><em><br>
        </em></font></td>
        <td width="20%"><font color="#FFFFFF"></font>&nbsp;</td>
        <td valign="top" nowrap><font color="#FFFFFF" size="1" face="Arial"><em>If you experience any problems with this
        page, please contact:</em></font><font color="#FFFFFF" face="Arial"><em><br>
        </em></font><font color="#FFFFFF" size="1" face="Arial"><em><b>WebMaster:</b></em><em>
        </em></font><a href="mailto:kclark@sss.sungard.com"><font color="#FFFFFF" size="1" face="Arial"><em><b>Ken Clark</b></em></font></a><font color="#FFFFFF"> </font></td>
    </tr>
</table>
</center></div><p><div align="center"><center>

<table border="0">
    <tr>
        <td width="33%"><img src="Images/MSnotepad.gif" width="114" height="43"></td>
        <td width="33%"><table border="0">
            <tr>
                <td align="center"><font color="#000080" size="1" face="ARIAL, HELVETICA"><b>Best experienced with<br>
                </b></font><a href="http://www.microsoft.com/ie/default.asp" target="_blank"><font color="#000080" size="1" face="ARIAL, HELVETICA"><b><img src="Images/ie_static.GIF" alt="Microsoft Internet Explorer" border="0" width="88" height="31" vsapce="7"></b></font></a><font color="#000080" size="1" face="ARIAL, HELVETICA"><b><br>
                Click here to start.</b></font></td>
            </tr>
        </table>
        </td>
        <td align="right" width="33%"><a href="http://www.microsoft.com/frontpage/" target="_top"><img src="Images/fp114a.gif" alt="Microsoft FrontPage" border="0" width="114" height="43"></a></td>
    </tr>
</table>
</center></div>

<p align="center"><font color="#FFFFFF" size="1" face="Arial"><i>--
Page Last modified </i><em><strong>Wednesday, June 10, 1998 01:16 AM</strong></em><i> --</i></font></p>
<!--webbot bot="Include" endspan i-checksum="280" -->
</body>
</html>
