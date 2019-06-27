<%@ LANGUAGE="vbscript" %>
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
Theme = "Redside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

