<%@ Language=VBScript%>
<!-- #include virtual="/Includes/Constants.inc.asp"-->
<%
Application.Lock
If Application("fDebugMode") or Application("fTraceMode") Then LogMessage Application("ApplicationLogFilename"), now & ": DEBUG: Default.asp Session(""ID""): " & Session("ID")
Application.UnLock
%>
<html>
<head>
<LINK REL="SHORTCUT ICON" HREF="/Images/Icons/X-Files.ico">
<title>Ken's WebSite</title>
<meta http-equiv="Content-Type" content="text/html; iso-8859-1">
<script language="VBScript">
<!--
Sub Window_onLoad()
<%
	If Application("fDebugMode") or Application("fTraceMode") Then 
%>
	Alert("Window_onLoad: Window.Name: " & """" & Window.Name & """" & "; Parent.Name: " & """" & Parent.Name & """")
<%
	End If
%>
	If Window.Name <> "" and Window.Name <> "New_Window" Then
<%
		If Application("fDebugMode") or Application("fTraceMode") Then 
			LogMessage Application("TraceLogFilename"), now & ": DEBUG: Window_onLoad: Redirecting to ""/"" because Window.Name isn't Null, nor ""New_Window""..."
			For Each key in Request.ServerVariables
				LogMessage Application("TraceLogFilename"), now & ": DEBUG: " & key & ":" & CHR(9) & """" & Request.ServerVariables(key) & """"
			Next
%>
	Alert("Window_onLoad: Redirecting to ""/"" because Window.Name (""" & Window.Name & """) isn't null, nor ""New_Window""...")
<%
		End If
%>
		top.location.href = "/"
		Window.Name = ""
	End If
End Sub
-->
</script>
</head>

<frameset cols="145,*">
    <frame src="Index.asp" name="Index" marginwidth="0" marginheight="0" align="center">
<!--    <frame src="Index.htm" name="Index" marginwidth="0" marginheight="0" align="center"> -->
    <frame src="Welcome.asp" name="Body">
    <noframes>
    </noframes>
</frameset>
<%
'<basefont face="Verdana, Arial, Helvetica">
'<body bgcolor="#FFFFFF" text="#000080" vlink="#000080" bgproperties="fixed" topmargin=0 leftmargin=0>
'	<iframe width=145 height="100%" src="/Index.asp" name="Index" marginwidth="0" marginheight="0" align=left></iframe>
'	<iframe width="100%" height="100%" src="/Welcome.asp" name="Body" marginwidth="0" marginheight="0" align=center frameborder=0></iframe>
'</body>
%>
</html>
