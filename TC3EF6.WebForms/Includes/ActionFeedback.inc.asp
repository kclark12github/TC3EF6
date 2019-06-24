<!-- Action feedback -->
<html>
	<head>
		<meta NAME="GENERATOR" CONTENT="Microsoft Visual InterDev">
		<meta HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=ISO-8859-1">
		<meta NAME="keywords" CONTENT="Microsoft DataForm, <%=strPageTitle%>">
		<title><%=strPageTitle%> - Feedback</title>
	</head>
	<basefont FACE="Arial, Helvetica, sans-serif">
	<link REL="STYLESHEET" HREF="/Stylesheets/<%=Theme%>/Style2.css">
	<body BACKGROUND="/Images/<%=Theme%>/Background/Back2.jpg" BGCOLOR="White">
		<table WIDTH="100%" CELLSPACING="0" CELLPADDING="0" BORDER="0">
			<tr>
				<th NOWRAP ALIGN="Left" BGCOLOR="#CCCCFF" BACKGROUND="/Images/<%=Theme%>/Navigation/Nav1.jpg">
					<font SIZE="6">&nbsp;<%=strPageTitle%> - Feedback:</font>
				</th>
			</tr>
			<tr>
				<td BGCOLOR="#FFFFCC">&nbsp;&nbsp;
				<font SIZE="-1">
<% 
			Select Case strDataAction
				Case "Insert"
					Response.Write("The following record has been inserted into " & strTablename & ".")
				Case "Update"
					Response.Write("The following updated record has been posted to " & strTablename & ".")
				Case "Delete"
					Response.Write("The record has been deleted from " & strTablename & ".")
			End Select
%>
				</font>
				</td>
			</tr>
		</table>
		<table WIDTH="100%" CELLSPACING="1" CELLPADDING="2" BORDER="0">
			<tr>
				<td WIDTH="30%" ALIGN="Left" BGCOLOR="Silver"><font SIZE="-1"><b>&nbsp;&nbsp;Field</b></font></td>
				<td WIDTH="100%" ALIGN="Left" BGCOLOR="Silver"><font SIZE="-1"><b>Value</b></font></td>
			</tr>
<%
		Response.Write Chr(13)
		'Response.Write "<" & "!-- DEBUG: " & strIgnoreFields & " -->" & CHR(13)
		For each x In Session(strDFName & "_Recordset").Fields
			Response.Write "<" & "!-- DEBUG: " & x.name & " -->" & CHR(13)
			If InStr(strIgnoreFields, QuotedString(x.Name)) = 0 Then
				'Response.Write "<" & "!-- DEBUG: " & x.name & " is not in strIgnoreFields... -->" & CHR(13)
				If InStr(strLookupFields, QuotedString(x.Name)) > 0 Then
					'Response.Write "<" & "!-- DEBUG: FeedbackField """ & x.name & """, """ & x.name & """, """ & Application(strDFName & "_Lookup_" & x.Name & "s") & """ -->" & CHR(13)
					FeedbackField x.Name, x.Name, Application(strDFName & "_Lookup_" & x.Name & "s")
				Else
					'Response.Write "<" & "!-- DEBUG: FeedbackField """ & x.name & """, """ & x.name & """, NULL -->" & CHR(13)
					FeedbackField x.Name, x.Name, Null
				End If
			End If
		Next
%>
			<tr>
				<td COLSPAN="2"><hr></td>
			</tr>
		</table>
		<FORM ACTION="<%=strBasePageName & "Action.asp"%>" METHOD="POST">
<!-- #include virtual="/Includes/BottomButtonBar.inc.asp"-->
<!-- #include virtual="/Includes/DataFooter.inc.asp"-->
	</body>
</html>
