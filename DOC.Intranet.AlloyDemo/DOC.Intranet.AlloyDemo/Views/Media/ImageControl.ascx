<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ImageControl.ascx.cs" Inherits="DOC.Intranet.Demo.Views.Media.ImageControl" %>

<img src="<%# ImageUrl %>" alt="<%# CurrentData.Name %>" title="<%# CurrentData.Copyright %>" class="image-file" />
