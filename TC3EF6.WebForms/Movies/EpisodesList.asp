<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsEpisodes"
strTableName = "Episodes"
strBasePageName = "Episodes"
strPageTitle = "Video Library; TV Series"
SQLstatement = "SELECT * FROM [Episodes] order by Series, Number"
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
<!-- #include virtual="/Movies/avarSeriess.inc.asp"-->
<!-- #include virtual="/Movies/avarSubjects.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Series</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Number</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Title</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		ShowListField "Series", avarSeriess, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Series") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Number") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Title") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->
