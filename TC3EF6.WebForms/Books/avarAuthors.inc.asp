<% 
Dim avarAuthors
If IsEmpty(Application(strDFName & "_Lookup_Authors")) Or strPagingMove = "Requery" Then
	Set Books = Server.CreateObject("ADODB.Connection")
	Books.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
	Books.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Books.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsAuthors = Books.Execute("SELECT DISTINCT Author FROM [Books] ORDER BY author")
	avarAuthors = Null
	On Error Resume Next
	avarAuthors = rsAuthors.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsAuthors consists of " & rsAuthors.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Authors") = avarAuthors
	Application.Unlock
Else
	avarAuthors = Application(strDFName & "_Lookup_Authors")
End If
%>
