<%@ LANGUAGE="vbscript" %>
<%
Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "KFC"
strDFName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Books"
SQLstatement = "Select [Books].*,[Locations].[OName] As [Location] From [Books] Inner Join [Locations] On [Books].[LocationID]=[Locations].[ID] Order By [AlphaSort];"
strProtectedFields = """Cataloged"",""Inventoried"""
strLookupFields = """Author"",""Subject"",""Location"""
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
<!-- #include virtual="/Books/avarLocations.inc.asp"-->

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

