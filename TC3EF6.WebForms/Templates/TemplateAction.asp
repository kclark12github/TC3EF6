<%@ LANGUAGE="VBScript" %>
<%
'-------------------------------------------------------------------------------
' Microsoft Visual InterDev - Data Form Wizard
' 
' Action Page
'
' (c) 1997 Microsoft Corporation.  All Rights Reserved.
'
' This file is an Active Server Page that contains the server script that 
' handles filter, update, insert, and delete commands from the form view of a 
' Data Form. It can also echo back confirmation of database operations and 
' report errors. Some commands are passed through and redirected. Microsoft 
' Internet Information Server 3.0 is required.
'
' Note: This file has been drastically customized to alleviate some problems
'		with Microsoft's generated code. Do not attempt to replace this file
'		with another regenerated copy, as the results will not operate 
'		properly.
'-------------------------------------------------------------------------------

Dim strDFName
Dim strErrorAdditionalInfo
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
strFormMode = "FeedBack"
Theme = "Brownside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Books/avarAuthors.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
