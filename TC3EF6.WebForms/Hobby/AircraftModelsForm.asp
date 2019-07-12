<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsAircraftKits"
strTableName = "Kits"
strBasePageName = "AircraftModels"
strPageTitle = "Aircraft Models"
SQLstatement = "SELECT * FROM [Kits] WHERE Type like 'AIRCRAFT' order by Scale, Designation, Name"
strProtectedFields = """DateInventoried"""
strLookupFields = """Condition"",""Catalog"",""Era"",""Location"",""Manufacturer"",""Nation"",""Scale"",""Service"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Redside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Hobby/avarcatalogs.inc.asp"-->
<!-- #include virtual="/Hobby/avarconditions.inc.asp"-->
<!-- #include virtual="/Hobby/avareras.inc.asp"-->
<!-- #include virtual="/Hobby/avarlocations.inc.asp"-->
<!-- #include virtual="/Hobby/avarmanufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarnations.inc.asp"-->
<!-- #include virtual="/Hobby/avarscales.inc.asp"-->
<!-- #include virtual="/Hobby/avarservices.inc.asp"-->
<!-- #include virtual="/Hobby/avartypes.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

