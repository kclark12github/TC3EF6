<% 
Dim avarCatalogs
If IsEmpty(Application(strDFName & "_Lookup_Catalogs")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsCatalogs = Hobby.Execute("Select Distinct ProductCatalog From Kits Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Decals Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From DetailSets Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From FinishingProducts Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Rockets Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Tools Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Trains Where ProductCatalog Is Not Null " & _
        "Order By ProductCatalog;")
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
