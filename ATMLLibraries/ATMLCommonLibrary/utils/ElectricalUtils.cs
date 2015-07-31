/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ATMLModelLibrary.model.common;

namespace ATMLCommonLibrary.utils
{
    /**
     * The ElectricalUtils class is a collection of static methods used for common electronic calculations, conversions and parsing.
     */

    public class ElectricalUtils
    {
        /**
         * Returns the frequency given a duration of time ( f=1/t )
         */

        public static Dictionary<string, int> multipliers = new Dictionary<string, int>();

        static ElectricalUtils()
        {
            multipliers.Add("p", -12);
            multipliers.Add("n", -9);
            multipliers.Add("μ", -6);
            multipliers.Add("u", -6);
            multipliers.Add("m", -3);
            multipliers.Add("k", 3);
            multipliers.Add("M", 6);
            multipliers.Add("G", 12);
        }

        public static double GetFrequencyByTime(double time)
        {
            return 1d/time;
        }

        /**
         * Returns the time given a frequency ( t=1/f )
         */

        public static double GetTimeByFrequency(double frequency)
        {
            return 1d/frequency;
        }

        /**
         * Returns the current in ampreres given the power (watts) and resistance (ohms). ( I=W/R )
         */

        public static double GetCurrentByPowerResistance(double watts, double ohms)
        {
            return watts/ohms; // I = W/R
        }

        //ublic static double GetCurrentByPowerResistance(double watts, double ohms)
        // {
        //     return (watts * ohms) * (watts * ohms); //I = (W / R)2
        // }

        /**
         * Returns the power as watts given the voltage (volts) and current (ampreres). ( W=VxI )
         */

        public static double GetPowerByVoltageCurrent(double volts, double amperes)
        {
            return volts*amperes; //W = V x I
        }

        /**
         * Returns the power as watts given the voltage (volts) and Resistance (ohms). ( W = V2 / R )
         */

        public static double GetPowerByVoltageResistance(double volts, double ohms)
        {
            return (volts*volts)/ohms; // W = V2 / R
        }

        /**
         * Returns the power as watts given the current (ampreres) and Resistance (ohms). ( W = I2 x R )
         */

        public static double GetPowerByCurrentResistance(double amperes, double ohms)
        {
            return (amperes*amperes)*ohms; //W = I2 x R
        }

        /**
         * Returns the voltage as volts given the current (ampreres) and Resistance (ohms). ( V = I x R )
         */

        public static double GetVoltageByCurrentResistance(double amperes, double ohms)
        {
            return amperes*ohms;
        }

        /**
         * Returns the voltage as volts given the power (watts) and Resistance (ohms). ( V = (W x R)2 )
         */

        public static double GetVoltageByPowerResistance(double watts, double ohms)
        {
            return (watts*ohms)*(watts*ohms); //V = (W x R)2
        }

        /**
         * Returns the voltage as volts given the power (watts) and current (amperes). ( V = W / I )
         */

        public static double GetVoltageByPowerCurrent(double watts, double amperes)
        {
            return (watts/amperes); //V = W / I
        }

        /**
         * Returns the resistance as ohms given the power (watts) and voltage (volts). ( R = V2 / W )
         */

        public static double GetResistanceByPowerVoltage(double watts, double volts)
        {
            return ((volts*volts)/watts); //R = V2 / W
        }

        /**
         * Returns the resistance as ohms given the power (watts) and current (amperes). ( R = W / I2 )
         */

        public static double GetResistanceByPowerCurrent(double watts, double amperes)
        {
            return (watts/(amperes*amperes)); // R = W / I2
        }

        /**
         * 
         * Standard units - 
         *     Volts, 
         *     Amperes, 
         *     Ohms, Watts, Farad, Henry, siemens, Coulomb, Ampere-Hour, Tesla, Weber, Joule, Hertz
         * 
         * Maps a prefix character to a multiplier value for conversions to a standar unit of measure
         * <table>
         *       <tr><td>pico	</td><td>p</td><td>	10-12	</td><td>1pF = 10-12F</td></tr>
         *       <tr><td>nano	</td><td>n</td><td>	10-9	</td><td>1nF = 10-9F </td></tr>
         *       <tr><td>micro	</td><td>μ</td><td>	10-6	</td><td>1μA = 10-6A </td></tr>
         *       <tr><td>milli	</td><td>m</td><td>	10-3	</td><td>1mA = 10-3A </td></tr>
         *       <tr><td>kilo	</td><td>k</td><td>	10 3	</td><td>1kΩ = 1000Ω </td></tr>
         *       <tr><td>mega	</td><td>M</td><td>	10 6	</td><td>1MHz = 106Hz</td></tr>
         *       <tr><td>giga	</td><td>G</td><td>	10 9	</td><td>1GHz = 109Hz</td></tr>
         * </table>
         */

        /**
         * Converts a Pico value to a standard value
         */

        public static double PicoTo(double value)
        {
            return value*Math.Exp(-12);
        }

        /**
         * Converts a Nano value to a standard value
         */

        public static double NanoTo(double value)
        {
            return value*Math.Exp(-9);
        }

        /**
         * Converts a Micro value to a standard value
         */

        public static double MicroTo(double value)
        {
            return value*Math.Exp(-6);
        }

        /**
         * Converts a Milli value to a standard value
         */

        public static double MilliTo(double value)
        {
            return value*Math.Exp(-3);
        }

        /**
         * Converts a Kilo value to a standard value
         */

        public static double KiloTo(double value)
        {
            return value*Math.Exp(3);
        }

        /**
         * Converts a Mega value to a standard value
         */

        public static double MegaTo(double value)
        {
            return value*Math.Exp(-6);
        }

        /**
         * Converts a Giga value to a standard value
         */

        public static double GigaTo(double value)
        {
            return value*Math.Exp(9);
        }

        /**
         * Parses an signal expression into a list of segmented/nested values.
         * 
         * <pre>
         * Examples:
         *      trms 1 V range 6 uV to 2 V errlmt 0.1% range 1V to 10V errlmt 3%
         *      range 100uHz to 15MHz errlmt 20uHz res 10uHz
         *      errlmt 0.01% res 1mV range 50mV to 10V  range 100mV to 20V
         *      range 10mHz to 2.5kHz errlmt 0.5mHz range 2.5kHz to 20kHz errlmt 4mHz
         * </pre>
         */

        public static List<Value> ParseExpression(String expression)
        {
            var numbers = new List<Value>();
            String qualifier = "";
            String[] parts = expression.Split(' ');
            Value v = null;
            bool isBuildingRange = false;
            bool isBuildingRangeTo = false;
            bool isBuildingErrLimit = false;
            bool isBuildingResolution = false;
            int i = 0;
            foreach (String part in parts)
            {
                if (0 == i++)
                {
                }

                //Test for qualifier - resets everything
                if (IsQualifier(part))
                {
                    qualifier = part;
                }
                else if (IsResolution(part))
                {
                    if (v == null)
                    {
                        v = new Value();
                        numbers.Add(v);
                    }
                    v.resoluion = new Value();
                    isBuildingResolution = true;
                }
                else if (IsRange(part))
                {
                    isBuildingRange = true;
                    isBuildingRangeTo = false;
                    Console.WriteLine("Start Building Range");
                    if (v == null)
                    {
                        v = new Value();
                        numbers.Add(v);
                    }
                    v.currentRange = new Range();
                    v.ranges.Add(v.currentRange);
                }
                else if (IsTo(part) && isBuildingRange)
                {
                    isBuildingRangeTo = true;
                    Console.WriteLine("Working on Range");
                    v.currentRange.to = new Value();
                }
                else if (IsErrorLimit(part))
                {
                    if (v == null)
                    {
                        v = new Value();
                        numbers.Add(v);
                    }
                    isBuildingErrLimit = true;
                    Console.WriteLine("Start Building ErrLmt");
                    if (isBuildingRange)
                        v.currentRange.errorLimit = new ErrorLimit();
                    else
                        v.errorLimit = new ErrorLimit();
                }
                else
                {
                    String val = null;
                    String unit = null;
                    String prefix = null;
                    String standardUnit = null;

                    ParseWord(part, out val, out standardUnit);
                    if (!String.IsNullOrEmpty(standardUnit))
                        ParseUnit(standardUnit, out prefix, out unit);

                    //--- Add To Error Limit ---//
                    if (isBuildingResolution)
                    {
                        if (!String.IsNullOrEmpty(val))
                            v.resoluion.value += val;
                        if (!String.IsNullOrEmpty(prefix))
                            v.resoluion.prefix += prefix;
                        if (!String.IsNullOrEmpty(unit))
                        {
                            v.resoluion.unit += unit;
                            v.standardUnit = standardUnit;
                            isBuildingResolution = false;
                        }
                    }
                    else if (isBuildingErrLimit)
                    {
                        if (isBuildingRange)
                        {
                            if (v.currentRange.errorLimit == null)
                                v.currentRange.errorLimit = new ErrorLimit();
                            if (!String.IsNullOrEmpty(val))
                                v.currentRange.errorLimit.From.value += val;
                            if (!String.IsNullOrEmpty(prefix))
                                v.currentRange.errorLimit.From.prefix += prefix;
                            if (!String.IsNullOrEmpty(unit))
                            {
                                v.currentRange.errorLimit.From.unit += unit;
                                v.currentRange.errorLimit.From.standardUnit = standardUnit;
                                isBuildingErrLimit = false;
                            }
                        }
                        else
                        {
                            if (v.errorLimit == null)
                                v.errorLimit = new ErrorLimit();
                            if (!String.IsNullOrEmpty(val))
                                v.errorLimit.From.value += val;
                            if (!String.IsNullOrEmpty(prefix))
                                v.errorLimit.From.prefix += prefix;
                            if (!String.IsNullOrEmpty(unit))
                            {
                                v.errorLimit.From.unit += unit;
                                v.errorLimit.From.standardUnit = standardUnit;
                                isBuildingErrLimit = false;
                            }
                        }
                    }
                        //--- Add To Range ---//
                    else if (isBuildingRange)
                    {
                        if (!isBuildingRangeTo)
                        {
                            if (!String.IsNullOrEmpty(val))
                                v.currentRange.from.value += val;
                            if (!String.IsNullOrEmpty(prefix))
                                v.currentRange.from.prefix += prefix;
                            if (!String.IsNullOrEmpty(unit))
                            {
                                v.currentRange.from.unit += unit;
                                v.currentRange.from.standardUnit = standardUnit;
                            }
                        }
                        else
                        {
                            if (!String.IsNullOrEmpty(val))
                                v.currentRange.to.value += val;
                            if (!String.IsNullOrEmpty(prefix))
                                v.currentRange.to.prefix += prefix;
                            if (!String.IsNullOrEmpty(unit))
                            {
                                v.currentRange.to.unit += unit;
                                v.currentRange.to.standardUnit = standardUnit;
                                //isBuildingRange = false;
                                //isBuildingRangeTo = false;
                                //v.currentRange = null;
                            }
                        }
                    }
                        //--- Add To Value ---//
                    else
                    {
                        if (!String.IsNullOrEmpty(val))
                        {
                            v = new Value();
                            numbers.Add(v);
                            v.value += val;
                        }
                        if (v != null)
                        {
                            if (!String.IsNullOrEmpty( prefix ))
                            {
                                v.prefix += prefix;
                            }
                            if (!String.IsNullOrEmpty( unit ))
                            {
                                v.unit += unit;
                                v.standardUnit = standardUnit;
                            }
                        }
                    }
                }
            }

            if (v != null && v.errorLimit != null && v.value != null )
            {
                v.errorLimit.ErrorLimitOf = double.Parse(v.value);
                v.errorLimit.StandardUnit = v.standardUnit;
            }

            Console.WriteLine("\tqualifier: " + qualifier);
            foreach (Value vv in numbers)
                Console.WriteLine("Value: " + vv.ToString());

            return numbers;
        }

        private static bool IsQualifier(String value)
        {
            return "inst|pk_pk|pk|trms|inst_max|inst_min|pk_neg|".Contains(value + "|");
        }

        private static bool IsResolution(String value)
        {
            return "res|".Contains(value + "|");
        }

        private static void ParseWord(String value, out String number, out String unit)
        {
            var n = new StringBuilder();
            var s = new StringBuilder();
            foreach (char c in value)
            {
                if ((c >= '0' && c <= '9') || c == '.')
                    n.Append(c);
                else
                    s.Append(c);
            }
            number = n.ToString();
            unit = s.ToString();
        }

        private static void ParseUnit(String value, out String prefix, out String unit)
        {
            var p = new StringBuilder();
            var s = new StringBuilder();
            foreach (char c in value)
            {
                if (c == 'p' || c == 'n' || c == 'u' || c == 'μ' || c == 'm' || c == 'k' || c == 'M' || c == 'G')
                    p.Append(c);
                else
                    s.Append(c);
            }
            prefix = p.ToString();
            unit = s.ToString();
        }


        private static bool IsErrorLimit(String value)
        {
            //trms 
            //0V 
            //range 
            //1uV 
            //to 
            //10V 
            //errlmt 
            //0.1% 
            //range 
            //10V 
            //to 
            //150V 
            //errlmt 
            //1%"
            return "±|+-|errlmt|".Contains(value + "|");
        }

        private static bool IsRange(String value)
        {
            //"trms 0V range 1uV to 10V errlmt 0.1% range 10V to 150V errlmt 1%"
            return "range|".Contains(value + "|");
        }

        private static bool IsTo(String value)
        {
            //"trms 0V range 1uV to 10V errlmt 0.1% range 10V to 150V errlmt 1%"
            return "to|".Contains(value + "|");
        }

        private static bool IsNumeric(String value)
        {
            double Num;
            return (double.TryParse(value, out Num));
        }
    }

    /**
     * A class representation of a range of values. A range of values may have a low value as well as a high value and may also 
     * have an error limit. 
     */

    public class Range
    {
        public Range()
        {
            from = new Value();
        }

        public LimitPair LimitPair
        {
            get
            {
                var lp = new LimitPair();
                lp.@operator = LogicalOperator.AND;
                lp.Limit = new List<SingleLimit>();
                var sl1 = new SingleLimit();
                var sl2 = new SingleLimit();
                sl1.Item = from.@double;
                sl2.Item = to.@double;
                lp.Limit.Add(sl1);
                lp.Limit.Add(sl2);
                return lp;
            }
        }

        public Value from { set; get; }
        public Value to { set; get; }
        public ErrorLimit errorLimit { set; get; }

        public bool hasFrom()
        {
            return from != null;
        }

        public bool hasTo()
        {
            return to != null;
        }

        /**
         *  Returns a string representation of a Range object.
         */

        public override String ToString()
        {
            var sb = new StringBuilder();
            sb.Append("\r\n\t\tFrom: "
                      + (from != null ? from.ToString() : "")
                      + "\r\n\t\tTo: "
                      + (to != null ? to.ToString() : ""));
            if (errorLimit != null)
            {
                sb.Append("\r\n\tErrLmt: ").Append(errorLimit);
            }
            return sb.ToString();
        }
    }

    /**
     * A class representation of a value. A value may have several ranges as well as an error limit.
     */

    public class Value
    {
        public Value()
        {
            ranges = new List<Range>();
        }

        public SingleLimit SingleLimit
        {
            get
            {
                var slLimit = new SingleLimit();
                SingleLimit.Item = @double;
                return slLimit;
            }
        }

        public @double @double
        {
            get
            {
                @double dVal = null;
                double d;
                if (double.TryParse(value, out d))
                {
                    dVal = new @double();
                    dVal.standardUnit = standardUnit;
                    dVal.unitQualifier = qualifier;
                    dVal.value = d;
                    if (resoluion != null)
                    {
                        @double dRes = resoluion.@double;
                        if (dRes != null)
                            dVal.Resolution = dRes.value;
                    }

                    if (errorLimit != null)
                    {
                        dVal.ErrorLimits = errorLimit.Limit;
                    }

                    if (ranges.Count > 0)
                    {
                        var collection = new Collection();
                        collection.Item = new List<CollectionItem>();
                        foreach (Range range in ranges)
                        {
                            var lRange = new Limit();
                            lRange.Item = range.LimitPair;
                            var item = new CollectionItem();
                            item.Item = lRange;
                            collection.Item.Add(item);
                        }
                        dVal.Range = new Limit();
                        dVal.Range.Item = collection;
                    }
                }
                return dVal;
            }
        }


        public string qualifier { get; set; }
        public string value { get; set; }
        public string prefix { get; set; }
        public string unit { get; set; }
        public string standardUnit { get; set; }
        public Value resoluion { set; get; }
        public Range currentRange { set; get; }
        public List<Range> ranges { get; set; }
        public ErrorLimit errorLimit { get; set; }

        public void addRange(Range range)
        {
            ranges.Add(range);
        }

        public double getStandardValue()
        {
            double d = 0;
            try
            {
                d = double.Parse(value);
                d = ((prefix != null)
                ? double.Parse(value) * Math.Pow(10, ElectricalUtils.multipliers[prefix])
                : double.Parse(value));
            }
            catch (Exception)
            {
                MessageBox.Show(@"Invalid value");
            }
            return d;
        }

        /**
         * Returns a string representation of a Value object.
         */

        public String ToString()
        {
            var sb = new StringBuilder();
            if (qualifier != null)
                sb.Append(" ").Append(qualifier);
            if (value != null)
                sb.Append(" ").Append(value);
            if (prefix != null)
            {
                sb.Append(" (").Append(getStandardValue()).Append(") ");
                sb.Append(" prefix: ").Append(prefix);
            }
            if (unit != null)
                sb.Append(" unit: ").Append(unit);
            foreach (Range range in ranges)
                sb.Append("\r\n\trange: ").Append(range);
            if (errorLimit != null)
                sb.Append("\r\n\terrlmt: ").Append(errorLimit);
            if (resoluion != null)
                sb.Append("\r\n\tRes: ").Append(resoluion.ToString());
            return sb.ToString();
        }
    }

    /**
     * A class representation of an Error Limit.
     */

    public class ErrorLimit
    {
        public ErrorLimit()
        {
            From = new Value();
        }

        public Limit Limit
        {
            get
            {
                var limit = new Limit();
                var pair = new LimitPair();
                pair.Limit = new List<SingleLimit>();
                var limit1 = new SingleLimit();
                var limit2 = new SingleLimit();
                if (From == null)
                    throw new Exception(@"An Error Limit requires a From value");
                if (To == null)
                    To = new Value();
                @double from = From.@double;
                var to = new @double();
                if (from.standardUnit == "%")
                {
                    double plusOrMinus = from.value*ErrorLimitOf;
                    from.value = (ErrorLimitOf - plusOrMinus);
                    to.value = (ErrorLimitOf + plusOrMinus);
                    To.value = "" + to.value;
                    to.standardUnit = StandardUnit;
                    from.standardUnit = StandardUnit;
                    From.value = "" + from.value;
                    From.standardUnit = StandardUnit;
                }
                limit1.Item = From.@double;
                limit2.Item = To.@double;
                limit1.comparator = ComparisonOperator.GE;
                limit2.comparator = ComparisonOperator.LE;
                pair.Limit.Add(limit1);
                pair.Limit.Add(limit2);
                pair.@operator = LogicalOperator.AND;
                limit.Item = pair;
                return limit;
            }
        }

        public double ErrorLimitOf { set; get; }
        public string StandardUnit { set; get; }
        public Value From { set; get; }
        public Value To { set; get; }

        public override String ToString()
        {
            return "errlmt " + From.ToString()
                   + (To != null ? (" " + To.ToString()) : "");
        }
    }
}