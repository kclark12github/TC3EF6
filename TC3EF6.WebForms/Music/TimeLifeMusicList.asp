<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strDFName
strDBName = "KFC"
strDFName = "rsTimeLifeMusic"
strTableName = "Music"
strBasePageName = "TimeLifeMusic"
strPageTitle = "Music Library; TimeLife"
SQLstatement = "SELECT * FROM [Music] WHERE Artist like 'Various Artists (Time Life Series)' order by Alphasort"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
RowsToDisplay = 50
MinRowsForBottomButtons = 10
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Music/avarArtists.inc.asp"-->
<!-- #include virtual="/Music/avarTypes.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Series</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Artist</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Title</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Year</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Series") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Artist") & "</FONT></a></TD>"		
		'ShowListField "Artist", avarArtists, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Title") & "</FONT></a></TD>"
		ShowListField "Year", Null, False
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->