<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "Software"
strDFName = "rsPC"
strTableName = "PC"
strBasePageName = "PC"
strPageTitle = "Software Library; PC Software"
SQLstatement = "SELECT * FROM [Software] WHERE (Platform like 'Win%' or Platform like 'MS-DOS') order by Type, Publisher, Title, Version"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
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

