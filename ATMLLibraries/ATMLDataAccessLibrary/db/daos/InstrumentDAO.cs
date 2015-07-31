/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using ATMLDataAccessLibrary.db.beans;
using ATMLUtilitiesLibrary;

namespace ATMLDataAccessLibrary.db.daos
{
    public class InstrumentDAO : DAO
    {

        public bool TestAttribute( string uuid, string attribute, object value, string qualifier )
        {
            bool inBounds = false;
            object valueHi;
            object valueLo;
            DetermineHoLoValues( qualifier, value, out valueHi, out valueLo );

            string sql = string.Format("SELECT COUNT(*) as cnt from {0} WHERE {1}=? AND {2}=? AND {3}<=? AND {4}>=?", 
                                        InstrumentCapabilitiesBean._TABLE_NAME, 
                                        InstrumentCapabilitiesBean._INSTRUMENT_UUID,
                                        InstrumentCapabilitiesBean._ATTRIBUTE, 
                                        InstrumentCapabilitiesBean._LOW_VALUE, 
                                        InstrumentCapabilitiesBean._HIGH_VALUE );
            List<OleDbParameter> dbParams = new List<OleDbParameter>();
            dbParams.Add(CreateParameter(InstrumentCapabilitiesBean._INSTRUMENT_UUID, uuid));
            dbParams.Add(CreateParameter(InstrumentCapabilitiesBean._ATTRIBUTE, attribute));
            dbParams.Add(CreateParameter(InstrumentCapabilitiesBean._LOW_VALUE, valueLo));
            dbParams.Add(CreateParameter(InstrumentCapabilitiesBean._HIGH_VALUE, valueHi));
            using (OleDbDataReader rs = ExecuteSqlQuery( sql, dbParams.ToArray() ))
            {
                if (rs != null)
                {
                    if (rs.Read())
                    {
                        inBounds = int.Parse( rs["cnt"].ToString() ) > 0;
                    }

                }
            }
            return inBounds;
        }
        

        public ICollection<object> FindCapableEquipment(ICollection<Tuple<string, object, string>> attributes, string uuid = null)
        {
            List<object> instrumentIds = new List<object>();
            List<string> names = new List<string>();
            List<object> values = new List<object>();
            List<string> qualifiers = new List<string>();
            foreach (Tuple<string, object, string> attribute in attributes)
            {
                names.Add( attribute.Item1 );
                values.Add( attribute.Item2 );
                qualifiers.Add(attribute.Item3);
            }
            string sql = BuildCapabilityQuery( names.ToArray() );
            if (uuid != null)
                sql += " AND instrument_uuid=? ";

            List<OleDbParameter> dbParams = new List<OleDbParameter>();
            foreach (Tuple<string, object, string> attribute in attributes)
            {
                names.Add(attribute.Item1);
                values.Add(attribute.Item2);
                string name = attribute.Item1;
                object value = attribute.Item2;
                object valueHi;
                object valueLo;
                string qualifier = attribute.Item3;
                DetermineHoLoValues( qualifier, value, out valueHi, out valueLo );
                dbParams.Add(CreateParameter(string.Format("{0}_low", name), valueLo));
                dbParams.Add(CreateParameter(string.Format("{0}_high", name), valueHi));
            }

            if (uuid != null)
                dbParams.Add(CreateParameter("instrument_uuid", uuid));

            using (OleDbDataReader rs = ExecuteSqlQuery( sql, dbParams.ToArray() ))
            {
                if (rs != null)
                {
                    try
                    {
                        while (rs.Read())
                        {
                            instrumentIds.Add( rs[InstrumentCapabilitiesBean._INSTRUMENT_UUID] );
                        }
                    }
                    finally
                    {
                        rs.Close();
                        rs.Dispose();
                    }
                }
            }
            return instrumentIds;
        }
        private static void DetermineHoLoValues( string qualifier, object value, out object valueHi, out object valueLo )
        {
            valueLo = null;
            valueHi = null;

            if (!string.IsNullOrEmpty( qualifier ))
            {
                //--- If it is a string try to convert it to a double ---//
                if (value is string)
                {
                    double d;
                    if (double.TryParse( (string) value, out d ))
                        value = d;
                }

                if ("pk_pk".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double d = (double) value;
                        double pk = ( (double) value )/2;
                        valueHi = pk;
                        valueLo = pk - d;
                    }
                }
                else if ("pk".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double pk = (double) value;
                        valueHi = pk;
                        valueLo = pk - 2*pk;
                    }
                }
                else if ("pk_pos".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double pk = (double) value;
                        valueHi = pk;
                        valueLo = pk - 2*pk;
                    }
                }
                else if ("pk_neg".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double d = (double) value;
                        valueLo = d < 0 ? d : -1*d;
                        valueHi = d < 0 ? -1*d : d;
                    }
                }
                else if ("trms".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double d = (double) value;
                        double pk = .707*d;
                        valueHi = pk;
                        valueLo = -1*pk;
                    }
                }
                else if ("av".Equals( qualifier ))
                {
                    if (value is double)
                    {
                        double d = Math.Abs( (double) value );
                        double pk = d/.637;
                        valueHi = pk;
                        valueLo = -1*pk;
                    }
                }
            }

            if (valueLo == null)
                valueLo = value;
            if (valueHi == null)
                valueHi = value;
        }

        /*
         * 
SELECT * FROM
(
SELECT * FROM
(
SELECT instrument_uuid, signal_name, 
sum(switch( attribute='ac_ampl', low_value )) as ac_ampl_low, 
sum(switch( attribute='ac_ampl', high_value )) as ac_ampl_high, 
sum(switch( attribute='dc_offset', low_value )) as dc_offset_low, 
sum(switch( attribute='dc_offset', high_value )) as dc_offset_high, 
sum(switch( attribute='freq', low_value  )) as freq_low, 
sum(switch( attribute='freq', high_value  )) as freq_high, 
sum(switch( attribute='limit', low_value )) as limit_low, 
sum(switch( attribute='limit', high_value )) as limit_high, 
sum(switch( attribute='phase', low_value )) as phase_low,
sum(switch( attribute='phase', high_value )) as phase_high
FROM instrument_capabilities 
GROUP BY  instrument_uuid, signal_name
)
WHERE 
( ac_ampl_low IS NOT NULL or ac_ampl_high IS NOT NULL )
AND ( dc_offset_low IS NOT NULL OR dc_offset_high IS NOT NULL )
AND ( freq_low IS NOT NULL OR freq_high IS NOT NULL )
AND ( limit_low IS NOT NULL OR limit_high IS NOT NULL )
AND ( phase_low IS NOT NULL OR phase_high IS NOT NULL )
)
WHERE
ac_ampl_low <=30 AND ac_ampl_high >=30
         */

        public static string BuildCapabilityQuery( string[] attributes )
        {
            StringBuilder sb = new StringBuilder();
            sb.Append( "SELECT * FROM ( SELECT * FROM ( SELECT instrument_uuid, capability_name, signal_name, " );
            foreach (string attribute in attributes)
            {
                sb.Append( string.Format("sum(switch( attribute='{0}', low_value )) as {0}_low, ", attribute) );
                sb.Append(string.Format("sum(switch( attribute='{0}', high_value )) as {0}_high, ", attribute));
            }

            if (sb.ToString().EndsWith( ", " ))
                sb.Length = sb.Length - 2;

            sb.Append(" FROM instrument_capabilities GROUP BY instrument_uuid, capability_name, signal_name ) WHERE ( ");
            foreach (string attribute in attributes)
            {
                sb.Append(string.Format(" ( {0}_low IS NOT NULL or {0}_high IS NOT NULL ) AND ", attribute));
            }

            if (sb.ToString().EndsWith("AND "))
                sb.Length = sb.Length - 4;
            sb.Append( ") ) WHERE " );

            foreach (string attribute in attributes)
            {
                sb.Append(string.Format(" ( {0}_low <= ? AND {0}_high >= ? ) AND ", attribute));
            }

            if (sb.ToString().EndsWith("AND "))
                sb.Length = sb.Length - 4;

            return sb.ToString();
        }

    }
}
