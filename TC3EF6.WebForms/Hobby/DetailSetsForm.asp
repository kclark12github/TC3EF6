<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "KFC"
strDFName = "rsDetailSets"
strTableName = "DetailSets"
strBasePageName = "DetailSets"
strPageTitle = "Detail Sets"
SQLstatement = "Select * From [DetailSets] Order By Scale, Name;"
strProtectedFields = """DateInventoried"""
strLookupFields = """Manufacturer"",""Catalog"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

