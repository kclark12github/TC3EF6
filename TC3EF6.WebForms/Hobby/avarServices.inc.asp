<% 
Dim avarServices
If IsEmpty(Application(strRSName & "_Lookup_Services")) Or strPagingMove = "Requery" Then
	avarServices = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Service From [" & strTableName & "] Where Service Is Not Null Order By Service;")
	'On Error Resume Next
	avarServices = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Services") = avarServices
	Application.Unlock
Else
	avarServices = Application(strRSName & "_Lookup_Services")
End If
%>
