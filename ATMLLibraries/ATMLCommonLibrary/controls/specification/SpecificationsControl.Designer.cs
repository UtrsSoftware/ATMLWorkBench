/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.specification
{
    partial class SpecificationsControl
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
            if( disposing && ( components != null ) )
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
            this.tabSpecifications = new System.Windows.Forms.TabControl();
            this.tabSubSpecifications = new System.Windows.Forms.TabPage();
            this.specificationListControl = new ATMLCommonLibrary.controls.lists.SpecificationListControl();
            this.tabConditions = new System.Windows.Forms.TabPage();
            this.conditionListControl = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabCertifications = new System.Windows.Forms.TabPage();
            this.certificationListControl = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.tabSpecifications.SuspendLayout();
            this.tabSubSpecifications.SuspendLayout();
            this.tabConditions.SuspendLayout();
            this.tabCertifications.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSpecifications
            // 
            this.tabSpecifications.Controls.Add(this.tabSubSpecifications);
            this.tabSpecifications.Controls.Add(this.tabConditions);
            this.tabSpecifications.Controls.Add(this.tabCertifications);
            this.tabSpecifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSpecifications.Location = new System.Drawing.Point(0, 0);
            this.tabSpecifications.Margin = new System.Windows.Forms.Padding(0);
            this.tabSpecifications.Name = "tabSpecifications";
            this.tabSpecifications.Padding = new System.Drawing.Point(0, 0);
            this.tabSpecifications.SelectedIndex = 0;
            this.tabSpecifications.Size = new System.Drawing.Size(661, 199);
            this.tabSpecifications.TabIndex = 12;
            // 
            // tabSubSpecifications
            // 
            this.tabSubSpecifications.BackColor = System.Drawing.Color.SteelBlue;
            this.tabSubSpecifications.Controls.Add(this.specificationListControl);
            this.tabSubSpecifications.Location = new System.Drawing.Point(4, 22);
            this.tabSubSpecifications.Name = "tabSubSpecifications";
            this.tabSubSpecifications.Size = new System.Drawing.Size(639, 158);
            this.tabSubSpecifications.TabIndex = 2;
            this.tabSubSpecifications.Text = "Sub Specifications";
            // 
            // specificationListControl
            // 
            this.specificationListControl.AllowRowResequencing = false;
            this.specificationListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.specificationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specificationListControl.FormTitle = null;
            this.specificationListControl.HasErrors = false;
            this.specificationListControl.HelpKeyWord = null;
            this.specificationListControl.LastError = null;
            this.specificationListControl.ListName = null;
            this.specificationListControl.Location = new System.Drawing.Point(0, 0);
            this.specificationListControl.Margin = new System.Windows.Forms.Padding(0);
            this.specificationListControl.Name = "specificationListControl";
            this.specificationListControl.SchemaTypeName = null;
            this.specificationListControl.ShowFind = false;
            this.specificationListControl.Size = new System.Drawing.Size(639, 158);
            this.specificationListControl.TabIndex = 0;
            this.specificationListControl.TargetNamespace = null;
            this.specificationListControl.TooltipTextAddButton = "Press to add a new Specification";
            this.specificationListControl.TooltipTextDeleteButton = "Press to delete the selected Specification";
            this.specificationListControl.TooltipTextEditButton = "Press to edit the selected Specification";
            // 
            // tabConditions
            // 
            this.tabConditions.BackColor = System.Drawing.Color.SteelBlue;
            this.tabConditions.Controls.Add(this.conditionListControl);
            this.tabConditions.Location = new System.Drawing.Point(4, 22);
            this.tabConditions.Margin = new System.Windows.Forms.Padding(0);
            this.tabConditions.Name = "tabConditions";
            this.tabConditions.Size = new System.Drawing.Size(639, 158);
            this.tabConditions.TabIndex = 1;
            this.tabConditions.Text = "Conditions";
            // 
            // conditionListControl
            // 
            this.conditionListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.conditionListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conditionListControl.HasErrors = false;
            this.conditionListControl.HelpKeyWord = null;
            this.conditionListControl.LastError = null;
            this.conditionListControl.Location = new System.Drawing.Point(0, 0);
            this.conditionListControl.Name = "conditionListControl";
            this.conditionListControl.SchemaTypeName = null;
            this.conditionListControl.Size = new System.Drawing.Size(639, 158);
            this.conditionListControl.TabIndex = 34;
            this.conditionListControl.TargetNamespace = null;
            // 
            // tabCertifications
            // 
            this.tabCertifications.BackColor = System.Drawing.Color.SteelBlue;
            this.tabCertifications.Controls.Add(this.certificationListControl);
            this.tabCertifications.Location = new System.Drawing.Point(4, 22);
            this.tabCertifications.Margin = new System.Windows.Forms.Padding(0);
            this.tabCertifications.Name = "tabCertifications";
            this.tabCertifications.Size = new System.Drawing.Size(653, 173);
            this.tabCertifications.TabIndex = 3;
            this.tabCertifications.Text = "Certifications";
            // 
            // certificationListControl
            // 
            this.certificationListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.certificationListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.certificationListControl.HasErrors = false;
            this.certificationListControl.HelpKeyWord = null;
            this.certificationListControl.LastError = null;
            this.certificationListControl.Location = new System.Drawing.Point(0, 0);
            this.certificationListControl.Name = "certificationListControl";
            this.certificationListControl.SchemaTypeName = null;
            this.certificationListControl.Size = new System.Drawing.Size(653, 173);
            this.certificationListControl.TabIndex = 33;
            this.certificationListControl.TargetNamespace = null;
            // 
            // SpecificationsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Controls.Add(this.tabSpecifications);
            this.Name = "SpecificationsControl";
            this.Size = new System.Drawing.Size(661, 199);
            this.tabSpecifications.ResumeLayout(false);
            this.tabSubSpecifications.ResumeLayout(false);
            this.tabConditions.ResumeLayout(false);
            this.tabCertifications.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSpecifications;
        private System.Windows.Forms.TabPage tabConditions;
        private System.Windows.Forms.TabPage tabSubSpecifications;
        private System.Windows.Forms.TabPage tabCertifications;
        private lists.SpecificationListControl specificationListControl;
        private awb.AWBTextCollectionList conditionListControl;
        private awb.AWBTextCollectionList certificationListControl;
    }
}
