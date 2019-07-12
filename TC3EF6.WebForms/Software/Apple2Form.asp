<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsApple2"
strTableName = "Software"
strBasePageName = "Apple2"
strPageTitle = "Software Library; Apple ][ Software"
SQLstatement = "Select Software.*,Locations.Name As Location From Software Inner Join Locations On Locations.ID=Software.LocationID WHERE (Platform like 'Apple%' or Platform='CP/M') order by Type, Publisher, Title, Version"
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

