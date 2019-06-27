<%@ LANGUAGE="vbscript" %>
<%
strDBName = "KFC"
strDFName = "rsVisitors"
strTableName = "Visitors"
strBasePageName = "Visitor"
strPageTitle = "Visitors"
SQLstatement = "SELECT * FROM Visitors order by LastName,FirstName"
strLookupFields = ""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

