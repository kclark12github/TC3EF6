<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsSubmarines"
strTableName = "Ships"
strBasePageName = "Submarines"
strPageTitle = "U.S. Navy Submarines"
SQLstatement = "SELECT * FROM Ships WHERE (HullNumber Like 'SS%') ORDER BY Classification, Number"
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

