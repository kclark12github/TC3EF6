<% 
Dim avarHomePorts
If IsEmpty(Application(strDFName & "_Lookup_HomePorts")) Or strPagingMove = "Requery" Then
    Set USNavyUSNavyShips = Server.CreateObject("ADODB.Connection")
    USNavyShips.ConnectionTimeout = Session("USNavyShips_ConnectionTimeout")
    USNavyShips.CommandTimeout = Session("USNavyShips_CommandTimeout")
    USNavyShips.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsHomePorts = USNavyShips.Execute("SELECT ID, CityName FROM HomePort ORDER BY CityName")
	avarHomePorts = Null
	On Error Resume Next
	avarHomePorts = rsHomePorts.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsHomePorts consists of " & rsHomePorts.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_HomePorts") = avarHomePorts
	Application.Unlock
Else
	avarHomePorts = Application(strDFName & "_Lookup_HomePorts")
End If
%>
