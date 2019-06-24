<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "KFC"
strDFName = "rsSpecials"
strTableName = "Specials"
strBasePageName = "Specials"
strPageTitle = "Video Library; Specials"
SQLstatement = "SELECT * FROM [Specials] order by Sort"
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
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
