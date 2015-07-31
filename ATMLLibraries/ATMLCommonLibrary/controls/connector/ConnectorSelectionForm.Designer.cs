/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.connector
{
    partial class ConnectorSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectorSelectionForm));
            this.lvConnectors = new ATMLCommonLibrary.controls.connector.ConnectorListView(this.components);
            this.lvConnectorPins = new ATMLCommonLibrary.controls.connector.ConnectorPinListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvConnectorPins);
            this.panel1.Controls.Add(this.lvConnectors);
            this.panel1.Size = new System.Drawing.Size(423, 336);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 354);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(280, 354);
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 365);
            // 
            // lvConnectors
            // 
            this.lvConnectors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnectors.FullRowSelect = true;
            this.lvConnectors.Location = new System.Drawing.Point(1, 0);
            this.lvConnectors.Name = "lvConnectors";
            this.lvConnectors.Size = new System.Drawing.Size(421, 142);
            this.lvConnectors.TabIndex = 0;
            this.lvConnectors.UseCompatibleStateImageBehavior = false;
            this.lvConnectors.View = System.Windows.Forms.View.Details;
            this.lvConnectors.SelectedIndexChanged += new System.EventHandler(this.lvConnectors_SelectedIndexChanged);
            // 
            // lvConnectorPins
            // 
            this.lvConnectorPins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConnectorPins.FullRowSelect = true;
            this.lvConnectorPins.Location = new System.Drawing.Point(1, 142);
            this.lvConnectorPins.Name = "lvConnectorPins";
            this.lvConnectorPins.Size = new System.Drawing.Size(421, 193);
            this.lvConnectorPins.TabIndex = 1;
            this.lvConnectorPins.UseCompatibleStateImageBehavior = false;
            this.lvConnectorPins.View = System.Windows.Forms.View.Details;
            // 
            // ConnectorSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(448, 381);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConnectorSelectionForm";
            this.Text = "Connector/Pin Selection";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ConnectorListView lvConnectors;
        private ConnectorPinListView lvConnectorPins;
    }
}
