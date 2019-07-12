<% 
Dim avarHomePorts
If IsEmpty(Application(strRSName & "_Lookup_HomePorts")) Or strPagingMove = "Requery" Then
	avarHomePorts = Null
	Set adoRS = Session("adoConn").Execute("SELECT ID, CityName FROM HomePort ORDER BY CityName")
	'On Error Resume Next
	avarHomePorts = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_HomePorts") = avarHomePorts
	Application.Unlock
Else
	avarHomePorts = Application(strRSName & "_Lookup_HomePorts")
End If
%>
