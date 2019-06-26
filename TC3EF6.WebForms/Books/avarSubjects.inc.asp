<% 
Dim avarSubjects
If IsEmpty(Application(strDFName & "_Lookup_Subjects")) Or strPagingMove = "Requery" Then
	Set Books = Server.CreateObject("ADODB.Connection")
	Books.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
	Books.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Books.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsSubjects = Books.Execute("SELECT DISTINCT Subject FROM [Books] ORDER BY Subject")
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
