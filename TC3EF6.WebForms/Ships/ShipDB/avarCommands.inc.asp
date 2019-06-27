<% 
Dim avarCommands
If IsEmpty(Application(strDFName & "_Lookup_Commands")) Or strPagingMove = "Requery" Then
    Set USNavyUSNavyShips = Server.CreateObject("ADODB.Connection")
    USNavyShips.ConnectionTimeout = Session("USNavyShips_ConnectionTimeout")
    USNavyShips.CommandTimeout = Session("USNavyShips_CommandTimeout")
    USNavyShips.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsCommands = USNavyShips.Execute("SELECT ID, Name FROM Command ORDER BY Name")
	avarCommands = Null
	On Error Resume Next
	avarCommands = rsCommands.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsCommands consists of " & rsCommands.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Commands") = avarCommands
	Application.Unlock
Else
	avarCommands = Application(strDFName & "_Lookup_Commands")
End If
%>
