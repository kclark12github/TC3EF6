<% 
Dim avarDistributors
If IsEmpty(Application(strRSName & "_Lookup_Distributors")) Or strPagingMove = "Requery" Then
	avarDistributors = Null
	Set adoRS = Session("adoConn").Execute("SELECT Distinct Distributor FROM [" & strTableName & "] ORDER BY Distributor")
	'On Error Resume Next
	avarDistributors = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Distributors") = avarDistributors
	Application.Unlock
Else
	avarDistributors = Application(strRSName & "_Lookup_Distributors")
End If
%>
