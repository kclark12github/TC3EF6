<% 
Dim avarManufacturers
If IsEmpty(Application(strDFName & "_Lookup_Manufacturers")) Or strPagingMove = "Requery" Then
    Set Hobby = Server.CreateObject("ADODB.Connection")
    Hobby.ConnectionTimeout = Session(strDBName & "_ConnectionTimeout")
    Hobby.CommandTimeout = Session(strDBName & "_CommandTimeout")
    Hobby.Open Application("KFC.ConnectionString"), Session("KFC.RuntimeUserName"), Session("KFC.RuntimePassword")
	Set rsManufacturers = Hobby.Execute("Select Distinct Manufacturer From Kits Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Decals Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From DetailSets Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From FinishingProducts Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Rockets Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Tools Where Manufacturer Is Not Null Union " & _
        "Select Distinct Manufacturer From Trains Where Manufacturer Is Not Null " & _
        "Order By Manufacturer;")
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

