<% 
Dim avarArtists
If IsEmpty(Application(strDFName & "_Lookup_Artists")) Or strPagingMove = "Requery" Then
    Set Music = Server.CreateObject("ADODB.Connection")
    Music.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Music.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Music.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsArtists = Music.Execute("SELECT Distinct Artist FROM Music ORDER BY Artist")
	avarArtists = Null
	On Error Resume Next
	avarArtists = rsArtists.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsArtists consists of " & rsArtists.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Artists") = avarArtists
	Application.Unlock
Else
	avarArtists = Application(strDFName & "_Lookup_Artists")
End If
%>
