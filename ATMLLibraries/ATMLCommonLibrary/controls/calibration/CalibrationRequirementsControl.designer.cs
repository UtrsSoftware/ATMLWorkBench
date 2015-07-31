/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.document;

namespace ATMLCommonLibrary.controls.calibration
{
    partial class CalibrationRequirementsControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.supportEquipmentTextCollection = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.procedureDocument = new ATMLCommonLibrary.controls.document.DocumentListControl();
            this.hlplblfrequency = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.requiredFieldValidator1 = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.awbTimeSpan = new ATMLCommonLibrary.controls.awb.AWBDurationControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 35);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(578, 282);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.supportEquipmentTextCollection);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(570, 256);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Support Equipment";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // supportEquipmentTextCollection
            // 
            this.supportEquipmentTextCollection.AutoScroll = true;
            this.supportEquipmentTextCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.supportEquipmentTextCollection.HelpKeyWord = null;
            this.supportEquipmentTextCollection.Location = new System.Drawing.Point(3, 3);
            this.supportEquipmentTextCollection.Name = "supportEquipmentTextCollection";
            this.supportEquipmentTextCollection.SchemaTypeName = null;
            this.supportEquipmentTextCollection.Size = new System.Drawing.Size(564, 250);
            this.supportEquipmentTextCollection.TabIndex = 0;
            this.supportEquipmentTextCollection.TargetNamespace = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.procedureDocument);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(503, 256);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Procedure";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // procedureDocument
            // 
            this.procedureDocument.AllowRowResequencing = false;
            this.procedureDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.procedureDocument.DocumentType = ATMLDataAccessLibrary.model.dbDocument.DocumentType.PROCEDURE;
            this.procedureDocument.FormTitle = null;
            this.procedureDocument.HelpKeyWord = null;
            this.procedureDocument.ListName = null;
            this.procedureDocument.Location = new System.Drawing.Point(3, 3);
            this.procedureDocument.Margin = new System.Windows.Forms.Padding(0);
            this.procedureDocument.Name = "procedureDocument";
            this.procedureDocument.SchemaTypeName = null;
            this.procedureDocument.ShowFind = false;
            this.procedureDocument.Size = new System.Drawing.Size(497, 250);
            this.procedureDocument.TabIndex = 0;
            this.procedureDocument.TargetNamespace = null;
            this.procedureDocument.TooltipTextAddButton = "Press to add a new ";
            this.procedureDocument.TooltipTextDeleteButton = "Press to delete the selected ";
            this.procedureDocument.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // hlplblfrequency
            // 
            this.hlplblfrequency.AutoSize = true;
            this.hlplblfrequency.HelpMessageKey = "HardwareItemDescCalibrationReq.Frequency";
            this.hlplblfrequency.Location = new System.Drawing.Point(3, 9);
            this.hlplblfrequency.Name = "hlplblfrequency";
            this.hlplblfrequency.RequiredField = false;
            this.hlplblfrequency.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hlplblfrequency.Size = new System.Drawing.Size(57, 13);
            this.hlplblfrequency.TabIndex = 2;
            this.hlplblfrequency.Text = "Frequency";
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ControlToValidate = null;
            this.requiredFieldValidator1.ErrorMessage = "Field required.";
            this.requiredFieldValidator1.ErrorProvider = this.errorProvider1;
            this.requiredFieldValidator1.Icon = null;
            this.requiredFieldValidator1.InitialValue = null;
            this.requiredFieldValidator1.IsEnabled = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // awbTimeSpan
            // 
            this.awbTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.awbTimeSpan.Location = new System.Drawing.Point(66, 3);
            this.awbTimeSpan.MaximumDuration = ATMLCommonLibrary.controls.awb.AWBDurationControl.MaxDuration.Years;
            this.awbTimeSpan.Name = "awbTimeSpan";
            this.awbTimeSpan.Size = new System.Drawing.Size(484, 28);
            this.awbTimeSpan.TabIndex = 3;
            this.awbTimeSpan.TimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // CalibrationRequirementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.awbTimeSpan);
            this.Controls.Add(this.hlplblfrequency);
            this.Controls.Add(this.tabControl1);
            this.Name = "CalibrationRequirementsControl";
            this.Size = new System.Drawing.Size(578, 319);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private awb.AWBTextCollectionList supportEquipmentTextCollection;
        private DocumentListControl procedureDocument;
        private HelpLabel hlplblfrequency;
        private validators.RequiredFieldValidator requiredFieldValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private awb.AWBDurationControl awbTimeSpan;
    }
}
