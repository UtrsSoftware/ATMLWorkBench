/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.switching
{
    partial class SwitchRelayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblName = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.dgRelayConnections = new System.Windows.Forms.DataGridView();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredNameValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.cfrom = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRelayConnections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.helpLabel1);
            this.panel1.Controls.Add(this.dgRelayConnections);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.edtName);
            this.panel1.Size = new System.Drawing.Size(426, 305);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(369, 324);
            this.btnCancel.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(288, 324);
            this.btnOk.TabIndex = 1;
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(2, 333);
            // 
            // lblName
            // 
            this.lblName.HelpMessageKey = "Item.name";
            this.lblName.Location = new System.Drawing.Point(15, 19);
            this.lblName.Name = "lblName";
            this.lblName.RequiredField = true;
            this.lblName.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(58, 16);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(319, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // dgRelayConnections
            // 
            this.dgRelayConnections.BackgroundColor = System.Drawing.Color.White;
            this.dgRelayConnections.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRelayConnections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRelayConnections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRelayConnections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cfrom,
            this.to});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRelayConnections.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgRelayConnections.Location = new System.Drawing.Point(18, 71);
            this.dgRelayConnections.Name = "dgRelayConnections";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRelayConnections.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgRelayConnections.RowHeadersVisible = false;
            this.dgRelayConnections.Size = new System.Drawing.Size(394, 217);
            this.dgRelayConnections.TabIndex = 3;
            this.dgRelayConnections.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgRelayConnections_RowsAdded);
            // 
            // helpLabel1
            // 
            this.helpLabel1.HelpMessageKey = "SwitchRelay,connection";
            this.helpLabel1.Location = new System.Drawing.Point(15, 55);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(39, 13);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Relay Connection";
            // 
            // requiredNameValidator
            // 
            this.requiredNameValidator.ControlToValidate = this.edtName;
            this.requiredNameValidator.ErrorMessage = "The Switch Relay name is required";
            this.requiredNameValidator.ErrorProvider = this.errorProvider;
            this.requiredNameValidator.Icon = null;
            this.requiredNameValidator.InitialValue = null;
            this.requiredNameValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // cfrom
            // 
            this.cfrom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cfrom.HeaderText = "From";
            this.cfrom.Name = "cfrom";
            this.cfrom.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cfrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // to
            // 
            this.to.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.to.HeaderText = "To";
            this.to.Name = "to";
            this.to.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.to.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SwitchRelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 352);
            this.Name = "SwitchRelayForm";
            this.Text = "Switch Relay";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRelayConnections)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRelayConnections;
        protected HelpLabel lblName;
        protected awb.AWBTextBox edtName;
        protected HelpLabel helpLabel1;
        private validators.RequiredFieldValidator requiredNameValidator;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.DataGridViewComboBoxColumn cfrom;
        private System.Windows.Forms.DataGridViewComboBoxColumn to;
    }
}