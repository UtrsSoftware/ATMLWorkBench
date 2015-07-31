/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using ATMLCommonLibrary.controls;

namespace WindowsFormsApplication10
{
    public partial class SecurityClassificationControl : ATMLControl
    {
        #region Members

        private bool _classified;
        private string _securityClassification;

        #endregion

        private static string DefaultClassification = "UNCLASSIFIED";

        public SecurityClassificationControl()
        {
            InitializeComponent();
            chkClassified.Checked = _classified;
            cmbSecurityClass.SelectedIndex = -1;
        }

        public string SecurityClassification
        {
            get
            {
                _securityClassification = cmbSecurityClass.SelectedItem as string;
                return _securityClassification;
            }
            set
            {
                _securityClassification = value;
                if (_securityClassification != null)
                    cmbSecurityClass.SelectedIndex = cmbSecurityClass.FindString(_securityClassification);
            }
        }

        public bool Classified
        {
            get { _classified = chkClassified.Checked; return _classified; }
            set { _classified = value; chkClassified.Checked = _classified; }
        }

        private void chk_CheckedChanged( object sender, EventArgs e )
        {
            _classified = chkClassified.Checked;
            if (chkClassified.Checked == false)
            {
                cmbSecurityClass.Text = DefaultClassification;
                cmbSecurityClass.Enabled = false;
            }

            if (chkClassified.Checked)
            {
                cmbSecurityClass.Enabled = true;
                _securityClassification = cmbSecurityClass.Text;
            }
        }

        private void cmb_SelectedIndexChanged( object sender, EventArgs e )
        {
            _classified = chkClassified.Checked;
            if (cmbSecurityClass.Text == DefaultClassification)
            {
                chkClassified.Checked = false;
                cmbSecurityClass.Enabled = false;
            }

            SecurityClassification = cmbSecurityClass.Text;
        }

        private void label1_Click( object sender, EventArgs e )
        {
        }
    }
}