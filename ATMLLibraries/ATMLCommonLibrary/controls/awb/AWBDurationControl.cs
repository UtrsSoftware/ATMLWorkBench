/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Windows.Forms;

namespace ATMLCommonLibrary.controls.awb
{
    public partial class AWBDurationControl : UserControl
    {
        private const double ApproxDaysPerMonth = 30.4375;
        private const double ApproxDaysPerYear = 365.25;
        private TimeSpan _timeSpan;

        private MaxDuration _maxDuration = MaxDuration.Years;

        public enum MaxDuration
        {
            Seconds,
            Minutes,
            Hours,
            Days,
            Months,
            Years
        }

        public AWBDurationControl()
        {
            InitializeComponent();
            SetControlStates();
        }

        public TimeSpan TimeSpan
        {
            get
            {
                ControlsToData();
                return _timeSpan;
            }
            set
            {
                _timeSpan = value;
                DataToControls();
            }
        }

        public MaxDuration MaximumDuration
        {
            get { return _maxDuration; }
            set
            {
                _maxDuration = value;
                SetControlStates();
            }
        }

        private void SetControlStates()
        {
            lblYear.Visible = numYears.Visible = _maxDuration >= MaxDuration.Years;
            lblMonth.Visible = numMonths.Visible = _maxDuration >= MaxDuration.Months;
            lblDay.Visible = numDays.Visible = _maxDuration >= MaxDuration.Days;
            lblHour.Visible = numHours.Visible = _maxDuration >= MaxDuration.Hours;
            lblMinute.Visible = numMinutes.Visible = _maxDuration >= MaxDuration.Minutes;
        }

        private void ControlsToData()
        {
            var years = (int) numYears.Value;
            var months = (int) numMonths.Value;
            var days = (int) numDays.Value;
            var hours = (int) numHours.Value;
            var minutes = (int) numMinutes.Value;
            var seconds = (int) numSeconds.Value;
            days += (int) (years*ApproxDaysPerYear) + (int) (months*ApproxDaysPerMonth);
            _timeSpan = new TimeSpan(days, hours, minutes, seconds);
        }

        private void DataToControls()
        {
            int days = _timeSpan.Days;

            //Calculate years as an integer division
            var years = (int) (days/ApproxDaysPerYear);

            //Decrease remaing days
            days -= (int) (years*ApproxDaysPerYear);

            //Calculate months as an integer division
            var months = (int) (days/ApproxDaysPerMonth);

            //Decrease remaing days
            days -= (int) (months*ApproxDaysPerMonth);

            numYears.Value = years;
            numMonths.Value = months;
            numDays.Value = days;
            numHours.Value = _timeSpan.Hours;
            numMinutes.Value = _timeSpan.Minutes;
            numSeconds.Value = _timeSpan.Seconds;
        }
    }
}