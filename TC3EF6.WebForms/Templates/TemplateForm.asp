<%@ LANGUAGE="vbscript" %>
<%
'-------------------------------------------------------------------------------
' Microsoft Visual InterDev - Data Form Wizard
' 
' Form Page
'
' (c) 1997 Microsoft Corporation.  All Rights Reserved.
'
' This file is an Active Server Page that contains the form view of a Data Form. 
' It requires Microsoft Internet Information Server 3.0 and can be displayed
' using any browser that supports tables. You can edit this file to further 
' customize the form view.
'
' Modes: 		The form mode can be controlled by passing the following
'				name/value pairs using POST or GET:
'				FormMode=Edit
'				FormMode=Filter
'				FormMode=New
' Tips:			- If a field contains a URL to an image and has a name that 
'				begins with "img_" (case-insensitive), the image will be 
'				displayed using the IMG tag.
'				- If a field contains a URL and has a name that begins with 
'				"url_" (case-insensitive), a jump will be displayed using the 
'				Anchor tag.
'
' Note: This file has been drastically customized to alleviate some problems
'		with Microsoft's generated code. Do not attempt to replace this file
'		with another regenerated copy, as the results will not operate 
'		properly.
'-------------------------------------------------------------------------------

Dim strPagingMove	
Dim strFormMode
Dim strDFName
strDBName = "Books"
strDFName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Miscellaneous"
SQLstatement = "SELECT * FROM [Books] order by Subject, Alphasort"
strLookupFields = """Author"""
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

<!---------------------------- Heading Section -------------------------------->

<!-- #include virtual="/Includes/FormTemplateBottom.inc.asp"-->

