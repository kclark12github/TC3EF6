<% 
Dim avarPlatforms
If IsEmpty(Application(strRSName & "_Lookup_Platforms")) Or strPagingMove = "Requery" Then
	avarPlatforms = Null
	If fDebugMode Then Response.Write "DEBUG: Creating new avarPlatforms...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Platform FROM [" & strTableName & "] ORDER BY Platform")
	'On Error Resume Next
	avarPlatforms = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: avarPlatforms contains " & UBound(avarPlatforms,2) & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strRSName & "_Lookup_Platforms") = avarPlatforms
	Application.Unlock
Else
	If fDebugMode Then Response.Write "DEBUG: avarPlatforms already exists and consists of " & UBound(Application(strRSName & "_Lookup_Platforms"),2) & " rows...<br>" & CHR(13)
	avarPlatforms = Application(strRSName & "_Lookup_Platforms")
End If
%>
