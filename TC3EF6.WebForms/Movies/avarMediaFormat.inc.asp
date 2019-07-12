<% 
Dim avarMediaFormats
If IsEmpty(Application(strRSName & "_Lookup_MediaFormats")) Or strPagingMove = "Requery" Then
	avarMediaFormats = Null
	if fDebugMode Then Response.Write "DEBUG: Creating new avarMediaFormats...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT MediaFormat FROM [" & strTableName & "] ORDER BY MediaFormat")
	'On Error Resume Next
	avarMediaFormats = adoRS.GetRows()
	if fDebugMode Then Response.Write "DEBUG: avarMediaFormats contains " & UBound(avarMediaFormats,2) & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strRSName & "_Lookup_MediaFormats") = avarMediaFormats
	Application.Unlock
Else
	if fDebugMode Then Response.Write "DEBUG: avarMediaFormats already exists and consists of " & UBound(Application(strRSName & "_Lookup_MediaFormats"),2) & " rows...<br>" & CHR(13)
	avarMediaFormats = Application(strRSName & "_Lookup_MediaFormats")
End If
%>
