<%
if (Session("Music"))
{
%>
<!-- #include virtual="/Includes/GetRandomMIDI.inc.asp"-->
<% 
	SongURL = GetSongURL()
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

<center>
   <font face="Arial" SIZE=-1>To get another random MIDI just reload the page </FONT>
   <p><img src="Images/Animated/dottie.gif" width="32" height="32"></p>
</center>
<%
}
%>
