<% 
Dim avarCatalogs
If IsEmpty(Application(strRSName & "_Lookup_Catalogs")) Or strPagingMove = "Requery" Then
	avarCatalogs = Null
	Set adoRS = Session("adoConn").Execute("Select Distinct ProductCatalog From [" & strTableName & "] Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Decals Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From DetailSets Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From FinishingProducts Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Rockets Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Tools Where ProductCatalog Is Not Null Union " & _
        "Select Distinct ProductCatalog From Trains Where ProductCatalog Is Not Null " & _
        "Order By ProductCatalog;")
	'On Error Resume Next
	avarCatalogs = adoRS.GetRows()
	Application.Lock
	Application(strRSName & "_Lookup_Catalogs") = avarCatalogs
	Application.Unlock
Else
	avarCatalogs = Application(strRSName & "_Lookup_Catalogs")
End If
%>
