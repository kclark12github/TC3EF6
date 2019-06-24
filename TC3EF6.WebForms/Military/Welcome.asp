<%@ Language=JScript %>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	<meta name="GENERATOR" content="Microsoft FrontPage 2.0"> 
	<title>Welcome Page</title>
	
</head>

<body bgcolor="#FFFFFF" text="#000080" link="#000080" vlink="#000080" bgproperties="fixed" face="Arial">

<h1 align="center"><font color="#000000" face="Arial"><i>Ken's Military Links...</i></font></h1>

<p align="center"><font color="#000000" face="Arial"><strong>You are Visitor<br>
<!--webbot i-image="4" bot="HitCounter" i-digits="0" b-reset="FALSE" preview="&lt;strong&gt;Hit Counter&lt;/strong&gt;" u-custom i-resetvalue="0" startspan --><strong>[FrontPage HitCounter Component]</strong><!--webbot bot="HitCounter" endspan i-checksum="16176" --></strong></font></p>

<p align="center"><font color="#000000" face="Arial"><strong>Come on in and browse around...</strong></font></p>

<p align="center"><font color="#000000" face="Arial"><strong>Each
of the Armed Forces are represented here on the left... click on
one of the seals or insignia and go to that branch of the
military's official web site...</strong></font></p>

<hr>

<h2 align="left"><font face="Arial"><em><strong>Links</strong></em></font></h2>
<div align="center"><center>

<table border="0">
    <tr>
        <td align="center" valign="top">
			<a href="../Ships/" target="_top"><img src="../Ships/Images/thcomehome.jpg" alt="U.S. Navy Stuff..." border="0" width="200" height="141"></a>
		</td>
        <td valign="top"><a href="../Ships/USN%20Index.asp" target="Body"><font face="Arial"><em><strong>U.S. Navy Links...</strong></em></font></a>
		<ul>
            <li><a href="../Ships/USN%20Index.asp#Official U.S. Navy Sites" target="Body"><font face="Arial"><em><strong>Official US Navy Sites</strong></em></font></a></li>
            <li><a href="../Ships/USN%20Index.asp#Surface Fleet" target="Body"><font face="Arial"><em><strong>Surface Fleet</strong></em></font></a></li>
            <li><a href="../Ships/USN%20Index.asp#Naval Aviation" target="Body"><font face="Arial"><em><strong>Naval Aviation</strong></em></font></a><font face="Arial"><em><strong> (</strong></em></font><a href="../Aircraft/Blue%20Angels/BlueAngels.asp" target="_top"><font face="Arial"><em><strong>Blue Angels</strong></em></font></a><font face="Arial"><em><strong>)</strong></em></font></li>
            <li><a href="../Ships/USN%20Index.asp#Internet Resources" target="Body"><font face="Arial"><em><strong>Internet Resources</strong></em></font></a></li>
            <li><a href="../Ships/" target="_top"><font face="Arial"><em><strong>Ken's Ship Images &amp; Histories</strong></em></font></a><font face="Arial"><em><strong> <img src="Images/Animated/cool.gif" width="30" height="15"></strong></em></font></li>
        </ul>
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr width="75%"></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td align="center"><a href="../Aircraft/" target="_top"><img src="Images/s50l.gif" alt="U.S. Air Force Links" border="0" width="72" height="87"></a></td>
        <td><a href="../Aircraft/USAF%20Index.asp" target="Body"><font face="Arial"><em><strong>U.S. Air Force Links...</strong></em></font></a><ul>
            <li><a href="../Aircraft/USAF%20Index.asp#Official US Air Force Sites" target="Body"><font face="Arial"><em><strong>Official US Air Force Sites</strong></em></font></a></li>
            <li><a href="../Aircraft/USAF%20Index.asp#Internet Resources..." target="Body"><font face="Arial"><em><strong>Internet Resources</strong></em></font></a></li>
            <li><a href="../Aircraft/" target="_top"><font face="Arial"><em><strong>Ken's Aircraft Archive</strong></em></font></a><font face="Arial"><em><strong> <img src="Images/Animated/cool.gif" width="30" height="15"></strong></em></font></li>
        </ul>
        </td>
    </tr>
    <tr>
        <td colspan="2"><hr width="75%"></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
			<p align="center"><a href="http://www.usmc.mil/factfile/default.htm" target="_top"><img src="Images/thM1A1.gif" border="0" width="239" height="150"></a></p>
        </td>
        <td>
			<a href="http://www.usmc.mil/factfile/default.htm" target="_top"><font face="Arial"><em><strong>U.S. Marine Corps Fact File</strong></em></font></a>
		</td>
    </tr>
    <tr>
        <td colspan="2"><hr width="75%"></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
			<p align="center"><a href="http://www.e-hawk.com/milcat/index.html" target="_top"><img src="Images/thmilcat.jpg" alt="Mil-Cat" border="0" width="150" height="60"></a></p>
        </td>
        <td>
			<a href="http://www.e-hawk.com/milcat/index.html" target="_top"><font face="Arial"><em><strong>Mil-Cat (Military Site Catalog)</strong></em></font></a>
		</td>
    </tr>
</table>
</center></div>
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
        <td valign="top" nowrap><a href="../" target="_top"><font
        face="Arial"><img src="../Images/home.gif"
        alt="Home to the Main Page" border="0" width="60"
        height="59"></font></a><font size="1" face="Arial"><em><br>
        </em></font></td>
        <td width="20%"><font face="Arial"></font>&nbsp;</td>
        <td valign="top" nowrap><font size="1" face="Arial"><em>If
        you experience any problems with this page, please
        contact:</em></font><font face="Arial"><em><br>
        </em></font><font size="1" face="Arial"><em><b>WebMaster:</b></em><em>
        </em></font><a href="mailto:kclark@sss.sungard.com"><font
        size="1" face="Arial"><em><b>Ken Clark</b></em></font></a><font
        face="Arial"> </font></td>
    </tr>
</table>
</center></div><div align="center"><center>

<table border="0" width="100%">
    <tr>
        <td align="right" width="33%"><img
        src="Images/Logos/MSnotepad.gif" width="114" height="43"></td>
        <td align="center" width="33%"><font color="#000080"
        size="1" face="ARIAL, HELVETICA"><b>Best experienced with<br>
        </b></font><a href="http://www.microsoft.com/ie/"
        target="_blank"><img src="Images/Logos/ie_static.GIF"
        alt="Microsoft Internet Explorer" border="0" width="88"
        height="31" vsapce="7"></a><br>
        <font color="#000080" size="1" face="ARIAL, HELVETICA"><b>Click
        here to start.</b></font> </td>
        <td width="33%"><a
        href="http://www.microsoft.com/frontpage/" target="_top"><img
        src="Images/Logos/fp114a.gif" alt="Microsoft FrontPage"
        border="0" width="114" height="43"> </a></td>
    </tr>
</table>
</center></div>

<p align="center"><font size="1" face="Arial"><i>-- Page Last
modified </i><em><strong>Monday, June 14, 2004 11:50 PM</strong></em><i> --</i></font></p>
<!--webbot bot="Include" endspan i-checksum="60857" -->
</body>
</html>
