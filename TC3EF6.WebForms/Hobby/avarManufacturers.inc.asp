<% 
Dim avarManufacturers
If IsEmpty(Application(strDFName & "_Lookup_Manufacturers")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Session("KFC").ConnectionString, Session("KFC_RuntimeUserName"), Session("KFC_RuntimePassword")
	Set rsManufacturers = Hobby.Execute("SELECT ShortName FROM Companies WHERE ShortName <>'' AND (ProductType Like 'Model%' OR ProductType Like 'Decal%') ORDER BY ShortName")
	avarManufacturers = Null
	On Error Resume Next
	avarManufacturers = rsManufacturers.GetRows()
	Application.Lock
	Application(strDFName & "_Lookup_Manufacturers") = avarManufacturers
	Application.Unlock
Else
	avarManufacturers = Application(strDFName & "_Lookup_Manufacturers")
End If
%>

