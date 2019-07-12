<%@ LANGUAGE="VBScript" %>
<%
strRSName = "rsLinks"
strTableName = "Links"
strBasePageName = "Links"
strPageTitle = "Links"
SQLstatement = "SELECT * FROM MenuEntries order by ButtonLabel,ParentCode,Code"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Redside"
blnShowUserName = True
fDebugMode = False
fForceReadRecordSet = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Button</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>ParentCode</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Code</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Label</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>HasMembers</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("ButtonLabel") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("ParentCode") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Code") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Label") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("HasMembers") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

