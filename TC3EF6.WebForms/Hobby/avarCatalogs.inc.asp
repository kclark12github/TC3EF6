<% 
Dim avarCatalogs
If IsEmpty(Application(strDFName & "_Lookup_Catalogs")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsCatalogs = Hobby.Execute("SELECT ShortName FROM Companies WHERE Code <>'' AND ProductType Like 'Mail%' ORDER BY Code")
	avarCatalogs = Null
	On Error Resume Next
	avarCatalogs = rsCatalogs.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Catalogs") = avarCatalogs
	Application.Unlock
Else
	avarCatalogs = Application(strDFName & "_Lookup_Catalogs")
End If
%>
