/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.datum
{
    partial class DatumTypeDoubleControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatumTypeDoubleControl));
            this.flowLayoutPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtDoubleValue = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.standardUnitControl = new ATMLCommonLibrary.controls.StandardUnitControl();
            this.btnDatum = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDoubleDescription = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel.Controls.Add(this.panel1);
            this.flowLayoutPanel.Controls.Add(this.standardUnitControl);
            this.flowLayoutPanel.Controls.Add(this.btnDatum);
            this.flowLayoutPanel.Controls.Add(this.panel2);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(300, 50);
            this.flowLayoutPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.edtDoubleValue);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2, 4, 4, 2);
            this.panel1.Size = new System.Drawing.Size(89, 23);
            this.panel1.TabIndex = 0;
            // 
            // edtDoubleValue
            // 
            this.edtDoubleValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDoubleValue.AttributeName = null;
            this.edtDoubleValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtDoubleValue.Location = new System.Drawing.Point(2, 4);
            this.edtDoubleValue.Margin = new System.Windows.Forms.Padding(0);
            this.edtDoubleValue.Multiline = true;
            this.edtDoubleValue.Name = "edtDoubleValue";
            this.edtDoubleValue.Size = new System.Drawing.Size(79, 13);
            this.edtDoubleValue.TabIndex = 0;
            this.edtDoubleValue.Tag = 0D;
            this.edtDoubleValue.Text = "0";
            this.edtDoubleValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.edtDoubleValue.Value = 0D;
            this.edtDoubleValue.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsDouble;
            this.edtDoubleValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtDoubleValue_KeyDown);
            // 
            // standardUnitControl
            // 
            this.standardUnitControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.standardUnitControl.BackColor = System.Drawing.Color.Transparent;
            this.standardUnitControl.Location = new System.Drawing.Point(92, 2);
            this.standardUnitControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 0);
            this.standardUnitControl.Name = "standardUnitControl";
            this.standardUnitControl.SchemaTypeName = null;
            this.standardUnitControl.Size = new System.Drawing.Size(185, 23);
            this.standardUnitControl.TabIndex = 1;
            this.standardUnitControl.TargetNamespace = null;
            // 
            // btnDatum
            // 
            this.btnDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDatum.BackColor = System.Drawing.Color.White;
            this.btnDatum.FlatAppearance.BorderSize = 0;
            this.btnDatum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDatum.Image = ((System.Drawing.Image)(resources.GetObject("btnDatum.Image")));
            this.btnDatum.Location = new System.Drawing.Point(280, 3);
            this.btnDatum.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.btnDatum.Name = "btnDatum";
            this.btnDatum.Size = new System.Drawing.Size(19, 19);
            this.btnDatum.TabIndex = 2;
            this.btnDatum.UseVisualStyleBackColor = false;
            this.btnDatum.Click += new System.EventHandler(this.btnDatum_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblDoubleDescription);
            this.panel2.Location = new System.Drawing.Point(3, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 21);
            this.panel2.TabIndex = 6;
            // 
            // lblDoubleDescription
            // 
            this.lblDoubleDescription.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblDoubleDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoubleDescription.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoubleDescription.Location = new System.Drawing.Point(0, 0);
            this.lblDoubleDescription.Name = "lblDoubleDescription";
            this.lblDoubleDescription.Size = new System.Drawing.Size(294, 21);
            this.lblDoubleDescription.TabIndex = 0;
            this.lblDoubleDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DatumTypeDoubleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "DatumTypeDoubleControl";
            this.Size = new System.Drawing.Size(300, 50);
            this.flowLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private awb.AWBTextBox edtDoubleValue;
        private System.Windows.Forms.Button btnDatum;
        private System.Windows.Forms.Panel flowLayoutPanel;
        private StandardUnitControl standardUnitControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDoubleDescription;
    }
}
