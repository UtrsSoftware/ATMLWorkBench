/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary.controls.controller
{
    partial class ControllerOperatingSystemControl
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
            this.OperatingSystemUpdates = new ATMLCommonLibrary.controls.awb.AWBTextCollectionList();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // identificationControl
            // 
            this.identificationControl.Location = new System.Drawing.Point(3, 258);
            this.identificationControl.Size = new System.Drawing.Size(651, 297);
            // 
            // edtVersion
            // 
            this.edtVersion.Size = new System.Drawing.Size(353, 20);
            // 
            // OperatingSystemUpdates
            // 
            this.OperatingSystemUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperatingSystemUpdates.BackColor = System.Drawing.Color.AliceBlue;
            this.OperatingSystemUpdates.HasErrors = false;
            this.OperatingSystemUpdates.HelpKeyWord = null;
            this.OperatingSystemUpdates.LastError = null;
            this.OperatingSystemUpdates.Location = new System.Drawing.Point(3, 154);
            this.OperatingSystemUpdates.Name = "OperatingSystemUpdates";
            this.OperatingSystemUpdates.SchemaTypeName = null;
            this.OperatingSystemUpdates.Size = new System.Drawing.Size(647, 95);
            this.OperatingSystemUpdates.TabIndex = 8;
            this.OperatingSystemUpdates.TargetNamespace = null;
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "ControllerOperatingSystem.OSUpdates";
            this.helpLabel1.Location = new System.Drawing.Point(5, 137);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(136, 13);
            this.helpLabel1.TabIndex = 9;
            this.helpLabel1.Text = "Operating System Updates:";
            // 
            // ControllerOperatingSystemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.helpLabel1);
            this.Controls.Add(this.OperatingSystemUpdates);
            this.Name = "ControllerOperatingSystemControl";
            this.Size = new System.Drawing.Size(668, 570);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.edtName, 0);
            this.Controls.SetChildIndex(this.identificationControl, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.edtDescription, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.edtVersion, 0);
            this.Controls.SetChildIndex(this.OperatingSystemUpdates, 0);
            this.Controls.SetChildIndex(this.helpLabel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private awb.AWBTextCollectionList OperatingSystemUpdates;
        private HelpLabel helpLabel1;

    }
}
