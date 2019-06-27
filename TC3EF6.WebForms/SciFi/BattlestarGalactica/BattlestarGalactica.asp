<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">

<%@ Language=JScript %><html>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
<meta name="GENERATOR" content="Microsoft FrontPage 2.0">
<title>Battlestar Galactica</title>
<base target="Body">

</head>

<body stylesrc="../SciFi.asp" background="../../Images/Backgrounds/starfiel.gif" bgproperties="fixed" bgcolor="#000080" text="#FFFFFF" link="#FFFFFF" vlink="#FFFFFF">

<table border="0" width="100%">
    <tr>
        <td><h1 align="center"><img src="bg.gif" width="399" height="94"></h1>
        </td>
        <td align="right"><font face="Arial"><img src="GALACTICA.GIF" width="175" height="54"></font></td>
    </tr>
</table>

<hr>

<table border="0" width="100%">
    <tr>
        <td><h2><a href="Centurion.htm" target="_top"><font face="Arial"><em><strong>Cylon Centurion</strong></em></font></a></h2>
        <h2><font face="Arial">Links...</font></h2>
        <ul>
            <li><a href="http://www.chrispappas.com/Galactica/" target="_top"><font size="2" face="Arial"><em><strong>Chris
                Pappas Collection</strong></em></font></a></li>
            <li><a href="http://mcmfh.acns.carleton.edu/BG/" target="_top"><font size="2" face="Arial"><em><strong>Mark
                Heiman's Battlestar Galactica Archives</strong></em></font></a><font size="2" face="Arial"><em><strong> (</strong></em></font><a href="../../BattlestarGalactica/index.html" target="_top"><font size="2" face="Arial"><em><strong>local</strong></em></font></a><font size="2" face="Arial"><em><strong>)</strong></em></font></li>
            <li><a href="http://www9.pair.com/iwc/RichardHatch/battlestar.html" target="_top"><font size="2" face="Arial"><em><strong>Richard
                Hatch's Galactica Page</strong></em></font></a></li>
            <li><a href="http://www.scifi.com/galactica/galix.html" target="_top"><font size="2" face="Arial"><em><strong>Sci-Fi
                Channel's Colonial Data Bank</strong></em></font></a></li>
        </ul>
        </td>
        <td align="right"><img src="Viper.gif" width="300" height="100"></td>
    </tr>
</table>

<p align="center"><img src="vmovie.gif" width="500" height="42"></p>
<% 
if (Session("Music"))
{
	SongURL = "/Sounds/MIDI/Soundtracks/bg_short.mid"
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

<p align="center"><img src="GALACTICA2.jpg" width="600" height="200"></p>
</body>
</html>
