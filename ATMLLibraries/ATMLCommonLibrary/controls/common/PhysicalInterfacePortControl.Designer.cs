/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using ATMLCommonLibrary.controls.connector;

namespace ATMLCommonLibrary.controls.common
{
    partial class PhysicalInterfacePortControl
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
            this.connectorLocationPinListControl = new ConnectorLocationPinListControl();
            this.connectorPinListView1 = new ConnectorPinListView();
            this.helpLabel = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.portControl = new ATMLCommonLibrary.controls.common.PortControl();
            this.SuspendLayout();
            // 
            // connectorLocationPinListControl
            // 
            this.connectorLocationPinListControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectorLocationPinListControl.Connectors = null;
            this.connectorLocationPinListControl.ListName = null;
            this.connectorLocationPinListControl.Location = new System.Drawing.Point(13, 133);
            this.connectorLocationPinListControl.Margin = new System.Windows.Forms.Padding(0);
            this.connectorLocationPinListControl.Name = "connectorLocationPinListControl";
            this.connectorLocationPinListControl.SchemaTypeName = null;
            this.connectorLocationPinListControl.Size = new System.Drawing.Size(380, 150);
            this.connectorLocationPinListControl.TabIndex = 4;
            this.connectorLocationPinListControl.TargetNamespace = null;
            // 
            // connectorPinListView1
            // 
            this.connectorPinListView1.Location = new System.Drawing.Point(201, 190);
            this.connectorPinListView1.Name = "connectorPinListView1";
            this.connectorPinListView1.Size = new System.Drawing.Size(8, 8);
            this.connectorPinListView1.TabIndex = 3;
            this.connectorPinListView1.UseCompatibleStateImageBehavior = false;
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.HelpMessageKey = "PhysicalInterfacePort.ConnectorPins";
            this.helpLabel.Location = new System.Drawing.Point(13, 117);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.RequiredField = false;
            this.helpLabel.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel.Size = new System.Drawing.Size(79, 13);
            this.helpLabel.TabIndex = 2;
            this.helpLabel.Text = "Connector Pins";
            // 
            // portControl
            // 
            this.portControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portControl.BackColor = System.Drawing.Color.AliceBlue;
            this.portControl.Location = new System.Drawing.Point(0, 0);
            this.portControl.Name = "portControl";
            this.portControl.SchemaTypeName = null;
            this.portControl.Size = new System.Drawing.Size(405, 111);
            this.portControl.TabIndex = 0;
            this.portControl.TargetNamespace = null;
            // 
            // PhysicalInterfacePortControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.connectorLocationPinListControl);
            this.Controls.Add(this.connectorPinListView1);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.portControl);
            this.Name = "PhysicalInterfacePortControl";
            this.Size = new System.Drawing.Size(408, 295);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PortControl portControl;
        private HelpLabel helpLabel;
        private ConnectorPinListView connectorPinListView1;
        private ConnectorLocationPinListControl connectorLocationPinListControl;
    }
}
