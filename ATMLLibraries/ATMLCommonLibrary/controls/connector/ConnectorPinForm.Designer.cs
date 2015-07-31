/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.connector
{
    partial class ConnectorPinForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorPinForm));
            this.itemDescriptionControl = new ATMLCommonLibrary.controls.ItemDescriptionControl();
            this.connectorPinControl = new ATMLCommonLibrary.controls.common.ConnectorPinControl();
            this.chkIncludeDefinition = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkIncludeDefinition);
            this.panel1.Controls.Add(this.itemDescriptionControl);
            this.panel1.Controls.Add(this.connectorPinControl);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Size = new System.Drawing.Size(499, 434);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(435, 449);
            this.btnCancel.TabIndex = 2;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(354, 449);
            this.btnOk.TabIndex = 1;
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 460);
            // 
            // itemDescriptionControl
            // 
            this.itemDescriptionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemDescriptionControl.BackColor = System.Drawing.Color.AliceBlue;
            this.itemDescriptionControl.Location = new System.Drawing.Point(11, 120);
            this.itemDescriptionControl.Name = "itemDescriptionControl";
            this.itemDescriptionControl.Size = new System.Drawing.Size(479, 311);
            this.itemDescriptionControl.TabIndex = 2;
            // 
            // connectorPinControl
            // 
            this.connectorPinControl.Location = new System.Drawing.Point(7, 14);
            this.connectorPinControl.Name = "connectorPinControl";
            this.connectorPinControl.Size = new System.Drawing.Size(490, 83);
            this.connectorPinControl.TabIndex = 0;
            // 
            // chkIncludeDefinition
            // 
            this.chkIncludeDefinition.AutoSize = true;
            this.chkIncludeDefinition.Location = new System.Drawing.Point(11, 103);
            this.chkIncludeDefinition.Name = "chkIncludeDefinition";
            this.chkIncludeDefinition.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkIncludeDefinition.Size = new System.Drawing.Size(108, 17);
            this.chkIncludeDefinition.TabIndex = 1;
            this.chkIncludeDefinition.Text = "Include Definition";
            this.chkIncludeDefinition.UseVisualStyleBackColor = true;
            this.chkIncludeDefinition.CheckedChanged += new System.EventHandler(this.chkIncludeDefinition_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ConnectorPinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 477);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectorPinForm";
            this.Text = "Connector Pin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private controls.ItemDescriptionControl itemDescriptionControl;
        private controls.common.ConnectorPinControl connectorPinControl;
        private System.Windows.Forms.CheckBox chkIncludeDefinition;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}