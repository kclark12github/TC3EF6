<%@ LANGUAGE="VBScript" %>
<%
strDBName = "KFC"
strDFName = "rsVisitors"
strTableName = "Visitors"
strBasePageName = "Visitor"
strPageTitle = "Visitors"
SQLstatement = "Select * From Visitors Order By LastName,FirstName;"
strLookupFields = ""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Blueside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
