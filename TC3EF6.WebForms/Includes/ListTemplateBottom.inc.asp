<%
		fHideRule = True
%>
	</TR>

<%
Loop
If tRangeType = "Table" Then Response.Write "</TABLE>"
%>
<table>
	<tr><td><font size=1><i>Click on a row number or highlighted text to get more detail...</i></font></td></tr>
</table>
</td></tr></table>
<%
If Not Session(strDFName & "_Recordset") is Nothing Then
	If Session(strDFName & "_Recordset").State <> 0 Then	'adStateClosed
		If Session(strDFName & "_Recordset").RecordCount > Session("MinRowsForBottomButtons") Then 
			fNoListButton = True
%>
<!-- #include virtual="/Includes/BottomNavBar.inc.asp"-->
<%
			fNoListButton = False
		End If
	End If
End If
%>

<!---------------------------- Footer Section -------------------------------->

<!-- #include virtual="/Includes/DataFooter.inc.asp"-->
</BODY>
</HTML>
