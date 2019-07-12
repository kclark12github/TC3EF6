<%@ LANGUAGE="VBScript" %>
<%
strRSName = "rsUserAccessInfo"
strTableName = "UserAccessInfo"
strBasePageName = "UserAccessInfo"
strPageTitle = "User Access Info"
SQLstatement = "SELECT * FROM UserAccessInfo order by ID desc"
strLookupFields = ""
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
