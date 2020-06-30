<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="PageListBlockControl.ascx.cs" Inherits="DOC.Intranet.Demo.Views.Blocks.PageListBlockControl" %>
<%@ Register src="../Shared/PageList.ascx" tagPrefix="UC" tagName="PageList" %>

<EPiServer:Property PropertyName="Heading" CustomTagName="h2" runat="server" />
<hr />

<UC:PageList ID="PageList" runat="server" />
