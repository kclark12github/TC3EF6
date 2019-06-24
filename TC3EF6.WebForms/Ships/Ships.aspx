<%@ Page Title="Ship Image Archive" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ships.aspx.cs" Inherits="TC3EF6.WebForms.Ships.Ships" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding:10px;background-image:url(/Images/Backgrounds/Water.gif);background-color:#FFFFFF;color:#FFFFFF;font-family:Arial;font-size:medium;">
        <h1><img src="Images/USflag.gif" width="100" height="55">Ship Image Archive</h1>
        <hr>
        <table border="0">
            <tr>
                <td><h2>U.S. Navy Ships</h2>
                    <ul>
                        <li><a href="Carriers/Carriers.asp"><i><b>Aircraft Carriers...</b></i></a></li>
                        <li><a href="Battleships/Battleships.asp"><i><b>Battleships...</b></i></a></li>
                        <li><a href="Crusiers/Crusiers.asp"><i><b>Crusiers...</b></i></a></li>
                        <li><a href="Destroyers/Destroyers.asp"><i><b>Destroyers...</b></i></a></li>
                        <li><a href="Submarines/Submarines.asp"><i><b>Submarines...</b></i></a></li>
                    </ul>
                </td>
                <td><a href="Images/comehome.jpg"><img src="Images/thcomehome.jpg" border="0" width="200" height="141"></a></td>
            </tr>
        </table>
        <hr>
        <table border="0">
            <tr>
                <td style="vertical-align:top"><h2>Naval Aviation...</h2>
                    <dl>
                        <dd><i>(from the </i><a href="../Aircraft/"><i><b>Aircraft Image Archive</b></i></a><i>)</i></dd>
                    </dl>
                </td>
                <td><a href="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/CVW-2%20AIRWING%20FLYOVER.jpg"><img src="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/thCVW-2%20AIRWING%20FLYOVER.jpg" border="0" width="150" height="112"></a></td>
            </tr>
            <tr>
                <td>
                    <ul>
                        <li><a href="../Aircraft/Attack%20Aircraft/A-4%20Skyhawk/A-4%20Skyhawk.htm"><i><b>A-4 Skyhawk</b></i></a></li>
                        <li><a href="../Aircraft/Attack%20Aircraft/A-6%20Intruder/A-6%20Intruder.htm"><i><b>A-6 Intruder</b></i></a></li>
                        <li><a href="../Aircraft/Attack%20Aircraft/AV-8B%20Harrier/AV-8B%20Harrier.htm"><i><b>AV-8B Harrier</b></i></a></li>
                        <li><a href="../Aircraft/Blue%20Angels/BlueAngels.asp"><i><b>Blue Angels</b></i></a></li>
                        <li><a href="../Aircraft/Cargo%20Aircraft/CH-53%20Sea%20Stallion/CH-53%20Sea%20Stallion.htm"><i><b>CH-53 Sea Stallion/Dragon</b></i></a></li>
                        <li><a href="../Aircraft/Electronic%20Warfare%20Aircraft/EA-6B%20Prowler/EA-6B%20Prowler.htm"><i><b>EA-6B Prowler</b></i></a></li>
                        <li><a href="../Aircraft/Electronic%20Warfare%20Aircraft/E-2C%20Hawkeye/E-2C%20Hawkeye.htm"><i><b>E-2C Hawkeye</b></i></a></li>
                        <li><a href="../Aircraft/Fighter%20Aircraft/F-4%20Phantom%20II/F-4%20Phantom%20II.htm"><i><b>F-4 Phantom II</b></i></a></li>
                        <li><a href="../Aircraft/Fighter%20Aircraft/F-14%20Tomcat/F-14%20Tomcat.htm"><i><b>F-14 Tomcat</b></i></a></li>
                        <li><a href="../Aircraft/Fighter%20Aircraft/FA-18%20Hornet/FA-18%20Hornet.htm"><i><b>F/A-18 Hornet</b></i></a></li>
                        <li><a href="../Aircraft/ASW-Patrol%20Aircraft/P-3%20Orion/P-3%20Orion.htm"><i><b>P-3C Orion</b></i></a></li>
                        <li><a href="../Aircraft/ASW-Patrol%20Aircraft/S-3%20Viking/S-3%20Viking.htm"><i><b>S-3A Viking</b></i></a></li>
                    </ul>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <hr>
        <h2>Links...</h2>
        <ul>
            <li><a href="USN%20Index.asp"><i><b>U.S. Navy Links</b></i></a></li>
        </ul>
    </div>
</asp:Content>
<!-- #include virtual="/Includes/Footer.inc.aspx" -->