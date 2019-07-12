<% 
Dim avarScales
If IsEmpty(Application(strRSName & "_Lookup_Scales")) Or strPagingMove = "Requery" Then
	avarScales = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Scale From [" & strTableName & "] Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Decals Where Scale Is Not Null Union " & _
        "Select Distinct Scale From DetailSets Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Rockets Where Scale Is Not Null Union " & _
        "Select Distinct Scale From Trains Where Scale Is Not Null " & _
        "Order By Scale;")
	'On Error Resume Next
	avarScales = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Scales") = avarScales
	Application.Unlock
Else
	avarScales = Application(strRSName & "_Lookup_Scales")
End If
%>
