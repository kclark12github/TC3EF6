<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "KFC"
strDFName = "rsMovies"
strTableName = "Movies"
strBasePageName = "Movies"
strPageTitle = "Video Library; Movies"
SQLstatement = "SELECT * FROM [Movies] order by Sort"
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
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
