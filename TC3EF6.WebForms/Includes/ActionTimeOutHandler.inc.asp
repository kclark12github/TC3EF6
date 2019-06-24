<%
		' Make sure we exit and re-process the form if session has timed out
		If IsEmpty(Session(strDFName & "_Recordset")) Then
			WriteLog "Action - " & strDataAction & "; " & Session(strDFName & "_Recordset") & " is empty, refreshing (Session Timeout: " & Session.Timeout & ")..."
			Response.Write "<html>" & CHR(13)
			Response.Write "	<head>" & CHR(13)
			Response.Write "		<meta NAME=""GENERATOR"" CONTENT=""Microsoft Visual InterDev"">" & CHR(13)
			Response.Write "		<meta HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=ISO-8859-1"">" & CHR(13)
			Response.Write "		<meta NAME=""keywords"" CONTENT=""Microsoft DataForm, " & strPageTitle & """>" & CHR(13)
			Response.Write "		<title>" & strPageTitle & " - Time Out</title>" & CHR(13)
			Response.Write "	</head>" & CHR(13)
			Response.Write "	<basefont FACE=""Arial, Helvetica, sans-serif"">" & CHR(13)
			Response.Write "	<link REL=""STYLESHEET"" HREF=""/Stylesheets/" & Theme & "/Style2.css"">" & CHR(13)
			Response.Write "	<body BACKGROUND=""/Images/" & Theme & "/Background/Back2.jpg"" BGCOLOR=""White"">" & CHR(13)
			Response.Write "		<table WIDTH=""100%"" CELLSPACING=""0"" CELLPADDING=""0"" BORDER=""0"">" & CHR(13)
			Response.Write "			<tr>" & CHR(13)
			Response.Write "				<th NOWRAP ALIGN=""Left"" BGCOLOR=""#CCCCFF"" BACKGROUND=""/Images/" & Theme & "/Navigation/Nav1.jpg"">" & CHR(13)
			Response.Write "					<font SIZE=""6"">&nbsp;" & strPageTitle & " - Time Out</font>" & CHR(13)
			Response.Write "				</th>" & CHR(13)
			Response.Write "			</tr>" & CHR(13)
			Response.Write "			<tr>" & CHR(13)
			Response.Write "				<td BGCOLOR=""#FFFFCC"">&nbsp;&nbsp;" & "<font SIZE=""-1"">Session TimeOut Exceeded</font></td>" & CHR(13)
			Response.Write "			</tr>" & CHR(13)
			Response.Write "		</table>" & CHR(13)
			Response.Write "		<hr>" & CHR(13)
			Response.Write "		<table WIDTH=""100%"" CELLSPACING=""1"" CELLPADDING=""2"" BORDER=""0"">" & CHR(13)
			Response.Write "			<tr>" & CHR(13)
			Response.Write "				<td ALIGN=""Left""><img src=""/Images/Exclamation.gif""></td>" & CHR(13)
			Response.Write "				<td ALIGN=""Left""><p>Sorry, but your " & strDataAction & " operation could not complete. The record set it was based on was represented as a session variable, and your session has timed-out after <i><b>" & Session.Timeout & "</b> minutes</i> of inactivity. Please try posting your transaction again.</p></td>" & CHR(13)
			Response.Write "			</tr>" & CHR(13)
			Response.Write "			<tr>" & CHR(13)
			Response.Write "				<td COLSPAN=""2""><hr></td>" & CHR(13)
			Response.Write "			</tr>" & CHR(13)
			Response.Write "		</table>" & CHR(13)
			Response.Write "		<FORM ACTION=""" & strBasePageName & "Action.asp" & """ METHOD=""POST"">" & CHR(13)
%>
<!-- #include virtual="/Includes/BottomButtonBar.inc.asp"-->
<!-- #include virtual="/Includes/DataFooter.inc.asp"-->
<%
			Response.Write "	</body>" & CHR(13)
			Response.Write "</html>" & CHR(13)
			TmpNumber = -1
		End If
%>		
