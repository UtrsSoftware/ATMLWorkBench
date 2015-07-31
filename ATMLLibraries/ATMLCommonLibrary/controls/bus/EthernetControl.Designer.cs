/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class EthernetControl
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
            this.chkSupportsDHCP = new System.Windows.Forms.CheckBox();
            this.lblSupportsDHCP = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.SuspendLayout();
            // 
            // edtDefaultAddress
            // 
            this.edtDefaultAddress.Location = new System.Drawing.Point(97, 10);
            this.edtDefaultAddress.Size = new System.Drawing.Size(166, 20);
            // 
            // chkSupportsDHCP
            // 
            this.chkSupportsDHCP.AutoSize = true;
            this.chkSupportsDHCP.Location = new System.Drawing.Point(97, 36);
            this.chkSupportsDHCP.Name = "chkSupportsDHCP";
            this.chkSupportsDHCP.Size = new System.Drawing.Size(15, 14);
            this.chkSupportsDHCP.TabIndex = 8;
            this.chkSupportsDHCP.UseVisualStyleBackColor = true;
            // 
            // lblSupportsDHCP
            // 
            this.lblSupportsDHCP.AutoSize = true;
            this.lblSupportsDHCP.HelpMessageKey = "Ethernet.SupportsDHCP";
            this.lblSupportsDHCP.Location = new System.Drawing.Point(10, 36);
            this.lblSupportsDHCP.Name = "lblSupportsDHCP";
            this.lblSupportsDHCP.RequiredField = false;
            this.lblSupportsDHCP.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupportsDHCP.Size = new System.Drawing.Size(82, 13);
            this.lblSupportsDHCP.TabIndex = 10;
            this.lblSupportsDHCP.Text = "Supports DHCP";
            // 
            // EthernetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSupportsDHCP);
            this.Controls.Add(this.chkSupportsDHCP);
            this.Name = "EthernetControl";
            this.Size = new System.Drawing.Size(289, 61);
            this.Controls.SetChildIndex(this.edtDefaultAddress, 0);
            this.Controls.SetChildIndex(this.lblDefaultAddress, 0);
            this.Controls.SetChildIndex(this.chkSupportsDHCP, 0);
            this.Controls.SetChildIndex(this.lblSupportsDHCP, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSupportsDHCP;
        private HelpLabel lblSupportsDHCP;
    }
}
