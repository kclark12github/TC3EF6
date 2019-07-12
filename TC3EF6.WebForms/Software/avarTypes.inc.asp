<% 
Dim avarTypes
If IsEmpty(Application(strRSName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
	avarTypes = Null
	If fDebugMode Then Response.Write "DEBUG: Creating new avarTypes...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Type FROM [" & strTableName & "] ORDER BY Type")
	'On Error Resume Next
	avarTypes = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: avarTypes contains " & UBound(avarTypes,2) & " rows...<br>" & CHR(13)
    Application.Lock
	Application(strRSName & "_Lookup_Types") = avarTypes
	Application.Unlock
Else
	If fDebugMode Then Response.Write "DEBUG: avarPublishers already exists and consists of " & UBound(Application(strRSName & "_Lookup_Publishers"),2) & " rows...<br>" & CHR(13)
	avarTypes = Application(strRSName & "_Lookup_Types")
End If
%>
