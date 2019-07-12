<% 
Dim avarPublishers
If IsEmpty(Application(strRSName & "_Lookup_Publishers")) Or strPagingMove = "Requery" Then
	avarPublishers = Null
	If fDebugMode Then Response.Write "DEBUG: Creating new avarPublishers...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Publisher FROM [" & strTableName & "] ORDER BY Publisher")
	'On Error Resume Next
	avarPublishers = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: avarPublishers contains " & UBound(avarPublishers,2) & " rows...<br>" & CHR(13)
    Application.Lock
	Application(strRSName & "_Lookup_Publishers") = avarPublishers
	Application.Unlock
Else
	If fDebugMode Then Response.Write "DEBUG: avarPublishers already exists and consists of " & UBound(Application(strRSName & "_Lookup_Publishers"),2) & " rows...<br>" & CHR(13)
	avarPublishers = Application(strRSName & "_Lookup_Publishers")
End If
%>
