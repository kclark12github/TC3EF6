<% 
Dim avarCommands
If IsEmpty(Application(strRSName & "_Lookup_Commands")) Or strPagingMove = "Requery" Then
	avarCommands = Null
	Set adoRS = Session("adoConn").Execute("SELECT ID, Name FROM Command ORDER BY Name")
	'On Error Resume Next
	avarCommands = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Commands") = avarCommands
	Application.Unlock
Else
	avarCommands = Application(strRSName & "_Lookup_Commands")
End If
%>
