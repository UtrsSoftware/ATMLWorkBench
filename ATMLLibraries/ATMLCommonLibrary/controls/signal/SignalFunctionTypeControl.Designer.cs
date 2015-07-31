/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.signal
{
    partial class SignalFunctionTypeControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalFunctionTypeControl));
            this.signalAttributes = new System.Windows.Forms.DataGridView();
            this.colPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropertyType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectIns = new System.Windows.Forms.Button();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIn = new System.Windows.Forms.TextBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new System.Windows.Forms.TextBox();
            this.requiredNameFieldValidator = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.awbDropListTree = new ATMLCommonLibrary.controls.awb.AWBDropListView();
            ((System.ComponentModel.ISupportInitialize)(this.signalAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // signalAttributes
            // 
            this.signalAttributes.AllowUserToOrderColumns = true;
            this.signalAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signalAttributes.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.signalAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.signalAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.signalAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPropertyName,
            this.colPropertyType,
            this.colPropertyValue});
            this.signalAttributes.Location = new System.Drawing.Point(12, 117);
            this.signalAttributes.Name = "signalAttributes";
            this.signalAttributes.RowHeadersVisible = false;
            this.signalAttributes.Size = new System.Drawing.Size(505, 385);
            this.signalAttributes.TabIndex = 7;
            this.signalAttributes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.otherAttributes_CellContentClick);
            this.signalAttributes.Resize += new System.EventHandler(this.otherAttributes_Resize);
            // 
            // colPropertyName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.colPropertyName.DefaultCellStyle = dataGridViewCellStyle1;
            this.colPropertyName.Frozen = true;
            this.colPropertyName.HeaderText = "Property";
            this.colPropertyName.Name = "colPropertyName";
            // 
            // colPropertyType
            // 
            this.colPropertyType.Frozen = true;
            this.colPropertyType.HeaderText = "Type";
            this.colPropertyType.Name = "colPropertyType";
            // 
            // colPropertyValue
            // 
            this.colPropertyValue.HeaderText = "Value";
            this.colPropertyValue.Name = "colPropertyValue";
            this.colPropertyValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPropertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPropertyValue.Width = 24;
            // 
            // btnSelectIns
            // 
            this.btnSelectIns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectIns.FlatAppearance.BorderSize = 0;
            this.btnSelectIns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectIns.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectIns.Image")));
            this.btnSelectIns.Location = new System.Drawing.Point(495, 69);
            this.btnSelectIns.Name = "btnSelectIns";
            this.btnSelectIns.Size = new System.Drawing.Size(24, 23);
            this.btnSelectIns.TabIndex = 6;
            this.btnSelectIns.UseVisualStyleBackColor = true;
            this.btnSelectIns.Click += new System.EventHandler(this.btnSelectIns_Click);
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "SignalFunctionType.Inputs";
            this.helpLabel2.Location = new System.Drawing.Point(12, 73);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(36, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "Inputs";
            // 
            // edtIn
            // 
            this.edtIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIn.Location = new System.Drawing.Point(85, 69);
            this.edtIn.Name = "edtIn";
            this.edtIn.Size = new System.Drawing.Size(408, 20);
            this.edtIn.TabIndex = 5;
            this.edtIn.TextChanged += new System.EventHandler(this.edtIn_TextChanged);
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "SignalFunctionType.Name";
            this.helpLabel1.Location = new System.Drawing.Point(12, 45);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(35, 13);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Name";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.Location = new System.Drawing.Point(85, 41);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(408, 20);
            this.edtName.TabIndex = 3;
            this.edtName.TextChanged += new System.EventHandler(this.edtName_TextChanged);
            // 
            // requiredNameFieldValidator
            // 
            this.requiredNameFieldValidator.ControlToValidate = this.edtName;
            this.requiredNameFieldValidator.ErrorMessage = "The Name is required";
            this.requiredNameFieldValidator.ErrorProvider = this.errorProvider;
            this.requiredNameFieldValidator.Icon = null;
            this.requiredNameFieldValidator.InitialValue = null;
            this.requiredNameFieldValidator.IsEnabled = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "SignalFunctionType.Name";
            this.helpLabel3.Location = new System.Drawing.Point(12, 13);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(63, 13);
            this.helpLabel3.TabIndex = 0;
            this.helpLabel3.Text = "Signal Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Attributes";
            // 
            // awbDropListTree
            // 
            this.awbDropListTree.Location = new System.Drawing.Point(85, 13);
            this.awbDropListTree.Margin = new System.Windows.Forms.Padding(0);
            this.awbDropListTree.Name = "awbDropListTree";
            this.awbDropListTree.Size = new System.Drawing.Size(408, 20);
            this.awbDropListTree.TabIndex = 9;
            this.awbDropListTree.TreeModel = null;
            this.awbDropListTree.SignalSelected += new ATMLCommonLibrary.controls.awb.SignalSelectHandler(this.awbDropListTree_SignalSelected);
            // 
            // SignalFunctionTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.awbDropListTree);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.signalAttributes);
            this.Controls.Add(this.btnSelectIns);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtIn);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtName);
            this.Name = "SignalFunctionTypeControl";
            this.Size = new System.Drawing.Size(531, 515);
            ((System.ComponentModel.ISupportInitialize)(this.signalAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView signalAttributes;
        private System.Windows.Forms.Button btnSelectIns;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.TextBox edtIn;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.TextBox edtName;
        private validators.RequiredFieldValidator requiredNameFieldValidator;
        protected System.Windows.Forms.ErrorProvider errorProvider;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyValue;
        private awb.AWBDropListView awbDropListTree;
    }
}
