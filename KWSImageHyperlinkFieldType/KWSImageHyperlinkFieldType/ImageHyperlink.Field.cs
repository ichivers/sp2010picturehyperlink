using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Microsoft.SharePoint.Security;
using System.Windows.Controls;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using KWS.SharePoint.WebControls;
using KWS.System.Windows.Controls;

namespace KWS.Sharepoint.ImageHyperlinkFieldType
{
    public class ImageHyperlinkField : SPFieldUrl
    {
        public ImageHyperlinkField(SPFieldCollection fields, string fieldName) : base(fields, fieldName)
        {
            base.DisplayFormat = SPUrlFieldFormatType.Hyperlink;
        }

        public ImageHyperlinkField(SPFieldCollection fields, string typeName, string displayName) : base(fields, typeName, displayName)
        {
            base.DisplayFormat = SPUrlFieldFormatType.Hyperlink;
        }

        public string UrlFieldHref { get; set; }

        public override BaseFieldControl FieldRenderingControl
        {
            [SharePointPermission(SecurityAction.LinkDemand, ObjectModel = true)]
            get
            {
                BaseFieldControl fieldControl = new ImageHyperlinkFieldControl();
                fieldControl.FieldName = this.InternalName;
                return fieldControl;
            }   
        }           

        public override string GetValidatedString(object value)
        {
            if ((this.Required == true) && ((value == null) || ((String)value == "")))
            {
                throw new SPFieldValidationException(this.Title + " must have a value.");
            } else {
                ImageHyperlinkValidationRule rule = new ImageHyperlinkValidationRule();
                ValidationResult result = rule.Validate(value, CultureInfo.InvariantCulture);
                if (!result.IsValid)
                    throw new SPFieldValidationException((String)result.ErrorContent);
                else
                {
                    return base.GetValidatedString(value);
                }
            }
        }
    }
}
