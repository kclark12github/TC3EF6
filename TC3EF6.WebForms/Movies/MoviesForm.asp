<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsMovies"
strTableName = "Videos"
strBasePageName = "Movies"
strPageTitle = "Video Library; Movies"
SQLstatement = "SELECT * FROM [Videos] order by Sort"
strLookupFields = """Distributor"",""Subject"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Greenside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Movies/avarDistributors.inc.asp"-->
<!-- #include virtual="/Movies/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

