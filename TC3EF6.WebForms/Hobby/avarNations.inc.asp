<% 
Dim avarNations
If IsEmpty(Application(strRSName & "_Lookup_Nations")) Or strPagingMove = "Requery" Then
	avarNations = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Nation From [" & strTableName & "] Where Nation Is Not Null Union " & _
        "Select Distinct Nation From Decals Where Nation Is Not Null Union " & _
        "Select Distinct Nation From DetailSets Where Nation Is Not Null Union " & _
        "Select Distinct Nation From Rockets Where Nation Is Not Null " & _
        "Order By Nation;")
	'On Error Resume Next
	avarNations = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Nations") = avarNations
	Application.Unlock
Else
	avarNations = Application(strRSName & "_Lookup_Nations")
End If
%>
