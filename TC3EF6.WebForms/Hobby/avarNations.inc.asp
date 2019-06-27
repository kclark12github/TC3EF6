<% 
Dim avarNations
If IsEmpty(Application(strDFName & "_Lookup_Nations")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsNations = Hobby.Execute("Select Distinct Nation From Kits Where Nation Is Not Null Union " & _
        "Select Distinct Nation From Decals Where Nation Is Not Null Union " & _
        "Select Distinct Nation From DetailSets Where Nation Is Not Null Union " & _
        "Select Distinct Nation From Rockets Where Nation Is Not Null " & _
        "Order By Nation;")
	avarNations = Null
	On Error Resume Next
	avarNations = rsNations.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Nations") = avarNations
	Application.Unlock
Else
	avarNations = Application(strDFName & "_Lookup_Nations")
End If
%>
