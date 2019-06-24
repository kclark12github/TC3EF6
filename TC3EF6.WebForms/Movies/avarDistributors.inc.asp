<% 
Dim avarDistributors
If IsEmpty(Application(strDFName & "_Lookup_Distributors")) Or strPagingMove = "Requery" Then
    Set VideoTapes = Server.CreateObject("ADODB.Connection")
    VideoTapes.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    VideoTapes.CommandTimeout = Session(strDBName & "_CommandTimeout")
    VideoTapes.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsDistributors = VideoTapes.Execute("SELECT Distinct Distributor FROM [Movies] ORDER BY Distributor")
	avarDistributors = Null
	On Error Resume Next
	avarDistributors = rsDistributors.GetRows()
	if fDebugMode Then Response.Write "DEBUG: rsDistributors consists of " & rsDistributors.RecordCount & " rows...<br>" & CHR(13)
	Application.Lock
	Application(strDFName & "_Lookup_Distributors") = avarDistributors
	Application.Unlock
Else
	avarDistributors = Application(strDFName & "_Lookup_Distributors")
End If
%>
