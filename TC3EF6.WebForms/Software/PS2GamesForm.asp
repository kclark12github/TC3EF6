<%@ LANGUAGE="vbscript" %>
<%
strRSName = "rsPS2Games"
strTableName = "Software"
strBasePageName = "PS2Games"
strPageTitle = "Software Library; PS2 Games"
SQLstatement = "Select * From [Software] Where (Platform='Sony Playstation 2') And [Type] Like 'Game%' Order By Title, Version;"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """MediaFormat"",""Location"",""Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Software/avarLocations.inc.asp"-->
<!-- #include virtual="/Software/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Software/avarPlatforms.inc.asp"-->
<!-- #include virtual="/Software/avarPublishers.inc.asp"-->
<!-- #include virtual="/Software/avarTypes.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

