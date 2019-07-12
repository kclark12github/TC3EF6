<%@ LANGUAGE="vbscript" %>
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
Theme = "Greenside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

