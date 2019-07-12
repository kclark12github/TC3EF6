<%
strFormMode = "Edit"	' Initalize the default
If Not IsEmpty(Request("FormMode")) Then strFormMode = Request("FormMode")
If Not IsEmpty(Request(strRSName & "_PagingMove")) Then
	strPagingMove = Trim(Request(strRSName & "_PagingMove"))
End If
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->

<html>
<head>
	<meta NAME="GENERATOR" CONTENT="Microsoft Visual InterDev">
	<meta HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=ISO-8859-1">
	<meta NAME="Keywords" CONTENT="Microsoft Data Form, <%=strPageTitle%>">
	<title><%=strPageTitle%> - Form Mode</title>
</head>

<!--------------------------- Formatting Section ------------------------------>

<BASEFONT FACE="Arial, Helvetica, sans-serif">
<LINK REL=STYLESHEET HREF="/Stylesheets/<%=Theme%>/Style2.css">
<BODY BACKGROUND="/Images/<%=Theme%>/Background/Back2.jpg" BGCOLOR=White TOPMARGIN=0>

