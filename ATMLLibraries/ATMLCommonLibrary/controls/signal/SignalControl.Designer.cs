/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.signal
{
    partial class SignalControl
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSignalFunctions = new System.Windows.Forms.TabPage();
            this.signalPartsListControl = new ATMLCommonLibrary.controls.signal.SignalPartsListControl();
            this.tabInputs = new System.Windows.Forms.TabPage();
            this.signalInputList = new ATMLCommonLibrary.controls.signal.SignalInputListControl();
            this.tabOtherAttributes = new System.Windows.Forms.TabPage();
            this.otherAttributes = new System.Windows.Forms.DataGridView();
            this.colPropertyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awbDropListTree = new ATMLCommonLibrary.controls.awb.AWBDropListView();
            this.helpLabel8 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.btnSelectOuts = new System.Windows.Forms.Button();
            this.helpLabel6 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtScriptEngine = new System.Windows.Forms.TextBox();
            this.helpLabel5 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtRefType = new System.Windows.Forms.TextBox();
            this.helpLabel4 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtType = new System.Windows.Forms.TextBox();
            this.helpLabel3 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtOut = new System.Windows.Forms.TextBox();
            this.btnSelectIns = new System.Windows.Forms.Button();
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtIn = new System.Windows.Forms.TextBox();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabSignalFunctions.SuspendLayout();
            this.tabInputs.SuspendLayout();
            this.tabOtherAttributes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.otherAttributes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSignalFunctions);
            this.tabControl1.Controls.Add(this.tabInputs);
            this.tabControl1.Controls.Add(this.tabOtherAttributes);
            this.tabControl1.Location = new System.Drawing.Point(11, 180);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 221);
            this.tabControl1.TabIndex = 21;
            // 
            // tabSignalFunctions
            // 
            this.tabSignalFunctions.Controls.Add(this.signalPartsListControl);
            this.tabSignalFunctions.Location = new System.Drawing.Point(4, 22);
            this.tabSignalFunctions.Name = "tabSignalFunctions";
            this.tabSignalFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignalFunctions.Size = new System.Drawing.Size(488, 195);
            this.tabSignalFunctions.TabIndex = 1;
            this.tabSignalFunctions.Text = "Signal Model";
            this.tabSignalFunctions.UseVisualStyleBackColor = true;
            // 
            // signalPartsListControl
            // 
            this.signalPartsListControl.AllowRowResequencing = true;
            this.signalPartsListControl.BackColor = System.Drawing.Color.AliceBlue;
            this.signalPartsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalPartsListControl.FormTitle = null;
            this.signalPartsListControl.HasErrors = false;
            this.signalPartsListControl.HelpKeyWord = null;
            this.signalPartsListControl.LastError = null;
            this.signalPartsListControl.ListName = null;
            this.signalPartsListControl.Location = new System.Drawing.Point(3, 3);
            this.signalPartsListControl.Margin = new System.Windows.Forms.Padding(0);
            this.signalPartsListControl.Name = "signalPartsListControl";
            this.signalPartsListControl.SchemaTypeName = null;
            this.signalPartsListControl.ShowFind = false;
            this.signalPartsListControl.Size = new System.Drawing.Size(482, 189);
            this.signalPartsListControl.TabIndex = 0;
            this.signalPartsListControl.TargetNamespace = null;
            this.signalPartsListControl.TooltipTextAddButton = "Press to add a new ";
            this.signalPartsListControl.TooltipTextDeleteButton = "Press to delete the selected ";
            this.signalPartsListControl.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabInputs
            // 
            this.tabInputs.Controls.Add(this.signalInputList);
            this.tabInputs.Location = new System.Drawing.Point(4, 22);
            this.tabInputs.Name = "tabInputs";
            this.tabInputs.Padding = new System.Windows.Forms.Padding(3);
            this.tabInputs.Size = new System.Drawing.Size(488, 195);
            this.tabInputs.TabIndex = 0;
            this.tabInputs.Text = "Inputs";
            this.tabInputs.UseVisualStyleBackColor = true;
            // 
            // signalInputList
            // 
            this.signalInputList.AllowRowResequencing = false;
            this.signalInputList.BackColor = System.Drawing.Color.AliceBlue;
            this.signalInputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalInputList.FormTitle = null;
            this.signalInputList.HasErrors = false;
            this.signalInputList.HelpKeyWord = null;
            this.signalInputList.LastError = null;
            this.signalInputList.ListName = null;
            this.signalInputList.Location = new System.Drawing.Point(3, 3);
            this.signalInputList.Margin = new System.Windows.Forms.Padding(0);
            this.signalInputList.Name = "signalInputList";
            this.signalInputList.SchemaTypeName = null;
            this.signalInputList.ShowFind = false;
            this.signalInputList.Size = new System.Drawing.Size(482, 189);
            this.signalInputList.TabIndex = 0;
            this.signalInputList.TargetNamespace = null;
            this.signalInputList.TooltipTextAddButton = "Click to add a new SignalIN";
            this.signalInputList.TooltipTextDeleteButton = "Click to delete the selected SignalIN";
            this.signalInputList.TooltipTextEditButton = "Click to edit the selected SignalIN";
            // 
            // tabOtherAttributes
            // 
            this.tabOtherAttributes.Controls.Add(this.otherAttributes);
            this.tabOtherAttributes.Location = new System.Drawing.Point(4, 22);
            this.tabOtherAttributes.Name = "tabOtherAttributes";
            this.tabOtherAttributes.Size = new System.Drawing.Size(488, 195);
            this.tabOtherAttributes.TabIndex = 3;
            this.tabOtherAttributes.Text = "Other Attributes";
            this.tabOtherAttributes.UseVisualStyleBackColor = true;
            // 
            // otherAttributes
            // 
            this.otherAttributes.AllowUserToOrderColumns = true;
            this.otherAttributes.BackgroundColor = System.Drawing.SystemColors.InactiveCaption;
            this.otherAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.otherAttributes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.otherAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.otherAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPropertyName,
            this.colPropertyValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.otherAttributes.DefaultCellStyle = dataGridViewCellStyle3;
            this.otherAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.otherAttributes.Location = new System.Drawing.Point(0, 0);
            this.otherAttributes.Name = "otherAttributes";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.otherAttributes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.otherAttributes.Size = new System.Drawing.Size(488, 195);
            this.otherAttributes.TabIndex = 4;
            // 
            // colPropertyName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(228)))), ((int)(((byte)(242)))));
            this.colPropertyName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPropertyName.Frozen = true;
            this.colPropertyName.HeaderText = "Property";
            this.colPropertyName.Name = "colPropertyName";
            // 
            // colPropertyValue
            // 
            this.colPropertyValue.Frozen = true;
            this.colPropertyValue.HeaderText = "Value";
            this.colPropertyValue.Name = "colPropertyValue";
            // 
            // awbDropListTree
            // 
            this.awbDropListTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.awbDropListTree.Location = new System.Drawing.Point(82, 8);
            this.awbDropListTree.Margin = new System.Windows.Forms.Padding(0);
            this.awbDropListTree.Name = "awbDropListTree";
            this.awbDropListTree.Size = new System.Drawing.Size(400, 20);
            this.awbDropListTree.TabIndex = 20;
            this.awbDropListTree.TreeModel = null;
            this.awbDropListTree.SignalSelected += new ATMLCommonLibrary.controls.awb.SignalSelectHandler(this.awbDropListTree_SignalSelected);
            this.awbDropListTree.Load += new System.EventHandler(this.awbDropListTree_Load);
            // 
            // helpLabel8
            // 
            this.helpLabel8.AutoSize = true;
            this.helpLabel8.HelpMessageKey = "SignalFunctionType.Name";
            this.helpLabel8.Location = new System.Drawing.Point(9, 11);
            this.helpLabel8.Name = "helpLabel8";
            this.helpLabel8.RequiredField = false;
            this.helpLabel8.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel8.Size = new System.Drawing.Size(63, 13);
            this.helpLabel8.TabIndex = 0;
            this.helpLabel8.Text = "Signal Type";
            // 
            // btnSelectOuts
            // 
            this.btnSelectOuts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectOuts.FlatAppearance.BorderSize = 0;
            this.btnSelectOuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectOuts.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectOuts.Image")));
            this.btnSelectOuts.Location = new System.Drawing.Point(482, 90);
            this.btnSelectOuts.Name = "btnSelectOuts";
            this.btnSelectOuts.Size = new System.Drawing.Size(26, 23);
            this.btnSelectOuts.TabIndex = 9;
            this.btnSelectOuts.UseVisualStyleBackColor = true;
            this.btnSelectOuts.Click += new System.EventHandler(this.btnSelectOuts_Click);
            // 
            // helpLabel6
            // 
            this.helpLabel6.AutoSize = true;
            this.helpLabel6.HelpMessageKey = "SignalControl.ScriptEngine";
            this.helpLabel6.Location = new System.Drawing.Point(8, 148);
            this.helpLabel6.Name = "helpLabel6";
            this.helpLabel6.RequiredField = false;
            this.helpLabel6.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel6.Size = new System.Drawing.Size(70, 13);
            this.helpLabel6.TabIndex = 14;
            this.helpLabel6.Text = "Script Engine";
            // 
            // edtScriptEngine
            // 
            this.edtScriptEngine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtScriptEngine.Location = new System.Drawing.Point(82, 145);
            this.edtScriptEngine.Name = "edtScriptEngine";
            this.edtScriptEngine.Size = new System.Drawing.Size(400, 20);
            this.edtScriptEngine.TabIndex = 15;
            // 
            // helpLabel5
            // 
            this.helpLabel5.AutoSize = true;
            this.helpLabel5.HelpMessageKey = "SignalControl.RefType";
            this.helpLabel5.Location = new System.Drawing.Point(267, 122);
            this.helpLabel5.Name = "helpLabel5";
            this.helpLabel5.RequiredField = false;
            this.helpLabel5.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel5.Size = new System.Drawing.Size(51, 13);
            this.helpLabel5.TabIndex = 12;
            this.helpLabel5.Text = "Ref Type";
            // 
            // edtRefType
            // 
            this.edtRefType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtRefType.Location = new System.Drawing.Point(322, 119);
            this.edtRefType.Name = "edtRefType";
            this.edtRefType.Size = new System.Drawing.Size(160, 20);
            this.edtRefType.TabIndex = 13;
            // 
            // helpLabel4
            // 
            this.helpLabel4.AutoSize = true;
            this.helpLabel4.HelpMessageKey = "SignalControl.Type";
            this.helpLabel4.Location = new System.Drawing.Point(8, 119);
            this.helpLabel4.Name = "helpLabel4";
            this.helpLabel4.RequiredField = false;
            this.helpLabel4.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel4.Size = new System.Drawing.Size(31, 13);
            this.helpLabel4.TabIndex = 10;
            this.helpLabel4.Text = "Type";
            // 
            // edtType
            // 
            this.edtType.Location = new System.Drawing.Point(82, 118);
            this.edtType.Name = "edtType";
            this.edtType.Size = new System.Drawing.Size(170, 20);
            this.edtType.TabIndex = 11;
            // 
            // helpLabel3
            // 
            this.helpLabel3.AutoSize = true;
            this.helpLabel3.HelpMessageKey = "SignalControl.Out";
            this.helpLabel3.Location = new System.Drawing.Point(9, 93);
            this.helpLabel3.Name = "helpLabel3";
            this.helpLabel3.RequiredField = false;
            this.helpLabel3.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel3.Size = new System.Drawing.Size(24, 13);
            this.helpLabel3.TabIndex = 7;
            this.helpLabel3.Text = "Out";
            // 
            // edtOut
            // 
            this.edtOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtOut.Location = new System.Drawing.Point(82, 91);
            this.edtOut.Name = "edtOut";
            this.edtOut.Size = new System.Drawing.Size(400, 20);
            this.edtOut.TabIndex = 8;
            // 
            // btnSelectIns
            // 
            this.btnSelectIns.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectIns.FlatAppearance.BorderSize = 0;
            this.btnSelectIns.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectIns.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectIns.Image")));
            this.btnSelectIns.Location = new System.Drawing.Point(482, 63);
            this.btnSelectIns.Name = "btnSelectIns";
            this.btnSelectIns.Size = new System.Drawing.Size(26, 23);
            this.btnSelectIns.TabIndex = 6;
            this.btnSelectIns.UseVisualStyleBackColor = true;
            this.btnSelectIns.Click += new System.EventHandler(this.btnSelectIns_Click);
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "SignalControl.In";
            this.helpLabel2.Location = new System.Drawing.Point(8, 66);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(16, 13);
            this.helpLabel2.TabIndex = 4;
            this.helpLabel2.Text = "In";
            // 
            // edtIn
            // 
            this.edtIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtIn.Location = new System.Drawing.Point(82, 64);
            this.edtIn.Name = "edtIn";
            this.edtIn.Size = new System.Drawing.Size(400, 20);
            this.edtIn.TabIndex = 5;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "SignalControl.Name";
            this.helpLabel1.Location = new System.Drawing.Point(8, 40);
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
            this.edtName.Location = new System.Drawing.Point(82, 37);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(400, 20);
            this.edtName.TabIndex = 3;
            // 
            // SignalControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.awbDropListTree);
            this.Controls.Add(this.helpLabel8);
            this.Controls.Add(this.btnSelectOuts);
            this.Controls.Add(this.helpLabel6);
            this.Controls.Add(this.edtScriptEngine);
            this.Controls.Add(this.helpLabel5);
            this.Controls.Add(this.edtRefType);
            this.Controls.Add(this.helpLabel4);
            this.Controls.Add(this.edtType);
            this.Controls.Add(this.helpLabel3);
            this.Controls.Add(this.edtOut);
            this.Controls.Add(this.btnSelectIns);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.edtIn);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.edtName);
            this.Name = "SignalControl";
            this.Size = new System.Drawing.Size(518, 417);
            this.Load += new System.EventHandler(this.SignalControl_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSignalFunctions.ResumeLayout(false);
            this.tabInputs.ResumeLayout(false);
            this.tabOtherAttributes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.otherAttributes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private System.Windows.Forms.TextBox edtName;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.TextBox edtIn;
        private System.Windows.Forms.Button btnSelectIns;
        private HelpLabel helpLabel3;
        private System.Windows.Forms.TextBox edtOut;
        private HelpLabel helpLabel4;
        private System.Windows.Forms.TextBox edtType;
        private HelpLabel helpLabel5;
        private System.Windows.Forms.TextBox edtRefType;
        private HelpLabel helpLabel6;
        private System.Windows.Forms.TextBox edtScriptEngine;
        private System.Windows.Forms.Button btnSelectOuts;
        private HelpLabel helpLabel8;
        private awb.AWBDropListView awbDropListTree;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSignalFunctions;
        private SignalPartsListControl signalPartsListControl;
        private System.Windows.Forms.TabPage tabInputs;
        private SignalInputListControl signalInputList;
        //private SignalInputListView signalInputListView;
        //private SignalInputListView signalInputListView1;
        private System.Windows.Forms.TabPage tabOtherAttributes;
        private System.Windows.Forms.DataGridView otherAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPropertyValue;

    }
}
