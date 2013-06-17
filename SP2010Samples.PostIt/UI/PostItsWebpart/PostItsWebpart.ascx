<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PostItsWebpart.ascx.cs" Inherits="SP2010Samples.PostIt.UI.PostItsWebpart.PostItsWebpart" %>
<link type="text/css" href="/_LAYOUTS/INC/SP2010Samples.PostIt/css/PostIt.css" rel="stylesheet" />
<asp:Repeater runat="server" ID="postIts">
    <HeaderTemplate>
        <ul class="post-its">
    </HeaderTemplate>
    <ItemTemplate>
        <li>
            <a href="javascript:void(0);">
                <h2>
                    <asp:Literal runat="server" ID="ltrlTitle" Text='<%#Bind("Title") %>' />
                </h2>
                <p>
                    <asp:Literal runat="server" ID="ltrlDescription" Text='<%#Bind("Description") %>' />
                </p>
            </a>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
