<% 
Dim avarTypes
'If IsEmpty(Application(strDFName & "_Lookup_Types")) Or strPagingMove = "Requery" Then
    Set Music = Server.CreateObject("ADODB.Connection")
    Music.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Music.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Music.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsTypes = Music.Execute("SELECT Distinct Type FROM Music ORDER BY Type")
	avarTypes = Null
	On Error Resume Next
	avarTypes = rsTypes.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsTypes consists of " & rsTypes.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Types") = avarTypes
	Application.Unlock
'Else
'	avarTypes = Application(strDFName & "_Lookup_Types")
'End If
%>
