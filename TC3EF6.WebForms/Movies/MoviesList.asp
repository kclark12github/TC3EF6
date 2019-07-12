<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsMovies"
strTableName = "Videos"
strBasePageName = "Movies"
strPageTitle = "Video Library; Movies"
SQLstatement = "SELECT * FROM [Videos] order by Sort"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Greenside"
RowsToDisplay = 50
MinRowsForBottomButtons = 10
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Movies/avarDistributors.inc.asp"-->
<!-- #include virtual="/Movies/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Title</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Subject</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Title") & "</FONT></a></TD>"
		ShowListField "Subject", avarSubjects, False
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->
