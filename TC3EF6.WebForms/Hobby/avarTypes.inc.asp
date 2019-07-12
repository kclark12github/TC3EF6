<% 
Dim avarTypes
If IsEmpty(Application(strRSName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
	avarTypes = Null
    'TODO: This should be refined with separate Types for the different Hobby Tables...
	Set adoRS = Session("adoConn").Execute("Select Distinct Type From [" & strTableName & "] Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Decals Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From DetailSets Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From FinishingProducts Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Rockets Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Tools Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From Trains Where [Type] Is Not Null Union " & _
        "Select Distinct [Type] From AircraftDesignations Where [Type] Is Not Null " & _
        "Order By [Type];")
	'On Error Resume Next
	avarTypes = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Types") = avarTypes
	Application.Unlock
Else
	avarTypes = Application(strRSName & "_Lookup_Types")
End If
%>
