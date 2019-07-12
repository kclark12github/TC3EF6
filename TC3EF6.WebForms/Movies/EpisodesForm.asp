<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsEpisodes"
strTableName = "Episodes"
strBasePageName = "Episodes"
strPageTitle = "Video Library; TV Series"
SQLstatement = "SELECT * FROM [Episodes] order by Series, Number"
strLookupFields = """Distributor"",""Series"",""Subject"""
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
<!-- #include virtual="/Movies/avarSeriess.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

