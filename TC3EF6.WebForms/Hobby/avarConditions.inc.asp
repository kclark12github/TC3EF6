<% 
Dim avarConditions
If IsEmpty(Application(strRSName & "_Lookup_Conditions")) Or strPagingMove = "Requery" Then
	avarConditions = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Condition From [" & strTableName & "] Where Condition Is Not Null Order By Condition;")
	'On Error Resume Next
	avarConditions = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Conditions") = avarConditions
	Application.Unlock
Else
	avarConditions = Application(strRSName & "_Lookup_Conditions")
End If
%>

