<%@ Language=JScript %>
<html>

<head>
   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
   <meta name="FORMATTER" content="Microsoft FrontPage 2.0">
   <meta name="GENERATOR" content="Microsoft FrontPage (Visual InterDev Edition) 2.0">
   <title>Software Tools/Links...</title>
</head>

<body background="/Images/Backgrounds/grid.gif" bgcolor="#000000" text="#0080FF" link="#8080FF" vlink="#0080C0" bgproperties="fixed">

<h1><a name="top"><font color="#0080FF" face="Arial">Software Tools/Links...</font></a></h1>

<hr>
<%
   var DebugMode = "off"
   bc = Server.CreateObject("MSWC.BrowserType")
   if (DebugMode == "on") 
   {
%>
<p>DEBUG: Browser: <%= bc.Browser %> Version <%= bc.Version %><br>
<%
   }
   if (bc.Browser == "IE") 
   {
%>
<object id="BooksOnLine" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
   <param name="_Version" value="65536"> 
   <param name="_ExtentX" value="2752"> 
   <param name="_ExtentY" value="388"> 
   <param name="_StockProps" value="2"> 
   <param name="Caption" value="Books OnLine"> 
   </object> <br>
   <object id="InternetResources" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
      <param name="_Version" value="65536"> 
      <param name="_ExtentX" value="2752"> 
      <param name="_ExtentY" value="388"> 
      <param name="_StockProps" value="2"> 
      <param name="Caption" value="Internet Resources">
   </object> <br>
   <object id="Stash" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
      <param name="_Version" value="65536"> 
      <param name="_ExtentX" value="3704"> 
      <param name="_ExtentY" value="388"> 
      <param name="_StockProps" value="2"> 
      <param name="Caption" value="Ken's Stash"> 
   </object> <br>
   <object id="Magazines" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
      <param name="_Version" value="65536"> 
      <param name="_ExtentX" value="2752"> 
      <param name="_ExtentY" value="388"> 
      <param name="_StockProps" value="2"> 
      <param name="Caption" value="Magazines"> 
   </object><br>
   <object id="StandardsOrgs" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
      <param name="_Version" value="65536"> 
      <param name="_ExtentX" value="2752"> 
      <param name="_ExtentY" value="388"> 
      <param name="_StockProps" value="2"> 
      <param name="Caption" value="Standards Organizations"> 
   </object> <br>
   <object id="Vendors" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
      <param name="_Version" value="65536"> 
      <param name="_ExtentX" value="3704"> 
      <param name="_ExtentY" value="388"> 
      <param name="_StockProps" value="2"> 
      <param name="Caption" value="Vendors"> 
   </object> <br>
	<object id="WebTools" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20"> 
		<param name="_Version" value="65536"> 
		<param name="_ExtentX" value="3704"> 
		<param name="_ExtentY" value="388"> 
		<param name="_StockProps" value="2"> 
		<param name="Caption" value="Web Tools"> 
	</object> <br>
	<object id="Menu" classid="clsid:F5131C24-E56D-11CF-B78A-444553540000" codebase="http://www.microsoft.com/iis/ikcntrls.cab#Version=1,0,0,8" align="baseline" border="0" width="100" height="52"> 
		<param name="_Version" value="65536"> 
		<param name="_ExtentX" value="2117"> 
		<param name="_ExtentY" value="1094"> 
		<param name="_StockProps" value="0"> 
	</object> 
	
	<script language="VBScript">
	<!--
Sub window_onBeforeUnload()
	if Menu.readyState = 4 then Menu.RemoveAllItems()
End Sub
Sub Menu_OnClick(id)
	'On Error Resume Next

	URL = Menu.GetItemValue(id)
	If lcase(Left(URL,7)) = "http://" Then
		top.location.href = URL
	Else
		parent.frames("Body").location.href = URL
	End If
End Sub

Sub BooksOnLine_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("BooksOnLinePage", "Books OnLine", "/BooksOnLine/", "")
	call Menu.Popup(BooksOnLine.Left + BooksOnLine.Width, BooksOnLine.Top)
End Sub
Sub InternetResources_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("InternetResourcesPage", "Internet Resources", "/Software/Links.htm", "")
	call Menu.Popup(InternetResources.Left + InternetResources.Width, InternetResources.Top)
End Sub
Sub Stash_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("StashPage", "Ken's Stash", "/Ken's%20Stash.htm", "")
	call Menu.Popup(Stash.Left + Stash.Width, Stash.Top)
End Sub
Sub Magazines_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("MagazinesByte", "Byte", "http://www.byte.com/byte.htm", "")
	call Menu.AddItem("MagazinesComputerworld", "Computerworld", "http://www.computerworld.com/", "")
	call Menu.AddItem("MagazinesDBMS", "DBMS Magazine", "http://www.dbmsmag.com/", "")
	call Menu.AddItem("MagazinesDDJ", "Dr. Dobb's Journal", "http://www.ddj.com/", "")
	call Menu.AddItem("MagazinesInformationWeek", "Information Week", "http://techweb.cmp.com/iw/601/", "")
	call Menu.AddItem("MagazinesInfoWorld", "InfoWorld", "http://www.infoworld.com/", "")	
	call Menu.AddItem("MagazinesPC", "PC Magazine", "http://www.pcmag.com/", "")
	call Menu.AddItem("MagazinesPCweek", "PC Week", "http://www.pcweek.com/", "")
	call Menu.AddItem("MagazinesSoftwareDevelopment", "Software Development Magazine", "http://www.sdmagazine.com/", "")
	call Menu.AddItem("MagazinesWin95", "Win95 Magazine", "http://www.win95mag.com/", "")
	call Menu.AddItem("MagazinesNetGuide", "NetGuide Magazine OnLine!", "http://techweb.cmp.com/ng/home/", "")
	call Menu.AddItem("MagazinesMIND", "Microsoft Interactive Developer", "http://www.microsoft.com/mind/", "")
	call Menu.Popup(Magazines.Left + Magazines.Width, Magazines.Top)
End Sub
Sub StandardsOrgs_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("OrgsACM", "ACM", "http://www.acm.org/", "")
	call Menu.AddItem("OrgsANSI", "ANSI OnLine", "http://www.ansi.org/", "")
	call Menu.AddItem("OrgsIEEE", "IEEE Standards Home Page", "http://stdsbbs.ieee.org/index.html", "")
	call Menu.AddItem("OrgsISO", "ISO OnLine", "http://www.iso.ch/", "")
	call Menu.AddItem("OrgsW3", "WWW Consortium", "", "")
	call Menu.AddItem("OrgsW3home", "WWW Consortium Home Page", "http://www.w3.org/", "OrgsW3")
	call Menu.AddItem("OrgsW3HTML", "HTML Standard", "http://www.w3.org/pub/WWW/MarkUp/", "OrgsW3")
	call Menu.AddItem("OrgsW3HTTP", "HTTP 1.1 Standard", "http://www.w3.org/pub/WWW/Protocols/HTTP/1.1/spec.html", "OrgsW3")
	call Menu.AddItem("OrgsW3Symbols", "Symbols", "http://www.sandia.gov/sci_compute/symbols.html", "OrgsW3")
	call Menu.AddItem("OrgsW3ISOsymbols", "ISO Symbols", "http://www.sandia.gov/sci_compute/iso_symbol.html", "OrgsW3")
	call Menu.Popup(Magazines.Left + Magazines.Width, Magazines.Top)
End Sub
Sub Vendors_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("Apple", "Apple Computer", "", "Vendors")
	call Menu.AddItem("AppleHome", "Apple Computer Home Page", "http://www.apple.com/", "Apple")
	call Menu.AddItem("AppleQT", "Apple QuickTime Home Page", "http://www.quicktime.apple.com/", "Apple")
	call Menu.AddItem("AppleQTdownload", "QuickTime Download page", "http://www.quicktime.apple.com/sw/qtwin32.html", "Apple")
	call Menu.AddItem("AppleQTDiscussion", "QuickTime Discussion Forum", "http://discuss.info.apple.com/boards/qtime.nsf/by+Topic?OpenView", "Apple")
	call Menu.AddItem("Centura", "Centura Software", "", "Vendors")
	call Menu.AddItem("CenturaHome", "Centura Software Home Page", "http://www.centurasoft.com/", "Centura")
	call Menu.AddItem("BeerFinder", "BeerFinder Demo", "http://www.beerfinder.com/", "Centura")
	call Menu.AddItem("ComputerAssociates", "Computer Associates", "http://www.cai.com/", "Vendors")
	call Menu.AddItem("Digital", "Digital", "/Software/DEC.htm", "Vendors")
	call Menu.AddItem("InSci", "InSci - Optrieve", "http://www.insci.com/", "Vendors")
	call Menu.AddItem("ISG", "ISG", "/Software/ISG.htm", "Vendors")
	call Menu.AddItem("Microsoft", "Microsoft", "/Software/Microsoft.asp", "Vendors")
	call Menu.AddItem("OpenPL1", "Open-PL1", "http://www.liant.com/products/openpli.htm", "Vendors")
	call Menu.AddItem("OracleRdb", "Oracle Rdb", "http://www.oracle.com/products/servers/rdb/html/index.html", "Vendors")
	call Menu.AddItem("Powersoft", "Powersoft", "http://www.powersoft.com/", "Vendors")
	call Menu.AddItem("PerformanceSoftware", "Performance Software - VTEST", "http://www.pstest.com/welcome.html", "Vendors")
	call Menu.AddItem("ProcessSoftware", "Process Software", "", "Vendors")
	call Menu.AddItem("ProcessSoftwareHome", "Process Software Home Page", "http://www.process.com/", "ProcessSoftware")
	call Menu.AddItem("Purveyor", "Purveyor", "http://www.process.com/purchase/purvms11.htp", "ProcessSoftware")
	call Menu.AddItem("TCPware", "TCPware", "http://www.process.com/tcp1.htp", "ProcessSoftware")
	call Menu.AddItem("Pronexus", "Pronexus", "http://www.pronexus.com/", "Vendors")
	call Menu.AddItem("Prolifics", "Prolifics", "", "Vendors")
	call Menu.AddItem("ProlificsHome", "Prolifics Home Page", "http://www.prolifics.com/", "Prolifics")
	call Menu.AddItem("BEAsystems", "BEA Systems - Inc.", "http://www.beasys.com/", "Prolifics")
	call Menu.AddItem("Rhetorex", "Rhetorex", "http://www.rhetorex.com/", "Vendors")
	call Menu.AddItem("Sybase", "Sybase", "http://www.sybase.com/", "Vendors")
	call Menu.AddItem("Verisign", "Verisign", "http://www.verisign.com/", "Vendors")
	call Menu.AddItem("Watcom", "Watcom", "http://www.watcom.com/", "Vendors")
	call Menu.Popup(Vendors.Left + Vendors.Width, Vendors.Top)
End Sub
Sub WebTools_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	call Menu.AddItem("WebTools", "Web Tools", "/WebTools.htm", "WebStuff")
	call Menu.Popup(WebTools.Left + WebTools.Width, WebTools.Top)
End Sub
-->
</script> 
<% 
	}
	else 
	{
%>

<h2><font color="#0080FF" face="Arial"><em><strong>Contents...</strong></em></font></h2>

<ul>
    <li><a href="BooksOnLine/" target="_top"><font
        color="#0080FF" face="Arial"><em><strong>Books OnLine...</strong></em></font></a></li>
    <li><a href="Software/Links.htm" target="Body"><font
        color="#0080FF" face="Arial"><em><strong>Internet
        Resources...</strong></em></font></a></li>
    <li><a href="Ken's%20Stash.htm" target="Body"><font
        color="#0080FF" face="Arial"><em><strong>Ken's Stash of
        Downloaded Stuff...</strong></em></font></a></li>
    <li><a href="Software/Magazines.htm" target="Body"><font
        color="#0080FF" face="Arial"><em><strong>Magazines...</strong></em></font></a></li>
    <li><a href="Software/StandardsOrgs.htm" target="Body"><font
        color="#0080FF" face="Arial"><em><strong>Standards
        Organizations...</strong></em></font></a></li>
    <li><a href="SoftwareIDX.asp#Vendor Web Sites..."><font
        color="#0080FF" face="Arial"><em><strong>Vendor Web
        Sites...</strong></em></font></a></li>
</ul>

<table border="0">
    <tr>
        <td><blockquote>
            <ul>
                <li><a href="SoftwareIDX.asp#Apple"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>Apple...</strong></em></font></a></li>
                <li><a href="SoftwareIDX.asp#Centura"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>Centura...</strong></em></font></a></li>
                <li><a href="http://www.cai.com/"
                    name="Computer Associates" target="_top"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>Computer
                    Associates</strong></em></font></a></li>
                <li><a href="Software/DEC.htm" target="Body"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>Digital
                    Equipment Corporation...</strong></em></font></a></li>
                <li><a href="http://www.insci.com/" name="InSci"
                    target="_top"><font color="#0080FF" size="2"
                    face="Arial"><em><strong>InSci</strong></em></font></a><font
                    color="#0080FF" size="2" face="Arial"><em><strong>
                    - Optrieve</strong></em></font></li>
                <li><a href="Software/ISG.htm" target="Body"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>ISG
                    - International Software Group...</strong></em></font></a></li>
                <li><a href="Software/Microsoft.asp"
                    target="Body"><font color="#0080FF" size="2"
                    face="Arial"><em><strong>Microsoft...</strong></em></font></a></li>
                <li><a
                    href="http://www.liant.com/products/openpli.htm"
                    target="_top"><font color="#0080FF" size="2"
                    face="Arial"><em><strong>Open PL-I
                    Information</strong></em></font></a></li>
                <li><a
                    href="http://www.oracle.com/products/servers/rdb/html/index.html"
                    name="Oracle" target="_top"><font
                    color="#0080FF" size="2" face="Arial"><em><strong>Oracle
                    Rdb</strong></em></font></a></li>
            </ul>
        </blockquote>
        </td>
        <td><ul>
            <li><a href="http://www.powersoft.com/"
                name="Powersoft" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Powersoft</strong></em></font></a></li>
            <li><a href="http://www.pstest.com/welcome.html"
                name="Performance Software" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Performance
                Software</strong></em></font><font
                color="#0080FF" size="1" face="Arial"><em><strong>
                (VTEST)</strong></em></font></a></li>
            <li><a href="SoftwareIDX.asp#Process Software"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Process
                Software</strong></em></font></a></li>
            <li><a href="http://www.pronexus.com/"
                name="Pronexus" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Pronexus</strong></em></font></a></li>
            <li><a href="SoftwareIDX.asp#Prolifics"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Prolifics...</strong></em></font></a></li>
            <li><a href="http://www.rhetorex.com/" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Rhetorex</strong></em></font></a></li>
            <li><a href="http://www.sybase.com/" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Sybase</strong></em></font></a></li>
            <li><a href="http://www.verisign.com" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Verisign</strong></em></font></a></li>
            <li><a href="http://www.watcom.com/" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>Watcom</strong></em></font></a></li>
        </ul>
        </td>
    </tr>
</table>

<ul>
    <li><a href="WebTools.htm" target="Body"><font
        color="#0080FF" face="Arial"><em><strong>Web
        Tools/Links...</strong></em></font></a></li>
</ul>

<hr>

<h2><a name="Vendor Web Sites..."><font color="#0080FF"
face="Arial"><em><strong>Vendor Web Sites...</strong></em></font></a></h2>

<ul>
    <li><a href="http://www.apple.com/" name="Apple"
        target="_top"><font color="#0080FF" face="Arial"><em><strong>Apple</strong></em></font></a><ul>
            <li><a href="http://www.quicktime.apple.com/"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>Apple QuickTime Home</strong></em></font></a></li>
            <li><a
                href="http://www.quicktime.apple.com/sw/qtwin32.html"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>Download QuickTime for
                Windows 95-NT</strong></em></font></a></li>
            <li><a
                href="http://discuss.info.apple.com/boards/qtime.nsf/by+Topic?OpenView"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>QuickTime Discussion
                Forum</strong></em></font></a></li>
        </ul>
    </li>
    <li><a href="http://www.centurasoft.com/" name="Centura"
        target="_top"><font color="#0080FF" face="Arial"><em><strong>Centura</strong></em></font></a><ul>
            <li><a href="http://www.beerfinder.com/"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>Beer Finder</strong></em></font></a></li>
        </ul>
    </li>
    <li><a href="http://www.process.com/" name="Process Software"
        target="_top"><font color="#0080FF" face="Arial"><em><strong>Process
        Software</strong></em></font></a><ul>
            <li><a
                href="http://www.process.com/purchase/purvms11.htp"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>Purveyor</strong></em></font></a></li>
            <li><a href="http://www.process.com/tcp1.htp"
                target="_top"><font color="#0080FF" size="2"
                face="Arial"><em><strong>TCPware</strong></em></font></a></li>
        </ul>
    </li>
    <li><a href="http://www.prolifics.com/" name="Prolifics"
        target="_top"><font color="#0080FF" face="Arial"><em><strong>Prolifics</strong></em></font></a><font
        color="#0080FF" face="Arial"><em><strong> (formerly
        Jyacc)</strong></em></font><ul>
            <li><a href="http://www.beasys.com/" target="_top"><font
                color="#0080FF" size="2" face="Arial"><em><strong>BEA
                Systems- Inc. </strong></em></font></a></li>
        </ul>
    </li>
</ul>

<p>
	<a href="SoftwareIDX.asp#top">
		<img src="/Images/up.gif" border="0" width="14" height="10">
	</a>
</p>

<hr>
<% 
	}
%>
</body>
</html>
