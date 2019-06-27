<% 
Dim avarPublishers
If IsEmpty(Application(strDFName & "_Lookup_Publishers")) Or strPagingMove = "Requery" Then
	Set Software = Server.CreateObject("ADODB.Connection")
	Software.ConnectionTimeout = Session("Software_ConnectionTimeout")
	Software.CommandTimeout = Session("Software_CommandTimeout")
	Software.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsPublishers = Software.Execute("SELECT DISTINCT Publisher FROM Software ORDER BY Publisher")
	avarPublishers = Null
	On Error Resume Next
	avarPublishers = rsPublishers.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsPublishers consists of " & rsPublishers.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Publishers") = avarPublishers
	Application.Unlock
Else
	avarPublishers = Application(strDFName & "_Lookup_Publishers")
End If
%>
