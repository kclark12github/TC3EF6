<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "Software"
strDFName = "rsApple2"
strTableName = "Apple2"
strBasePageName = "Apple2"
strPageTitle = "Software Library; Apple ][ Software"
SQLstatement = "SELECT * FROM [Software] WHERE (Platform like 'Apple%' or Platform='CP/M') order by Type, Publisher, Title, Version"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Redside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Software/avarPlatforms.inc.asp"-->
<!-- #include virtual="/Software/avarPublishers.inc.asp"-->
<!-- #include virtual="/Software/avarTypes.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

