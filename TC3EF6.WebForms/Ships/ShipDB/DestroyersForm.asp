<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsDestroyers"
strTableName = "Ships"
strBasePageName = "Destroyers"
strPageTitle = "U.S. Navy Destroyers"
SQLstatement = "SELECT * FROM Ships WHERE (HullNumber Like 'D%') ORDER BY Classification, Number"
strLookupFields = """Class"",""Classification"",""Command"",""HomePort"""
strIgnoreFields = ""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Ships/ShipDB/avarClasss.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarClassifications.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarCommands.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarHomePorts.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

