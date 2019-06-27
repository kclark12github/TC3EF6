<% 
Dim avarLocations
If IsEmpty(Application(strDFName & "_Lookup_Locations")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsLocations = Hobby.Execute("Select Distinct Name From Locations Order By Name;")
	avarLocations = Null
	On Error Resume Next
	avarLocations = rsLocations.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Locations") = avarLocations
	Application.Unlock
Else
	avarLocations = Application(strDFName & "_Lookup_Locations")
End If
%>
