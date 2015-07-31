/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.controls.validators
{
    internal abstract class BaseValidator : Component
    {
        protected Control _controlToValidate;
        protected string _errorMessage;
        protected Icon _icon;
        protected string _initialValue;
        private bool _isEnabled = true;
        protected bool _isValid;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; }
        }

        public ErrorProvider ErrorProvider { get; set; }

        [Category("Behaviour")]
        [Description("Gets or sets the control to validate.")]
        public Control ControlToValidate
        {
            get { return _controlToValidate; }
            set
            {
                _controlToValidate = value;
                // Hook up ControlToValidate's Validating event
                // at run-time ie not from VS.NET
                if ((_controlToValidate != null) && (!_controlToValidate.IsInDesignMode()))
                {
                    _controlToValidate.Validating +=
                        ControlToValidate_Validating;
                }
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the text for the error message.")]
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
            }
        }

        [Category("Appearance")]
        [Description("Gets or sets the Icon to display ErrorMessage.")]
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        [Category("Behaviour")]
        [Description("Gets or sets the default value to validate against.")]
        public string InitialValue
        {
            get { return _initialValue; }
            set { _initialValue = value; }
        }

        private bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; }
        }

        private void ControlToValidate_Validating(
            object sender,
            CancelEventArgs e)
        {
            // We don't cancel if invalid since we don't want to force
            // the focus to remain on ControlToValidate if invalid
            e.Cancel = !Validate();
            if (e.Cancel)
            {
                _controlToValidate.BackColor = Color.LightPink;
            }
            else
            {
                _controlToValidate.BackColor = Color.White;
            }
        }

        protected virtual bool Validate()
        {
            return true;
        }
    }

    internal class RequiredFieldValidator : BaseValidator
    {
        protected override bool Validate()
        {
            bool valid = true;
            bool ok2Validate = true;
            IValidatable iValidatatble = ControlToValidate.Parent as IValidatable;
            if (iValidatatble != null)
                ok2Validate = iValidatatble.Ok2Validate();
            
            if (IsEnabled 
                    && ControlToValidate != null 
                    && ControlToValidate.Enabled
                    && ErrorProvider != null 
                    && ok2Validate )
            {
                // Is valid if different than initial value,
                // which is not necessarily an empty string
                string controlValue = ControlToValidate.Text.Trim();
                string initialValue;
                if (_initialValue == null) initialValue = "";
                else initialValue = _initialValue.Trim();
                _isValid = (controlValue != initialValue);
                string errorMessage = "";
                if (!_isValid)
                {
                    errorMessage = _errorMessage;
                    if (_icon != null)
                        ErrorProvider.Icon = _icon;
                    valid = false;
                    if (ControlToValidate is ATMLControl)
                        ( (ATMLControl) ControlToValidate ).HasErrors = true;
                }
                ErrorProvider.SetError(_controlToValidate, errorMessage);
            }
            return valid;
        }
    }

    internal class RegularExpressionValidator : BaseValidator
    {
        private string _regularExpression;

        [Category("Behaviour")]
        [Description("Enter the Regular Expression mask.")]
        public string RegularExpression
        {
            get { return _regularExpression; }
            set { _regularExpression = value; }
        }

        protected override bool Validate()
        {
            bool valid = true;
            if (IsEnabled && ControlToValidate.Enabled && !string.IsNullOrWhiteSpace(_regularExpression ) )
            {
                // Is valid if different than initial value,
                // which is not necessarily an empty string
                Regex regex = new Regex(_regularExpression);
                string controlValue = ControlToValidate.Text.Trim();
                string initialValue;
                if (_initialValue == null) initialValue = "";
                else initialValue = _initialValue.Trim();
                _isValid = regex.Match(controlValue).Success;
                // Display an error if ControlToValidate is invalid
                string errorMessage = "";
                if (!_isValid)
                {
                    errorMessage = _errorMessage;
                    if (_icon != null)
                        ErrorProvider.Icon = _icon;
                    valid = false;
                    if (ControlToValidate is ATMLControl)
                        ((ATMLControl)ControlToValidate).HasErrors = true;
                }
                ErrorProvider.SetError(_controlToValidate, errorMessage);
            }
            return valid;
        }
    }

    internal class NumericFieldValidator : BaseValidator
    {
        protected override bool Validate()
        {
            bool valid = true;
            if (IsEnabled && ControlToValidate.Enabled)
            {
                // Is valid if different than initial value,
                // which is not necessarily an empty string
                string controlValue = ControlToValidate.Text.Trim();
                string initialValue;
                if (_initialValue == null) initialValue = "";
                else initialValue = _initialValue.Trim();
                double value;
                _isValid = double.TryParse(controlValue, out value);
                // Display an error if ControlToValidate is invalid
                string errorMessage = "";
                if (!_isValid)
                {
                    errorMessage = _errorMessage;
                    if (_icon != null)
                        ErrorProvider.Icon = _icon;
                    valid = false;
                    if (ControlToValidate is ATMLControl)
                        ((ATMLControl)ControlToValidate).HasErrors = true;
                }
                ErrorProvider.SetError(_controlToValidate, errorMessage);
            }
            return valid;
        }
    }

    internal class RangeFieldValidator : BaseValidator
    {
        private double _highRange;
        private double _lowRange;

        [Category("Behaviour")]
        [Description("Enter the Low Range Value.")]
        public double LowRange
        {
            get { return _lowRange; }
            set { _lowRange = value; }
        }

        [Category("Behaviour")]
        [Description("Enter the High Range value.")]
        public double HighRange
        {
            get { return _highRange; }
            set { _highRange = value; }
        }

        protected override bool Validate()
        {
            bool valid = true;
            if (IsEnabled && ControlToValidate.Enabled)
            {
                // Is valid if different than initial value,
                // which is not necessarily an empty string
                string controlValue = ControlToValidate.Text.Trim();
                string initialValue;
                if (_initialValue == null) initialValue = "";
                else initialValue = _initialValue.Trim();
                double value;
                _isValid = double.TryParse(controlValue, out value);
                // Display an error if ControlToValidate is invalid
                string errorMessage = "";
                if (_isValid)
                {
                    if ((_lowRange != null && value < _lowRange) || (_highRange != null && value > _lowRange))
                    {
                        errorMessage = _errorMessage;
                        if (_icon != null)
                            ErrorProvider.Icon = _icon;
                        valid = false;
                        if (ControlToValidate is ATMLControl)
                            ((ATMLControl)ControlToValidate).HasErrors = true;
                    }
                }
                ErrorProvider.SetError(_controlToValidate, errorMessage);
            }
            return valid;
        }
    }

    internal class XSDSchemaValidator : BaseValidator
    {
        private String _attributeName;
        private String _targetNamespace;
        private String _typeName;

        [Category("Behaviour")]
        [Description("Enter the XML Schema Type Name.")]
        public String XSDTypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

        [Category("Behaviour")]
        [Description("Enter the XML Schema Type Attribute Name.")]
        public String XSDAttributeName
        {
            get { return _attributeName; }
            set { _attributeName = value; }
        }

        [Category("Behaviour")]
        [Description("Enter the target namespace for the XML Schema Type.")]
        public String XSDTargetNamespace
        {
            get { return _targetNamespace; }
            set { _targetNamespace = value; }
        }

        protected override bool Validate()
        {
            string controlValue = ControlToValidate.Text.Trim();
            bool valid = true;
            if (IsEnabled && ControlToValidate.Enabled)
            {
                String minInclusive = null;
                String minExclusive = null;
                String maxInclusive = null;
                String maxExclusive = null;
                String length = null;
                String minLength = null;
                String maxLength = null;
                var errorMessage = new StringBuilder();
                
                XmlSchemaAttribute attribute = null;
                SchemaManager.FindAttribute(_targetNamespace, _typeName, _attributeName, out attribute);

                if (attribute == null)
                {
                    LogManager.Error("XSDSchemaValidator - Failed to locate attribute: {0} in {1}", _attributeName, _targetNamespace);
                }
                else
                {

                    XmlSchemaUse use = attribute.Use;

                    XmlSchemaSimpleType attributeSchemaType = attribute.AttributeSchemaType;
                    XmlQualifiedName qname = attributeSchemaType.BaseXmlSchemaType.QualifiedName;
                    String typeName = qname.Name;
                    ErrorProvider.SetError(_controlToValidate, "");


                    if (attributeSchemaType.Content is XmlSchemaSimpleTypeRestriction)
                    {
                        var restr = (XmlSchemaSimpleTypeRestriction) attributeSchemaType.Content;
                        foreach (object facet in restr.Facets)
                        {
                            if (facet is XmlSchemaMinInclusiveFacet)
                            {
                                var lf = facet as XmlSchemaMinInclusiveFacet;
                                if (!String.IsNullOrEmpty(controlValue))
                                {
                                    int iResult;
                                    double dResult;
                                    if ((typeName.Contains("int") && int.TryParse(controlValue, out iResult) &&
                                         iResult < int.Parse(lf.Value))
                                        ||
                                        (typeName.Contains("dou") && double.TryParse(controlValue, out dResult) &&
                                         dResult < double.Parse(lf.Value)))
                                    {
                                        errorMessage.Append((errorMessage.Length > 0) ? "\r\n" : "")
                                            .Append(String.Format("The value must not be less than {0}", lf.Value));
                                    }
                                }
                            }
                            else if (facet is XmlSchemaMinExclusiveFacet)
                            {
                                minExclusive = ((XmlSchemaMinExclusiveFacet) facet).Value;
                            }
                            else if (facet is XmlSchemaMaxInclusiveFacet)
                            {
                                maxInclusive = ((XmlSchemaMaxInclusiveFacet) facet).Value;
                            }
                            else if (facet is XmlSchemaMaxExclusiveFacet)
                            {
                                maxExclusive = ((XmlSchemaMaxExclusiveFacet) facet).Value;
                            }
                            else if (facet is XmlSchemaLengthFacet)
                            {
                                var lf = facet as XmlSchemaLengthFacet;
                                if (!String.IsNullOrEmpty(controlValue) && controlValue.Length > int.Parse(lf.Value))
                                {
                                    errorMessage.Append((errorMessage.Length > 0) ? "\r\n" : "")
                                        .Append(String.Format("The value's length must not excede {0} characters",
                                            lf.Value));
                                }
                            }
                            else if (facet is XmlSchemaMinLengthFacet)
                            {
                                var lf = facet as XmlSchemaMinLengthFacet;
                                if (!String.IsNullOrEmpty(controlValue) && controlValue.Length < int.Parse(lf.Value))
                                {
                                    errorMessage.Append((errorMessage.Length > 0) ? "\r\n" : "")
                                        .Append(String.Format("The value's length must not be less than {0} characters",
                                            lf.Value));
                                }
                            }
                            else if (facet is XmlSchemaMaxLengthFacet)
                            {
                                var lf = facet as XmlSchemaMaxLengthFacet;
                                if (!String.IsNullOrEmpty(controlValue) && controlValue.Length > int.Parse(lf.Value))
                                {
                                    errorMessage.Append((errorMessage.Length > 0) ? "\r\n" : "")
                                        .Append(
                                            String.Format("The value's length must not be greater than {0} characters",
                                                lf.Value));
                                }
                            }
                            else if (facet is XmlSchemaPatternFacet)
                            {
                                var spf = facet as XmlSchemaPatternFacet;
                                //Console.WriteLine(spf.Id + " : " + spf.Value);
                                if (!Regex.IsMatch(controlValue, spf.Value))
                                {
                                    if (_icon != null)
                                        ErrorProvider.Icon = _icon;
                                    errorMessage.Append((errorMessage.Length > 0) ? "\r\n" : "")
                                        .Append(String.Format(
                                            "The \"{0}\" value must match the regular expression: {1}",
                                            _attributeName, spf.Value));
                                    valid = false;
                                }
                            }
                            else if (facet is XmlSchemaEnumerationFacet)
                            {
                            }
                            else if (facet is XmlSchemaTotalDigitsFacet)
                            {
                            }
                            else if (facet is XmlSchemaWhiteSpaceFacet)
                            {
                            }
                        }

                        ErrorProvider.SetError(_controlToValidate, errorMessage.ToString());
                    }
                }
            }
            if (!valid)
            {
                if (ControlToValidate is ATMLControl)
                    ((ATMLControl)ControlToValidate).HasErrors = true;
            }

            return valid;
        }
    }
}