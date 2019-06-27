<%@ LANGUAGE="VBScript" %>
<%
strDBName = "KFC"
strDFName = "rsLinks"
strTableName = "Links"
strBasePageName = "Links"
strPageTitle = "Links"
SQLstatement = "SELECT * FROM MenuEntries order by ButtonLabel,ParentCode,Code"
strLookupFields = ""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Redside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
