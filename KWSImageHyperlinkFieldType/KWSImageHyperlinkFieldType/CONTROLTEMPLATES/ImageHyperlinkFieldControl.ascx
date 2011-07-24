<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" %>
<SharePoint:RenderingTemplate ID="ImageHyperlinkFieldControl" runat="server">
  <Template>
    <span class="ms-formdescription"><SharePoint:EncodedLiteral ID="EncodedLiteral1" runat="server" text="<%$Resources:wss,form_type_web_address%>" EncodeMethod='HtmlEncode'/>&#160;(<asp:HyperLink id="UrlControlId" Target="_self" runat="server" />)
	&#160;<br /></span>
	<asp:TextBox id="UrlFieldUrl" dir="ltr" maxlength="255" runat="server"/><br />     
	<span class="ms-formdescription">Type the Picture address:<br /></span>
	<asp:TextBox id="UrlFieldDescription" maxlength="255" runat="server"/><br />
  </Template>
</SharePoint:RenderingTemplate>
<SharePoint:RenderingTemplate ID="ImageHyperlinkFieldControlForDisplay" runat="server">
  <Template>
    <asp:HyperLink runat="server" ID="hlUrlField" />
  </Template>
</SharePoint:RenderingTemplate>
