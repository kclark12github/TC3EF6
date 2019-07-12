<% 
Dim avarLocations
If IsEmpty(Application(strRSName & "_Lookup_Locations")) Or strPagingMove = "Requery" Then
	avarLocations = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Name From Locations Order By Name;")
	'On Error Resume Next
	avarLocations = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Locations") = avarLocations
	Application.Unlock
Else
	avarLocations = Application(strRSName & "_Lookup_Locations")
End If
%>
