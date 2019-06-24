<%@ LANGUAGE="vbscript" %>
<%
strDBName = "Software"
strDFName = "rsPCGames"
strTableName = "PC"
strBasePageName = "PCGames"
strPageTitle = "Software Library; PC Games"
SQLstatement = "SELECT * FROM [Software] WHERE (Platform like 'Win%' or Platform like 'MS-DOS') and Type='Games' order by Title, Version"
strProtectedFields = """Cataloged"",""DateInventoried"""
strLookupFields = """Platform"",""Publisher"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Greenside"
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

