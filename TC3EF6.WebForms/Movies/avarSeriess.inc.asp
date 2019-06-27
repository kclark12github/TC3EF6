<% 
Dim avarSeriess
If IsEmpty(Application(strDFName & "_Lookup_Seriess")) Or strPagingMove = "Requery" Then
    Set VideoTapes = Server.CreateObject("ADODB.Connection")
    VideoTapes.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    VideoTapes.CommandTimeout = Session(strDBName & "_CommandTimeout")
    VideoTapes.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsSeriess = VideoTapes.Execute("SELECT Distinct Series FROM [Episodes] ORDER BY Series")
	avarSeriess = Null
	On Error Resume Next
	avarSeriess = rsSeriess.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsSeriess consists of " & rsSeriess.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Seriess") = avarSeriess
	Application.Unlock
Else
	avarSeriess = Application(strDFName & "_Lookup_Seriess")
End If
%>

