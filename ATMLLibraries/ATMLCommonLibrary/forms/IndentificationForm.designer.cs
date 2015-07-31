/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class IdentificationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentificationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabIdentificationNumbers = new System.Windows.Forms.TabPage();
            this.lvIdentifications = new System.Windows.Forms.ListView();
            this.colNumber = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.colType = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.colQualifier = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.colManufacturerName = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.btnDeleteIdentification = new System.Windows.Forms.Button();
            this.btnEditIdentification = new System.Windows.Forms.Button();
            this.btnAddIdentification = new System.Windows.Forms.Button();
            this.tabManufacturers = new System.Windows.Forms.TabPage();
            this.lvManufacturers = new System.Windows.Forms.ListView();
            this.colManufacturer = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.colCageCode = ( (System.Windows.Forms.ColumnHeader)( new System.Windows.Forms.ColumnHeader() ) );
            this.btnDeleteManufacturer = new System.Windows.Forms.Button();
            this.btnEditManufacturer = new System.Windows.Forms.Button();
            this.btnAddManufacturer = new System.Windows.Forms.Button();
            this.tabExtensions = new System.Windows.Forms.TabPage();
            this.lvExtensions = new System.Windows.Forms.ListView();
            this.btnDeleteExtension = new System.Windows.Forms.Button();
            this.btnEditExtension = new System.Windows.Forms.Button();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.edtVersion = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabDesignator = new System.Windows.Forms.TabPage();
            this.edtDesignator = new ATMLCommonLibrary.controls.awb.AWBTextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabIdentificationNumbers.SuspendLayout();
            this.tabManufacturers.SuspendLayout();
            this.tabExtensions.SuspendLayout();
            this.tabDesignator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.edtVersion);
            this.panel1.Location = new System.Drawing.Point(6, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 375);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.tabControl1.Controls.Add(this.tabIdentificationNumbers);
            this.tabControl1.Controls.Add(this.tabManufacturers);
            this.tabControl1.Controls.Add(this.tabExtensions);
            this.tabControl1.Controls.Add(this.tabDesignator);
            this.tabControl1.Location = new System.Drawing.Point(21, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 265);
            this.tabControl1.TabIndex = 4;
            // 
            // tabIdentificationNumbers
            // 
            this.tabIdentificationNumbers.Controls.Add(this.lvIdentifications);
            this.tabIdentificationNumbers.Controls.Add(this.btnDeleteIdentification);
            this.tabIdentificationNumbers.Controls.Add(this.btnEditIdentification);
            this.tabIdentificationNumbers.Controls.Add(this.btnAddIdentification);
            this.tabIdentificationNumbers.Location = new System.Drawing.Point(4, 22);
            this.tabIdentificationNumbers.Name = "tabIdentificationNumbers";
            this.tabIdentificationNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabIdentificationNumbers.Size = new System.Drawing.Size(726, 239);
            this.tabIdentificationNumbers.TabIndex = 0;
            this.tabIdentificationNumbers.Text = "Identification Numbers";
            this.tabIdentificationNumbers.UseVisualStyleBackColor = true;
            // 
            // lvIdentifications
            // 
            this.lvIdentifications.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lvIdentifications.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNumber,
            this.colType,
            this.colQualifier,
            this.colManufacturerName});
            this.lvIdentifications.Location = new System.Drawing.Point(4, 28);
            this.lvIdentifications.Name = "lvIdentifications";
            this.lvIdentifications.Size = new System.Drawing.Size(716, 204);
            this.lvIdentifications.TabIndex = 15;
            this.lvIdentifications.UseCompatibleStateImageBehavior = false;
            this.lvIdentifications.View = System.Windows.Forms.View.Details;
            // 
            // colNumber
            // 
            this.colNumber.Text = "Number";
            this.colNumber.Width = 113;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 120;
            // 
            // colQualifier
            // 
            this.colQualifier.Text = "Qualifier";
            this.colQualifier.Width = 138;
            // 
            // colManufacturerName
            // 
            this.colManufacturerName.Text = "Manufacturer";
            this.colManufacturerName.Width = 248;
            // 
            // btnDeleteIdentification
            // 
            this.btnDeleteIdentification.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDeleteIdentification.FlatAppearance.BorderSize = 0;
            this.btnDeleteIdentification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteIdentification.Image = ( (System.Drawing.Image)( resources.GetObject("btnDeleteIdentification.Image") ) );
            this.btnDeleteIdentification.Location = new System.Drawing.Point(701, 6);
            this.btnDeleteIdentification.Name = "btnDeleteIdentification";
            this.btnDeleteIdentification.Size = new System.Drawing.Size(19, 17);
            this.btnDeleteIdentification.TabIndex = 14;
            this.btnDeleteIdentification.UseVisualStyleBackColor = true;
            // 
            // btnEditIdentification
            // 
            this.btnEditIdentification.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnEditIdentification.FlatAppearance.BorderSize = 0;
            this.btnEditIdentification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditIdentification.Image = ( (System.Drawing.Image)( resources.GetObject("btnEditIdentification.Image") ) );
            this.btnEditIdentification.Location = new System.Drawing.Point(682, 6);
            this.btnEditIdentification.Name = "btnEditIdentification";
            this.btnEditIdentification.Size = new System.Drawing.Size(19, 17);
            this.btnEditIdentification.TabIndex = 13;
            this.btnEditIdentification.UseVisualStyleBackColor = true;
            // 
            // btnAddIdentification
            // 
            this.btnAddIdentification.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddIdentification.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddIdentification.FlatAppearance.BorderSize = 0;
            this.btnAddIdentification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddIdentification.Image = ( (System.Drawing.Image)( resources.GetObject("btnAddIdentification.Image") ) );
            this.btnAddIdentification.Location = new System.Drawing.Point(662, 6);
            this.btnAddIdentification.Name = "btnAddIdentification";
            this.btnAddIdentification.Size = new System.Drawing.Size(19, 17);
            this.btnAddIdentification.TabIndex = 12;
            this.btnAddIdentification.UseVisualStyleBackColor = true;
            // 
            // tabManufacturers
            // 
            this.tabManufacturers.Controls.Add(this.lvManufacturers);
            this.tabManufacturers.Controls.Add(this.btnDeleteManufacturer);
            this.tabManufacturers.Controls.Add(this.btnEditManufacturer);
            this.tabManufacturers.Controls.Add(this.btnAddManufacturer);
            this.tabManufacturers.Location = new System.Drawing.Point(4, 22);
            this.tabManufacturers.Name = "tabManufacturers";
            this.tabManufacturers.Padding = new System.Windows.Forms.Padding(3);
            this.tabManufacturers.Size = new System.Drawing.Size(726, 239);
            this.tabManufacturers.TabIndex = 1;
            this.tabManufacturers.Text = "Manufacturers";
            this.tabManufacturers.UseVisualStyleBackColor = true;
            // 
            // lvManufacturers
            // 
            this.lvManufacturers.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lvManufacturers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colManufacturer,
            this.colCageCode});
            this.lvManufacturers.Location = new System.Drawing.Point(4, 28);
            this.lvManufacturers.Name = "lvManufacturers";
            this.lvManufacturers.Size = new System.Drawing.Size(716, 204);
            this.lvManufacturers.TabIndex = 19;
            this.lvManufacturers.UseCompatibleStateImageBehavior = false;
            this.lvManufacturers.View = System.Windows.Forms.View.Details;
            // 
            // colManufacturer
            // 
            this.colManufacturer.Text = "Manufacturer";
            this.colManufacturer.Width = 333;
            // 
            // colCageCode
            // 
            this.colCageCode.Text = "Cage Code";
            this.colCageCode.Width = 128;
            // 
            // btnDeleteManufacturer
            // 
            this.btnDeleteManufacturer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDeleteManufacturer.FlatAppearance.BorderSize = 0;
            this.btnDeleteManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteManufacturer.Image = ( (System.Drawing.Image)( resources.GetObject("btnDeleteManufacturer.Image") ) );
            this.btnDeleteManufacturer.Location = new System.Drawing.Point(701, 6);
            this.btnDeleteManufacturer.Name = "btnDeleteManufacturer";
            this.btnDeleteManufacturer.Size = new System.Drawing.Size(19, 17);
            this.btnDeleteManufacturer.TabIndex = 18;
            this.btnDeleteManufacturer.UseVisualStyleBackColor = true;
            // 
            // btnEditManufacturer
            // 
            this.btnEditManufacturer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnEditManufacturer.FlatAppearance.BorderSize = 0;
            this.btnEditManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditManufacturer.Image = ( (System.Drawing.Image)( resources.GetObject("btnEditManufacturer.Image") ) );
            this.btnEditManufacturer.Location = new System.Drawing.Point(682, 6);
            this.btnEditManufacturer.Name = "btnEditManufacturer";
            this.btnEditManufacturer.Size = new System.Drawing.Size(19, 17);
            this.btnEditManufacturer.TabIndex = 17;
            this.btnEditManufacturer.UseVisualStyleBackColor = true;
            // 
            // btnAddManufacturer
            // 
            this.btnAddManufacturer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddManufacturer.FlatAppearance.BorderSize = 0;
            this.btnAddManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddManufacturer.Image = ( (System.Drawing.Image)( resources.GetObject("btnAddManufacturer.Image") ) );
            this.btnAddManufacturer.Location = new System.Drawing.Point(662, 6);
            this.btnAddManufacturer.Name = "btnAddManufacturer";
            this.btnAddManufacturer.Size = new System.Drawing.Size(19, 17);
            this.btnAddManufacturer.TabIndex = 16;
            this.btnAddManufacturer.UseVisualStyleBackColor = true;
            // 
            // tabExtensions
            // 
            this.tabExtensions.Controls.Add(this.lvExtensions);
            this.tabExtensions.Controls.Add(this.btnDeleteExtension);
            this.tabExtensions.Controls.Add(this.btnEditExtension);
            this.tabExtensions.Controls.Add(this.btnAddExtension);
            this.tabExtensions.Location = new System.Drawing.Point(4, 22);
            this.tabExtensions.Name = "tabExtensions";
            this.tabExtensions.Size = new System.Drawing.Size(726, 239);
            this.tabExtensions.TabIndex = 2;
            this.tabExtensions.Text = "Extensions";
            this.tabExtensions.UseVisualStyleBackColor = true;
            // 
            // lvExtensions
            // 
            this.lvExtensions.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                        | System.Windows.Forms.AnchorStyles.Left )
                        | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.lvExtensions.Location = new System.Drawing.Point(4, 28);
            this.lvExtensions.Name = "lvExtensions";
            this.lvExtensions.Size = new System.Drawing.Size(716, 204);
            this.lvExtensions.TabIndex = 23;
            this.lvExtensions.UseCompatibleStateImageBehavior = false;
            this.lvExtensions.View = System.Windows.Forms.View.Details;
            // 
            // btnDeleteExtension
            // 
            this.btnDeleteExtension.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnDeleteExtension.FlatAppearance.BorderSize = 0;
            this.btnDeleteExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteExtension.Image = ( (System.Drawing.Image)( resources.GetObject("btnDeleteExtension.Image") ) );
            this.btnDeleteExtension.Location = new System.Drawing.Point(701, 6);
            this.btnDeleteExtension.Name = "btnDeleteExtension";
            this.btnDeleteExtension.Size = new System.Drawing.Size(19, 17);
            this.btnDeleteExtension.TabIndex = 22;
            this.btnDeleteExtension.UseVisualStyleBackColor = true;
            // 
            // btnEditExtension
            // 
            this.btnEditExtension.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnEditExtension.FlatAppearance.BorderSize = 0;
            this.btnEditExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditExtension.Image = ( (System.Drawing.Image)( resources.GetObject("btnEditExtension.Image") ) );
            this.btnEditExtension.Location = new System.Drawing.Point(682, 6);
            this.btnEditExtension.Name = "btnEditExtension";
            this.btnEditExtension.Size = new System.Drawing.Size(19, 17);
            this.btnEditExtension.TabIndex = 21;
            this.btnEditExtension.UseVisualStyleBackColor = true;
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
            this.btnAddExtension.FlatAppearance.BorderSize = 0;
            this.btnAddExtension.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddExtension.Image = ( (System.Drawing.Image)( resources.GetObject("btnAddExtension.Image") ) );
            this.btnAddExtension.Location = new System.Drawing.Point(662, 6);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(19, 17);
            this.btnAddExtension.TabIndex = 20;
            this.btnAddExtension.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Model Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(299, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Version";
            // 
            // edtVersion
            // 
            this.edtVersion.Location = new System.Drawing.Point(91, 23);
            this.edtVersion.Name = "edtVersion";
            this.edtVersion.Size = new System.Drawing.Size(100, 20);
            this.edtVersion.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(621, 390);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(702, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabDesignator
            // 
            this.tabDesignator.Controls.Add(this.edtDesignator);
            this.tabDesignator.Location = new System.Drawing.Point(4, 22);
            this.tabDesignator.Name = "tabDesignator";
            this.tabDesignator.Size = new System.Drawing.Size(726, 239);
            this.tabDesignator.TabIndex = 3;
            this.tabDesignator.Text = "Designator";
            this.tabDesignator.UseVisualStyleBackColor = true;
            // 
            // edtDesignator
            // 
            this.edtDesignator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtDesignator.Location = new System.Drawing.Point(0, 0);
            this.edtDesignator.Multiline = true;
            this.edtDesignator.Name = "edtDesignator";
            this.edtDesignator.Size = new System.Drawing.Size(726, 239);
            this.edtDesignator.TabIndex = 0;
            // 
            // IdentificationForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(785, 420);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panel1);
            this.Name = "IdentificationForm";
            this.Text = "Identification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabIdentificationNumbers.ResumeLayout(false);
            this.tabManufacturers.ResumeLayout(false);
            this.tabExtensions.ResumeLayout(false);
            this.tabDesignator.ResumeLayout(false);
            this.tabDesignator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabIdentificationNumbers;
        private System.Windows.Forms.TabPage tabManufacturers;
        private System.Windows.Forms.TabPage tabExtensions;
        private System.Windows.Forms.Label label2;
        private ATMLCommonLibrary.controls.awb.AWBTextBox textBox1;
        private System.Windows.Forms.Label label1;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtVersion;
        private System.Windows.Forms.Button btnDeleteIdentification;
        private System.Windows.Forms.Button btnEditIdentification;
        private System.Windows.Forms.Button btnAddIdentification;
        private System.Windows.Forms.ListView lvIdentifications;
        private System.Windows.Forms.ColumnHeader colNumber;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ColumnHeader colQualifier;
        private System.Windows.Forms.ColumnHeader colManufacturerName;
        private System.Windows.Forms.ListView lvManufacturers;
        private System.Windows.Forms.Button btnDeleteManufacturer;
        private System.Windows.Forms.Button btnEditManufacturer;
        private System.Windows.Forms.Button btnAddManufacturer;
        private System.Windows.Forms.ListView lvExtensions;
        private System.Windows.Forms.Button btnDeleteExtension;
        private System.Windows.Forms.Button btnEditExtension;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader colManufacturer;
        private System.Windows.Forms.ColumnHeader colCageCode;
        private System.Windows.Forms.TabPage tabDesignator;
        private ATMLCommonLibrary.controls.awb.AWBTextBox edtDesignator;
    }
}