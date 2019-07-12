<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
strRSName = "rsEpisodes"
strTableName = "Episodes"
strBasePageName = "Episodes"
strPageTitle = "Video Library; TV Series"
SQLstatement = "SELECT * FROM [Episodes] order by Series, Number"
strLookupFields = """Distributor"",""Series"",""Subject"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Greenside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Movies/avarDistributors.inc.asp"-->
<!-- #include virtual="/Movies/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Movies/avarSeriess.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
