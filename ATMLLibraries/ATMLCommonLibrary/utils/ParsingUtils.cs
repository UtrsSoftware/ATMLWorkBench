/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ATMLCommonLibrary.utils
{
    internal class ParsingUtils
    {
    }

    public class Param
    {
        public String Unit;
        public Double Value;

        public void Parse(String strParam)
        {
            if (strParam.IndexOf(" ") > 0)
            {
                // if indexof <> lastindexof then split string on lastindexof and strip spaces -> String.Replace(" ", "")
                String strValue = strParam.Substring(0, strParam.LastIndexOf(" ")).Trim().Replace(" ", "");
                if (strValue.StartsWith("'") && strValue.EndsWith("'"))
                {
                    // variable name, do nothing
                }
                else
                {
                    // parse numeric value and unit
                    Value = Double.Parse(strValue);
                    Unit = strParam.Substring(strParam.LastIndexOf(" ")).Trim();
                }
            }
            else
            {
                String strValue = Regex.Split(strParam, @"[^0-9E\.\+\-]+")[0];
                Value = Double.Parse(strParam.Substring(0, strValue.Length).Trim());
                Unit = strParam.Substring(strValue.Length).Trim();
            }
        } // parse

        public override String ToString()
        {
            String str = ((Unit != null)
                ? Value.ToString("0.##########", CultureInfo.InvariantCulture) + " " + Unit
                : "");
            return str.Trim();
        }
    } // class Param


    public class ParamField
    {
        public Param Base;
        public Param BaseFrom;
        public Param BaseTo;
        public Param By;
        public Param ErrlmtMinus;
        public Param ErrlmtPlus;

        public Boolean HasBy;
        public Boolean HasContinuous;
        public Boolean HasErrlmt;
        public Boolean HasRange;
        private String strBy = "BY";
        private String strContinuous = "CONTINUOUS";
        private String strErrlmt = "ERRLMT";
        private String strMinus = "-";
        private String strPlus = "+";
        private String strPlusMinus = "+-";
        private String strRange = "RANGE";
        private String strTo = "TO";
        private String tmpErrlmt = "";
        private String tmpStr = "";

        public void Parse(String strParamField)
        {
            strParamField = strParamField.ToUpper();
            if (strParamField.Contains(strRange))
            {
                HasRange = true;
                if (strParamField.Contains(strContinuous) || strParamField.Contains(strBy))
                {
                    if (strParamField.Contains(strContinuous))
                    {
                        HasContinuous = true;
                        HasBy = false;
                    }
                    else
                    {
                        HasBy = true;
                        HasContinuous = false;
                    }
                }
                else
                {
                    HasContinuous = false;
                    HasBy = false;
                }
            }
            else
            {
                HasRange = false;
                HasContinuous = false;
                HasBy = false;
            }

            if (strParamField.Contains(strErrlmt))
            {
                HasErrlmt = true;
            }
            else
            {
                HasErrlmt = false;
            }


            if (HasRange)
            {
                Base = null;
                BaseFrom = new Param();
                BaseTo = new Param();

                tmpStr =
                    strParamField.Substring((strParamField.IndexOf(strRange) + strRange.Length),
                        strParamField.IndexOf(strTo) - (strParamField.IndexOf(strRange) + strRange.Length)).Trim();
                BaseFrom.Parse(tmpStr);

                if (HasContinuous || HasBy)
                {
                    if (HasContinuous)
                    {
                        tmpStr =
                            strParamField.Substring((strParamField.IndexOf(strTo) + strTo.Length),
                                strParamField.IndexOf(strContinuous) - (strParamField.IndexOf(strTo) + strTo.Length))
                                .Trim();
                    }
                    else // this.HasBy
                    {
                        tmpStr =
                            strParamField.Substring((strParamField.IndexOf(strTo) + strTo.Length),
                                strParamField.IndexOf(strBy) - (strParamField.IndexOf(strTo) + strTo.Length)).Trim();
                    }
                }
                else
                {
                    tmpStr = strParamField.Substring(strParamField.IndexOf(strTo) + strTo.Length).Trim();
                }
                BaseTo.Parse(tmpStr);

                if (HasBy)
                {
                    By = new Param();
                    if (HasErrlmt)
                    {
                        tmpStr =
                            strParamField.Substring((strParamField.IndexOf(strBy) + strBy.Length),
                                strParamField.IndexOf(strErrlmt) - (strParamField.IndexOf(strBy) + strBy.Length)).Trim();
                    }
                    else
                    {
                        tmpStr = strParamField.Substring(strParamField.IndexOf(strBy) + strBy.Length).Trim();
                    }
                    By.Parse(tmpStr);
                }
                else
                {
                    By = null;
                }
            }
            else
            {
                Base = new Param();
                BaseFrom = null;
                BaseTo = null;

                if (HasErrlmt)
                {
                    tmpStr = strParamField.Substring(0, strParamField.IndexOf(strErrlmt)).Trim();
                }
                else
                {
                    tmpStr = strParamField.Trim();
                }
                Base.Parse(tmpStr);
            }

            if (HasErrlmt)
            {
                ErrlmtPlus = new Param();
                ErrlmtMinus = new Param();

                tmpErrlmt = strParamField.Substring(strParamField.IndexOf(strErrlmt) + strErrlmt.Length).Trim();
                if (tmpErrlmt.Contains(strPlusMinus) || (tmpErrlmt.Contains(strPlus) && tmpErrlmt.Contains(strMinus)))
                {
                    if (tmpErrlmt.Contains(strPlusMinus))
                    {
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strPlusMinus) + strPlusMinus.Length).Trim();
                        ErrlmtPlus.Parse(tmpStr);
                        ErrlmtMinus.Parse(tmpStr);
                    }
                    else if (tmpErrlmt.IndexOf(strPlus) < tmpErrlmt.IndexOf(strMinus))
                    {
                        tmpStr =
                            tmpErrlmt.Substring((tmpErrlmt.IndexOf(strPlus) + strPlus.Length),
                                tmpErrlmt.IndexOf(strMinus) - (tmpErrlmt.IndexOf(strPlus) + strPlus.Length)).Trim();
                        ErrlmtPlus.Parse(tmpStr);
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strMinus) + strMinus.Length).Trim();
                        ErrlmtMinus.Parse(tmpStr);
                    }
                    else // tmpErrlmt.IndexOf(strMinus) < tmpErrlmt.IndexOf(strPlus)
                    {
                        tmpStr =
                            tmpErrlmt.Substring((tmpErrlmt.IndexOf(strMinus) + strMinus.Length),
                                tmpErrlmt.IndexOf(strPlus) - (tmpErrlmt.IndexOf(strMinus) + strMinus.Length)).Trim();
                        ErrlmtMinus.Parse(tmpStr);
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strPlus) + strPlus.Length).Trim();
                        ErrlmtPlus.Parse(tmpStr);
                    }
                }
            }
            else
            {
                ErrlmtPlus = null;
                ErrlmtMinus = null;
            }
        } // parse

        public override String ToString()
        {
            String str;

            if (HasRange)
            {
                str = strRange + " " + BaseFrom.Value + " " + BaseFrom.Unit + " " + strTo + " " + BaseTo.Value + " " +
                      BaseTo.Unit;
                if (HasContinuous || HasBy)
                {
                    if (HasContinuous)
                    {
                        str += " " + strContinuous;
                    }
                    else // this.HasBy
                    {
                        str += " " + strBy + " " + By.Value + " " + By.Unit;
                    }
                }
            }
            else
            {
                str = Base.Value + " " + Base.Unit;
            }

            if (HasErrlmt)
            {
                if (ErrlmtPlus.Value == ErrlmtMinus.Value && ErrlmtPlus.Unit == ErrlmtMinus.Unit)
                {
                    str += " " + strErrlmt + " " + strPlusMinus + ErrlmtPlus.Value + " " + ErrlmtPlus.Unit;
                }
                else
                {
                    str += " " + strErrlmt + " " + strPlus + ErrlmtPlus.Value + " " + ErrlmtPlus.Unit + " " + strMinus +
                           ErrlmtMinus.Value + " " + ErrlmtMinus.Unit;
                }
            }
            return str;
        }
    } // class ParamField
}