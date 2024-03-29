﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TC3EF6.WebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <dl>
        <dt>IsAuthenticated</dt>
        <dd><%= HttpContext.Current.User.Identity.IsAuthenticated %></dd>
        <dt>AuthenticationType</dt>
        <dd><%= HttpContext.Current.User.Identity.AuthenticationType %></dd>
        <dt>Name</dt>
        <dd><%= HttpContext.Current.User.Identity.Name %></dd>
        <dt>Is in "group1"</dt>
        <dd><%= HttpContext.Current.User.IsInRole("yourgroup1here") %></dd>
        <dt>Is in "group2"</dt>
        <dd><%= HttpContext.Current.User.IsInRole("yourgroup2here") %></dd>
    </dl>
</asp:Content>
