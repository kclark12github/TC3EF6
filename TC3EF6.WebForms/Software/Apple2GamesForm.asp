<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsApple2Games"
strTableName = "Software"
strBasePageName = "Apple2Games"
strPageTitle = "Software Library; Apple ][ Games"
SQLstatement = "Select * From [Software] Where (Platform Like 'Apple%' Or Platform='CP/M') And [Type] Like 'Game%' Order By Title, Version;"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """MediaFormat"",""Location"",""Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Redside"
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

