<% 
Dim avarTypes
If IsEmpty(Application(strRSName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
	avarTypes = Null
	Set adoRS = Session("adoConn").Execute("SELECT Distinct Type FROM " & strTableName & " ORDER BY Type")
	'On Error Resume Next
	avarTypes = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Types") = avarTypes
	Application.Unlock
Else
	avarTypes = Application(strRSName & "_Lookup_Types")
End If
%>
