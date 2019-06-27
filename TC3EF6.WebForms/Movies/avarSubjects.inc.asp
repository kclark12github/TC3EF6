<% 
Dim avarSubjects
If IsEmpty(Application(strDFName & "_Lookup_Subjects")) Or strPagingMove = "Requery" Then
    Set VideoTapes = Server.CreateObject("ADODB.Connection")
    VideoTapes.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    VideoTapes.CommandTimeout = Session(strDBName & "_CommandTimeout")
    VideoTapes.Open Session("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsSubjects = VideoTapes.Execute("SELECT Distinct Subject FROM [Movies] ORDER BY Subject")
	avarSubjects = Null
	On Error Resume Next
	avarSubjects = rsSubjects.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsSubjects consists of " & rsSubjects.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Subjects") = avarSubjects
	Application.Unlock
Else
	avarSubjects = Application(strDFName & "_Lookup_Subjects")
End If
%>
