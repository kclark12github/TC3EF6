<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsShipKits"
strTableName = "Kits"
strBasePageName = "NavalModels"
strPageTitle = "Naval Models"
SQLstatement = "SELECT * FROM [Kits] WHERE Type like 'SHIP%' order by Scale, Designation, Name"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Blueside"
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Hobby/avarcatalogs.inc.asp"-->
<!-- #include virtual="/Hobby/avarconditions.inc.asp"-->
<!-- #include virtual="/Hobby/avareras.inc.asp"-->
<!-- #include virtual="/Hobby/avarlocations.inc.asp"-->
<!-- #include virtual="/Hobby/avarmanufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarnations.inc.asp"-->
<!-- #include virtual="/Hobby/avarscales.inc.asp"-->
<!-- #include virtual="/Hobby/avarservices.inc.asp"-->
<!-- #include virtual="/Hobby/avartypes.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Scale</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Designation</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Name</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Scale") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Designation") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Name") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->
