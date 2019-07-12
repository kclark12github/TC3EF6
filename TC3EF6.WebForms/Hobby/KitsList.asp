<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsKits"
strTableName = "Kits"
strBasePageName = "Kits"
strPageTitle = "Kits"
SQLstatement = "Select * From [Kits] Order By Scale, Designation, Name;"
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
Theme = "Tealside"
blnShowUserName = True
fDebugMode = False
%>

<!-- #include virtual="/Includes/ListTemplateTop.inc.asp"-->

<!---------------------------- Lookups Section ------------------------------->

<!-- #include virtual="/Hobby/avarCatalogs.inc.asp"-->
<!-- #include virtual="/Hobby/avarConditions.inc.asp"-->
<!-- #include virtual="/Hobby/avarEras.inc.asp"-->
<!-- #include virtual="/Hobby/avarLocations.inc.asp"-->
<!-- #include virtual="/Hobby/avarManufacturers.inc.asp"-->
<!-- #include virtual="/Hobby/avarNations.inc.asp"-->
<!-- #include virtual="/Hobby/avarScales.inc.asp"-->
<!-- #include virtual="/Hobby/avarServices.inc.asp"-->
<!-- #include virtual="/Hobby/avarTypes.inc.asp"-->

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
