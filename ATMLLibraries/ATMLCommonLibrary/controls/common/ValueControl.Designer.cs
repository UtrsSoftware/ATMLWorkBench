/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
using ATMLCommonLibrary.controls.collection;
using ATMLCommonLibrary.controls.datum;

namespace ATMLCommonLibrary.controls.common
{
    partial class ValueControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmbValueType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.collectionControl = new CollectionControl();
            this.indexArrayControl = new ATMLCommonLibrary.controls.common.IndexArrayControl();
            this.datumTypeControl = new ATMLCommonLibrary.controls.datum.DatumTypeControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbValueType
            // 
            this.cmbValueType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbValueType.FormattingEnabled = true;
            this.cmbValueType.Items.AddRange(new object[] {
            "Collection",
            "Datum",
            "Indexed Array"});
            this.cmbValueType.Location = new System.Drawing.Point(78, 3);
            this.cmbValueType.Name = "cmbValueType";
            this.cmbValueType.Size = new System.Drawing.Size(139, 21);
            this.cmbValueType.TabIndex = 1;
            this.cmbValueType.SelectedIndexChanged += new System.EventHandler(this.cmbValueType_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.indexArrayControl);
            this.panel1.Controls.Add(this.datumTypeControl);
            this.panel1.Controls.Add(this.collectionControl);
            this.panel1.Location = new System.Drawing.Point(11, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(607, 584);
            this.panel1.TabIndex = 4;
            // 
            // collectionControl
            // 
            this.collectionControl.BackColor = System.Drawing.Color.Transparent;
            this.collectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collectionControl.HasErrors = false;
            this.collectionControl.HelpKeyWord = null;
            this.collectionControl.LastError = null;
            this.collectionControl.Location = new System.Drawing.Point(0, 0);
            this.collectionControl.LockTypes = false;
            this.collectionControl.Name = "collectionControl";
            this.collectionControl.SchemaTypeName = null;
            this.collectionControl.Size = new System.Drawing.Size(603, 580);
            this.collectionControl.TabIndex = 2;
            this.collectionControl.TargetNamespace = null;
            // 
            // indexArrayControl
            // 
            this.indexArrayControl.BackColor = System.Drawing.Color.Transparent;
            this.indexArrayControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexArrayControl.Location = new System.Drawing.Point(0, 0);
            this.indexArrayControl.LockTypes = false;
            this.indexArrayControl.Name = "indexArrayControl";
            this.indexArrayControl.Size = new System.Drawing.Size(603, 580);
            this.indexArrayControl.TabIndex = 4;
            this.indexArrayControl.Load += new System.EventHandler(this.indexArrayControl_Load);
            // 
            // datumTypeControl
            // 
            this.datumTypeControl.BackColor = System.Drawing.Color.Transparent;
            this.datumTypeControl.DefaultComparitor = -1;
            this.datumTypeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.datumTypeControl.HasErrors = false;
            this.datumTypeControl.HelpKeyWord = "Datum Type";
            this.datumTypeControl.LastError = null;
            this.datumTypeControl.Location = new System.Drawing.Point(0, 0);
            this.datumTypeControl.LockTypes = false;
            this.datumTypeControl.MinimumSize = new System.Drawing.Size(594, 548);
            this.datumTypeControl.Name = "datumTypeControl";
            this.datumTypeControl.SchemaTypeName = null;
            this.datumTypeControl.Size = new System.Drawing.Size(603, 580);
            this.datumTypeControl.TabIndex = 3;
            this.datumTypeControl.TargetNamespace = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "Value.ValueType";
            this.helpLabel1.Location = new System.Drawing.Point(8, 6);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(61, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Value Type";
            // 
            // ValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbValueType);
            this.Controls.Add(this.helpLabel1);
            this.MinimumSize = new System.Drawing.Size(595, 550);
            this.Name = "ValueControl";
            this.Size = new System.Drawing.Size(630, 626);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected HelpLabel helpLabel1;
        protected System.Windows.Forms.ComboBox cmbValueType;
        protected CollectionControl collectionControl;
        protected System.Windows.Forms.Panel panel1;
        protected DatumTypeControl datumTypeControl;
        protected IndexArrayControl indexArrayControl;
    }
}
