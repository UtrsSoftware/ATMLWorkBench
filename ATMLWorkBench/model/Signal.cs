/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATMLWorkBench.model
{
    public class SignalWrapper
    {
        private Signal signal;
        public Signal Signal
        {
            get { return signal; }
            set { signal = value; }
        }
        private String signalPath;
        public String SignalPath
        {
            get { return signalPath; }
            set { signalPath = value; }
        }
    }

    public class Signal : Verb
    {
        /*
         * VOLTAGE-P 2.5V,
           PRF 1KHZ,
           PULSE-WIDTH 500USEC,
           DC-OFFSET 0.0V,
           RISE-TIME 50NSEC,
           FALL-TIME 50NSEC,
           GATED FROM 'PGENTRIG1' TO 'PGENTRIG2',
           CNX VIA NONE   
         * 
         * 
         * 
         */


        private String mapping;

        public Signal()
        {
        }

        public Signal(ref List<String> statements, ref int index)
            : base(ref statements, ref index)
        {
            //Console.Write("Processing Signal: " );
            int count = parts.Count();
            for( int i=0; i < count; i++ )
            {
                switch( i )
                {
                    case 0:
                        //Verb - APPLY
                        break;
                    case 1:
                        //Type - SHORT, IMPEDIENCE, DC SIGNAL, COMPLEX SIGNAL, SQUARE WAVE, PULSED DC 
                        this.Type = parts[i];
                        string[] delimeters = null;
                        if( this.Type.Contains( "USING" ) )
                            delimeters = new string[] { "USING" };
                        else if( this.Type.Contains( "VIA" ) )
                            delimeters = new string[] { "VIA" };
                        if( delimeters != null )
                        {
                            string[] subParts = this.Type.Split(delimeters, StringSplitOptions.None);
                            if( subParts.Count() > 1 )
                            {
                                this.Type = subParts[0].Trim();
                                this.mapping = subParts[1].Trim();
                            }
                        }
                        this.Type = this.Type.Trim();
                        break;
                    default:
                        //Add to parameters
                        String attrValue = parts[i].Trim();
                        Attribute attribute = new Attribute();
                        int idx = attrValue.IndexOf(" ");
                        if( idx != -1 )
                        {
                            attribute.Name = attrValue.Substring(0, idx).Trim();
                            attribute.Value = attrValue.Substring(idx).Trim();
                        }
                        else
                        {
                            attribute.Name = attrValue;
                        }

                        this.Attributes.Add(attribute.Name, attribute); 
                        //short - CNX VIA GO4515
                        //SQUARE WAVE USING 'AWFGA-SQ' -    VOLTAGE-PP 5.0V         |                   
                        //                                  FREQ 1KHZ               |                   
                        //                                  DUTY-CYCLE 50PC         |                   
                        //                                  DC-OFFSET 0.0V          |                   
                        //                                  RISE-TIME 50NSEC        |                   
                        //                                  FALL-TIME 50NSEC        |                   
                        //                                  CNX VIA NONE            |
                        //PULSED DC USING 'STRGA' -         PRF 500 KHZ             |                   
                        //                                  PULSE-WIDTH 1.0 USEC    |                   
                        //                                  CNX VIA NONE            | 
                        //IMPEDANCE USING 'CAL-RES' -       RES 1 OHM               |                   
                        //                                  CNX HI NONE LO NONE     | 
                        //DC SIGNAL USING 'DCLVA05' -       VOLTAGE 5 V             |                   
                        //                                  CURRENT MAX 2 A         |                   
                        //                                  CNX HI NONE LO NONE     | 
                        break;


                }
                //Console.Write(parts[i] + " | ");
            }
            //Console.WriteLine();

        }

        public String getKey()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Type).Append(" - "); ;
            foreach( Attribute attr in Attributes.Values )
            {
                sb.Append(attr).Append(", ");
            }
            return sb.ToString();
        }


        private String type;
        public String Type
        {
            get { return type; }
            set { type = value; }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private String uuid;
        public String Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }

        private Boolean complexType;

        private Dictionary<String,Attribute> attributes = new Dictionary<string, Attribute>();
        public Dictionary<String, Attribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }
  
    }

    public class Attribute
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; cleanValue(); }
        }

        private String value;
        public String Value
        {
            get { return this.value; }
            set {this.value = value; cleanValue();}
        }

        private String unit;
        public String Unit
        {
            get { return unit; }
            set { unit = value;}
        }

        private String limit;
        public String Limit
        {
            get { return limit; }
            set { limit = value; }
        }

        private Annotation annotation;
        public Annotation Annotation
        {
            get { return annotation; }
            set { annotation = value; }
        }

        public override string ToString()
        {
            return ( String.IsNullOrEmpty(limit)?"":( limit + " " ) ) + value + " " + unit;
        }

        private void cleanValue()
        {
            if( name != null && value != null )
            {
                if( value.StartsWith("MAX") )
                {
                    limit = "MAX";
                    value = value.Substring(3).Trim();
                }
                if( value.StartsWith("MIN") )
                {
                    limit = "MAX";
                    value = value.Substring(3).Trim();
                }
                if( name.Contains("VOLTAGE")
                    || name.Contains("PRF")
                    || name.Contains("OFFSET")
                    || name.Contains("FREQ")
                    || name.Contains("RES")
                    || name.Contains("CYCLE")
                    || name.Contains("CURRENT")
                    || name.Contains("TIME")
                    || name.Contains("PULSE") )
                {
                  StringBuilder newVal = new StringBuilder();
                  StringBuilder newUnit = new StringBuilder(unit);
                  value = value.Trim();

                  for( int i=0; i<value.Length; i++ )
                  {
                      if( char.IsDigit(value[i]) || value[i] == '.' || value[i] == '-' || value[i] == '+' )
                          newVal.Append( value[i] );
                      else
                          newUnit.Append( value[i] );
                  }
                    if( newVal.Length > 0 )
                        value = newVal.ToString();
                    if( newUnit.Length > 0 )
                        unit = newUnit.ToString();
              }
            }
        }


        private String convertFreqToPeriod(String f)
        {
            //convert frequency to period in microseconds (us)
            String[] del = new String[] { " " };
            String[] fa = f.Split(del, StringSplitOptions.None);

            List<String> freqArr = fa.OfType<String>().ToList();
            String p = "";

            switch( freqArr[1] )
            {
                case "MHZ":
                    p = Double.Parse(freqArr[0].Trim()) * 1 + " us";
                    break;
                case "KHZ":
                    p = Double.Parse(freqArr[0].Trim()) * 1000 + " us";
                    break;
                case "HZ":
                    p = Double.Parse(freqArr[0].Trim()) * 1000000 + " us";
                    break;
                default:
                    break;
            }
            return p;
        } // convertFreqToPeriod


        private String convertUnit(String s) 
        {
		    //convert unit of time
            String[] del = new String[] { " " };
            String[] fa = s.Split(del, StringSplitOptions.None);

            List<String> strArr = fa.OfType<String>().ToList();

            String strOut = strArr[0].Trim();

		    switch (strArr[1]) 
            {
		        case "MSEC":
			        strOut += " ms";
			        break;
		        case "USEC":
			        strOut += " us";
			        break;
		        case "NSEC":
                    strOut += " ns";
			        break;
		        case "PC":
			        strOut += " %";
			        break;
		        case "OHM":
			        strOut += " ohm";
			        break;
		        case "KOHM":
			        strOut += " kohm";
			        break;
		        case "MHZ":
			        strOut += " MHz";
			        break;
		        case "KHZ":
			        strOut += " kHz";
			        break;
		        case "HZ":
			        strOut += " Hz";
			        break;
		        default:
			        strOut = s;
			        break;
		    }
            return strOut;
	    } // convertTimeUnit



    }

    public class Annotation
    {
        private String documentation;

    }



}
