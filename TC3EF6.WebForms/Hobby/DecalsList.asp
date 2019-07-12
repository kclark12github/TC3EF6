<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsDecals"
strTableName = "Decals"
strBasePageName = "Decals"
strPageTitle = "Decals"
SQLstatement = "SELECT * FROM [Decals] order by Scale, Type, Name"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Scale</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Type</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Name</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Scale") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Type") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Name") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->
