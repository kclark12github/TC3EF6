<% 
Dim avarClassifications
If IsEmpty(Application(strRSName & "_Lookup_Classifications")) Or strPagingMove = "Requery" Then
	avarClassifications = Null
	Set adoRS = Session("adoConn").Execute("SELECT ID, Type & " - " & Description FROM Classification ORDER BY Type")
	'On Error Resume Next
	avarClassifications = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Classifications") = avarClassifications
	Application.Unlock
Else
	avarClassifications = Application(strRSName & "_Lookup_Classifications")
End If
%>
