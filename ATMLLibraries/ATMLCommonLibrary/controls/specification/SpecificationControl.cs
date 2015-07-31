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
using System.Windows.Forms;
using ATMLCommonLibrary.controls.limit;
using ATMLCommonLibrary.managers;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;

namespace ATMLCommonLibrary.controls.specification
{
    public partial class SpecificationControl : UserControl
    {
        private const int CS_DROPSHADOW = 0x00020000;
        private Specification _specification;

        public SpecificationControl()
        {
            InitializeComponent();
            Validating += SpecificationControl_Validating;
            SetColumnWidths();
            limitListControl.OnAdd += limitListControl_OnAdd;
            limitListControl.OnEdit += limitListControl_OnEdit;
            limitListControl.OnDelete += limitListControl_OnDelete;
            rbNone.Checked = true;
            rbText.Checked = false;
            rbDocument.Checked = false;
            edtDefinitionText.Visible = false;
            documentControl.Visible = false;
            InitLimitList();
            SetControlStates();
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Specification Specification
        {
            get
            {
                ControlsToData();
                return _specification;
            }
            set
            {
                _specification = value;
                DataToControls();
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                // add the drop shadow flag for automatically drawing
                // a drop shadow around the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void InitLimitList()
        {
            limitListControl.Columns.Add("Type");
            limitListControl.Columns.Add("Limit");
            limitListControl.SetDistributedColumnWidths(new[] {.20d, .80d});
        }

        private void limitListControl_OnAdd()
        {
            var form = new LimitForm();
            if (DialogResult.OK == form.ShowDialog())
            {
                Limit limit = form.Limit;
                AddLimitToListView(limit);
            }
        }

        private void limitListControl_OnEdit()
        {
            if (limitListControl.HasSelected)
            {
                var limit = limitListControl.SelectedObject as Limit;
                if (limit != null)
                {
                    var form = new LimitForm(limit);
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        limit = form.Limit;
                        ListViewItem lvi = limitListControl.SelectedItems[0];
                        UpdateLimitInListView(lvi, limit);
                    }
                }
            }
        }

        private void limitListControl_OnDelete()
        {
            if (limitListControl.HasSelected)
            {
                var limit = limitListControl.SelectedObject as Limit;
                if (limit != null)
                {
                    String prompt = String.Format(MessageManager.getMessage("Generic.delete.prompt"), "Limit",
                        limit.name);
                    String title = MessageManager.getMessage("Generic.title.verification");

                    if (DialogResult.Yes == MessageBox.Show(prompt,
                        title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question))
                    {
                        limitListControl.SelectedItems[0].Remove();
                    }
                }
            }
        }


        private void ControlsToData()
        {
            if (_specification != null)
            {
                _specification.Description = edtSpecDescription.GetValue<string>();
                _specification.name = edtSpecName.GetValue<string>();
                if (limitListControl.Items.Count == 0)
                    _specification.Limits = null;
                else
                {
                    _specification.Limits = new List<Limit>();
                    foreach (ListViewItem item in limitListControl.Items)
                    {
                        _specification.Limits.Add(item.Tag as Limit);
                    }
                }

                _specification.Conditions = new List<string>();
                foreach (DataGridViewRow row in dgConditions.Rows)
                {
                    var value = row.Cells["condition"].Value as String;
                    if (!String.IsNullOrEmpty(value))
                        _specification.Conditions.Add(value);
                }
                if (_specification.Conditions.Count == 0)
                    _specification.Conditions = null;

                _specification.ExclusiveOptions = new List<string>();
                foreach (DataGridViewRow row in dgExclusiveOptions.Rows)
                {
                    var value = row.Cells["exclusiveOption"].Value as String;
                    if (!String.IsNullOrEmpty(value))
                        _specification.ExclusiveOptions.Add(value);
                }
                if (_specification.ExclusiveOptions.Count == 0)
                    _specification.ExclusiveOptions = null;

                _specification.RequiredOptions = new List<string>();
                foreach (DataGridViewRow row in dgRequiredOptions.Rows)
                {
                    var value = row.Cells["requiredOption"].Value as String;
                    if (!String.IsNullOrEmpty(value))
                        _specification.RequiredOptions.Add(value);
                }
                if (_specification.RequiredOptions.Count == 0)
                    _specification.RequiredOptions = null;

                _specification.SupplementalInformation = new List<string>();
                foreach (DataGridViewRow row in dgSupplimentalInfo.Rows)
                {
                    var value = row.Cells["information"].Value as String;
                    if (!String.IsNullOrEmpty(value))
                        _specification.SupplementalInformation.Add(value);
                }
                if (_specification.SupplementalInformation.Count == 0)
                    _specification.SupplementalInformation = null;


                if (rbNone.Checked)
                {
                    _specification.Definition = null;
                }
                else if (rbText.Checked)
                {
                    if (_specification.Definition == null)
                        _specification.Definition = new SpecificationDefinition();
                    _specification.Definition.Item = edtDefinitionText.GetValue<string>();
                }
                else if (rbDocument.Checked)
                {
                    if (_specification.Definition == null)
                        _specification.Definition = new SpecificationDefinition();
                    _specification.Definition.Item = documentControl.Document;
                }

                if (_specification.Definition != null && _specification.Definition.Item == null)
                    _specification.Definition = null;
            }
        }

        private void DataToControls()
        {
            if (_specification != null)
            {
                edtSpecDescription.Value = _specification.Description;
                edtSpecName.Value = _specification.name;

                SpecificationDefinition definition = _specification.Definition;
                if (definition != null)
                {
                    rbText.Checked = (definition.Item is String);
                    rbDocument.Checked = (definition.Item is Document);
                    if (rbText.Checked)
                        edtDefinitionText.Value = definition.Item as String;
                    else if (rbDocument.Checked)
                        documentControl.Document = definition.Item as Document;
                }


                //-----------------------------------//
                //--- Load the Limit List Control ---//
                //-----------------------------------//
                if (_specification.Limits != null)
                {
                    limitListControl.Items.Clear();
                    foreach (Limit limit in _specification.Limits)
                    {
                        AddLimitToListView(limit);
                    }
                }

                //---------------------------------------//
                //--- Load the Condition List Control ---//
                //---------------------------------------//
                if (_specification.Conditions != null)
                {
                    dgConditions.Rows.Clear();
                    foreach (String condition in _specification.Conditions)
                    {
                        int idx = dgConditions.Rows.Add();
                        DataGridViewRow row = dgConditions.Rows[idx];
                        row.Cells["condition"].Value = condition;
                    }
                }

                //-----------------------------------------//
                //--- Load the Required Options Control ---//
                //-----------------------------------------//
                if (_specification.RequiredOptions != null)
                {
                    dgRequiredOptions.Rows.Clear();
                    foreach (String option in _specification.RequiredOptions)
                    {
                        int idx = dgRequiredOptions.Rows.Add();
                        DataGridViewRow row = dgRequiredOptions.Rows[idx];
                        row.Cells["requiredOption"].Value = option;
                    }
                }

                //------------------------------------------//
                //--- Load the Exclusive Options Control ---//
                //------------------------------------------//
                if (_specification.ExclusiveOptions != null)
                {
                    dgExclusiveOptions.Rows.Clear();
                    foreach (String option in _specification.ExclusiveOptions)
                    {
                        int idx = dgExclusiveOptions.Rows.Add();
                        DataGridViewRow row = dgExclusiveOptions.Rows[idx];
                        row.Cells["exclusiveOption"].Value = option;
                    }
                }

                //-------------------------------------------------//
                //--- Load the Supplimental Information Control ---//
                //-------------------------------------------------//
                if (_specification.SupplementalInformation != null)
                {
                    dgSupplimentalInfo.Rows.Clear();
                    foreach (String information in _specification.SupplementalInformation)
                    {
                        int idx = dgSupplimentalInfo.Rows.Add();
                        DataGridViewRow row = dgSupplimentalInfo.Rows[idx];
                        row.Cells["information"].Value = information;
                    }
                }
            }
        }

        private void AddLimitToListView(Limit limit)
        {
            if (limit != null)
            {
                var lvi = new ListViewItem(limit.Item.GetType().Name);
                lvi.SubItems.Add(limit.ToString());
                lvi.Tag = limit;
                limitListControl.Items.Add(lvi);
            }
        }

        private void UpdateLimitInListView(ListViewItem lvi, Limit limit)
        {
            lvi.SubItems[0].Text = limit.Item.GetType().Name;
            lvi.SubItems[1].Text = limit.ToString();
            lvi.Tag = limit;
        }

        private void SpecificationControl_Validating(object sender, CancelEventArgs e)
        {
        }

        private void SetColumnWidths()
        {
            if (dgConditions.Columns.Count>=1)
                dgConditions.Columns[0].Width = dgConditions.Width - 2;
            if (dgExclusiveOptions.Columns.Count >= 1)
                dgExclusiveOptions.Columns[0].Width = dgExclusiveOptions.Width - 2;
            if (dgRequiredOptions.Columns.Count >= 1)
                dgRequiredOptions.Columns[0].Width = dgRequiredOptions.Width - 2;
            if (dgSupplimentalInfo.Columns.Count >= 1)
                dgSupplimentalInfo.Columns[0].Width = dgSupplimentalInfo.Width - 2;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void rbDocument_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            SetControlStates();
        }

        private void SetControlStates()
        {
            documentControl.ValidationEnabled = documentControl.Visible = rbDocument.Checked;
            requiredDefinitionTextValidator.IsEnabled = edtDefinitionText.Visible = rbText.Checked;
        }

        private void SpecificationControl_SizeChanged(object sender, EventArgs e)
        {
            SetColumnWidths();
        }

        private void SpecificationControl_Load(object sender, EventArgs e)
        {
            SetColumnWidths();
        }

        private void tabSpecifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetColumnWidths();
        }

        private void btnConditionsAdd_Click(object sender, EventArgs e)
        {
            dgConditions.Rows.Add();
        }

        private void btnConditionsDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dgConditions);
        }

        private void btnConditionsEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dgConditions);
        }

        private void btnSuppInfoAdd_Click(object sender, EventArgs e)
        {
            dgSupplimentalInfo.Rows.Add();
        }

        private void btnSuppInfoEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dgSupplimentalInfo);
        }

        private void btnSuppInfoDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dgSupplimentalInfo);
        }

        private void btnReqOptionAdd_Click(object sender, EventArgs e)
        {
            dgRequiredOptions.Rows.Add();
        }

        private void btnReqOptionEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dgRequiredOptions);
        }

        private void btnReqOptionDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dgRequiredOptions);
        }

        private void btnExcOptionAdd_Click(object sender, EventArgs e)
        {
            dgExclusiveOptions.Rows.Add();
        }

        private void btnExcOptionEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(dgExclusiveOptions);
        }

        private void btnExcOptionDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedRows(dgExclusiveOptions);
        }

        private void SetEditMode(DataGridView dataGridView)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                DataGridViewCell cell = dataGridView.SelectedCells[0];
                dataGridView.CurrentCell = cell;
                dataGridView.BeginEdit(true);
            }
        }

        private void DeleteSelectedRows(DataGridView dataGridView)
        {
            foreach (DataGridViewCell cell in dataGridView.SelectedCells)
            {
                DataGridViewRow row = dataGridView.Rows[cell.RowIndex];
                if (!row.IsNewRow)
                    dataGridView.Rows.Remove(row);
            }
        }
    }
}