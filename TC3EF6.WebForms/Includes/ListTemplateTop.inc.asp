<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->

<%
If Not IsEmpty(Request("DataAction")) Then
	strDataAction = Trim(Request("DataAction"))
	PageName = Request.ServerVariables("PATH_INFO")
	PageName = Left(PageName, Len(PageName)-8) & "Action.asp"
	
	Select Case strDataAction
		Case "Filter"
			Response.Redirect PageName & "?DataAction=Filter"
		Case "New"
			Response.Redirect PageName & "?DataAction=New"
	End Select
End If
%>
<html>
<head>
	<meta NAME="GENERATOR" CONTENT="Microsoft Visual InterDev">
	<meta HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=ISO-8859-1">
	<meta NAME="Keywords" CONTENT="Microsoft Data Form, <%=strPageTitle%>">
	<title><%=strPageTitle%> - List Mode</title>
</head>

<!--------------------------- Formatting Section ------------------------------>

<BASEFONT FACE="Arial, Helvetica, sans-serif">
<LINK REL=STYLESHEET HREF="/Stylesheets/<%=Theme%>/Style2.css">
<BODY BACKGROUND="/Images/<%=Theme%>/Background/Back2.jpg" BGCOLOR=White TOPMARGIN=0>

