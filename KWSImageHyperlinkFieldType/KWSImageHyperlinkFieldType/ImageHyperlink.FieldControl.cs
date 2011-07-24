using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using KWS.Sharepoint.ImageHyperlinkFieldType;

namespace KWS.SharePoint.WebControls
{
    class ImageHyperlinkFieldControl : UrlField 
    {
        protected HyperLink hlUrlField;

        protected override string DefaultTemplateName
        {
            get
            {
                if (this.ControlMode == SPControlMode.Display)
                {
                    return this.DisplayTemplateName;
                }
                else
                {
                    return "ImageHyperlinkFieldControl";
                }
            }
        }

        public override string DisplayTemplateName
        {
            get
            {
                return "ImageHyperlinkFieldControlForDisplay";
            }
            set
            {
                base.DisplayTemplateName = value;
            }
        }

        protected override void CreateChildControls()
        {
            if (this.Field != null)
            {
                // Make sure inherited child controls are completely rendered.
                base.CreateChildControls();

                // Associate child controls in the .ascx file with the 
                // fields allocated by this control.
                this.textBox = (TextBox)TemplateContainer.FindControl("UrlFieldDescription");
                this.urlBox = (TextBox)TemplateContainer.FindControl("UrlFieldUrl");
                this.hlUrlField = (HyperLink)TemplateContainer.FindControl("hlUrlField");

                switch (this.ControlMode)
                {
                    case SPControlMode.New :
                        if (!Page.IsPostBack)
                            this.textBox.Text = string.Empty;
                        break;
                    case SPControlMode.Edit :
                        this.textBox.Text = ((SPFieldUrlValue)this.ItemFieldValue).Description;
                        this.urlBox.Text = ((SPFieldUrlValue)this.ItemFieldValue).Url;
                        break;
                    case SPControlMode.Display:
                        this.hlUrlField.ImageUrl = ((SPFieldUrlValue)this.ItemFieldValue).Description;
                        this.hlUrlField.NavigateUrl = ((SPFieldUrlValue)this.ItemFieldValue).Url;
                        break;
                }                
            }
        }

        public override object Value
        {
            get
            {
                EnsureChildControls();
                return base.Value;
            }
            set
            {
                EnsureChildControls();
                base.Value = (SPFieldUrlValue)value;
            }
        }
    }
}
