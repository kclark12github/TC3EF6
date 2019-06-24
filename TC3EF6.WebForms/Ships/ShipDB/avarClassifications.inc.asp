<% 
Dim avarClassifications
If IsEmpty(Application(strDFName & "_Lookup_Classifications")) Or strPagingMove = "Requery" Then
    Set USNavyUSNavyShips = Server.CreateObject("ADODB.Connection")
    USNavyShips.ConnectionTimeout = Session("USNavyShips_ConnectionTimeout")
    USNavyShips.CommandTimeout = Session("USNavyShips_CommandTimeout")
    USNavyShips.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsClassifications = USNavyShips.Execute("SELECT ID, Type & " - " & Description FROM Classification ORDER BY Type")
	avarClassifications = Null
	On Error Resume Next
	avarClassifications = rsClassifications.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsClassifications consists of " & rsClassifications.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Classifications") = avarClassifications
	Application.Unlock
Else
	avarClassifications = Application(strDFName & "_Lookup_Classifications")
End If
%>
