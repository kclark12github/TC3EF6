<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strRSName
strRSName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Books"
SQLstatement = "Select Books.*,Locations.Name As Location From Books Inner Join Locations On Books.LocationID=Locations.ID Order By AlphaSort;"
strProtectedFields = """Cataloged"",""Inventoried"""
strLookupFields = """Author"",""Subject"",""MediaFormat"",""Location"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Brownside"
blnShowUserName = False
fDebugMode = False
%>

<!-- #include virtual="/Includes/FormTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section -------------------------------->

<!-- #include virtual="/Books/avarAuthors.inc.asp"-->
<!-- #include virtual="/Books/avarSubjects.inc.asp"-->
<!-- #include virtual="/Books/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Books/avarLocations.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

