/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ATMLModelLibrary.model.signal.basic;

namespace ATMLModelLibrary.model
{
    public class Physical
    {
        private static readonly string PHYSICAL_PATTERN =
            "( *(trms|pk_pk|pk|pk_pos|pk_neg|inst|av|inst_max|inst_min|errlmt (±|\\+-)?|±|\\+-|" +
            "range (MAX|MIN)?|MAX|MIN|to|:|\\-|res|conf|load)? *((\\+|\\-)?\\d+(\\.\\d*)?" +
            "((E|e)(\\+|\\-)?\\d+)? *((y|z|a|f|p|n|µ|u|m|c|d|h|k|M|G|T|P|E|Z|Y|Ki|Mi|Gi|Ti|Pi|Ei)?" +
            "(F|S|C|A|V|J|eV|T|N|Hz|lx|H|m|in|ft|mi|nmi|lm|cd|Wb|g|rad|deg|°|W|BW|Bm|Pa|bar|B(\\(\\d *m?W\\))?" +
            "|%|pc|decade|octave|Ohm|sr|kn|K|degC|°C|degF|°F|s|min|h|L|mol)\\d*((·|\\.|/)\\" +
            "(*(y|z|a|f|p|n|µ|u|m|c|d|h|k|M|G|T|P|E|Z|Y|Ki|Mi|Gi|Ti|Pi|Ei)?" +
            "(F|S|C|A|V|J|eV|T|N|Hz|lx|H|m|in|ft|mi|nmi|lm|cd|Wb|g|rad|deg|°|W|BW|Bm|Pa|bar|B(\\(\\d *m?W\\))?" +
            "|%|pc|decade|octave|Ohm|sr|kn|K|degC|°C|degF|°F|s|min|h|L|mol)\\d*)*)?\\)*) *)+";

        private readonly List<ErrorLimit> _errorLimits = new List<ErrorLimit>();
        private readonly QualifiedQuantity _magnitude;
        private readonly List<QualifiedQuantity> _quantities = new List<QualifiedQuantity>();
        private readonly List<RangingInformation> _ranges = new List<RangingInformation>();
        private readonly List<Quantity> _resolutions = new List<Quantity>();

        public Physical(string value)
        {
            Value = value;
            var rgx = new Regex(PHYSICAL_PATTERN);
            if (!rgx.Match(value).Success)
                throw new Exception(string.Format("Invalid Physical Expression - {0}", value));
            if( value.Contains( " to " ) && !value.Contains( "range" ))
                throw new Exception(string.Format("Invalid Physical Range - {0}, please prefix a range of values with \"range \"", value));
            string remainder = value;
            string word = NextWord(remainder, out remainder);
            while (!string.IsNullOrWhiteSpace(word))
            {
                if (IsNumericExpression(word) || IsQualifier(word))
                {
                    _magnitude = new QualifiedQuantity(word + " " + remainder, out remainder);
                    AddQuantity(_magnitude);
                }
                else if (IsRange(word))
                {
                    var range = new RangingInformation(remainder, out remainder,
                        _magnitude == null ? 0d : _magnitude.Magnitude);
                    Ranges.Add(range);
                }
                else if (IsErrorLimit(word))
                {
                    ErrorLimits.Add(new ErrorLimit(remainder, out remainder));
                }
                else if (IsResolution(word))
                {
                    Resolutions.Add(new Quantity(remainder, out remainder));
                }
                else if (IsConfidence(word))
                {
                }
                else if (IsLoad(word))
                {
                }
                word = NextWord(remainder, out remainder);
            }
        }

        public void Validate()
        {
            foreach (RangingInformation rangingInformation in _ranges)
                rangingInformation.Validate();
            foreach (QualifiedQuantity qualifiedQuantity in _quantities)
                qualifiedQuantity.Validate();
            foreach (Quantity resolution in _resolutions)
                resolution.Validate();
            foreach (ErrorLimit errorLimit in _errorLimits)
                errorLimit.Validate();
            if(_magnitude!=null )
                _magnitude.Validate();
            var rgx = new Regex(PHYSICAL_PATTERN);
            if (!rgx.Match(ToString()).Success)
                throw new Exception(string.Format("Invalid Physical Expression - {0}", ToString()));
        }

        public Loading Loading { get; set; }

        public string Value { get; set; }

        public RangingInformation GetMergedRange()
        {
            RangingInformation newRange = new RangingInformation();
            
            foreach (RangingInformation rangingInformation in _ranges)
            {
                Quantity from = rangingInformation.FromQuantity;
                Quantity to = rangingInformation.ToQuantity;
                if (newRange.FromQuantity == null || from < newRange.FromQuantity)
                    newRange.FromQuantity = from;
                if (newRange.ToQuantity == null || to > newRange.ToQuantity)
                    newRange.ToQuantity = to;
                if (rangingInformation.ErrorLimit != null)
                    newRange.ErrorLimit = newRange.ErrorLimit == null
                                              ? rangingInformation.ErrorLimit
                                              : ErrorLimit.LeastRestrictiveLimit( rangingInformation.ErrorLimit,
                                                                                  newRange.ErrorLimit );

            }
            return newRange;
        }

        public QualifiedQuantity Magnitude
        {
            get { return _magnitude; }
        }

        public List<ErrorLimit> ErrorLimits
        {
            get { return _errorLimits; }
        }

        public List<RangingInformation> Ranges
        {
            get { return _ranges; }
        }

        public List<Quantity> Resolutions
        {
            get { return _resolutions; }
        }

        public List<QualifiedQuantity> Quantities
        {
            get { return _quantities; }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public void AddQuantity(QualifiedQuantity quantity)
        {
            Quantities.Add(quantity);
        }

        public void AddRange(RangingInformation range)
        {
            Ranges.Add(range);
        }

        public static bool IsErrorLimit(string word)
        {
            return word.Trim().StartsWith("errlmt");
        }

        private static bool IsRange(string word)
        {
            return word.Trim().StartsWith("range");
        }

        public static bool IsResolution(string word)
        {
            return word.Trim().StartsWith("res");
        }

        public static bool IsConfidence(string word)
        {
            return word.Trim().ToLower().StartsWith("conf");
        }

        public static bool IsLoad(string word)
        {
            return word.Trim().StartsWith("load");
        }

        public static bool IsQualifier(string word)
        {
            qualifier q;
            return Enum.TryParse(word, true, out q);
        }

        public static bool IsNumericExpression(string word)
        {
            return Char.IsNumber(word[0]);
        }

        public static bool HasUnit(string word)
        {
            int i;
            return !Int32.TryParse(word.Substring(word.Length - 1, 1), out i);
        }

        public static string NextWord(string sentence, out string sentenceRemainder)
        {
            var word = new StringBuilder();
            sentence = sentence.Trim();
            foreach (char c in sentence)
            {
                if (c == ' ')
                    break;
                word.Append(c);
            }
            sentenceRemainder = sentence.Substring(word.Length).Trim();
            return word.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Magnitude != null)
                sb.Append(Magnitude);
            if (Resolutions.Count > 0)
            {
                foreach (Quantity resolution in Resolutions)
                    sb.Append(" res ").Append(resolution);
            }
            if (ErrorLimits.Count > 0)
            {
                foreach (ErrorLimit errorLimit in ErrorLimits)
                    sb.Append(" ").Append(errorLimit);
            }

            foreach (RangingInformation range in Ranges)
                sb.Append(" ").Append(range);

            return sb.ToString().Trim();
        }
    }

    public class QualifiedQuantity
    {
        private static readonly string QUALIFIER_PATTERN = @"(trms|pk_pk|pk|pk_pos|pk_neg|av|inst|inst_max|inst_min)?";

        private readonly Quantity _anyQuantity;
        private readonly bool _hasQualifier;
        private readonly qualifier _qualifier;


        public QualifiedQuantity(string value, out string remainder)
        {
            if (Char.IsLetter(value[0]))
            {
                string q = Physical.NextWord(value, out remainder);
                if (!Physical.IsQualifier(q))
                    throw new Exception(String.Format("Unknown Qualifier: {0}", q));
                _hasQualifier = Enum.TryParse(q, true, out _qualifier);
            }

            _anyQuantity = new Quantity(value, out remainder);
        }

        public void Validate()
        {
            if(_anyQuantity!=null)
                _anyQuantity.Validate();
        }

        public double Magnitude
        {
            get { return AnyQuantity == null ? 0d : AnyQuantity.Value; }
        }

        public qualifier Qualifier
        {
            get { return _qualifier; }
        }

        public bool HasQualifier
        {
            get { return _hasQualifier; }
        }

        public Quantity AnyQuantity
        {
            get { return _anyQuantity; }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (HasQualifier)
                sb.Append(_qualifier).Append(" ");
            if (AnyQuantity != null)
                sb.Append(AnyQuantity);
            return sb.ToString();
        }
    }

    public class AnyQuantity
    {
        public Quantity Quantity { get; set; }
        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }

    public class ErrorLimit : ICloneable
    {
        private const string PATTERN = "errlmt|±|\\+-";

        private Quantity _confidence;
        private Quantity _minusQuantity;
        private Quantity _plusQuantity;
        private Quantity _resolution;

        public ErrorLimit()
        {
        }

        public ErrorLimit(string value, out string remainder)
        {
            string nextWord = remainder = value.Trim(); //Physical.NextWord(value, out remainder);
            if (nextWord.ToLower().StartsWith("errlmt"))
                nextWord = Physical.NextWord(nextWord, out remainder).Trim();
            if (remainder.StartsWith(Quantity.PLUSMINUS1))
            {
                nextWord = remainder;
                _minusQuantity = new Quantity(Quantity.MINUS + nextWord.Substring(1), out remainder);
                _plusQuantity = new Quantity(nextWord.Substring(1), out remainder);
            }
            else if (remainder.StartsWith(Quantity.PLUSMINUS2))
            {
                nextWord = remainder;
                _minusQuantity = new Quantity(Quantity.MINUS + nextWord.Substring(2), out remainder);
                _plusQuantity = new Quantity(nextWord.Substring(2), out remainder);
            }
            else if (remainder.StartsWith(Quantity.PLUS))
            {
                string plusVal = remainder.Substring(1);
                _plusQuantity = new Quantity(plusVal, out remainder);
                if (remainder.StartsWith(Quantity.MINUS))
                    _minusQuantity = new Quantity(remainder, out remainder);
                else if (remainder.Length > 0 && Char.IsNumber(remainder[0]))
                {
                    throw new Exception(string.Format("Missing sign on the second error limit value. {0}", remainder));
                }
                else
                {
                    _plusQuantity = new Quantity(Quantity.MINUS + plusVal, out remainder);
                }
            }
            else if (remainder.StartsWith(Quantity.MINUS))
            {
                string minusVal = remainder;
                _minusQuantity = new Quantity(minusVal, out remainder);
                if (remainder.StartsWith(Quantity.PLUS))
                    _plusQuantity = new Quantity(remainder.Substring(1), out remainder);
                else if (remainder.Length > 0 && Char.IsNumber(remainder[0]))
                {
                    throw new Exception(string.Format("Missing sign on the second error limit value. {0}", remainder));
                }
                else
                {
                    _plusQuantity = new Quantity(minusVal.Substring(1), out remainder);
                }
            }
            else
            {
                nextWord = remainder;
                _minusQuantity = new Quantity(Quantity.MINUS + nextWord, out remainder);
                _plusQuantity = new Quantity(nextWord, out remainder);
            }

            if (!string.IsNullOrEmpty(remainder) && Physical.IsConfidence(remainder))
            {
                string key = Physical.NextWord(remainder, out remainder);
                _confidence = new Quantity(remainder, out remainder);
            }

            if (!string.IsNullOrEmpty(remainder) && Physical.IsResolution(remainder))
            {
                string key = Physical.NextWord(remainder, out remainder);
                _resolution = new Quantity(remainder, out remainder);
            }

            if (_confidence != null)
                _confidence.ValueChanged += delegate { OnValueChanged(); };
            if (_plusQuantity != null)
                _plusQuantity.ValueChanged += delegate { OnValueChanged(); };
            if (_minusQuantity != null)
                _minusQuantity.ValueChanged += delegate { OnValueChanged(); };
            if (_resolution != null)
                _resolution.ValueChanged += delegate { OnValueChanged(); };
        }

        public void Validate()
        {
            if (_confidence != null )
                _confidence.Validate();
            if (_minusQuantity != null)
                _minusQuantity.Validate();
            if (_plusQuantity != null)
                _plusQuantity.Validate();
            if (_resolution != null)
                _resolution.Validate();
        }

        public static ErrorLimit LeastRestrictiveLimit(ErrorLimit e1, ErrorLimit e2)
        {
            ErrorLimit newLimit = new ErrorLimit();
            newLimit.MinusQuantity = Quantity.Min(e1.MinusQuantity, e2.MinusQuantity);
            newLimit.PlusQuantity = Quantity.Max(e1.PlusQuantity, e2.PlusQuantity);
            newLimit.Confidence = Quantity.Min(e1.Confidence, e2.Confidence);
            newLimit.Resolution = Quantity.Max(e1.Resolution, e2.Resolution);
            return newLimit;
        }

        public Quantity Confidence
        {
            get { return _confidence; }
            set
            {
                _confidence = value;
                if (_confidence != null)
                {
                    _confidence.Unit = new StandardUnit("%");
                    OnValueChanged();
                }
            }
        }

        public Quantity Resolution
        {
            get { return _resolution; }
            set
            {
                _resolution = value;
                OnValueChanged();
            }
        }

        public Quantity MinusQuantity
        {
            get { return _minusQuantity; }
            set
            {
                _minusQuantity = value;
                OnValueChanged();
            }
        }

        public Quantity PlusQuantity
        {
            get { return _plusQuantity; }
            set
            {
                _plusQuantity = value;
                OnValueChanged();
            }
        }

        public object Clone()
        {
            var clone = new ErrorLimit();
            if (MinusQuantity != null)
                clone.MinusQuantity = MinusQuantity.Clone() as Quantity;
            if (PlusQuantity != null)
                clone.PlusQuantity = PlusQuantity.Clone() as Quantity;
            if (Resolution != null)
                clone.Resolution = Resolution.Clone() as Quantity;
            if (Confidence != null)
                clone.Confidence = Confidence.Clone() as Quantity;
            return clone;
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public static bool IsErrorLimit(string value)
        {
            return value.ToLower().Trim().StartsWith("errlmt");
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (MinusQuantity != null || PlusQuantity != null)
                sb.Append("errlmt ");
            if (MinusQuantity != null && PlusQuantity != null)
            {
                MinusQuantity.Value = Math.Abs(MinusQuantity.Value);
                if (MinusQuantity.ToString().Equals(PlusQuantity.ToString()))
                {
                    sb.Append(Quantity.PLUSMINUS1).Append(PlusQuantity);
                }
                else
                {
                    sb.Append(Quantity.MINUS)
                        .Append(MinusQuantity)
                        .Append(" ")
                        .Append(Quantity.PLUS)
                        .Append(PlusQuantity);
                }
            }
            else if (MinusQuantity != null)
            {
                MinusQuantity.Value = Math.Abs(MinusQuantity.Value);
                sb.Append(Quantity.MINUS).Append(MinusQuantity);
            }
            else if (PlusQuantity != null)
            {
                sb.Append(Quantity.PLUS).Append(PlusQuantity);
            }

            if (_confidence != null)
                sb.Append(" conf ").Append(_confidence);

            if (_resolution != null)
                sb.Append(" res ").Append(_resolution);

            return sb.ToString();
        }
    }

    public class Resolution
    {
        public static readonly string PATTERN = string.Format(@"(res\s+{0})?", Quantity.PATTERN);

        public event EventHandler ValueChanged;

        public Quantity Quantity { get; set; }

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (Quantity != null)
                sb.Append(string.Format("res {0}", Quantity));
            return sb.ToString();
        }

        public void Validate()
        {
            Regex regex = new Regex(PATTERN);
            if (!regex.Match(ToString()).Success)
                throw new Exception(string.Format("Invalid Resolution - {0}", ToString()));
        }

    }

    public class Confidence
    {
        public static readonly string PATTERN = string.Format(@"(conf\s+{0})?", Quantity.PATTERN );

        public event EventHandler ValueChanged;

        public Quantity Quantity { get; set; }

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            if( Quantity != null )
                sb.Append(string.Format("conf {0}",Quantity));
            return sb.ToString();
        }

        public void Validate()
        {
            Regex regex = new Regex( PATTERN );
            if( !regex.Match( ToString() ).Success )
                throw new Exception( string.Format("Invalid Confidence - {0}", ToString()));
        }
    }

    public class RangingInformation : ICloneable
    {
        public static readonly string PATTERN = string.Format(@"(range\s+{0}\s+(to|:)\s+{1})|(range\s+(MAX|MIN)?\s+{2})", Quantity.PATTERN, Quantity.PATTERN, Quantity.PATTERN);

        private ErrorLimit _errorLimit;
        private Quantity _fromQuantity;
        private Quantity _toQuantity;
        private double _magnitude;

        public RangingInformation()
        {
            
        }

        public RangingInformation(string value, double magnitude = 0)
        {
            string remainder;
            CreateRange(value, out remainder, magnitude);
        }

        public RangingInformation(string value, out string remainder, double magnitude = 0)
        {
            CreateRange(value, out remainder, magnitude);
        }

        public void Validate()
        {
            if( _fromQuantity != null )
                _fromQuantity.Validate();
            if( _toQuantity != null )
                _toQuantity.Validate();
            if (_errorLimit!=null) 
                _errorLimit.Validate();
            Regex regx = new Regex( PATTERN );
            if( !regx.Match( ToString() ).Success )
                throw new Exception(string.Format("Invalid Physical Expression - {0}", ToString()));
        }

        private void CreateRange(string value, out string remainder, double magnitude)
        {
            Quantity qty1;
            Quantity qty2;

            string nextWord = remainder = value.Trim(); //Physical.NextWord(value, out remainder);
            _magnitude = magnitude;

            if (nextWord.ToLower().StartsWith("range"))
                nextWord = Physical.NextWord(remainder, out remainder);
            if (nextWord.ToLower().StartsWith("max"))
            {
                nextWord = Physical.NextWord(remainder, out remainder);
                _toQuantity = new Quantity(remainder, out remainder);
            }
            else if (nextWord.ToLower().StartsWith("min"))
            {
                nextWord = Physical.NextWord(remainder, out remainder);
                _fromQuantity = new Quantity(remainder, out remainder);
            }
            else
            {
                if (nextWord.StartsWith(Quantity.PLUSMINUS1))
                {
                    remainder = CalculateRange(magnitude, nextWord, Quantity.PLUSMINUS1.Length);
                }
                else if (nextWord.StartsWith(Quantity.PLUSMINUS2))
                {
                    remainder = CalculateRange(magnitude, nextWord, Quantity.PLUSMINUS2.Length);
                }
                else
                {
                    _fromQuantity = new UncertainQuantity(remainder, out remainder);
                    string to = Physical.NextWord(remainder, out remainder);
                    _toQuantity = new Quantity(remainder, out remainder);
                }
            }
            if (ErrorLimit.IsErrorLimit(remainder))
                _errorLimit = new ErrorLimit(remainder, out remainder);
        }

        public Quantity FromQuantity
        {
            get { return _fromQuantity; }
            set { _fromQuantity = value; }
        }

        public Quantity ToQuantity
        {
            get { return _toQuantity; }
            set { _toQuantity = value;  }
        }

        public ErrorLimit ErrorLimit
        {
            get { return _errorLimit; }
            set { _errorLimit = value; }
        }

        public double Magnitude
        {
            get { return _magnitude; }
            set { _magnitude = value; }
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        private string CalculateRange(double magnitude, string nextWord, int size)
        {
            string remainder;
            _fromQuantity = new Quantity(nextWord.Substring(size), out remainder);
            _toQuantity = _fromQuantity.Clone() as Quantity;
            _fromQuantity.Value = magnitude - _fromQuantity.Value;
            if (_toQuantity != null) _toQuantity.Value = magnitude + _toQuantity.Value;
            return remainder;
        }

        public static bool IsRange(string value)
        {
            return value.ToLower().Trim().StartsWith("range");
        }

        public override string ToString()
        {
            var sb = new StringBuilder("range ");
            if (FromQuantity != null && ToQuantity != null)
                sb.Append(FromQuantity).Append(" to ").Append(ToQuantity);
            else if (FromQuantity != null)
                sb.Append("MIN ").Append(FromQuantity);
            else if (ToQuantity != null)
                sb.Append("MAX ").Append(ToQuantity);
            if (ErrorLimit != null)
                sb.Append(" ").Append(ErrorLimit);
            return sb.ToString();
        }

        public object Clone()
        {
            var clone = new RangingInformation();
            clone._fromQuantity = _fromQuantity.Clone() as Quantity;
            clone._toQuantity = _toQuantity.Clone() as Quantity;
            clone.ErrorLimit = _errorLimit.Clone() as ErrorLimit;
            clone.Magnitude = _magnitude;
            return clone;
        }
    }

    public class Quantity : ICloneable
    {
        public static readonly string NUMERIC_PATTERN = "(\\+|\\-)?\\d+(\\.\\d*)?((E|e)(\\+|\\-)?\\d+)? *";
        public static readonly string PATTERN = string.Format("{0}{1}", NUMERIC_PATTERN, StandardUnitPrefix.PATTERN);

        protected bool Equals(Quantity other)
        {
            return this == other;
        }

        public void Validate()
        {
            if (_unit != null)
                _unit.Validate();
            var rgx = new Regex(PATTERN);
            if (!rgx.Match(ToString()).Success)
                throw new Exception(string.Format("Invalid Physical Expression - {0}", ToString()));
        }

        public static bool operator <(Quantity qty1, Quantity qty2)
        {
            bool results = false;
            if (qty1 != null && qty2 != null)
            {
                double d1 = qty1._value*qty1._unit.Multiplier();
                double d2 = qty2._value*qty2._unit.Multiplier();
                results = d1 < d2;
            }
            return results;
        }

        public static bool operator >(Quantity qty1, Quantity qty2)
        {
            bool results = false;
            if (qty1 != null && qty2 != null)
            {
                double d1 = qty1._value * qty1._unit.Multiplier();
                double d2 = qty2._value * qty2._unit.Multiplier();
                results = d1 > d2;
            }
            return results;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Quantity) obj);
        }

        public static Quantity Min( Quantity qty1, Quantity qty2 )
        {
            if (qty1 < qty2) return qty1;
            return qty2;
        }

        public static Quantity Max(Quantity qty1, Quantity qty2)
        {
            if (qty1 > qty2) return qty1;
            return qty2;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_unit != null ? _unit.GetHashCode() : 0)*397) ^ _value.GetHashCode();
            }
        }

        public const string PLUSMINUS1 = "±";
        public const string PLUSMINUS2 = "+-";
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string DECIMAL = ".";

        private StandardUnit _unit;
        private double _value;

        public Quantity()
        {
        }

        public Quantity(Decimal value)
        {
            _value = Decimal.ToDouble(value);
        }

        public Quantity(string value)
        {
            string remainder;
            InitQuantity(value, out remainder);
        }

        public Quantity(string value, out string remainder)
        {
            InitQuantity(value, out remainder);
        }

        private void InitQuantity(string value, out string remainder)
        {
            var number = new StringBuilder();
            var unit = new StringBuilder();
            string nextWord = Physical.NextWord(value, out remainder).Trim();
            if (!double.TryParse(nextWord, out _value))
            {
                foreach (char c in nextWord)
                {
                    if (Char.IsNumber(c) || c == PLUS[0] || c == MINUS[0] || c == DECIMAL[0])
                        number.Append(c);
                    else
                        unit.Append(c);
                }
                double.TryParse(number.ToString(), out _value);
            }
            else
            {
                unit.Append(Physical.NextWord(remainder, out remainder));
            }

            _unit = new StandardUnit(unit.ToString());
            _unit.ValueChanged += _unit_ValueChanged;
        }

        public double Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnValueChanged();
            }
        }

        public double NominalValue
        {
            get
            {
                return _unit != null ? _value * _unit.Multiplier() : _value;
            }
        }

        public StandardUnit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public object Clone()
        {
            var clone = new Quantity();
            clone.Value = Value;
            if (Unit != null)
                clone.Unit = Unit.Clone() as StandardUnit;
            return clone;
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public static Quantity operator +(Quantity arg1, string arg2)
        {
            string remainder;
            return arg1 + new Quantity(arg2, out remainder);
        }

        public static Quantity operator -(Quantity arg1, string arg2)
        {
            string remainder;
            return arg1 - new Quantity(arg2, out remainder);
        }

        public static Quantity operator +(Quantity arg1, Quantity arg2)
        {
            StandardUnit unit1 = arg1.Unit;
            StandardUnit unit2 = arg2.Unit;
            if (unit1 == null && unit2 != null)
                unit1 = unit2.Clone() as StandardUnit;
            string prefix1 = unit1==null?"":unit1.Prefix;
            string prefix2 = unit2 == null ? "" : unit2.Prefix;
            double value1 = arg1.Value;
            double value2 = arg2.Value;
            if (!string.IsNullOrEmpty(prefix1))
                value1 *= StandardPrefixes.Multiplier(prefix1);
            if (!string.IsNullOrEmpty(prefix2))
                value2 *= StandardPrefixes.Multiplier(prefix2);

            double value = value1 + value2;
            if (!string.IsNullOrEmpty(prefix1))
                value /= StandardPrefixes.Multiplier(prefix1);
            var q = new Quantity(Convert.ToDecimal(value));
            if( unit1 != null )
                q.Unit = unit1.Clone() as StandardUnit;
            return q;
        }

        public static Quantity operator -(Quantity arg1, Quantity arg2)
        {
            StandardUnit unit1 = arg1.Unit;
            StandardUnit unit2 = arg2.Unit;
            if (unit1 == null && unit2 != null)
                unit1 = unit2.Clone() as StandardUnit;
            string prefix1 = unit1 == null ? "" : unit1.Prefix;
            string prefix2 = unit2 == null ? "" : unit2.Prefix;
            double value1 = arg1.Value;
            double value2 = arg2.Value;
            if (prefix1 != null)
                value1 *= StandardPrefixes.Multiplier(prefix1);
            if (prefix2 != null)
                value2 *= StandardPrefixes.Multiplier(prefix2);

            double value = value1 - value2;
            if (prefix1 != null)
                value /= StandardPrefixes.Multiplier(prefix1);
            var q = new Quantity(Convert.ToDecimal(value));
            if (unit1 != null )
                q.Unit = unit1.Clone() as StandardUnit;
            return q;
        }

        public static bool operator ==(Quantity arg1, Quantity arg2)
        {
            bool isEqual = ((object)arg1) == ((object)arg2);
            if (!isEqual)
            {
                StandardUnit unit1 = ((object) arg1) == null ? new StandardUnit() : arg1.Unit;
                StandardUnit unit2 = ((object) arg2) == null ? new StandardUnit() : arg2.Unit;
                if (((object) arg1) != null)
                {
                    double value1 = arg1.Value;
                    if (((object) arg2) != null)
                    {
                        double value2 = arg2.Value;

                        if (unit1 != null && unit1.HasPrefix())
                            value1 *= StandardPrefixes.Multiplier(unit1.Prefix);
                        if (unit2 != null && unit2.HasPrefix())
                            value2 *= StandardPrefixes.Multiplier(unit2.Prefix);

                        isEqual = value1.Equals(value2);
                    }
                }
            }
            return isEqual;
        }

        public static bool operator !=(Quantity arg1, Quantity arg2)
        {
            return !(arg1 == arg2);
        }


        private void _unit_ValueChanged(object sender, EventArgs e)
        {
            OnValueChanged();
        }

        public bool IsNegative()
        {
            return Value < 0;
        }

        public bool IsPositive()
        {
            return Value >= 0;
        }

        public override string ToString()
        {
            return _value + "" + Unit;
        }
    }

    public class StandardUnit : ICloneable
    {
        public static readonly string PREFIX_PATTERN = "(y|z|a|f|p|n|µ|u|m|c|d|h|k|M|G|T|P|E|Z|Y|Ki|Mi|Gi|Ti|Pi|Ei)";
        public static readonly string UNIT_PATTERN = "(F|S|C|A|V|J|eV|T|N|Hz|lx|H|m|in|ft|mi|nmi|lm|cd|Wb|g|rad|deg|°|W|BW|Bm|Pa|bar|B(\\(\\d *m?W\\))?|%|pc|decade|octave|Ohm|sr|kn|K|degC|°C|degF|°F|s|min|h|L|mol)";
        public static readonly string PATTERN = string.Format("{0}?{1}", PREFIX_PATTERN, UNIT_PATTERN);
        private string _prefix;
        private string _unit;

        public StandardUnit()
        {
        }

        public StandardUnit(string prefix, string unit)
        {
            Prefix = prefix;
            Unit = unit;
        }

        public StandardUnit(string value)
        {
            //--------------------------//
            //--- Extract the prefix ---//
            //--------------------------//
            string prefix;
            if (!BinaryPrefixes.HasPrefix(value, out prefix))
                MetricPrefixes.HasPrefix(value, out prefix);
            Prefix = prefix;
            Unit = value.Substring(Prefix.Length);
            var rgx = new Regex(PATTERN);
            if (!rgx.Match(Unit).Success)
            {
                Prefix = null;
                Unit = null;
            }
        }

        public void Validate()
        {
            if( !string.IsNullOrWhiteSpace( _prefix ))
                ValidatePrefix();
            if( !string.IsNullOrWhiteSpace( _unit ))
                ValidateUnit();
        }

        public void ValidatePrefix()
        {
            var rgx = new Regex(PREFIX_PATTERN);
            if (!_prefix.Equals(rgx.Match(_prefix).Value))
                throw new Exception(string.Format("Invalid Standard Unit Prefix - {0}", _prefix));
        }

        public void ValidateUnit()
        {
            var rgx = new Regex(UNIT_PATTERN);
            if (!_unit.Equals(rgx.Match(_unit).Value))
                throw new Exception(string.Format("Invalid Standard Unit- {0}", _unit));
        }

        public string Prefix
        {
            get { return _prefix; }
            set
            {
                _prefix = value;
                OnValueChanged();
            }
        }

        public string Unit
        {
            get { return _unit; }
            set
            {
                _unit = value;
                OnValueChanged();
            }
        }


        public object Clone()
        {
            var clone = new StandardUnit(Prefix, Unit);
            return clone;
        }

        public event EventHandler ValueChanged;

        protected virtual void OnValueChanged()
        {
            EventHandler handler = ValueChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return Prefix + Unit;
        }

        public string BaseUnitString
        {
            get { return Unit; } 
        }


        public double Multiplier()
        {
            return StandardPrefixes.Multiplier(_prefix);
        }

        public bool HasPrefix()
        {
            return !string.IsNullOrEmpty(Prefix);
        }

        public bool HasUnit()
        {
            return !string.IsNullOrEmpty(Unit);
        }

    }

    public class Loading
    {
    }

    public class UncertainQuantity : Quantity
    {
        public new static readonly string PATTERN = string.Format(@"{0}", Quantity.PATTERN);
        private ErrorLimit _errorLimit;
        private Resolution _resolution;
        private Confidence _confidence;

        public UncertainQuantity(string value, out string remainder) : base(value, out remainder)
        {
        }

        public new void Validate()
        {
            
        }
    }

    public class StandardPrefixes
    {
        protected static readonly Dictionary<string, StandardUnitPrefix> prefixes =
            new Dictionary<string, StandardUnitPrefix>();

        public static Dictionary<string, StandardUnitPrefix> Prefixes
        {
            get { return prefixes; }
        }

        public static double Multiplier(string prefix)
        {
            double multiplier = 1d;
            if (!string.IsNullOrWhiteSpace(prefix) && Prefixes.ContainsKey(prefix))
                multiplier = Prefixes[prefix].Multiplier;
            return multiplier;
        }

        protected static void Add(StandardUnitPrefix prefix)
        {
            if (!prefixes.ContainsKey(prefix.Prefix))
                prefixes.Add(prefix.Prefix, prefix);
        }
    }

    public class BinaryPrefixes : StandardPrefixes
    {
        private static BinaryPrefixes _instance;
        private static readonly object syncRoot = new Object();

        public BinaryPrefixes()
        {
            Add(new StandardUnitPrefix("Ki", "kibi", 2e10, "1 KiB = 1.024 kB"));
            Add(new StandardUnitPrefix("Mi", "mebi", 2e20, "1 MiB = 1.048576 MB"));
            Add(new StandardUnitPrefix("Gi", "gibi", 2e30, "1 GiB = 1.073741824 GB"));
            Add(new StandardUnitPrefix("Ti", "tebi", 2e40, "1 TiB = 1.099511627776 TB"));
            Add(new StandardUnitPrefix("Pi", "pebi", 2e50, "1 PiB = 1.125899906842624 PB"));
            Add(new StandardUnitPrefix("Ei", "exbi", 2e60, "1 EiB = 1.152921504606846976 EB"));
        }

        public static BinaryPrefixes Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new BinaryPrefixes();
                        }
                    }
                }
                return _instance;
            }
        }

        public static StandardUnitPrefix GetPrefix(string prefix)
        {
            BinaryPrefixes i = BinaryPrefixes.Instance;
            return prefixes.ContainsKey(prefix) ? prefixes[prefix] : null;
        }

        public static bool HasPrefix(string value, out string prefix)
        {
            BinaryPrefixes i = BinaryPrefixes.Instance;
            prefix = "";
            bool hasPrefix = (value != null && value.Length >= 2 && prefixes.ContainsKey(value.Trim().Substring(0, 2)));
            if (hasPrefix)
                prefix = value.Trim().Substring(0, 2);
            return hasPrefix;
        }
    }

    public class MetricPrefixes : StandardPrefixes
    {
        private const string Note1 =
            "The preferred symbol for the prefix micro (i.e., μ) is normally replaced by the symbol u where the character set does not allow Greek letters. By custom, this convention is often used in test requirements.";

        private const string Note2 =
            "2—By custom, the prefixes for units used in test requirements representing powers of less than 3 (or –3) are not used in test requirements (except for decibel, dB, which is used exclusively)";

        private static MetricPrefixes _instance;
        private static readonly object syncRoot = new Object();

        public MetricPrefixes()
        {
            Add(new StandardUnitPrefix("y", "yocto", 1e-24, ""));
            Add(new StandardUnitPrefix("z", "zepto", 1e-21, ""));
            Add(new StandardUnitPrefix("a", "atto", 1e-18, ""));
            Add(new StandardUnitPrefix("f", "femto", 1e-15, ""));
            Add(new StandardUnitPrefix("p", "pico", 1e-12, ""));
            Add(new StandardUnitPrefix("n", "nano", 1e-9, ""));
            Add(new StandardUnitPrefix("u", "micro", 1e-6, Note1));
            Add(new StandardUnitPrefix("m", "milli", 1e-3, ""));
            Add(new StandardUnitPrefix("c", "centi", 1e-2, Note2));
            Add(new StandardUnitPrefix("d", "deci", 1e-1, Note2));
            Add(new StandardUnitPrefix("h", "hecto", 1e2, Note2));
            Add(new StandardUnitPrefix("k", "kilo", 1e3, ""));
            Add(new StandardUnitPrefix("M", "mega", 1e6, ""));
            Add(new StandardUnitPrefix("G", "giga", 1e9, ""));
            Add(new StandardUnitPrefix("T", "tera", 1e12, ""));
            Add(new StandardUnitPrefix("P", "peta", 1e15, ""));
            Add(new StandardUnitPrefix("E", "exa", 1e18, ""));
            Add(new StandardUnitPrefix("Z", "etta", 1e21, ""));
            Add(new StandardUnitPrefix("Y", "yotta", 1e24, ""));
        }

        public static MetricPrefixes Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new MetricPrefixes();
                        }
                    }
                }
                    return _instance;
            }
        }

        public static StandardUnitPrefix GetPrefix(string prefix)
        {
            MetricPrefixes m = Instance;
            return prefixes.ContainsKey(prefix) ? prefixes[prefix] : null;
        }

        public static bool HasPrefix(string value, out string prefix)
        {
            MetricPrefixes m = Instance;
            prefix = "";
            bool hasPrefix = (value != null && value.Length >= 1 && prefixes.ContainsKey(value.Trim().Substring(0, 1)));
            if (hasPrefix)
                prefix = value.Trim().Substring(0, 1);
            return hasPrefix;
        }
    }

    public class StandardUnitPrefix
    {
        public const string PATTERN = @"((y|z|a|f|p|n|µ|u|m|c|d|h|k|M|G|T|P|E|Z|Y|Ki|Mi|Gi|Ti|Pi|Ei)?(F|S|C|A|V|J|eV|T|N|Hz|lx|H|m|in|ft|mi|nmi|lm|cd|Wb|g|rad|deg|°|W|BW|Bm|Pa|bar|B(\(\d *m?W\))?|%|pc|decade|octave|Ohm|sr|kn|K|degC|°C|degF|°F|s|min|h|L|mol)\d*((·|\.|\/)(y|z|a|f|p|n|µ|u|m|c|d|h|k|M|G|T|P|E|Z|Y|Ki|Mi|Gi|Ti|Pi|Ei)?(F|S|C|A|V|J|eV|T|N|Hz|lx|H|m|in|ft|mi|nmi|lm|cd|Wb|g|rad|deg|°|W|BW|Bm|Pa|bar|B|%|pc|decade|octave|Ohm|sr|kn|K|degC|°C|degF|°F|s|min|h|L|mol)\d*)*)?";
        private readonly string _comment;
        private readonly double _multiplier;
        private readonly string _name;
        private readonly string _prefix;

        public StandardUnitPrefix(string prefix, string name, double multiplier, string comment)
        {
            _prefix = prefix;
            _name = name;
            _multiplier = multiplier;
            _comment = comment;
        }

        public string Comment
        {
            get { return _comment; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Prefix
        {
            get { return _prefix; }
        }

        public double Multiplier
        {
            get { return _multiplier; }
        }
    }
}