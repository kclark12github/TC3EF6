<% 
Dim avarEras
If IsEmpty(Application(strDFName & "_Lookup_Eras")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsEras = Hobby.Execute("Select Distinct Era From Kits Where Era Order By Era;")
	avarEras = Null
	On Error Resume Next
	avarEras = rsEras.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Eras") = avarEras
	Application.Unlock
Else
	avarEras = Application(strDFName & "_Lookup_Eras")
End If
%>
