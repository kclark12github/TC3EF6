<%
End Select
If TmpNumber = 0 Then
	If strActionRedirectURL <> "" Then Response.Redirect strActionRedirectURL
%>
<!-- #include virtual="/Includes/ActionFeedback.inc.asp"-->
<% 
End If 
%>
