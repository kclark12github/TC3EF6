<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
strRSName = "rsAircraftDesignations"
strTableName = "AircraftDesignations"
strBasePageName = "AircraftDesignations"
strPageTitle = "Aircraft Designations"
SQLstatement = "SELECT * FROM [Aircraft Designations] order by Type, Number, Designation"
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
