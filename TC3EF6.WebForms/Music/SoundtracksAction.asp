<%@ LANGUAGE="VBScript" %>
<%
Dim strRSName
Dim strErrorAdditionalInfo
strRSName = "rsSoundtracks"
strTableName = "Albums"
strBasePageName = "Soundtracks"
strPageTitle = "Music Library; Soundtracks"
SQLstatement = "SELECT * FROM [Albums] WHERE Type like 'SOUNDTRACK%' order by Alphasort"
strLookupFields = """Artist"",""Type"""
strHomeGIF = ""
strFooterURL = ""
strFooterTitle = ""
strFormMode = "FeedBack"
Theme = "Blueside"
blnShowUserName = False
TmpNumber = 0
fDebugMode = False
%>

<!-- #include virtual="/Includes/DataFunctions.inc.asp"-->
<!-- #include virtual="/Music/avarArtists.inc.asp"-->
<!-- #include virtual="/Music/avarMediaFormat.inc.asp"-->
<!-- #include virtual="/Music/avarTypes.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
