<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsRock"
strTableName = "Albums"
strBasePageName = "Rock"
strPageTitle = "Music Library; Rock"
SQLstatement = "SELECT * FROM [Albums] WHERE Type like 'ROCK' order by Alphasort, Year"
strLookupFields = """Artist"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Music/avarArtists.inc.asp"-->
<!-- #include virtual="/Music/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Music/avarTypes.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

