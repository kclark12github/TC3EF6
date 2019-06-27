<% 
Dim avarLocations
If IsEmpty(Application(strDFName & "_Lookup_Locations")) Or strPagingMove = "Requery" Then
	Set Books = Server.CreateObject("ADODB.Connection")
	Books.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
	Books.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Books.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsLocations = Books.Execute("SELECT DISTINCT Location FROM [Books] ORDER BY Location")
	avarLocations = Null
	On Error Resume Next
	avarLocations = rsLocations.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsLocations consists of " & rsLocations.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Locations") = avarLocations
	Application.Unlock
Else
	avarLocations = Application(strDFName & "_Lookup_Locations")
End If
%>
