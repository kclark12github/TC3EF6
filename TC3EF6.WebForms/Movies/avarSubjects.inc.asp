<% 
Dim avarSubjects
If IsEmpty(Application(strRSName & "_Lookup_Subjects")) Or strPagingMove = "Requery" Then
	avarSubjects = Null
	Set adoRS = Session("adoConn").Execute("SELECT Distinct Subject FROM [" & strTableName & "] ORDER BY Subject")
	'On Error Resume Next
	avarSubjects = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Subjects") = avarSubjects
	Application.Unlock
Else
	avarSubjects = Application(strRSName & "_Lookup_Subjects")
End If
%>
