<% 
Dim avarArtists
If IsEmpty(Application(strRSName & "_Lookup_Artists")) Or strPagingMove = "Requery" Then
	avarArtists = Null
	Set adoRS = Session("adoConn").Execute("SELECT Distinct Artist FROM " & strTableName & " ORDER BY Artist")
	'On Error Resume Next
	avarArtists = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Artists") = avarArtists
	Application.Unlock
Else
	avarArtists = Application(strRSName & "_Lookup_Artists")
End If
%>
