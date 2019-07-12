<%@ LANGUAGE="VBScript" %>
<%
strRSName = "rsPCGames"
strTableName = "Software"
strBasePageName = "PCGames"
strPageTitle = "Software Library; PC Games"
SQLstatement = "Select Software.*,Locations.Name As Location From Software Inner Join Locations On Locations.ID=Software.LocationID Where (Platform Like 'Win%' Or Platform Like 'MS-DOS') And [Type] Like 'Game%' Order By Title, Version;"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = True
fDebugMode = False
fForceReadRecordSet = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Software/avarLocations.inc.asp"-->
<!-- #include virtual="/Software/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Software/avarPlatforms.inc.asp"-->
<!-- #include virtual="/Software/avarPublishers.inc.asp"-->
<!-- #include virtual="/Software/avarTypes.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Title</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Publisher</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Platform</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Media</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Location</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Title") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Publisher") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Platform") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("MediaFormat") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Location") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

