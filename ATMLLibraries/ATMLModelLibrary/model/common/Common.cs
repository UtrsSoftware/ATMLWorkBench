/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATMLDataAccessLibrary.model;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;
using ATMLUtilitiesLibrary;
using Ionic.Crc;

namespace ATMLModelLibrary.model.common
{

    public partial class ItemDescriptionReference
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (this.Item != null)
            {
                sb.Append(Item);
            }
            else
            {
                sb.Append(this.GetType().Name);
            }
            return sb.ToString();
        }
    }

    public partial class ConfigurationResourceReference
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Item != null)
            {
                sb.Append(type).Append(" ").Append(Item);
            }
            else
            {
                sb.Append(type).Append(" ").Append(location);
            }
            return sb.ToString();
        }
    }

    public partial class DocumentReference
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(ID)
              .Append(" ")
              .Append(uuid)
              .Append(" ")
              .Append(DocumentName);
            
            return sb.ToString();
        }
    }

    public partial class unsignedLong
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "unsignedLong", testSubject, errors);
        }
    }

    public partial class unsignedInteger
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "unsignedInteger", testSubject, errors);
        }
    }

    public partial class @string
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "string", testSubject, errors);
        }
    }

    public partial class octal
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "octal", testSubject, errors);
        }
    }

    public partial class @long
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "long", testSubject, errors);
        }
    }

    public partial class integer
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "integer", testSubject, errors);
        }
    }

    public partial class hexadecimal
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "hexadecimal", testSubject, errors);
        }
    }

    public partial class @double
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "double", testSubject, errors);
        }
    }

    public partial class dateTime
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_value.ToShortDateString())
              .Append(" ")
              .Append(_value.ToShortTimeString())
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "dateTime", testSubject, errors);
        }
    }

    public partial class complex
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(base.ToPreValueString())
              .Append(" ")
              .Append(_real)
              .Append(" : ")
              .Append(imaginary)
              .Append(" ")
              .Append(standardUnit)
              .Append(" ")
              .Append(base.ToPostValueString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "complex", testSubject, errors);
        }
    }

    public partial class binary
    {
        public override string ToString()
        {
            return _value == null ? "" : "[Binary Data";
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "binary", testSubject, errors);
        }
    }

    public partial class boolean
    {
        public override string ToString()
        {
            return _value ? "true" : "false";
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "boolean", testSubject, errors);
        }
    }


    public partial class Collection
    {
        public override string ToString()
        {
            return "Collection Rows: " + (Item == null ? 0 : Item.Count);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Collection", testSubject, errors);
        }
    }

    public partial class Limit
    {

        public void CopyTo( Limit copy )
        {
            copy.@operator = @operator;
            copy.Description = Description;
            copy.Extension = Extension;
            copy.Item = Item;
            copy.name = name;
            copy.operatorSpecified = operatorSpecified;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Item == null ? "ERR" : Item.ToString());
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Limit", testSubject, errors);
        }
    }

    public partial class DatumType
    {

        public void CopyTo( DatumType copy )
        {
            copy.standardUnit = standardUnit;
            copy.unitQualifier = unitQualifier;
            copy.nonStandardUnit = nonStandardUnit;
            copy.Confidence = Confidence;
            copy.ConfidenceSpecified = ConfidenceSpecified;
            copy.Resolution = Resolution;
            copy.ResolutionSpecified = ResolutionSpecified;
            copy.ErrorLimits = ErrorLimits;
            copy.Range = Range;
        }

        public String ToPreValueString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(_unitQualifier))
                sb.Append(_unitQualifier).Append(" ");
            return sb.ToString();
        }

        public String ToPostValueString()
        {
            var sb = new StringBuilder();
            if (_confidence.HasValue)
                sb.Append("conf ").Append(_confidence.Value).Append("% ");
            if (_resolution.HasValue)
                sb.Append("res ").Append(_resolution.Value).Append("% ");
            if (_errorLimits != null)
                sb.Append("errlmt ").Append(_errorLimits);
            if (_range != null)
                sb.Append("range ").Append(_range);

            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "DatumType", testSubject, errors);
        }
    }


    public partial class LimitExpected : Value
    {
        public override string ToString()
        {
            return Enum.GetName(typeof (EqualityComparisonOperator), _comparator) + " " + base.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "LimitExpected", testSubject, errors);
        }
    }

    public partial class LimitPair : Value
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (_limit != null && _limit.Count >= 2)
            {
                sb.Append(_limit[0]).Append(" ");
                sb.Append(Enum.GetName(typeof (LogicalOperator), _operator)).Append(" ");
                sb.Append(_limit[1]);
            }
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "LimitPair", testSubject, errors);
        }
    }

    public partial class LimitMaskMaskValue : Value
    {
        public override string ToString()
        {
            return Enum.GetName(typeof (MaskOperator), _operation) + " " + (Item == null ? "ERR" : Item.ToString());
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "LimitMask", testSubject, errors);
        }
    }

    public partial class SingleLimit : Value
    {
        public override string ToString()
        {
            return Enum.GetName(typeof (ComparisonOperator), _comparator) + " " +
                   (Item == null ? "ERR" : Item.ToString());
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "SingleLimit", testSubject, errors);
        }
    }

    public partial class CollectionItem : Value
    {
        public override string ToString()
        {
            return _name + " " + (Item == null ? "ERR" : Item.ToString());
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "CollectionItem", testSubject, errors);
        }
    }

    public partial class NamedValue : Value
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "NamedValue", testSubject, errors);
        }
    }


    public partial class Value
    {
        public override string ToString()
        {
            return Item == null ? "" : Item.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Value", testSubject, errors);
        }
    }

    public partial class unsignedLongArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "ulong" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "unsignedLongArray", testSubject, errors);
        }
    }

    public partial class unsignedIntegerArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "uint" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "unsignedIntegerArray", testSubject, errors);
        }
    }

    public partial class stringArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "string" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "stringArray", testSubject, errors);
        }
    }

    public partial class octalArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "octal" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "octalArray", testSubject, errors);
        }
    }

    public partial class longArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "long" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "longArray", testSubject, errors);
        }
    }

    public partial class integerArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "int" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "integerArray", testSubject, errors);
        }
    }

    public partial class hexadecimalArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "hexadecimal" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "hexadecimalArray", testSubject, errors);
        }
    }

    public partial class doubleArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "double" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "doubleArray", testSubject, errors);
        }
    }

    public partial class complexArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "complex" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "complexArray", testSubject, errors);
        }
    }

    public partial class CollectionArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "Collection" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "CollectionArray", testSubject, errors);
        }
    }

    public partial class dateTimeArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "DateTime" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "dateTimeArray", testSubject, errors);
        }
    }

    public partial class booleanArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "bool" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "booleanArray", testSubject, errors);
        }
    }

    public partial class binaryArray : IndexedArrayType
    {
        public override string ToString()
        {
            return "binary" + dimensions;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "binaryArray", testSubject, errors);
        }
    }


    public partial class ItemDescriptionIdentification
    {
        public override string ToString()
        {
            return string.Format("Model: {0}", _modelName);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Identification", testSubject, errors);
        }
    }


    public partial class IdentificationNumber
    {
        public override string ToString()
        {
            return string.Format("Number: {0}, Type: {1}", _number, _type);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "IdentificationNumber", testSubject, errors);
        }
    }


    public partial class ItemDescription : ATMLCommon
    {
        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(name))
                sb.Append(name).Append(" ");
            if (!string.IsNullOrWhiteSpace(Description))
                sb.Append(Description).Append(" ");
            ItemDescriptionIdentification itemDescriptionIdentification = Identification;
            if (itemDescriptionIdentification != null)
            {
                sb.Append(itemDescriptionIdentification.ModelName).Append(" ");
                if (itemDescriptionIdentification.IdentificationNumbers != null)
                {
                    foreach (IdentificationNumber id in itemDescriptionIdentification.IdentificationNumbers)
                    {
                        var userId = id as UserDefinedIdentificationNumber;
                        var mfrId = id as ManufacturerIdentificationNumber;
                        sb.Append(id.type).Append(" Id: ").Append(id.number).Append(" ");
                        if (userId != null)
                            sb.Append("Qfr:").Append(userId.qualifier).Append(" ");
                        if (mfrId != null)
                            sb.Append("Mfr:").Append(mfrId.manufacturerName).Append(" ");
                    }
                }
            }
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "ItemDescription", testSubject, errors);
        }
    }


    public class Datum
    {
        public enum DatumTypes
        {
            ULONG,
            UINT,
            STRING,
            OCT,
            LONG,
            INT,
            HEX,
            DOUBLE,
            DATETIME,
            COMPLEX,
            BOOL,
            BINARY,
        }

        public static void SetDatumValue(String value, DatumType datum)
        {
            if (datum != null && !String.IsNullOrEmpty(value))
            {
                int iValue;
                long lValue;
                double dValue;
                uint uiValue;
                ulong ulValue;

                if (datum is binary)
                    ((binary) datum).value = value;
                if (datum is boolean)
                    ((boolean) datum).value = value.Equals("1"); // 0 or 1
                if (datum is dateTime)
                    ((dateTime) datum).value = DateTime.Parse(value); //YYYY-MM-DD
                if (datum is @double && double.TryParse(value, out dValue))
                    ((@double) datum).value = dValue;
                if (datum is hexadecimal)
                    ((hexadecimal) datum).value = value; //^[0-9A-Fa-f]+$
                if (datum is integer && int.TryParse(value, out iValue))
                    ((integer) datum).value = iValue;
                if (datum is @long && long.TryParse(value, out lValue))
                    ((@long) datum).value = lValue;
                if (datum is octal)
                    ((octal) datum).value = value; //^[1-7][0-7]*$
                if (datum is @string)
                    ((@string) datum).Value = value;
                if (datum is unsignedInteger && uint.TryParse(value, out uiValue))
                    ((unsignedInteger) datum).value = uiValue;
                if (datum is unsignedLong && ulong.TryParse(value, out ulValue))
                    ((unsignedLong) datum).value = ulValue;
            }
        }

        public static Object GetDatumValue(DatumType datum)
        {
            Object value = null;

            if (datum is binary)
                value = ((binary) datum).value;
            if (datum is boolean)
                value = ((boolean) datum).value;
            if (datum is dateTime)
                value = ((dateTime) datum).value;
            if (datum is @double)
                value = ((@double) datum).value;
            if (datum is hexadecimal)
                value = ((hexadecimal) datum).value;
            if (datum is integer)
                value = ((integer) datum).value;
            if (datum is @long)
                value = ((@long) datum).value;
            if (datum is octal)
                value = ((octal) datum).value;
            if (datum is @string)
                value = ((@string) datum).Value;
            if (datum is unsignedInteger)
                value = ((unsignedInteger) datum).value;
            if (datum is unsignedLong)
                value = ((unsignedLong) datum).value;

            return value;
        }


        public static Object GetNominalDatumValue(DatumType datum)
        {
            Object value = null;

            if (datum is binary)
                value = ((binary)datum).value;
            else if (datum is boolean)
                value = ((boolean)datum).value;
            else if (datum is dateTime)
                value = ((dateTime)datum).value;
            else if (datum is @double 
                || datum is integer 
                || datum is @long 
                || datum is unsignedInteger 
                || datum is unsignedLong )
            {
                Physical physical = new Physical(datum.ToString());
                value = physical.Magnitude.AnyQuantity.NominalValue;
            }
            else if (datum is hexadecimal)
                value = ((hexadecimal)datum).value;
            else if (datum is octal)
                value = ((octal)datum).value;
            else if (datum is @string)
                value = ((@string)datum).Value;

            return value;
        }



        public static DatumType GetDatumFromType(ComboBox combo)
        {
            DatumType datum = null;

            switch (combo.SelectedIndex)
            {
                case (int) DatumTypes.BINARY:
                    datum = new binary();
                    break;
                case (int) DatumTypes.BOOL:
                    datum = new boolean();
                    break;
                case (int) DatumTypes.DATETIME:
                    datum = new dateTime();
                    break;
                case (int) DatumTypes.DOUBLE:
                    datum = new @double();
                    break;
                case (int) DatumTypes.HEX:
                    datum = new hexadecimal();
                    break;
                case (int) DatumTypes.INT:
                    datum = new integer();
                    break;
                case (int) DatumTypes.LONG:
                    datum = new @long();
                    break;
                case (int) DatumTypes.OCT:
                    datum = new octal();
                    break;
                case (int) DatumTypes.STRING:
                    datum = new @string();
                    break;
                case (int) DatumTypes.UINT:
                    datum = new unsignedInteger();
                    break;
                case (int) DatumTypes.ULONG:
                    datum = new unsignedLong();
                    break;
            }
            return datum;
        }

        public static void SetDatumType(ComboBox combo, DatumType datum)
        {
            if (datum is binary)
                combo.SelectedIndex = (int) DatumTypes.BINARY;
            if (datum is boolean)
                combo.SelectedIndex = (int) DatumTypes.BOOL;
            if (datum is dateTime)
                combo.SelectedIndex = (int) DatumTypes.DATETIME;
            if (datum is @double)
                combo.SelectedIndex = (int) DatumTypes.DOUBLE;
            if (datum is hexadecimal)
                combo.SelectedIndex = (int) DatumTypes.HEX;
            if (datum is integer)
                combo.SelectedIndex = (int) DatumTypes.INT;
            if (datum is @long)
                combo.SelectedIndex = (int) DatumTypes.LONG;
            if (datum is octal)
                combo.SelectedIndex = (int) DatumTypes.OCT;
            if (datum is @string)
                combo.SelectedIndex = (int) DatumTypes.STRING;
            if (datum is unsignedInteger)
                combo.SelectedIndex = (int) DatumTypes.UINT;
            if (datum is unsignedLong)
                combo.SelectedIndex = (int) DatumTypes.ULONG;
        }


        public static void ValidateDatumValue(object datum,
            CancelEventArgs e,
            ErrorProvider errorProvider,
            Control control, object oValue)
        {
            uint ui = 0;
            ulong ul = 0;
            int i = 0;
            long l = 0;
            double d = 0;
            DateTime dt;
            String error = "";
            String value = oValue != null ? oValue.ToString() : "";
            if (datum is boolean && !Regex.IsMatch(value, "^[0-1]$"))
                error = "Invalid Boolean Expression, must be 0 or 1";
            else if (datum is hexadecimal && !Regex.IsMatch(value, "^[0-9A-Fa-f]+$"))
                error = "Invalid Hexidecimal Expression, must be 0-9 or A-F or a-f";
            else if (datum is octal && !Regex.IsMatch(value, "^[1-7][0-7]*$"))
                error = "Invalid Octal Expression, must be 0-7 ";
            else if (datum is unsignedInteger && !uint.TryParse(value, out ui))
                error = "Invalid Unsigned Integer value";
            else if (datum is unsignedLong && !ulong.TryParse(value, out ul))
                error = "Invalid Unsigned Long value";
            else if (datum is @long && !long.TryParse(value, out l))
                error = "Invalid Long value";
            else if (datum is @integer && !int.TryParse(value, out i))
                error = "Invalid Integer value";
            else if (datum is @double && !double.TryParse(value, out d))
                error = "Invalid Double value";
            else if (datum is dateTime && !DateTime.TryParse(value, out dt))
                error = "Invalid Date value";

            if (!String.IsNullOrEmpty(error) && e != null)
                e.Cancel = true;

            errorProvider.SetError(control, error);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Datum", testSubject, errors);
        }
    }


    public partial class Port
    {
        private Dictionary<String, Port> mappedPorts = new Dictionary<string, Port>();

        [XmlIgnore]
        public Dictionary<String, Port> MappedPorts
        {
            get { return mappedPorts; }
            set { mappedPorts = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_name );
            if (this.directionSpecified)
                sb.Append( string.Format( " Direction: {0}", _direction ) );
            if (this.typeSpecified)
                sb.Append(string.Format(" Type: {0}", _type));
            return sb.ToString();
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Port", testSubject, errors);
        }
    }

    public partial class Document : ATMLCommon
    {
        private int _crc32;
        private FileInfo _fileInfo;
        private HardwareItemDescriptionLegalDocumentsItemsChoiceType _legalDocumentType;
        private String contentType;
        private String description;
        private byte[] documentContent;
        private dbDocument.DocumentType documentType;

        public Document()
        {
        }

        public Document(dbDocument document)
        {
            if (document != null)
            {
                ContentType = document.contentType;
                name = document.documentName;
                DocumentContent = document.documentContent;
                if (document.documentTypeId != null) DocumentType = (dbDocument.DocumentType) document.documentTypeId;
                Description = document.documentDescription;
                uuid = document.UUID.ToString();
                version = document.documentVersion;
                if (document.contentType != null && document.contentType.Contains("text"))
                {
                    Item = Encoding.UTF8.GetString(document.documentContent);
                    ItemElementName = DocumentItemChoiceType.Text;
                }
                else
                {
                    var document_uri = (string) ATMLContext.GetProperty("environment.document-location");
                    Item = document_uri + "?id=" + uuid;
                    ItemElementName = DocumentItemChoiceType.URL;
                }
            }
        }


        [XmlIgnore]
        public string Dump
        {
            get
            {
                var dump = new StringBuilder();
                dump.Append("Document Name: ").Append(name).Append("\r\n");
                dump.Append("  Description: ").Append(description).Append("\r\n");
                dump.Append(" Content Type: ").Append(contentType).Append("\r\n");
                dump.Append("      Version: ").Append(_version).Append("\r\n");
                dump.Append("Document Type: ").Append(documentType).Append("\r\n");
                dump.Append("         uuid: ").Append(_uuid).Append("\r\n");
                dump.Append("        crc32: ").Append(_crc32).Append("\r\n");
                return dump.ToString();
            }
        }


        [XmlIgnore]
        public HardwareItemDescriptionLegalDocumentsItemsChoiceType LegalDocumentType
        {
            get { return _legalDocumentType; }
            set { _legalDocumentType = value; }
        }

        [XmlIgnore]
        public byte[] DocumentContent
        {
            get { return documentContent; }
            set
            {
                documentContent = value;
                using (var memStream = new MemoryStream(documentContent))
                {
                    var crc = new CRC32();
                    _crc32 = crc.GetCrc32(memStream);
                }
            }
        }

        [XmlIgnore]
        public FileInfo FileInfo
        {
            get { return _fileInfo; }
            set { _fileInfo = value; }
        }

        [XmlIgnore]
        public String ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        [XmlIgnore]
        public dbDocument.DocumentType DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        [XmlIgnore]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Crc32
        {
            get { return _crc32; }
        }

        public event EventHandler SaveDocument;

        protected virtual void OnSaveDocument()
        {
            EventHandler handler = SaveDocument;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Document", testSubject, errors);
        }
    }


    public partial class Connector
    {
        public override string ToString()
        {
            return ID + " : " + name;
        }

        public new bool Validate(SchemaValidationResult schemaValidationResult)
        {
            object testSubject = this;
            bool isValid = SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Connector", testSubject,
                                                  schemaValidationResult);
            return isValid;
        }
    }

    public partial class ConnectorPin
    {
        public override string ToString()
        {
            return ID + " : " + name;
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "ConnectorPin", testSubject, errors);
        }
    }


    public partial class DocumentReference : ATMLCommon
    {
        private int _crc32;
        private String contentType;

        private byte[] documentContent;

        private String documentName;

        private dbDocument.DocumentType documentType;

        [XmlIgnore]
        public byte[] DocumentContent
        {
            get { return documentContent; }
            set
            {
                documentContent = value;
                using (var memStream = new MemoryStream(documentContent))
                {
                    var crc = new CRC32();
                    _crc32 = crc.GetCrc32(memStream);
                }
            }
        }

        [XmlIgnore]
        public String DocumentName
        {
            get { return documentName; }
            set { documentName = value; }
        }

        [XmlIgnore]
        public dbDocument.DocumentType DocumentType
        {
            get { return documentType; }
            set { documentType = value; }
        }

        [XmlIgnore]
        public String ContentType
        {
            get { return contentType; }
            set { contentType = value; }
        }

        [XmlIgnore]
        public int Crc32
        {
            get { return _crc32; }
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "DocumentReference", testSubject, errors);
        }
    }


    public partial class PhysicalInterface
    {
        public override string ToString()
        {
            return string.Format("Item count: {0}", Items != null ? Items.Count : 0);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "PhysicalInterface", testSubject, errors);
        }
    }


    public partial class PhysicalInterfaceConnectors
    {
        public override string ToString()
        {
            return string.Format("Connector count: {0}", Connector != null ? Connector.Count : 0);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Connectors", testSubject, errors);
        }
    }


    public partial class PhysicalInterfacePorts
    {
        public override string ToString()
        {
            return string.Format("Port count: {0}", Port != null ? Port.Count : 0);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Ports", testSubject, errors);
        }
    }


    public partial class Interface
    {
        public override string ToString()
        {
            return string.Format("Interface Port count: {0}", Ports != null ? Ports.Count : 0);
        }

        public bool Validate(SchemaValidationResult errors)
        {
            object testSubject = this;
            return SchemaManager.Validate("urn:IEEE-1671:2010:Common", "Interface", testSubject, errors);
        }
    }
}