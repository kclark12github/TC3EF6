<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
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
strFormMode = "FeedBack"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Movies/avarDistributors.inc.asp"-->
<!-- #include virtual="/Movies/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
