<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "KFC"
strDFName = "rsAircraftDesignations"
strTableName = "AircraftDesignations"
strBasePageName = "AircraftDesignations"
strPageTitle = "Aircraft Designations"
SQLstatement = "SELECT * FROM [Aircraft Designations] order by Type, Number, Designation"
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

