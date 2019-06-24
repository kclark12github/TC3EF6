<%@ Language=JScript %>
<!DOCTYPE HTML PUBLIC "-//IETF//DTD HTML//EN">
<html>

<head>
<meta http-equiv="Content-Type"
content="text/html; charset=iso-8859-1">
<meta name="FORMATTER" content="Microsoft FrontPage 2.0">
<meta name="GENERATOR"
content="Microsoft FrontPage (Visual InterDev Edition) 2.0">
<title>Microsoft Links...</title>
</head>

<body background="/Images/Backgrounds/grid.gif" bgcolor="#000000" text="#0080FF" link="#8080FF" vlink="#0080C0" bgproperties="fixed">

	<a href="http://www.microsoft.com/" target="_top"><img src="/Images/Logos/mslogo.jpg" alt="Microsoft" border="0" width="328" height="57"></a>
	<p>
<%
   var DebugMode = "off"
   bc = Server.CreateObject("MSWC.BrowserType")
   if (DebugMode == "on") 
   {%>
      DEBUG: Browser: <%= bc.Browser %> Version <%= bc.Version %><br>
   <%}

   if (bc.ActiveXControls)
   {
%>
	<object id="Microsoft" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="2752">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Microsoft">
	</object> <br>
	<object id="Internet" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="2752">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Internet">
	</object> <br>
	<object id="MicrosoftPress" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="3704">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Microsoft Press">
	</object> <br>
	<object id="Office97" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="2752">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Office 97">
	</object><br>
	<object id="OfficeDeveloperForum" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="2752">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Office Developer Forum">
	</object> <br>
	<object id="UniversalDataAccess" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="3704">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Universal Data Access">
	</object> <br>
	<object id="VisualStudio" name="VisualStudio" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="3704">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Visual Studio">
	</object><br>
	<object id="Windows95" name="Windows95" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="3704">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Windows95">
	</object><br>
	<object id="WindowsNT" name="WindowsNT" classid="clsid:B10CBD8D-F9B6-11CF-9B38-0080AD11B667" codebase="http://www.microsoft.com/iis/ikcntrls.cab#version=1,0,0,5" align="baseline" border="0" width="175" height="20">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="3704">
		<param name="_ExtentY" value="388">
		<param name="_StockProps" value="2">
		<param name="Caption" value="Windows/NT">
	</object><br>

	<object id="Menu" classid="clsid:F5131C24-E56D-11CF-B78A-444553540000" codebase="http://www.microsoft.com/iis/ikcntrls.cab#Version=1,0,0,8" align="baseline" border="0" width="100" height="52">
		<param name="_Version" value="65536">
		<param name="_ExtentX" value="2117">
		<param name="_ExtentY" value="1094">
		<param name="_StockProps" value="0">
	</object>
	<script language="VBScript"><!--
Sub Window_onBeforeUnload()
	Menu.RemoveAllItems()
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
sub Ad (cde,lbl,menuitem,par)
	Menu.AddItem cde,lbl,menuitem,par
End Sub

Sub Microsoft_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "MSmain", "Main Microsoft Site", "http://www.microsoft.com/", "MS"
	Ad "MSproducts", "Products", "http://www.microsoft.com/products/default.asp", "MS"
	Ad "MSsearch", "Search", "http://www.microsoft.com/search/default.asp", "MS"
	Ad "MSsupport", "Support", "http://support.microsoft.com/support/c.asp?PR=ALL&FR=0&M=F&", "MS"
	Ad "MSsupportDL", "Support Downloads", "http://support.microsoft.com/support/downloads/default.asp?M=F&PR=ALL&FR=0&", "MS"
	'Ad "MSkb", "Knowledge Base", "http://www.microsoft.com/Support/", "MS"
	call Menu.Popup(Microsoft.Left + Microsoft.Width, Microsoft.Top)
End Sub
Sub Internet_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "WindowsNTiis", "IIS - Internet Information Server", "http://www.microsoft.com/iis/", "Internet"
	Ad "IE", "Internet Explorer", "http://www.microsoft.com/ie/", "Internet"
	Ad "JavaHome", "Java", "http://www.microsoft.com/java/", "Internet"
	Ad "NetMeeting", "NetMeeting", "http://www.microsoft.com/netmeeting/", "Internet"
	Ad "SBW", "Site Builder Workshop", "", "Internet"
		Ad "SBWhome", "Site Builder Workshop Home Page", "http://www.microsoft.com/workshop/default.asp", "SBW"
		Ad "SBWAuthoring", "Authoring", "http://www.microsoft.com/workshop/author/default.asp", "SBW"
		Ad "SBWDesign", "Design", "http://www.microsoft.com/workshop/design/default.asp", "SBW"
		Ad "SBWProgramming", "Programming", "", "SBW"
			Ad "SBWProgrammingHome", "Programming Home", "http://www.microsoft.com/workshop/prog/default.asp", "SBWProgramming"
			Ad "SBWActiveXTutorial", "ActiveX Tutorial Samples Overview", "http://www.microsoft.com/intdev/activex/tutorial/tutorial.htm", "SBWProgramming"
			Ad "SBWdtctrl", "Web Design-time Control SDK", "http://www.microsoft.com/workshop/prog/sdk/dtctrl/dcsdk-f.HTM", "SBWProgramming"
		Ad "SBWServer", "Server", "http://www.microsoft.com/workshop/server/default.asp", "SBW"
		Ad "SBWGallery", "Gallery", "http://www.microsoft.com/gallery/default.asp", "SBW"
		Ad "SBWIndexes", "Indexes", "", "SBW"
			Ad "SBWIndexesHome", "SBN Index Home Page", "http://www.microsoft.com/workshop/index/default.asp", "SBWIndexes"
			Ad "SBWDynamicHTMLindex", "Dynamic HTML", "http://www.microsoft.com/workshop/author/dynhtml/index-f.htm", "SBWIndexes"
			Ad "SBWHTMLindex", "Internet Explorer 3.0 HTML Reference", "http://www.microsoft.com/workshop/author/newhtml/index-f.htm", "SBWIndexes"
			Ad "SBWWin32index", "Win32 Internet Programmer's Reference", "http://www.microsoft.com/workshop/prog/sdk/docs/wininet/index-f.htm", "SBWIndexes"
			Ad "SBWWebPostIndex", "WebPost API Reference", "http://www.microsoft.com/workshop/prog/sdk/docs/webpost/index-f.htm", "SBWIndexes"
			Ad "SBWBrowserObjectsIndex", "Web Browsing Objects Index", "http://www.microsoft.com/workshop/prog/sdk/docs/iexplore/index-f.htm", "SBWIndexes"
			Ad "SBWObjectModelScriptingIndex", "Object Model for Scripting Reference", "http://www.microsoft.com/workshop/prog/sdk/docs/scriptom/index-f.htm", "SBWIndexes"
			Ad "SBWActiveXScriptingIndex", "ActiveX Scripting Reference", "http://www.microsoft.com/workshop/prog/sdk/docs/scriptom/index-f.htm", "SBWIndexes"
			Ad "SBWInternetRatingsIndex", "Internet Ratings API Reference", "http://www.microsoft.com/workshop/prog/sdk/docs/ratings/index-f.htm", "SBWIndexes"
			Ad "SBNdownloads", "Downloads", "http://www.microsoft.com/sbnmember/download/default.htm", "SBW"
		Ad "SBN", "Site Builder Network Magazine", "http://www.microsoft.com/sitebuilder/default.htm", "SBW"
	call Menu.Popup(Internet.Left + Internet.Width, Internet.Top)
End Sub
Sub MicrosoftPress_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "MicrosoftPressHome", "Microsoft Press Online Book Store", "http://mspress.microsoft.com/", ""
	call Menu.Popup(MicrosoftPress.Left + MicrosoftPress.Width, MicrosoftPress.Top)
'	parent.frames("top").Location.Href="http://mspress.microsoft.com/"
End Sub
Sub Office97_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "Office97home", "Office 97 Home Page", "http://www.microsoft.com/office/", "Office97"
	Ad "Office97access", "Access", "http://www.microsoft.com/access/", "Office97"
	Ad "Office97excel", "Excel", "http://www.microsoft.com/excel/", "Office97"
	Ad "Office97frontpage", "FrontPage", "http://www.microsoft.com/frontpage/", "Office97"
	Ad "Office97sp", "Service Packs", "http://www.microsoft.com/Office/Office97/ServiceRelease/", "Office97"
	Ad "Office97outlook", "Outlook", "http://www.microsoft.com/outlook/", "Office97"
	Ad "Office97powerpoint", "PowerPoint", "http://www.microsoft.com/powerpoint/", "Office97"
	Ad "Office97project", "Project", "http://www.microsoft.com/project/", "Office97"
	Ad "Office97publisher", "Publisher", "http://www.microsoft.com/publisher/", "Office97"
	Ad "Office97teammanager", "Team Manager", "http://www.microsoft.com/teammanager/", "Office97"
	Ad "Office97word", "Word", "http://www.microsoft.com/word/", "Office97"
	call Menu.Popup(Office97.Left + Office97.Width, Office97.Top)
End Sub
Sub OfficeDeveloperForum_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "OfficeDeveloperForumHome", "Office Developer Forum Home Page", "http://www.microsoft.com/OfficeDev/", "OfficeDev"
	Ad "OfficeDeveloperForumAccess", "Access", "http://www.microsoft.com/AccessDev/", "OfficeDev"
	Ad "OfficeDeveloperForumExcel", "Excel", "http://www.microsoft.com/ExcelDev/", "OfficeDev"
	Ad "OfficeDeveloperForumOutlook", "Outlook", "http://www.microsoft.com/OutlookDev/", "OfficeDev"
	Ad "OfficeDeveloperForumPowerPoint", "PowerPoint", "http://www.microsoft.com/PowerPointDev/", "OfficeDev"
	Ad "OfficeDeveloperForumWord", "Word", "http://www.microsoft.com/WordDev/", "OfficeDev"
	call Menu.Popup(OfficeDeveloperForum.Left + OfficeDeveloperForum.Width, OfficeDeveloperForum.Top)
End Sub
Sub UniversalDataAccess_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "UDAhome", "Universal Data Access Home Page", "http://www.microsoft.com/data/", "UDA"
	Ad "ADO", "ADO Web Page", "http://www.microsoft.com/data/ado/", "UDA"
	Ad "UDAODBC", "ODBC - Open DataBase Connectivity", "http://www.microsoft.com/data/odbc/", "UDA"
	Ad "UDAOLEDB", "OLE DB", "http://www.microsoft.com/data/oledb/", "UDA"
	Ad "UDARDS", "RDS - Remote Data Service (ADC)", "http://www.microsoft.com/data/rds/", "UDA"
	call Menu.Popup(UniversalDataAccess.Left + UniversalDataAccess.Width, UniversalDataAccess.Top)
End Sub
Sub VisualStudio_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "VS97home", "Visual Studio 97 Home Page", "http://www.microsoft.com/vstudio/", "VS97"
	Ad "VS97premium", "Owner's Area - Premium Content", "http://www.microsoft.com/vstudio/owner/default.asp", "VS97"
	Ad "VS97ActiveXFAQ", "ActiveX FAQ", "http://www.microsoft.com/support/axcontrols.htm", "VS97"
	Ad "VS97JScript", "JScript", "http://www.microsoft.com/jscript/", "VS97"
	Ad "VS97MIND", "MIND - Microsoft Interactive Developer", "http://www.microsoft.com/mind/", "VS97"
	Ad "VS97MSDN", "MSDN OnLine", "http://www.microsoft.com/msdn/", "VS97"
	Ad "VS97VB", "Visual Basic", "", "VS97"
	Ad "VS97VBhome", "Visual Basic Home Page", "http://www.microsoft.com/vbasic/", "VS97VB"
	Ad "VS97VBNamingConventions", "Naming Conventions", "http://premium.microsoft.com/support/kb/articles/q110/2/64.asp", "VS97VB"
	Ad "VS97VBA", "VBA - Visual Basic for Applications", "http://www.microsoft.com/vba/", "VS97VB"
	Ad "VS97VBScript", "VBScript", "http://www.microsoft.com/vbscript/", "VS97VB"
	Ad "VS97VC++", "Visual C++", "http://www.microsoft.com/visualc/", "VS97"
	Ad "VS97VInterDev", "Visual InterDev", "http://www.microsoft.com/vinterdev/", "VS97"
	Ad "VS97VJ++", "Visual J++", "http://www.microsoft.com/visualj/", "VS97"
	Ad "VS97VSS", "Visual SourceSafe", "http://www.microsoft.com/ssafe/", "VS97"
	Ad "VS97SP", "Service Packs", "", "VS97"
		Ad "VS97SPhome", "Service Packs Home Page", "http://www.microsoft.com/vstudio/sp/", "VS97SP"
		Ad "VS97SPreadme", "ReadMe for Current Service Pack", "http://www.microsoft.com/vstudio/sp/ReadMe.htm", "VS97SP"
		Ad "VS97SP1", "Service Pack 1", "http://premium.microsoft.com/support/kb/articles/Q170/3/66.asp?PR=CHS&FR=0&M=S&", "VS97SP"
		Ad "VS97SP2", "Service Pack 2", "http://premium.microsoft.com/support/kb/articles/Q172/6/10.asp?PR=CHS&FR=0&M=S&", "VS97SP"
		Ad "VS97SP3", "Service Pack 3", "http://premium.microsoft.com/support/kb/articles/q176/0/66.asp", "VS97SP"
	call Menu.Popup(VisualStudio.Left + VisualStudio.Width, VisualStudio.Top)
End Sub
Sub Windows95_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "Windows95home", "Windows95 Home page", "http://www.microsoft.com/windows95/", "Win95"
	Ad "Windows95updates", "Windows 95 Updates and Utilities", "http://www.microsoft.com/windows95/info/legacy.htm", "Win95"
	call Menu.Popup(Windows95.Left + Windows95.Width, Windows95.Top)
End Sub
Sub WindowsNT_MouseDown(Button, Shift, X, Y)
	call Menu.RemoveAllItems()
	Ad "WindowsNThome", "Windows/NT Home Page", "http://www.microsoft.com/ntserver/", "WinNT"
	Ad "WindowsNTiis", "IIS - Internet Information Server", "http://www.microsoft.com/iis/", "WinNT"
	Ad "WindowsNTdownload", "Microsoft BackOffice Live Download and Trial", "http://backoffice.microsoft.com/downtrial/default.asp?product=19&item=183/", "WinNT"
	Ad "WindowsNTsp", "Service Packs", "http://www.microsoft.com/ntserversupport/content/servicepacks/", "WinNT"
	Ad "WindowsNTsql", "SQL Server Home Page", "http://www.microsoft.com/sql/", "WinNT"
	Ad "WindowsNTtransaction", "Transaction Server", "http://www.microsoft.com/transaction/default.asp", "WinNT"
	call Menu.Popup(WindowsNT.Left + WindowsNT.Width, WindowsNT.Top)
End Sub
--></script>

<% 
	}
	else 
	{
%>
<hr>

<ul>
    <li><a href="http://www.microsoft.com/" target="_top"><font
        color="#0080FF" size="5" face="Arial"><em><strong>Microsoft...</strong></em></font></a><font
        color="#0080FF" size="5" face="Arial"> </font><ul>
            <li><a href="http://www.microsoft.com/msdownload/"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Microsoft
                Free Downloads </strong></em></font></a></li>
            <li><a
                href="http://www.microsoft.com/products/default.asp?divisionid=6"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Microsoft
                Products </strong></em></font></a></li>
            <li><a
                href="http://www.microsoft.com/windows95/default.asp"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Windows95</strong></em></font></a><ul>
                    <li><a
                        href="http://www.pippin.com/English/ComputersSoftware/Software/Windows95/dialup.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Windows 95 Dial-Up Utilities at Pip.</strong></em></font></a></li>
                </ul>
            </li>
            <li><a href="http://www.microsoft.com/frontpage/"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Front
                Page</strong></em></font></a><ul>
                    <li><a
                        href="http://www.webofbooks.com/fpage/index.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>AOL
                        Upload</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/frontpage/documents/resources.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Authoring
                        Resources</strong></em></font></a></li>
                    <li><a
                        href="http://www.pmpcs.com/support/fp/answers.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        FrontPage - Answers to Common Newsg.</strong></em></font></a></li>
                    <li><a
                        href="http://www.mcp.com/que/et/MSFP97/msfp97.html"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        FrontPage Index Page</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/imagecomposer/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Image Composer Home</strong></em></font></a></li>
                    <li><a
                        href="http://www.pmpcs.com/support/fp/protect.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Password
                        Protection</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/ie/iesk/pws.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Personal
                        Web Server</strong></em></font></a></li>
                </ul>
            </li>
            <li><font color="#0080FF" face="Arial"><em><strong>Internet
                Assistants</strong></em></font><ul>
                    <li><a
                        href="http://www.microsoft.com/msword/it_wd.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Tools for Word</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/msaccess/it_acc.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Tools for Access</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/msexcel/it_xl.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Tools for Excel</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/mspowerpoint/internet/ia/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Tools for PowerPoint</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/msscheduleplus/it_sch.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Tools for SchedulePlus</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/accessdev/itk/default.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet-Intranet
                        Utilities for MS Access</strong></em></font></a></li>
                </ul>
            </li>
            <li><a href="http://www.microsoft.com/ie/"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Internet
                Explorer</strong></em></font></a><ul>
                    <li><a
                        href="http://www.microsoft.com/ie/download/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Download</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/ie/most/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Get the
                        Most from Internet Explorer</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/ie/ie3/layout.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>HTML
                        Layout Control</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/ie/ie40/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Internet
                        Explorer 4.0 Platform Preview</strong></em></font></a></li>
                    <li><a href="http://www.microsoft.com/vrml/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Supports VRML Download VRML2.0 Vi.</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/isapi/ie/ie_reg1.idc"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Welcome
                        to Microsoft Internet Explorer</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/ie/ie3setup/osr2/default.asp"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Internet Explorer Online Setup</strong></em></font></a></li>
                </ul>
            </li>
            <li><a href="http://www.microsoft.com/office/"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Office97</strong></em></font></a><font
                color="#0080FF" face="Arial"><em><strong> </strong></em></font><ul>
                    <li><a
                        href="http://www.microsoft.com/MSOfficeSupport/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Technical
                        Support</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/msaccesssupport/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Online
                        Support for Access</strong></em></font></a></li>
                </ul>
            </li>
        </ul>
        <ul>
            <li><a href="http://wayneproxy/iisadmin/default.htm"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Internet
                Service Manager</strong></em></font></a><ul>
                    <li><a
                        href="http://rampages.onramp.net/~steveg/iis.html"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>The
                        Microsoft Internet Information Server FAQ</strong></em></font></a></li>
                </ul>
            </li>
            <li><a href="http://www.microsoft.com/vstudio/"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Visual
                Studio 97</strong></em></font></a><ul>
                    <li><a
                        href="http://www.microsoft.com/vbasic/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Visual
                        Basic</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/jscript/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>JScript
                        Web Page</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/vbscript/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>VBScript
                        Web Page</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/vbscript/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Visual
                        Basic Web Page Demo</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/visualc/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Visual C++</strong></em></font></a></li>
                </ul>
            </li>
            <li><a
                href="http://www.microsoft.com/workshop/default.asp"
                target="_top"><font color="#0080FF" face="Arial"><em><strong>Site
                Builder Workshop</strong></em></font></a><ul>
                    <li><a
                        href="http://www.microsoft.com/intdev/activex/tutorial/tutorial.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>ActiveX
                        Tutorial Samples Overview</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/workshop/author/cpad/howto/container.htm#dataentry"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Authoring
                        Tips for the HTML Layout Control</strong></em></font></a></li>
                    <li><a
                        href="file://C:\CLARK\WebSite\colors.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>colors</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/iis/usingiis/developing/default.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Developing
                        for IIS</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/workshop/author/newhtml/htmlr005.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>HTML
                        Color</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/workshop/author/newfeat/ie30html-f.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>HTML
                        Reference</strong></em></font></a></li>
                    <li><a
                        href="http://wayneproxy/iisadmin/htmldocs/iisdocs.HTM"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>IIS
                        Documentation</strong></em></font></a></li>
                    <li><a
                        href="http://159.182.101.57/samples/default.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>IIS
                        Sample</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/win32dev/apiext/isalegal.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>ISAPI
                        Documentation</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/activex/actx-gen/ajava.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Java
                        and ActiveX</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/frontpage/documents/resources.htm"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        FrontPage - Authoring Resources</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/java/sdk/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        SDK for Java</strong></em></font></a></li>
                    <li><a
                        href="http://www.microsoft.com/workshop/prog/default.asp"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>SBN
                        Programming</strong></em></font></a></li>
                    <li><a href="http://www.microsoft.com/kb/"
                        target="_top"><font color="#0080FF"
                        size="2" face="Arial"><em><strong>Microsoft
                        Technical Support Knowledge Base</strong></em></font></a></li>
                </ul>
            </li>
        </ul>
    </li>
</ul>

<p><a href="#top"><font color="#0080FF" face="Arial"><img
src="/Images/up.gif" border="0" width="14" height="10"></font></a></p>

<hr>
<% 
	}
%>
</body>
</html>
