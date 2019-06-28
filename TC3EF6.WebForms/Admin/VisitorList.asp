<%@ LANGUAGE="VBScript" %>
<%
strDBName = "KFC"
strDFName = "rsVisitors"
strTableName = "Visitors"
strBasePageName = "Visitor"
strPageTitle = "Visitors"
SQLstatement = "Select * From Visitors Order By LastName,FirstName;"
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

<!---------------------------- Heading Section ------------------------------->

<!-- #include virtual="/Includes/ListTemplateBody1.inc.asp"-->
		<TD ALIGN=Left><FONT SIZE=-1><B>Last&nbsp;Name</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>First&nbsp;Name</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>E-Mail</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Visits</B></FONT></TD>
		<TD ALIGN=Left><FONT SIZE=-1><B>Date&nbsp;Last&nbsp;Visit</B></FONT></TD>
<!-- #include virtual="/Includes/ListTemplateBody2.inc.asp"-->
<%
		'	ShowListField "ID", Null, False
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("LastName") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("FirstName") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Email") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("Visits") & "</FONT></a></TD>"
		Response.Write "<TD BGCOLOR=White ALIGN=Left NOWRAP><FONT SIZE=-1><A HREF=" & QuotedString(strBasePageName & "Action.asp?Bookmark=" & tCurRec & "&DataAction=Find") & ">" & Session(strDFName & "_Recordset")("DateLastVisit") & "</FONT></a></TD>"
%>
<!-- #include virtual="/Includes/ListTemplateBottom.inc.asp"-->

