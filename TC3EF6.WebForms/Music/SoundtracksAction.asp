<%@ LANGUAGE="VBScript" %>
<%
Dim strDFName
Dim strErrorAdditionalInfo
strDBName = "KFC"
strDFName = "rsSoundtracks"
strTableName = "Music"
strBasePageName = "Soundtracks"
strPageTitle = "Music Library; Soundtracks"
SQLstatement = "SELECT * FROM [Music] WHERE Type like 'SOUNDTRACK%' order by Alphasort"
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
<!-- #include virtual="/Music/avarTypes.inc.asp"-->
<!-- #include virtual="/Includes/ActionTemplateCode.inc.asp"-->
