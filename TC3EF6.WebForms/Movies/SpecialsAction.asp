<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
strRSName = "rsSpecials"
strTableName = "Videos"
strBasePageName = "Specials"
strPageTitle = "Video Library; Specials"
SQLstatement = "SELECT * FROM [Videos] order by Sort"
strLookupFields = """Distributor"",""Subject"""
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
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
