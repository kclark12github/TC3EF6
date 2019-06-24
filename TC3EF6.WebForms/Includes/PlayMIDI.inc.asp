<%
   var WriteLegend = "yes"
   var PlayIfNoCrescendo = "yes"
   var NotCrescendo = "You don't have Crescendo, the <B>only</B> " +
      "streaming MIDI player for the web.<BR>" +
      "<B><A HREF='http://www.liveupdate.com/dl.html'>Download Crescendo now</A> -- it's free!</B>"
   var navParamAutoStart = 'AUTOSTART="true" '
   var navParamDetach = 'DETACH="false" '
   var navParamLoop = 'LOOP="false" '
   var navParamDelay = "DELAY=0 "
   var navParamBGCOLOR = 'BGCOLOR="#000000" '
   var ieParamAutoStart = 'PARAM NAME="AUTOSTART" VALUE="true"'
   var ieParamDetach = 'PARAM NAME="DETACH" VALUE="false"'
   var ieParamLoop = 'PARAM NAME="LOOP" VALUE="false"'
   var ieParamDelay = 'PARAM NAME="DELAY" VALUE="0"'
   var ieParamBGCOLOR = 'PARAM NAME="BGCOLOR" VALUE="#000000"'
   var CrescendoVersion = ""
   var PlugInDimensions = "HEIGHT=55 WIDTH=200 "
   var PlugInType = ""
   var Browser = ""
	var Version = ""
	var MajorVersion = ""
	var CrescendoVersion = ""
   var Legend = ""
   var DocString = ""
   var SongTitle = ""
   var Band = ""
   var DebugMode = "off"
 
   if (DebugMode == "on")
   {
      %>DEBUG: Building display...<br><%
   }
   if (Delay != "")
   {
      navParamDelay = 'DELAY="' + Delay + '" '
      ieParamDelay = 'PARAM NAME="DELAY" VALUE="' + Delay + '"'
   }
   if (AutoStart != "")
   {
      navParamAutoStart = 'AUTOSTART="' + AutoStart + '" '
      ieParamAutoStart = 'PARAM NAME="AUTOSTART" VALUE="' + AutoStart + '"'
   }
   if (Detached != "")
   {
      navParamDetach = 'DETACH="' + Detached + '" '
      ieParamDetach = 'PARAM NAME="DETACH" VALUE="' + Detached + '"'
   }

   SongTitle = SongURL.substring(SongURL.lastIndexOf("Sounds/MIDI/")+12, SongURL.length)
   if (SongTitle.indexOf("ClassicRock/") >= 0)
   {
      SongTitle = SongTitle.substring(SongTitle.indexOf("ClassicRock/")+12, SongTitle.length)
      if (SongTitle.indexOf("Miscellaneous/") >= 0)
      {
         SongTitle = SongTitle.substring(SongTitle.indexOf("Miscellaneous/")+14, SongTitle.length)
         Band = SongTitle.substring(0, SongTitle.indexOf("_"))
         SongTitle = SongTitle.substring(SongTitle.lastIndexOf("_")+1, SongTitle.length)
      }
      else
      {
         Band = SongTitle.substring(0, SongTitle.indexOf("/"))
         SongTitle = SongTitle.substring(SongTitle.lastIndexOf("/")+1, SongTitle.length)
      }
      Band = 'By <B>"' + Band + '"  </B><br>'
   }
   else if (SongTitle.indexOf("Doom/") >= 0)
   {
      SongTitle = SongTitle.substring(SongTitle.indexOf("Doom/")+5, SongTitle.length)
      Band = "From the <b>Doom Collection</b><br>"
   }
   else if (SongTitle.indexOf("Soundtracks/") >= 0)
   {
      SongTitle = SongTitle.substring(SongTitle.indexOf("Soundtracks/")+12, SongTitle.length)
      Band = "From the <b>Soundtracks Collection</b><br>"
   }

   // Now replace any spaces in the URL with "%20" so all browsers can find it...

   while(SongURL.indexOf(" ") > 0)
      SongURL = SongURL.substring(0, SongURL.indexOf(" ")) + '%20' + SongURL.substring(SongURL.indexOf(" ")+1)
%>
   <hr>
   <div align="center"><center>
      <table border="0">
         <tr>
            <td align="right" valign="top">
		       <img src="/Images/Animated/speaker.gif" width="80" height="80">
		    </td>
          <td align="center" valign="top">
					<font face="Arial" SIZE=-1>Now playing <B>&quot;<%= SongTitle%>&quot;</B><br>
   <%if (Band != "")
	{
%>
		<%= Band%>
<%	}
%>

<%
   if (Session("Browser") == "Default") // Assume MSIE...
	{
		var ua = window.navigator.userAgent;
		var msie = ua.indexOf("MSIE") ;
		if(msie > 0)
		{
			Browser = "IE"
			Version = ua.substring(msie+5,ua.indexOf(" ",msie));
			MajorVersion = parseInt(ua.substring(msie+5,ua.indexOf(".",msie)));
		}
		else
		{
			Browser = Session("Browser")
			Version = Session("Version")
		}
	}
	else
	{
		Browser = Session("Browser")
		Version = Session("Version")
	}

   if (DebugMode == "on") 
   {
      %>DEBUG: Browser: <%= Browser%> Version <%=Version%><br><%
   }
%>
	<OBJECT ID=Crescendo CLASSID="clsid:0FC6BF2B-E16A-11CF-AB2E-0080AD08A326" 
		CODEBASE="http://activex.liveupdate.com/controls/cres.cab#Version=2,3,0,35" HEIGHT=55 WIDTH=200>
		<PARAM NAME="Song" VALUE="<%= SongURL%>">
		<!-- Optional parmeters - See http://www.liveupdate.com/cpauth.html for docs. -->
      <<%= ieParamAutoStart%>>
      <<%= ieParamLoop%>>
      <<%= ieParamDelay%>>
		<<%= ieParamBGCOLOR%>>
      <<%= ieParamDetach%>>

      <!-- If the ActiveX Crescendo is not installed, this EMBED tag will cause MSIE
           to load any Netscape plug-in that is associated with *.MID files.
           The browser will only "see" this EMDED tag if the ActiveX Crescendo is not 
           registered.  This is for versions of MSIE that don't see OBJECT but do see <EMBED>. -->

      <EMBED TYPE="music/crescendo" SONG="<%= SongURL%>" PLUGINSPAGE="http://www.liveupdate.com/dl.html" 
			<%= PlugInDimensions%>
			<%= navParamDelay%>
			<%= navParamAutoStart%>
			<%= navParamDetach%>
			<%= navParamLoop%>
		>
	</OBJECT>

   <%= DocString%>
            </td>
            <td align="left"" valign="top">
   		       <img src="/Images/Animated/speaker.gif" width="80" height="80">
		    </td>
         </tr>
      </table>
 
   <%if (WriteLegend == "yes")
   {
	   if (Browser == "Netscape") 
			Legend = "Netscape Navigator " + Version + " running Crescendo."
      else if (Browser == "IE") 
         Legend = 'Microsoft IE ' + Version + ' running Crescendo.'
      else
         Legend = Browser + ' ' + Version + ' running Crescendo.'
%>
		<font face="Arial" SIZE=1><%=Legend%> </font>
<%
	}
%>
   </center></div>



