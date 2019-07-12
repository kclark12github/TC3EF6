<% 
Dim avarEras
If IsEmpty(Application(strRSName & "_Lookup_Eras")) Or strPagingMove = "Requery" Then
	avarEras = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct Era From [" & strTableName & "] Order By Era;")
	'On Error Resume Next
	avarEras = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Eras") = avarEras
	Application.Unlock
Else
	avarEras = Application(strRSName & "_Lookup_Eras")
End If
%>
