<%@ Page Title="Preferences" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="TC3EF6.WebForms.Admin.Admin" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="font-family:Arial;background-image:url(/Images/Backgrounds/white2.jpg);color:black;">
        <%--<p style="font-style:italic;"><%= Greeting %></p> --%>
<%--        <p style="font-size:smaller; color: #FF0000;">To keep your preferences from being confused with those of other folks,
        please be sure to complete the fields marked with *...</p>--%>






        <form action="<%=Application["AdminPage"]%>?FromForm=true" method="POST" name="Register">
	        <div style="text-align:left;padding-left:25px;padding-right:25px">
                <p style="font-weight:bold;font-style:italic;font-size:xx-large;">Preferences</p>
            </div>
	        <div style="text-align:center;padding-left:50px;padding-right:50px">
                <div id="Identification">
	                <hr style="color:black"/>
	                <p style="text-align:left;font-size:medium;"><b>Identification:</b></p>
	                <table border="0" style="vertical-align:middle;padding-right:10px;">
		                <tr>
			                <td style="text-align:right;">First Name:</td>
                            <td style="text-align:center;">
                                <input type="text" size="40" name="FirstName" value="<%=Session["FirstName"] %>" required tabindex="1"> 
                            </td>
		                </tr>
                        <tr>
                            <td style="text-align:right;">Last Name:</td>
                            <td style="text-align:center;">
                                <input type="text" size="40" name="LastName" value="<%=Session["LastName"]%>" tabindex="2" required> 
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right;">E-Mail Address:</td>
                            <td style="text-align:center;">
                                <input type="text" size="40" name="EMail" value="<%=Session["E-Mail"]%>" tabindex="3" required>
                            </td>
                        </tr>
	                </table>
                </div>
	            <hr style="color:black"/>
	            <p style="text-align:left;font-size:medium;"><b>Site Admin:</b></p>
	            <ul style="text-align:left;">
		            <li><a href="/Admin/LinksList.asp" target="Body"><b>Index Hyperlink DataBase...</b></a></li>
		            <li><a href="/Admin/VisitorList.asp" target="Body"><b>Visitor DataBase...</b></a></li>
		            <li><a href="/Admin/UserAccessInfoList.asp" target="Body"><b>User Access Information...</b></a></li>
	            </ul>
	            <hr style="color:black"/>
	            <p style="text-align:left;font-size:medium;"><b>MIDI Files:</b></p>
	            <table border="0">
		            <tr>
			            <td style="text-align:right;vertical-align:top;">Play MIDI Files:</td>
                        <td style="text-align:center;vertical-align:top;"><input type="checkbox" name="Music" <% if ((bool)Session["Music"]) { %> checked <% } %> tabindex="4"></td>
		            </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;">AutoStart:</td>
                        <td style="text-align:center;vertical-align:top;"><input type="checkbox" name="AutoStart" <% if ((bool)Session["AutoStart"]) { %> checked <% } %> tabindex="5"></td>
                    </tr>
                    <tr>
                        <td style="text-align:right;vertical-align:top;">Play Detached:</td>
                        <td style="text-align:center;vertical-align:top;"><input type="checkbox" name="Detached" <% if ((bool)Session["Detached"]) { %> checked <% } %> tabindex="5"></td>
                    </tr>
	            </table>
	            <hr style="color:black"/>
	            <p style="text-align:left;font-size:medium;"><b>Welcome Image:</b></p>
	            <div style="justify-content:center;width:100%">
	                <table border="0" style="text-align:center;width:100%">
		                <tr>
			                <td style="text-align:center;vertical-align:middle;" colspan="8">Lake Applet: <input type="checkbox" name="DoLake" <% if ((bool)Session["DoLake"]) { %>checked<% }%>></td>
		                </tr>
                        <tr>
                            <td style="text-align:center;vertical-align:top;" colspan=2>
                                <table border="0" style="width:100%;">
                                    <tr>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/Michael%20Whelan/Reduced%20Fileteth.gif" width=90 height=110></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/DragonSlayer50.gif" width=74 height=100></td>
                                        <td style="text-align:center;"><img src="/Aircraft/Bomber%20Aircraft/B-1%20Lancer/B-1B%20Painting2.gif" width=100 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/Boris%20Vallejo/The%20Ice%20Schooner50.gif" width=75 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/Boris%20Vallejo/Wolves50.gif" width=75 height=99></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/Darrell%20Sweet/Quest.gif" width=76 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/Frank%20Frazetta/The%20Silver%20Warrior75.gif" width=62 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/avatar.gif" width=97 height=100></td>
				                    </tr>
                                    <tr>
                <%
                    int lakeGIF = 1;    //Initialize to 1in case Session variable is empty...
                    if (Session["LakeGIF"] == null) { lakeGIF = (int)Session["LakeGIF"]; }
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 1 ? "checked" : string.Empty)} name=""LakeGIF"" value=""1""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 2 ? "checked" : string.Empty)} name=""LakeGIF"" value=""2""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 3 ? "checked" : string.Empty)} name=""LakeGIF"" value=""3""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 4 ? "checked" : string.Empty)} name=""LakeGIF"" value=""4""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 5 ? "checked" : string.Empty)} name=""LakeGIF"" value=""5""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 6 ? "checked" : string.Empty)} name=""LakeGIF"" value=""6""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 7 ? "checked" : string.Empty)} name=""LakeGIF"" value=""7""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 8 ? "checked" : string.Empty)} name=""LakeGIF"" value=""8""></td>");
                %>
				                    </tr>
                                    <tr>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/gloam.gif" width=73 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/robots.gif" width=63 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/elricsin.gif" width=54 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/storm.gif" width=73 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/king.gif" width=70 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/dragban.gif" width=61 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/draglord.gif" width=61 height=100></td>
                                        <td style="text-align:center;"><img src="/SciFi/Fantasy%20Art/royal.gif" width=77 height=100></td>
				                    </tr>
                                    <tr>
                <%
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 9 ? "checked" : string.Empty)} name=""LakeGIF"" value=""9""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 10 ? "checked" : string.Empty)} name=""LakeGIF"" value=""10""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 11 ? "checked" : string.Empty)} name=""LakeGIF"" value=""11""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 12 ? "checked" : string.Empty)} name=""LakeGIF"" value=""12""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 13 ? "checked" : string.Empty)} name=""LakeGIF"" value=""13""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 14 ? "checked" : string.Empty)} name=""LakeGIF"" value=""14""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 15 ? "checked" : string.Empty)} name=""LakeGIF"" value=""15""></td>");
                    Response.Write($@"<td style=""text-align:center;""><input type=""radio"" {(lakeGIF == 16 ? "checked" : string.Empty)} name=""LakeGIF"" value=""16""></td>");
                %>
				                    </tr>
                                    <tr>
                                        <td style="text-align:center;" colspan="3"><img src="/Images/Backgrounds/Tiger.gif" width=153 height=100></td>
                                        <td style="text-align:center;" colspan="2"><img src="/Images/Backgrounds/carney80.gif" width=196 height=100></td>
                                        <td style="text-align:center;" colspan="3"><img src="/Images/Backgrounds/Iceberg.gif" width=219 height=100></td>
				                    </tr>
				                    <tr>
                <%
                    Response.Write($@"<td style=""text-align:center;"" colspan=""3""><input type=""radio"" {(lakeGIF == 17 ? "checked" : string.Empty)} name=""LakeGIF"" value=""17""></td>");
                    Response.Write($@"<td style=""text-align:center;"" colspan=""2""><input type=""radio"" {(lakeGIF == 19 ? "checked" : string.Empty)} name=""LakeGIF"" value=""19""></td>");
                    Response.Write($@"<td style=""text-align:center;"" colspan=""3""><input type=""radio"" {(lakeGIF == 18 ? "checked" : string.Empty)} name=""LakeGIF"" value=""18""></td>");
                %>
				                    </tr>
				                    <tr>
				                        <td style="text-align:center;" colspan="8"><b>Surprise Me!</b></td>
                                    </tr>
				                    <tr>
                <%
                    Response.Write($@"<td style=""text-align:center;"" colspan=""8""><input type=""radio"" {(lakeGIF == 19 ? "checked" : string.Empty)} name=""LakeGIF"" value=""0""></td>");
                %>
				                    </tr>
                                </table>
                            </td>
		                </tr>
	                </table>
                </div>
	        </div>
            <p style="text-align:center;">
                <input type="submit" name="B1" value="Submit" onsubmit="return ValidateInput()">
            </p>
        </form>
        <hr/>
    </div>
</asp:Content>
