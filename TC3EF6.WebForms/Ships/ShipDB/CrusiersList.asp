<%@ LANGUAGE="VBScript" %>
<%
Dim strPagingMove
Dim strRSName
strRSName = "rsCrusiers"
strTableName = "Ships"
strBasePageName = "Crusiers"
strPageTitle = "U.S. Navy Crusiers"
SQLstatement = "SELECT * FROM Ships WHERE (HullNumber Like 'C%' And HullNumber Not Like 'CV%') ORDER BY Classification, Number"
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

<!-- #include virtual="/Ships/ShipDB/avarClasss.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarClassifications.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarCommands.inc.asp"-->
<!-- #include virtual="/Ships/ShipDB/avarHomePorts.inc.asp"-->

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Hull&nbsp;Number</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Name</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Class</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("HullNumber") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strRSName & "_Recordset")("Name") & "</FONT></a></TD>"
		ShowListField "Class", avarClasss, False
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

