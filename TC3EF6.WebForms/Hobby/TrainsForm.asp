<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsTrains"
strTableName = "Trains"
strBasePageName = "Trains"
strPageTitle = "Trains"
SQLstatement = "SELECT * FROM [Trains] order by Scale, Type, Line, Manufacturer"
strProtectedFields = """DateInventoried"""
strLookupFields = """Manufacturer"",""Catalog"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Greenside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

