<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsTools"
strTableName = "Tools"
strBasePageName = "Tools"
strPageTitle = "Model Tools"
SQLstatement = "SELECT * FROM [Tools] order by Manufacturer, Name"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Brownside"
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Manufacturer</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Name</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & GetLookupValue(Session(strRSName & "_Recordset")("Manufacturer"), avarManufacturers) & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Name") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->


