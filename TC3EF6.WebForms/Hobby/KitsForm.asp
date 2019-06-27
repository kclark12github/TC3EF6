<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "KFC"
strDFName = "rsAircraftKits"
strTableName = "Kits"
strBasePageName = "Kits"
strPageTitle = "Kits"
SQLstatement = "Select * From [Kits] Order By Scale, Designation, Name;"
strProtectedFields = """DateInventoried"""
strLookupFields = """Condition"",""Catalog"",""Era"",""Location"",""Manufacturer"",""Nation"",""Scale"",""Service"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Tealside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->
<!-- #include virtual="/Hobby/avarConditions.inc.asp"-->
<!-- #include virtual="/Hobby/avarEras.inc.asp"-->
<!-- #include virtual="/Hobby/avarLocations.inc.asp"-->
<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarNations.inc.asp"-->
<!-- #include virtual="/Hobby/avarScales.inc.asp"-->
<!-- #include virtual="/Hobby/avarServices.inc.asp"-->
<!-- #include virtual="/Hobby/avarTypes.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

