<%
	Response.Write "</TABLE>"
	If strFormMode = "Edit" Then
		stQueryString = "?FormMode=Edit"
		fHideNavBar = False
		fHideRule = True
	Else
		fHideNavBar = True
		fHideRule = True
	End If 
Loop

If Not fNoBottomButtonBar or fNoBottomButtonBar = "" Then
%>
<!-- #include virtual="/Includes/BottomButtonBar.inc.asp"-->
<%
End If
%>

<!---------------------------- Footer Section --------------------------------->

<%
' Display a message if there are no records to show
If strFormMode = "Edit" And fEmptyRecordset Then
	Response.Write "<p align=left>No Records Available</p>"
End If
%>
<!-- #include virtual="/Includes/DataFooter.inc.asp"-->
</BODY>
</HTML>
