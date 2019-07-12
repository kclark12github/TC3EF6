<%@ LANGUAGE="VBScript" %>

<%
Dim strPagingMove
Dim strRSName
strRSName = "rsBooks"
strTableName = "Books"
strBasePageName = "Books"
strPageTitle = "Library; Books"
SQLstatement = "Select Books.*,Locations.Name As Location From Books Inner Join Locations On Books.LocationID=Locations.ID Order By AlphaSort;"
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
<!-- #include virtual="/Books/avarSubjects.inc.asp"-->
<!-- #include virtual="/Books/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Books/avarLocations.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Subject</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>AlphaSort</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Format</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Location</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Subject") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Alphasort") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("MediaFormat") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Location") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

