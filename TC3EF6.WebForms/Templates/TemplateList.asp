<%@ LANGUAGE="VBScript" %>

<%
'-------------------------------------------------------------------------------
' Microsoft Visual InterDev - Data Form Wizard
' 
' List Page
'
' (c) 1997 Microsoft Corporation.  All Rights Reserved.
'
' This file is an Active Server Page that contains the list view of a Data Form. 
' It requires Microsoft Internet Information Server 3.0 and can be displayed
' using any browser that supports tables. You can edit this file to further 
' customize the list view.
'
' Note: This file has been drastically customized to alleviate some problems
'		with Microsoft's generated code. Do not attempt to replace this file
'		with another regenerated copy, as the results will not operate 
'		properly.
'-------------------------------------------------------------------------------

Dim strPagingMove
Dim strDFName
strDBName = "Books"
strDFName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Miscellaneous"
SQLstatement = "SELECT * FROM [Books] order by Subject, Alphasort"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Brownside"
RowsToDisplay = 50
MinRowsForBottomButtons = 10
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Books/avarAuthors.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Title</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Author</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Subject</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Title") & "</FONT></a></TD>"
		ShowListField "Author", avarAuthors, False
		ShowListField "Subject", Null, False
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

