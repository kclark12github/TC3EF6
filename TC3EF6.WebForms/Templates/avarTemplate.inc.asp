<% 
Dim avarTemplate
If IsEmpty(Application(strRSName & "_Lookup_Template")) Or strPagingMove = "Requery" Then
	avarTemplate = Null
	Set adoRS = Session("adoConn").Execute("SELECT ID, Author, LastName, FirstName FROM [" & strTableName & "] ORDER BY LastName, FirstName")
	'On Error Resume Next
	avarTemplate = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: " & UBound(avarTemplate,2) & " records read...<br>" & CHR(13)
    Application.Lock
	Application(strRSName & "_Lookup_Template") = avarTemplate
	Application.Unlock
Else
	avarTemplate = Application(strRSName & "_Lookup_Template")
End If
%>
