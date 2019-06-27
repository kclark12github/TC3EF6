<% 
Dim avarTypes
If IsEmpty(Application(strDFName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
	Set Software = Server.CreateObject("ADODB.Connection")
	Software.ConnectionTimeout = Session("Software_ConnectionTimeout")
	Software.CommandTimeout = Session("Software_CommandTimeout")
	Software.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsTypes = Software.Execute("SELECT DISTINCT Type FROM Software ORDER BY Type")
	avarTypes = Null
	On Error Resume Next
	avarTypes = rsTypes.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsTypes consists of " & rsTypes.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Types") = avarTypes
	Application.Unlock
Else
	avarTypes = Application(strDFName & "_Lookup_Types")
End If
%>
