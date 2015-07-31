/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.path
{
    partial class PathControl
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
            this.datumResistance = new ATMLCommonLibrary.controls.datum.DatumTypeDoubleControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtName = new ATMLCommonLibrary.controls.awb.AWBTextBox(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPathNodes = new System.Windows.Forms.TabPage();
            this.NodeListControl1 = new ATMLCommonLibrary.controls.path.PathNodeListControl();
            this.tabSignalDelays = new System.Windows.Forms.TabPage();
            this.SignalDelayListControl1 = new ATMLCommonLibrary.controls.path.PathSignalDelayListControl();
            this.tabVSWRValues = new System.Windows.Forms.TabPage();
            this.VSWRValueListControl1 = new ATMLCommonLibrary.controls.path.PathVSWRValueListControl();
            this.tabSParameters = new System.Windows.Forms.TabPage();
            this.SParameterList = new ATMLCommonLibrary.controls.path.PathSParameterListCntrlListCntrl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblError = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPathNodes.SuspendLayout();
            this.tabSignalDelays.SuspendLayout();
            this.tabVSWRValues.SuspendLayout();
            this.tabSParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // datumResistance
            // 
            this.datumResistance.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datumResistance.BackColor = System.Drawing.Color.White;
            this.datumResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.datumResistance.HelpKeyWord = null;
            this.datumResistance.Location = new System.Drawing.Point(80, 39);
            this.datumResistance.Name = "datumResistance";
            this.datumResistance.SchemaTypeName = null;
            this.datumResistance.Size = new System.Drawing.Size(287, 44);
            this.datumResistance.TabIndex = 3;
            this.datumResistance.TargetNamespace = null;
            this.datumResistance.UseFlowControl = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = null;
            this.helpLabel1.Location = new System.Drawing.Point(11, 39);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(63, 13);
            this.helpLabel1.TabIndex = 2;
            this.helpLabel1.Text = "Resistance:";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = null;
            this.helpLabel2.Location = new System.Drawing.Point(36, 9);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(38, 13);
            this.helpLabel2.TabIndex = 0;
            this.helpLabel2.Text = "Name:";
            // 
            // edtName
            // 
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtName.AttributeName = null;
            this.edtName.Location = new System.Drawing.Point(80, 9);
            this.edtName.Name = "edtName";
            this.edtName.Size = new System.Drawing.Size(287, 20);
            this.edtName.TabIndex = 1;
            this.edtName.Value = null;
            this.edtName.ValueType = ATMLCommonLibrary.controls.awb.AWBTextBox.eValueType.xsString;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPathNodes);
            this.tabControl1.Controls.Add(this.tabSignalDelays);
            this.tabControl1.Controls.Add(this.tabVSWRValues);
            this.tabControl1.Controls.Add(this.tabSParameters);
            this.tabControl1.Location = new System.Drawing.Point(12, 102);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 197);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPathNodes
            // 
            this.tabPathNodes.Controls.Add(this.NodeListControl1);
            this.tabPathNodes.Location = new System.Drawing.Point(4, 22);
            this.tabPathNodes.Name = "tabPathNodes";
            this.tabPathNodes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPathNodes.Size = new System.Drawing.Size(365, 171);
            this.tabPathNodes.TabIndex = 0;
            this.tabPathNodes.Text = "Path Nodes";
            this.tabPathNodes.UseVisualStyleBackColor = true;
            // 
            // NodeListControl1
            // 
            this.NodeListControl1.AllowRowResequencing = false;
            this.NodeListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.NodeListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeListControl1.FormTitle = null;
            this.NodeListControl1.HardwareItemDescription = null;
            this.NodeListControl1.HelpKeyWord = null;
            this.NodeListControl1.ListName = null;
            this.NodeListControl1.Location = new System.Drawing.Point(3, 3);
            this.NodeListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.NodeListControl1.Name = "NodeListControl1";
            this.NodeListControl1.SchemaTypeName = null;
            this.NodeListControl1.ShowFind = false;
            this.NodeListControl1.Size = new System.Drawing.Size(359, 165);
            this.NodeListControl1.TabIndex = 0;
            this.NodeListControl1.TargetNamespace = null;
            this.NodeListControl1.TooltipTextAddButton = "Press to add a new ";
            this.NodeListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.NodeListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabSignalDelays
            // 
            this.tabSignalDelays.Controls.Add(this.SignalDelayListControl1);
            this.tabSignalDelays.Location = new System.Drawing.Point(4, 22);
            this.tabSignalDelays.Name = "tabSignalDelays";
            this.tabSignalDelays.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignalDelays.Size = new System.Drawing.Size(365, 171);
            this.tabSignalDelays.TabIndex = 1;
            this.tabSignalDelays.Text = "Signal Delays";
            this.tabSignalDelays.UseVisualStyleBackColor = true;
            // 
            // SignalDelayListControl1
            // 
            this.SignalDelayListControl1.AllowRowResequencing = false;
            this.SignalDelayListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.SignalDelayListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SignalDelayListControl1.FormTitle = null;
            this.SignalDelayListControl1.HelpKeyWord = null;
            this.SignalDelayListControl1.ListName = null;
            this.SignalDelayListControl1.Location = new System.Drawing.Point(3, 3);
            this.SignalDelayListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.SignalDelayListControl1.Name = "SignalDelayListControl1";
            this.SignalDelayListControl1.SchemaTypeName = null;
            this.SignalDelayListControl1.ShowFind = false;
            this.SignalDelayListControl1.Size = new System.Drawing.Size(359, 165);
            this.SignalDelayListControl1.TabIndex = 0;
            this.SignalDelayListControl1.TargetNamespace = null;
            this.SignalDelayListControl1.TooltipTextAddButton = "Press to add a new ";
            this.SignalDelayListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.SignalDelayListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabVSWRValues
            // 
            this.tabVSWRValues.Controls.Add(this.VSWRValueListControl1);
            this.tabVSWRValues.Location = new System.Drawing.Point(4, 22);
            this.tabVSWRValues.Name = "tabVSWRValues";
            this.tabVSWRValues.Padding = new System.Windows.Forms.Padding(3);
            this.tabVSWRValues.Size = new System.Drawing.Size(365, 171);
            this.tabVSWRValues.TabIndex = 2;
            this.tabVSWRValues.Text = "VSWR Values";
            this.tabVSWRValues.UseVisualStyleBackColor = true;
            // 
            // VSWRValueListControl1
            // 
            this.VSWRValueListControl1.AllowRowResequencing = false;
            this.VSWRValueListControl1.BackColor = System.Drawing.Color.AliceBlue;
            this.VSWRValueListControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VSWRValueListControl1.FormTitle = null;
            this.VSWRValueListControl1.HelpKeyWord = null;
            this.VSWRValueListControl1.ListName = null;
            this.VSWRValueListControl1.Location = new System.Drawing.Point(3, 3);
            this.VSWRValueListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.VSWRValueListControl1.Name = "VSWRValueListControl1";
            this.VSWRValueListControl1.SchemaTypeName = null;
            this.VSWRValueListControl1.ShowFind = false;
            this.VSWRValueListControl1.Size = new System.Drawing.Size(359, 165);
            this.VSWRValueListControl1.TabIndex = 0;
            this.VSWRValueListControl1.TargetNamespace = null;
            this.VSWRValueListControl1.TooltipTextAddButton = "Press to add a new ";
            this.VSWRValueListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.VSWRValueListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // tabSParameters
            // 
            this.tabSParameters.Controls.Add(this.SParameterList);
            this.tabSParameters.Location = new System.Drawing.Point(4, 22);
            this.tabSParameters.Name = "tabSParameters";
            this.tabSParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabSParameters.Size = new System.Drawing.Size(365, 171);
            this.tabSParameters.TabIndex = 3;
            this.tabSParameters.Text = "S Parameters";
            this.tabSParameters.UseVisualStyleBackColor = true;
            // 
            // SParameterList
            // 
            this.SParameterList.AllowRowResequencing = false;
            this.SParameterList.BackColor = System.Drawing.Color.AliceBlue;
            this.SParameterList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SParameterList.FormTitle = null;
            this.SParameterList.HelpKeyWord = null;
            this.SParameterList.ListName = null;
            this.SParameterList.Location = new System.Drawing.Point(3, 3);
            this.SParameterList.Margin = new System.Windows.Forms.Padding(0);
            this.SParameterList.Name = "SParameterList";
            this.SParameterList.SchemaTypeName = null;
            this.SParameterList.ShowFind = false;
            this.SParameterList.Size = new System.Drawing.Size(359, 165);
            this.SParameterList.TabIndex = 0;
            this.SParameterList.TargetNamespace = null;
            this.SParameterList.TooltipTextAddButton = "Press to add a new ";
            this.SParameterList.TooltipTextDeleteButton = "Press to delete the selected ";
            this.SParameterList.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // lblError
            // 
            this.lblError.Location = new System.Drawing.Point(25, 87);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(10, 12);
            this.lblError.TabIndex = 5;
            // 
            // PathControl
            // 
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.datumResistance);
            this.Name = "PathControl";
            this.Size = new System.Drawing.Size(396, 309);
            this.tabControl1.ResumeLayout(false);
            this.tabPathNodes.ResumeLayout(false);
            this.tabSignalDelays.ResumeLayout(false);
            this.tabVSWRValues.ResumeLayout(false);
            this.tabSParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private datum.DatumTypeDoubleControl datumResistance;
        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private awb.AWBTextBox edtName;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPathNodes;
        private System.Windows.Forms.TabPage tabSignalDelays;
        private System.Windows.Forms.TabPage tabVSWRValues;
        private System.Windows.Forms.TabPage tabSParameters;
        private PathNodeListControl NodeListControl1;
        private PathSignalDelayListControl SignalDelayListControl1;
        private PathVSWRValueListControl VSWRValueListControl1;
        private PathSParameterListCntrlListCntrl SParameterList;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lblError;
    }
}
