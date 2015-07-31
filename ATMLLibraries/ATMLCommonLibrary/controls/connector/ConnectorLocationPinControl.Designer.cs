/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls
{
    partial class ConnectorLocationPinControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorLocationPinControl));
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.helpLabel2 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtConnectorId = new System.Windows.Forms.TextBox();
            this.edtConnectorPinId = new System.Windows.Forms.TextBox();
            this.btnSelectConnector = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ConnectorLocationPin.ConnectorId";
            this.helpLabel1.Location = new System.Drawing.Point(4, 15);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(68, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Connector Id";
            // 
            // helpLabel2
            // 
            this.helpLabel2.AutoSize = true;
            this.helpLabel2.HelpMessageKey = "ConnectorLocationPin.PinId";
            this.helpLabel2.Location = new System.Drawing.Point(38, 41);
            this.helpLabel2.Name = "helpLabel2";
            this.helpLabel2.RequiredField = false;
            this.helpLabel2.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel2.Size = new System.Drawing.Size(34, 13);
            this.helpLabel2.TabIndex = 1;
            this.helpLabel2.Text = "Pin Id";
            // 
            // edtConnectorId
            // 
            this.edtConnectorId.Location = new System.Drawing.Point(81, 12);
            this.edtConnectorId.Name = "edtConnectorId";
            this.edtConnectorId.Size = new System.Drawing.Size(100, 20);
            this.edtConnectorId.TabIndex = 2;
            // 
            // edtConnectorPinId
            // 
            this.edtConnectorPinId.Location = new System.Drawing.Point(81, 39);
            this.edtConnectorPinId.Name = "edtConnectorPinId";
            this.edtConnectorPinId.Size = new System.Drawing.Size(100, 20);
            this.edtConnectorPinId.TabIndex = 3;
            // 
            // btnSelectConnector
            // 
            this.btnSelectConnector.FlatAppearance.BorderSize = 0;
            this.btnSelectConnector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectConnector.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectConnector.Image")));
            this.btnSelectConnector.Location = new System.Drawing.Point(199, 3);
            this.btnSelectConnector.Name = "btnSelectConnector";
            this.btnSelectConnector.Size = new System.Drawing.Size(24, 23);
            this.btnSelectConnector.TabIndex = 4;
            this.btnSelectConnector.UseVisualStyleBackColor = true;
            this.btnSelectConnector.Click += new System.EventHandler(this.btnSelectConnector_Click);
            // 
            // ConnectorLocationPinControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSelectConnector);
            this.Controls.Add(this.edtConnectorPinId);
            this.Controls.Add(this.edtConnectorId);
            this.Controls.Add(this.helpLabel2);
            this.Controls.Add(this.helpLabel1);
            this.Name = "ConnectorLocationPinControl";
            this.Size = new System.Drawing.Size(226, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HelpLabel helpLabel1;
        private HelpLabel helpLabel2;
        private System.Windows.Forms.TextBox edtConnectorId;
        private System.Windows.Forms.TextBox edtConnectorPinId;
        private System.Windows.Forms.Button btnSelectConnector;

    }
}
