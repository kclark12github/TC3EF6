<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TC3EF6.WebForms.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding: 10px;">
        <table border="0" style="background-color:black; width: 100%">
	        <tr>
		        <td style="height: 570px">
			        <table border="0" style="background-color:black; width: 100%">
				        <tr>
					        <td style="text-align: center; color:white; width: 50%"> 
                                <h1 style="text-align: center"><i><%= Greeting %></i></h1>
						        <p style="text-align: center"><b>You are Visitor<br></b><%= HitCount.ToString("#,##0") %>  </p>
						        <p style="text-align: center"><b><i><%= SessionMessage %></i></b></p>
					        </td>
					        <td rowspan="2" style="text-align: center"> 
                                <% 
                                    if (Visitor != null && Visitor.DoLake) {
                                        //06/27/19: <applet> is no longer supported in HTML5 and most browsers...
                                        //Response.Write($@"<applet codebase=""/Java"" code=""/Java/Lake.class"" width={GIFWidth} height={GIFHeight}>");
                                        //Response.Write($@"	<param name=""image"" value=""{GIFPath}"">");
                                        //Response.Write($@"	<p>Must use a Java-enabled Browser to display this image.</p>");
                                        //Response.Write($@"</applet> ");

                                        Response.Write($@"<object type=""application/x-java-applet"" width={GIFWidth} height={GIFHeight}>");
                                        Response.Write($@"	<param name=""image"" value=""{GIFPath}"">");
                                        Response.Write($@"	<param name=""code"" value=""Lake"">");
                                        Response.Write($@"	<param name=""archive"" value=""Java/Lake.jar"">");
                                        //Response.Write($@"    <img src=""{GIFPath}"" width={GIFWidth} height={GIFHeight} border=0>");
                                        Response.Write($@"    <img src=""{GIFPath}"" border=0>");
                                        Response.Write($@"	<p style=""font-size:small"">Must use a Java-enabled Browser to display the Lake applet.</p>");
                                        Response.Write($@"</object> ");
                                    } else {
                                        //Response.Write($@"<img src=""{GIFPath}"" width={GIFWidth} height={GIFHeight} border=0>");
                                        Response.Write($@"<img src=""{GIFPath}"" border=0>");
                                    }
                                    %>
<%--                                <asp:Image ID="WelcomeImage" runat="server" ImageUrl="/SciFi/Fantasy%20Art/Michael%20Whelan/Reduced%20Fileteth.gif" />--%>
					        </td>
				        </tr>
				        <tr>
					        <td style="text-align: center; vertical-align: top; width: 50%;"><b><i><%: ExpectingMessage %></i></b></td>
				        </tr>
			        </table>
		        </td>
	        </tr>
        </table>
        <hr>
        <div style="padding: 10px;background-color:white;color:black;font-family:Arial">
            <p>Thanks for stopping by... You can find everything you need here to create great web sites! On the left here 
            you'll find links to all the areas of my site. So relax, browse around, listen to some tunes, have a little wine, 
            a little cheese...</p>

            <p>Feel free to
            steal whatever you please... that's how folks learn... To look behind the scenes, simply <i>right-mouse-click</i> on 
            the page you'd like to see, and select <b><u>V</u>iew Source</b> from the pop-up menu... that should pull up the
            ASCII HTML representing the page in your NotePad... or click on the lake image above to see how that is done... it's 
            really not that hard...</p>

            <p>Have Fun, and stop back often...!</p>
<% 
    if (Session["Visitor"] == null)
        Response.Write(@"<p>P.S. Register, and you can customize this site for your browsing pleasure...</p>");
    else
    {
        //Response.Write(@"<p><a href="""" style=""padding: 4px; border-top-style: solid; border-right-style: solid; border-bottom-style: solid; border-left-style: solid; border-color: #000000; border-width: thin; color: #000000; background-color: #F0F0F0"">Preferences</a></p>");
        Response.Write(@"<button type=""button"" class=""btn btn-secondary btn-sm"" data-toggle=""modal"" onclick=""top.location.href='/Admin/Admin.aspx'"" id=""preferences-button"">");
        Response.Write(@"    <span class=""fas fa-plus-square mr-1""></span><span>Preferences</span>");
        Response.Write(@"</button>");
    }
%>
        </div>
    </div>
</asp:Content>
