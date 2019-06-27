<% 
Dim avarClasss
If IsEmpty(Application(strDFName & "_Lookup_Classs")) Or strPagingMove = "Requery" Then
    Set USNavyShips = Server.CreateObject("ADODB.Connection")
    USNavyShips.ConnectionTimeout = Session("USNavyShips_ConnectionTimeout")
    USNavyShips.CommandTimeout = Session("USNavyShips_CommandTimeout")
    USNavyShips.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsClasss = USNavyShips.Execute("SELECT ID, cName FROM ClassView")
	avarClasss = Null
	On Error Resume Next
	avarClasss = rsClasss.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsClasss consists of " & rsClasss.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Classs") = avarClasss
	Application.Unlock
Else
	avarClasss = Application(strDFName & "_Lookup_Classs")
End If
%>
