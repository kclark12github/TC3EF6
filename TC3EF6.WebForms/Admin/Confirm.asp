<%@ LANGUAGE="VBSCRIPT" %>

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual InterDev 1.0">
<META HTTP-EQUIV="Content-Type" content="text/html; charset=iso-8859-1">
<TITLE>Options/Preferences Confirmation Page</TITLE>
</head>
<basefont face="Verdana, Arial, Helvetica">
<body BACKGROUND="/Images/Backgrounds/white2.jpg" bgcolor="#FFFFFF">
<script language="VBSCRIPT">
<!--
Sub GoHome()
	top.location.href = "/"
end sub
-->
</script>

<font size="5" face="Verdana, Arial, Helvetica"><strong>Confirmation</strong></font>
<hr>
<p><font size="3" face="Verdana, Arial, Helvetica"><i>OK <strong><%=Session("FirstName")%></strong>,
your preferences have been posted, Thanks again...!</i></font></p>

<form action="" method="POST" name="Confirm">
	<p align="center"><font size="3">
	<input type="button" name="B1" value="&nbsp;&nbsp;&nbsp;OK&nbsp;&nbsp;&nbsp" onclick="top.location.href='/'"></font></p>
</form>
</BODY>
</HTML>
