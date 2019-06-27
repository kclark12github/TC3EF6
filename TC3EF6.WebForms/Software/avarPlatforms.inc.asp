<% 
Dim avarPlatforms
If IsEmpty(Application(strDFName & "_Lookup_Platforms")) Or strPagingMove = "Requery" Then
	Set Software = Server.CreateObject("ADODB.Connection")
	Software.ConnectionTimeout = Session("Software_ConnectionTimeout")
	Software.CommandTimeout = Session("Software_CommandTimeout")
	Software.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsPlatforms = Software.Execute("SELECT DISTINCT Platform FROM Software ORDER BY Platform")
	avarPlatforms = Null
	On Error Resume Next
	avarPlatforms = rsPlatforms.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsPlatforms consists of " & rsPlatforms.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Platforms") = avarPlatforms
	Application.Unlock
Else
	avarPlatforms = Application(strDFName & "_Lookup_Platforms")
End If
%>
