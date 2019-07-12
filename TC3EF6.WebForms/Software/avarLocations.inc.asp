<% 
Dim avarLocations
If IsEmpty(Application(strRSName & "_Lookup_Locations")) Or strPagingMove = "Requery" Then
	avarLocations = Null
	If fDebugMode Then Response.Write "DEBUG: Creating new avarLocations...<br>" & CHR(13)
	Set adoRS = Session("adoConn").Execute("SELECT DISTINCT Locations.Name As Location FROM [" & strTableName & "] Inner Join Locations On Locations.ID=[" & strTableName & "].LocationID ORDER BY Name;")
	'On Error Resume Next
	avarLocations = adoRS.GetRows()
	If fDebugMode Then Response.Write "DEBUG: avarLocations contains " & UBound(avarLocations,2) & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strRSName & "_Lookup_Locations") = avarLocations
	Application.Unlock
Else
	if fDebugMode Then Response.Write "DEBUG: avarLocations already exists and consists of " & UBound(Application(strRSName & "_Lookup_Locations"),2) & " rows...<br>" & CHR(13)
	avarLocations = Application(strRSName & "_Lookup_Locations")
End If
%>
