<% 
Dim avarSubjects
If IsEmpty(Application(strRSName & "_Lookup_Subjects")) Or strPagingMove = "Requery" Then
	avarSubjects = Null
	If fDebugMode Then Response.Write "DEBUG: Creating new avarSubjects...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Subject FROM [" & strTableName & "] ORDER BY Subject")
	'On Error Resume Next
	avarSubjects = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: avarSubjects contains " & UBound(avarSubjects,2) & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strRSName & "_Lookup_Subjects") = avarSubjects
	Application.Unlock
Else
	If fDebugMode Then Response.Write "DEBUG: avarSubjects already exists and consists of " & UBound(Application(strRSName & "_Lookup_Subjects"),2) & " rows...<br>" & CHR(13)
	avarSubjects = Application(strRSName & "_Lookup_Subjects")
End If
%>
