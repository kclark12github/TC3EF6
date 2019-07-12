<% 
Dim avarSeriess
If IsEmpty(Application(strRSName & "_Lookup_Seriess")) Or strPagingMove = "Requery" Then
	avarSeriess = Null
	Set adoRS = Session("adoConn").Execute("SELECT Distinct Series FROM [Episodes] ORDER BY Series")
	'On Error Resume Next
	avarSeriess = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Seriess") = avarSeriess
	Application.Unlock
Else
	avarSeriess = Application(strRSName & "_Lookup_Seriess")
End If
%>

