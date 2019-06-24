<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "USNavyShips"
strDFName = "rsDestroyers"
strTableName = "Destroyers"
strBasePageName = "Destroyers"
strPageTitle = "U.S. Navy Destroyers"
SQLstatement = "SELECT * FROM Ships WHERE (HullNumber Like 'D%') ORDER BY Classification, Number"
strLookupFields = """Class"",""Classification"",""Command"",""HomePort"""
strIgnoreFields = ""
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
<!-- #include virtual="/Ships/ShipDB/avarClasss.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarClassifications.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarCommands.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarHomePorts.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
