<% 
Dim avarAuthors
If IsEmpty(Application(strRSName & "_Lookup_Authors")) Or strPagingMove = "Requery" Then
	avarAuthors = Null
	if fDebugMode Then Response.Write "DEBUG: Creating new avarAuthors...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Author FROM [" & strTableName & "] ORDER BY author")
	'On Error Resume Next
	avarAuthors = adoRS.GetRows()
	if fDebugMode Then Response.Write "DEBUG: avarAuthors contains " & UBound(avarAuthors,2) & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strRSName & "_Lookup_Authors") = avarAuthors
	Application.Unlock
Else
	if fDebugMode Then Response.Write "DEBUG: avarAuthors already exists and consists of " & UBound(Application(strRSName & "_Lookup_Authors"),2) & " rows...<br>" & CHR(13)
	avarAuthors = Application(strRSName & "_Lookup_Authors")
End If
%>
