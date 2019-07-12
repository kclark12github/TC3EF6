<% 
Dim avarClasss
If IsEmpty(Application(strRSName & "_Lookup_Classs")) Or strPagingMove = "Requery" Then
	avarClasss = Null
	Set adoRS = Session("adoConn").Execute("SELECT ID, cName FROM ClassView")
	'On Error Resume Next
	avarClasss = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Classs") = avarClasss
	Application.Unlock
Else
	avarClasss = Application(strRSName & "_Lookup_Classs")
End If
%>
